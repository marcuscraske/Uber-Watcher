/*                       ____               ____________
 *                      |    |             |            |
 *                      |    |             |    ________|
 *                      |    |             |   |
 *                      |    |             |   |    
 *                      |    |             |   |    ____
 *                      |    |             |   |   |    |
 *                      |    |_______      |   |___|    |
 *                      |            |  _  |            |
 *                      |____________| |_| |____________|
 *                        
 *      Author(s):      limpygnome (Marcus Craske)              limpygnome@gmail.com
 * 
 *      License:        Creative Commons Attribution-ShareAlike 3.0 Unported
 *                      http://creativecommons.org/licenses/by-sa/3.0/
 * 
 *      Path:           /UberLib.UW/CameraManager.cs
 * 
 *      Change-Log:
 *                      2013-06-26      Created initial class.
 * 
 * *********************************************************************************************************************
 * A model and manager for rendering and managing networked cameras.
 * *********************************************************************************************************************
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Xml;
using Uber_Watcher;
using System.IO;

namespace UberLib.UW
{
    /// <summary>
    /// A model and manager for rendering and managing networked cameras.
    /// </summary>
    public class CameraManager
    {
        // Enums *******************************************************************************************************
        public enum RenderStyle
        {
            SquareNumbers,
            Size,
            Columns
        }
        // Constants ***************************************************************************************************
        /// <summary>
        /// The maximum number of consecutive failures of fetching camera frames before considering a camera dead.
        /// </summary>
        public const int CAMERA_FAILCOUNTER_THRESHOLD = 5;
        // Fields ******************************************************************************************************
        private FormCameraGrid  renderForm;             // The form where the cameras are rendered.
        private List<Camera>    cameras;                // Active cameras.
        private List<Camera>    camerasDead;            // Dead cameras.
        private int[]           squares;                // A cached list of square numbers.
        private int             renderRows,             // The total number of rows to render.
                                renderCols,             // The total number of columns to render.
                                renderWidth,            // The width of a camera.
                                renderHeight,           // The height of a camera.
                                renderCircleWidth,      // The width of a dump-indicator circle.
                                renderCircleHeight;     // The height of a dump-indicator circle.
        private int             cameraSelected;         // Indicates if the current camera is selected.
        private int             renderOffsetY,          // The render offset of y.
                                renderClippingYMin,     // Clipping min and max of rendering cameras.
                                renderClippingYMax;
        private Bitmap          renderBuffer;           // The buffer for all render operations.
        private Graphics        renderBufferGraphics;   // The graphics manipulator object for the buffer.
        // Fields - Grid Style *****************************************************************************************
        private RenderStyle     gridStyle;              // The style of how the grid of camera's are currently being rendered.
        private int             gridSizeWidth,          // The width of a camera for a size render-style.
                                gridSizeHeight,         // The height of a camera for a size render-style.
                                gridColumns;            // The number of columns per a row for a columns render-style.
        // Fields - Debugging ******************************************************************************************
        private long debugTotalBytes;                   // The total number of bytes in bandwidth spent on fetching imagery.
        private long debugTotalImageFrames;             // The total number of successfully parsed frames.
        // Methods - Constructors **************************************************************************************
        public CameraManager(FormCameraGrid renderForm)
        {
            // Grid related
            this.gridStyle = RenderStyle.Size;
            this.gridSizeWidth = 256;
            this.gridSizeHeight = 256;
            this.gridColumns = 50;
            // Load initial field values and hook handlers of render-form
            this.cameraSelected = -1;
            this.renderForm = renderForm;
            this.renderForm.Resize += new EventHandler(renderForm_Resize);
            this.renderForm.Paint += new PaintEventHandler(renderForm_Paint);
            this.renderForm.MouseDown += new MouseEventHandler(renderForm_MouseDown);
            this.renderForm.MouseMove += new MouseEventHandler(renderForm_MouseMove);
            this.renderForm.MouseLeave += new EventHandler(renderForm_MouseLeave);
            this.cameras = new List<Camera>();
            this.camerasDead = new List<Camera>();
            this.debugTotalBytes = this.debugTotalImageFrames = 0;
            // Compile a list of squares for rendering style
            const int squaresMax = 9001; // Also the maximum number of cameras.
            squares = new int[squaresMax];
            for (int i = 1; i < squares.Length; i++)
                squares[i] = i * i;
            resizeRenderBuffer(renderForm.ClientSize.Width, renderForm.ClientSize.Height);
            // Reload settings
            reloadSettings(true);
        }
        // Methods - Render Form ***************************************************************************************
        void resizeRenderBuffer(int width, int height)
        {
            this.renderBuffer = new Bitmap(renderForm.ClientSize.Width, renderForm.ClientSize.Height);
            this.renderBufferGraphics = Graphics.FromImage(this.renderBuffer);
        }
        public void renderBufferSwap()
        {
            lock (this.renderBuffer)
            {
                Graphics g = this.renderForm.CreateGraphics();
                g.DrawImage(this.renderBuffer, 0, 0, this.renderForm.ClientSize.Width, this.renderForm.ClientSize.Height);
            }
        }
        void renderForm_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                int old = this.cameraSelected;
                this.cameraSelected = -1;
                if (old >= 0 && old < cameras.Count)
                    renderCamera(getGraphics(), this.cameras[old], old);
            }
            catch { }
        }
        void renderForm_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                int old = cameraSelected;
                if (e.Location.X < 0 || e.Location.X > (renderCols * renderWidth) ||
                    e.Location.Y < 0 || e.Location.Y > (renderRows * renderHeight)
                    )
                    cameraSelected = -1;
                else
                {
                    int row = ((e.Location.Y + renderOffsetY) / renderHeight);
                    int col = (e.Location.X / renderWidth);

                    cameraSelected = (row * renderCols) + col;
                    if (cameraSelected >= cameras.Count)
                        cameraSelected = -1;
                }
                if (old != cameraSelected)
                {
                    Graphics g = getGraphics(); ;
                    if (old != -1)
                        renderCamera(g, cameras[old], old);
                    if (cameraSelected != -1)
                        renderCamera(g, cameras[cameraSelected], cameraSelected);
                }
            }
            catch { }
        }
        void renderForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Location.X < 0 || e.Location.X > (renderCols * renderWidth) ||
                e.Location.Y < 0 || e.Location.Y > (renderRows * renderHeight)
                )
                return;
            try
            {
                int index = (e.Location.X / renderWidth) + (((e.Location.Y + renderOffsetY) / renderHeight) * renderCols);
                getGraphics().DrawRectangle(new Pen(Color.Green), e.Location.X - 2, e.Location.Y - 2, 4, 4);
                this.cameras[index].Dump = !this.cameras[index].Dump;
            }
            catch { }
        }
        void renderForm_Paint(object sender, PaintEventArgs e)
        {
            renderBufferSwap();
        }
        void renderForm_Resize(object sender, EventArgs e)
        {
            resizeRenderBuffer(renderForm.ClientSize.Width, renderForm.ClientSize.Height);
            calculateRenderSize();
            renderAll();
        }
        // Methods *****************************************************************************************************
        public Graphics getGraphics()
        {
            return renderBufferGraphics;
        }
        /// <summary>
        /// Reloads stored user settings.
        /// </summary>
        /// <param name="initCall">Indicates if this call is coming at the start of the application's execution.</param>
        public void reloadSettings(bool initCall)
        {
            lock (this)
            {
                lock (cameras)
                {
                    lock (camerasDead)
                    {
                        if (!File.Exists("settings.xml"))
                            return;
                        // -- Load settings
                        XmlDocument doc = new XmlDocument();
                        doc.Load("settings.xml");
                        gridStyle = (RenderStyle)Enum.Parse(typeof(RenderStyle), doc["settings"]["style"].InnerText);
                        gridSizeWidth = int.Parse(doc["settings"]["width"].InnerText);
                        gridSizeHeight = int.Parse(doc["settings"]["height"].InnerText);
                        gridColumns = int.Parse(doc["settings"]["columns"].InnerText);
                        renderForm.cameraUpdater.Interval = int.Parse(doc["settings"]["updating"].InnerText);
                        renderForm.cameraDeadTester.Interval = int.Parse(doc["settings"]["retest"].InnerText);
                        renderForm.cameraCleaner.Interval = int.Parse(doc["settings"]["hide"].InnerText);
                        // -- Recalculate and re-render
                        if (!initCall)
                        {
                            calculateRenderSize();
                            renderAll();
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Reloads the cameras from the stored list (list.xml).
        /// </summary>
        public void reload()
        {
            lock (this)
            {
                lock (cameras)
                {
                    lock (camerasDead)
                    {
                        if (!File.Exists("list.xml"))
                            return;
                        cameras.Clear();
                        camerasDead.Clear();
                        // Add all the new cameras
                        XmlDocument x = new XmlDocument();
                        x.Load("list.xml");
                        foreach (XmlNode a in x["list"])
                        {
                            Camera c = new Camera(a["title"].InnerText, a["url"].InnerText);
                            add(c);
                        }
                        // Recalculate grid
                        calculateRenderSize();
                        // Rerender all cameras
                        renderAll();
                    }
                }
            }
        }
        /// <summary>
        /// Stops all of the update threads of all cameras.
        /// </summary>
        public void stopThreads()
        {
            lock (this)
            {
                lock (cameras)
                {
                    lock (camerasDead)
                    {
                        foreach (Camera c in cameras)
                        {
                            if (c.ThreadUpdater != null)
                                c.ThreadUpdater.Abort();
                        }
                        foreach (Camera c in camerasDead)
                        {
                            if (c.ThreadUpdater != null)
                                c.ThreadUpdater.Abort();
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Stops all camera dumping.
        /// </summary>
        public void stopDumping()
        {
            lock (this)
            {
                lock (cameras)
                {
                    lock (camerasDead)
                    {
                        foreach (Camera c in cameras)
                            c.Dump = false;
                        foreach (Camera c in camerasDead)
                            c.Dump = false;
                    }
                }
            }
        }
        /// <summary>
        /// Increments debugging data of the total number of frames parsed thus far.
        /// </summary>
        public void incrementTotalFrames()
        {
            debugTotalImageFrames++;
        }
        /// <summary>
        /// Adds a total number of bytes to debugging data of overall total bytes exchanged when fetching camera data.
        /// </summary>
        /// <param name="bytes"></param>
        public void addBytesUsage(long bytes)
        {
            lock(this)
                debugTotalBytes += bytes;
        }
        /// <summary>
        /// Adds a camera to the collection.
        /// </summary>
        /// <param name="camera">The camera to be added.</param>
        public void add(Camera camera)
        {
            camera.CameraManager = this;
            this.cameras.Add(camera);
            calculateRenderSize();
            renderForm.Invalidate();
        }
        /// <summary>
        /// Disposes this manager and its cameras.
        /// </summary>
        public void dispose()
        {
            foreach (Camera c in cameras)
            {
                try
                {
                    if (c.ThreadUpdater != null)
                        c.ThreadUpdater.Abort();
                }
                catch { }
            }
            foreach (Camera c in camerasDead)
            {
                try
                {
                    if (c.ThreadUpdater != null)
                        c.ThreadUpdater.Abort();
                }
                catch { }
            }
        }
        /// <summary>
        /// Calculates and cache's rendering information.
        /// </summary>
        public void calculateRenderSize()
        {
            // Calculate most optimal grid-size to fit all cameras
            int total = cameras.Count;
            int windowWidth = this.renderForm.RenderWidth;
            int windowHeight = this.renderForm.RenderHeight;
            switch (gridStyle)
            {
                case RenderStyle.SquareNumbers:
                    int rows, cols;
                    if (total == 0)
                    {
                        rows = 1;
                        cols = 1;
                    }
                    else if (total < 2)
                    {
                        rows = 1;
                        cols = total;
                    }
                    else
                    {
                        // Find most optimal usage by finding the floor-square (the nearest square equal or above)
                        // -- The rows and cols are based on the two numbers which make the square
                        int nearestSquare = 1;
                        for (int i = 0; i < squares.Length; i++)
                            if (squares[i] >= total)
                            {
                                nearestSquare = squares[i];
                                break;
                            }
                        // Find multiple
                        int multiple = rows = cols = (int)Math.Sqrt(nearestSquare);
                        // Check if to subtract a row if: square - count >= multiple
                        if (nearestSquare - total >= multiple)
                            rows--;
                    }
                    // Update params safely
                    renderRows = rows;
                    renderCols = cols;
                    renderWidth = windowWidth / cols;
                    renderHeight = windowHeight / rows;
                    break;
                case RenderStyle.Columns:
                    lock (this)
                    {
                        renderWidth = renderHeight = windowWidth / gridColumns;
                        renderCols = gridColumns;
                        renderRows = total / gridColumns;
                        if (renderRows == 0)
                            renderRows = 1;
                    }
                    break;
                case RenderStyle.Size:
                    lock (this)
                    {
                        renderWidth = gridSizeWidth;
                        renderHeight = gridSizeHeight;
                        renderCols = windowWidth / renderWidth;
                        renderRows = total / renderCols;
                    }
                    break;
            }
            // Calculate circles
            renderCircleWidth = renderCircleHeight = (int)((float)(renderWidth > renderHeight ? renderWidth : renderHeight) * 0.05f);
            // Calculate y clipping
            renderClippingYMin = -renderHeight;
            renderClippingYMax = windowHeight + renderHeight;
        }
        /// <summary>
        /// Re-renders all the cameras.
        /// </summary>
        public void renderAll()
        {
            Graphics g = getGraphics();
            try
            {
                // Clear the scene
                g.FillRectangle(new SolidBrush(Color.Black), 0, 0, this.renderForm.ClientSize.Width, this.renderForm.ClientSize.Height);
                // Re-render cameras
                lock (cameras)
                {
                    for (int i = 0; i < cameras.Count; i++)
                        renderCamera(g, cameras[i], i);
                }
            }
            catch (Exception ex)
            {
                Uber_Watcher.FormDebug.write("Failed renderAll; exception: '" + ex.Message + "'!");
            }
        }
        /// <summary>
        /// Re-renders a specified camera.
        /// </summary>
        /// <param name="camera">The camera to be re-rendered.</param>
        public void renderCamera(Camera camera)
        {
            try
            {
                int index = cameras.FindIndex(delegate(Camera c) { return camera == c; });
                Graphics g = getGraphics();
                renderCamera(g, camera, index);
            }
            catch (Exception ex)
            {
                Uber_Watcher.FormDebug.write("Failed renderCamera(camera); url: '" + camera.URL + "', exception: '" + ex.Message + "'!");
            }
        }
        /// <summary>
        /// Re-renders a specified camera.
        /// </summary>
        /// <param name="g">Graphics object of the render form.</param>
        /// <param name="cam">The camera to be re-rendered.</param>
        /// <param name="index">The index of the camera in the internal camera array.</param>
        public void renderCamera(Graphics g, Camera cam, int index)
        {
            try
            {
                // Calculate camera position
                int row = (index / renderCols) + 1;
                int col = (index % renderCols) + 1;
                int x = (col * renderWidth) - renderWidth;
                int y = (row * renderHeight) - renderHeight - renderOffsetY;
                // Check the camera is within the clipping-y values
                if (y < renderClippingYMin || y + renderHeight > renderClippingYMax)
                    return;
                // Render the camera
                cam.render(g, x, y, renderWidth, renderHeight, index == cameraSelected);
            }
            catch (Exception ex)
            {
                Uber_Watcher.FormDebug.write("Failed renderCamera(graphics, camera, index); url: '" + cam.URL + "', exception: '" + ex.Message + "'!");
            }
        }
        /// <summary>
        /// Invokes the update method of all the cameras to fetch frame data, if they're not already fetching data.
        /// </summary>
        public void updateAll()
        {
            foreach (Camera c in cameras)
            {
                c.update();
                System.Threading.Thread.Sleep(1);
            }
        }
        /// <summary>
        /// Cleans and moves any cameras with an excessive fail account exceeding the constant
        /// CAMERA_FAILCOUNTER_THRESHOLD to the camerasDead internal array; this also removes the cameras from being
        /// actively displayed.
        /// </summary>
        public void cleanDeadCameras()
        {
            lock (cameras)
            {
                lock (camerasDead)
                {
                    // Find dead cameras
                    List<Camera> buffer = new List<Camera>();
                    foreach (Camera c in cameras)
                    {
                        if (c.FailCounter > CAMERA_FAILCOUNTER_THRESHOLD)
                        {
                            if (c.ThreadUpdater != null)
                                c.ThreadUpdater.Abort();
                            buffer.Add(c);
                        }
                    }
                    // Move cameras to dead list
                    if (buffer.Count > 0)
                    {
                        foreach (Camera c in buffer)
                        {
                            cameras.Remove(c);
                            camerasDead.Add(c);
                        }
                        // Re-render all cameras
                        calculateRenderSize();
                        renderAll();
                    }
                }
            }
        }
        /// <summary>
        /// Tests the dead cameras and moves them back as an active camera if they're online again.
        /// </summary>
        public void testDeadCameras()
        {
            lock (cameras)
            {
                lock (camerasDead)
                {
                    List<Camera> alive = new List<Camera>();
                    // Issue an update for each camera; check fail-count.
                    foreach (Camera c in camerasDead)
                    {
                        if (c.FailCounter < 5)
                            alive.Add(c);
                        else
                            c.update();
                    }
                    // Move alive cameras back to the show
                    if (alive.Count > 0)
                    {
                        foreach (Camera c in alive)
                        {
                            camerasDead.Remove(c);
                            cameras.Add(c);
                        }
                        // Rebuild the scene
                        calculateRenderSize();
                        renderAll();
                    }
                }
            }
        }
        // Methods - Properties ****************************************************************************************
        /// <summary>
        /// The width of dump indicators.
        /// </summary>
        public int RenderCircleWidth
        {
            get
            {
                return renderCircleWidth;
            }
        }
        /// <summary>
        /// The height of dump indicators.
        /// </summary>
        public int RenderCircleHeight
        {
            get
            {
                return renderCircleHeight;
            }
        }
        /// <summary>
        /// Indicates the index of the current camera selected.
        /// </summary>
        public int CameraSelected
        {
            get
            {
                return cameraSelected;
            }
        }
        /// <summary>
        /// Array of active cameras.
        /// </summary>
        public Camera[] Cameras
        {
            get
            {
                return cameras.ToArray();
            }
        }
        /// <summary>
        /// Array of dead cameras.
        /// </summary>
        public Camera[] CamerasDead
        {
            get
            {
                return camerasDead.ToArray();
            }
        }
        /// <summary>
        /// The number of active cameras, for debug purposes only.
        /// </summary>
        public int DebugCameras
        {
            get
            {
                return cameras.Count;
            }
        }
        /// <summary>
        /// The number of dead cameras; for debug purposes only.
        /// </summary>
        public int DebugCamerasDead
        {
            get
            {
                return camerasDead.Count;
            }
        }
        /// <summary>
        /// The total number of bytes exchanged fetching imagery, for debug purposes only.
        /// </summary>
        public long DebugTotalBytes
        {
            get
            {
                return debugTotalBytes;
            }
        }
        /// <summary>
        /// The total number of frames parsed, for debug purposes only.
        /// </summary>
        public long DebugTotalFrames
        {
            get
            {
                return debugTotalImageFrames;
            }
        }
        /// <summary>
        /// The current grid style.
        /// </summary>
        public RenderStyle GridStyle
        {
            get
            {
                return gridStyle;
            }
        }
        /// <summary>
        /// The number of columns for the render-style columns.
        /// </summary>
        public int GridColumns
        {
            get
            {
                return gridColumns;
            }
        }
        /// <summary>
        /// The width of a camera for the render-style size.
        /// </summary>
        public int GridSizeWidth
        {
            get
            {
                return gridSizeWidth;
            }
        }
        /// <summary>
        /// The height of a camera for the render-style size.
        /// </summary>
        public int GridSizeHeight
        {
            get
            {
                return gridSizeHeight;
            }
        }
        public float RenderOffsetY
        {
            set
            {
                renderOffsetY = (int)(((float)(value)/100.0f) * (float)((cameras.Count / renderCols) * renderHeight));
                calculateRenderSize();
                renderAll();
            }
        }
    }
}
