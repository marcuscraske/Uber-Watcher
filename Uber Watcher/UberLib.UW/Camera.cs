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
 *      Path:           /UberLib.UW/Camera.cs
 * 
 *      Change-Log:
 *                      2013-06-26      Created initial class.
 * 
 * *********************************************************************************************************************
 * A model for a networked camera.
 * *********************************************************************************************************************
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Threading;
using System.IO;

namespace UberLib.UW
{
    /// <summary>
    /// A model for a networked camera.
    /// </summary>
    public class Camera
    {
        // Constants ***************************************************************************************************
        /// <summary>
        /// The timeout, in milliseconds, of connecting to a URL to update.
        /// </summary>
        private const int UPDATE_TIMEOUT = 10000;
        // Fields ******************************************************************************************************
        private CameraManager cm;   // The camera manager; used for call-backs.
        private string title;       // The title of the camera; also used as directory name (if provided).
        private string url;         // The source URL of the image for this camera.
        private string dir;         // The directory name for storing the images of this camera.
        private Image buffer;       // The buffer containing the image of the camera.
        private byte[] rawBuffer;   // The raw byte buffer of the image; used internally for dumping.
        private bool dump;          // Indicates if to dump each frame to file.
        private bool verifyJpg;     // Indicates if to check the data is jpg.
        private int failCounter;    // Number of consecutive failed attempts to retrieve imagery.
        private Thread updater;     // The thread used for updating.
        // Methods - Constructors **************************************************************************************
        public Camera(string title, string url)
        {
            this.cm = null;
            this.title = title;
            this.url = url;
            this.buffer = null;
            this.rawBuffer = null;
            this.dump = false;
            this.verifyJpg = false;
            this.failCounter = 0;
            this.updater = null;
            // Build directory for dumping
            this.dir = (AppDomain.CurrentDomain.BaseDirectory.EndsWith("\\") ? AppDomain.CurrentDomain.BaseDirectory : AppDomain.CurrentDomain.BaseDirectory + "/").Replace("\\", "/") + "dump/";
            if (title == null || title.Length == 0)
            {
                StringBuilder buff = new StringBuilder();
                foreach (char c in url)
                    if ((c >= 48 && c <= 57) || (c >= 65 && c <= 90) || (c >= 97 && c <= 122))
                        buff.Append(c);
                    else if (c == '.')
                        buff.Append("_");
                dir += buff.ToString();
            }
            else
                dir += title;
        }
        // Methods *****************************************************************************************************
        /// <summary>
        /// Updates the camera's image.
        /// </summary>
        public void update()
        {
            try
            {
                lock (this)
                {
                    if (updater != null)
                        return;
                    // Create new thread to make the call to the image-lib to update the buffer
                    updater = new Thread(delegate()
                    {
                        long bytes = 0;
                        ImageLib.FetchResult res = ImageLib.fetchImage(this.url, ref this.buffer, ref this.rawBuffer, ref bytes, this.verifyJpg, UPDATE_TIMEOUT);
                        if (res != ImageLib.FetchResult.Success)
                            failCounter++;
                        else
                        {
                            failCounter = 0;
                            cm.addBytesUsage(bytes);
                            cm.incrementTotalFrames();
                        }
                        // Dump frame
                        if (buffer != null && dump)
                        {
                            lock (buffer)
                            {
                                // Check the directory exists
                                string d = dir + "/" + DateTime.Now.ToString("dd_MM_yyyy");
                                if (!Directory.Exists(d))
                                    Directory.CreateDirectory(d);
                                // Check the file doesn't exist
                                string file = d + "/" + DateTime.Now.ToString("HH_mm_ss") + ".jpg";
                                int errors = 0;
                                while (File.Exists(file) && errors++ < 5)
                                    file += ".2";
                                if (errors < 5)
                                    File.WriteAllBytes(file, rawBuffer);
                            }
                        }
                        // Re-render camera
                        cm.renderCamera(this);
                        updater = null;
                    });
                }
                updater.Start();
            }
            catch { }
        }
        /// <summary>
        /// Renders the camera taking ratio into consideraiton.
        /// </summary>
        /// <param name="g">Graphics renderer.</param>
        /// <param name="x">Destination x co-ord.</param>
        /// <param name="y">Destination y co-ord.</param>
        /// <param name="width">Destination width.</param>
        /// <param name="height">Destination height.</param>
        /// <param name="selected">Indicates if the camera is selected.</param>
        public void render(Graphics g, int x, int y, int width, int height, bool selected)
        {
            lock (this)
            {
                // Camera is offline/unavailable
                if (buffer == null)
                {
                    g.FillRectangle(new SolidBrush(Color.Black), x, y, width, height);
                    Pen r = new Pen(Color.Red);
                    g.DrawLine(r, x + 1, y + 1, x + width - 1, y + height - 1);
                    g.DrawLine(r, x + 1, y + height - 1, x + width - 1, y + 1);
                }
                else
                {
                    int wh = (int)((float)width / 2.0f);
                    int hh = (int)((float)height / 2.0f);
                    // Calculate ratio
                    float rw = (float)width / (float)buffer.Width;
                    float rh = (float)height / (float)buffer.Height;
                    float ratio = rw > rh ? rh : rw; // Min value of the ratios

                    int imgWidth = (int)((float)buffer.Width * ratio);
                    int imgHeight = (int)((float)buffer.Height * ratio);

                    int imgWidthH = (int)((float)imgWidth / 2.0f);
                    int imgHeightH = (int)((float)imgHeight / 2.0f);
                    // Render black background of camera
                    if (imgWidth != width || imgHeight != height)
                        g.FillRectangle(new SolidBrush(Color.Black), x, y, width, height);
                    // Render buffer of camera
                    g.DrawImage(buffer, x + wh - imgWidthH, y + hh - imgHeightH, imgWidth, imgHeight);
                }
                // Draw selection colour (if selected)
                if (selected)
                    g.FillRectangle(new SolidBrush(Color.FromArgb(40, 255, 0, 0)), x, y, width, height);
                // Render information
                // -- Dump/record icon
                g.DrawEllipse(new Pen(dump ? Color.DarkRed : Color.DarkGray), x + width - cm.RenderCircleWidth, y + height - cm.RenderCircleHeight, cm.RenderCircleWidth, cm.RenderCircleHeight);
                g.FillEllipse(new SolidBrush(dump ? Color.Red : Color.Gray), x + width - cm.RenderCircleWidth, y + height - cm.RenderCircleHeight, cm.RenderCircleWidth, cm.RenderCircleHeight);
                // Draw frame
                g.DrawRectangle(new Pen(Color.DarkGray), x, y, width, height);
            }
        }
        // Methods - Properties ****************************************************************************************
        /// <summary>
        /// The title of the camera.
        /// </summary>
        public string Title
        {
            get
            {
                return title;
            }
        }
        /// <summary>
        /// The URL of the camera.
        /// </summary>
        public string URL
        {
            get
            {
                return url;
            }
        }
        /// <summary>
        /// The camera's latest frame; possibly null.
        /// </summary>
        public Image Image
        {
            get
            {
                return buffer;
            }
        }
        /// <summary>
        /// Indicates if the camera should dump its frames to disk.
        /// </summary>
        public bool Dump
        {
            get
            {
                return dump;
            }
            set
            {
                dump = value;
            }
        }
        /// <summary>
        /// Indicates if to check the camera's frames are valid jpgs.
        /// </summary>
        public bool VerifyJpg
        {
            get
            {
                return verifyJpg;
            }
            set
            {
                verifyJpg = value;
            }
        }
        /// <summary>
        /// Indicates if the camera is currently updating its image.
        /// </summary>
        public bool IsUpdating
        {
            get
            {
                return updater != null;
            }
        }
        /// <summary>
        /// The manager of this camera.
        /// </summary>
        public CameraManager CameraManager
        {
            get
            {
                return cm;
            }
            set
            {
                cm = value;
            }
        }
        /// <summary>
        /// The thread currently updating this camera; null if the camera is not being updated.
        /// </summary>
        public Thread ThreadUpdater
        {
            get
            {
                return updater;
            }
        }
        /// <summary>
        /// The path of the directory containing dumped frames for this camera.
        /// </summary>
        public string DumpDirectory
        {
            get
            {
                return dir;
            }
        }
        /// <summary>
        /// The current number of consecutive failures.
        /// </summary>
        public int FailCounter
        {
            get
            {
                return failCounter;
            }
        }
    }
}
