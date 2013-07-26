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
 *      Path:           /FormCameraGrid.cs
 * 
 *      Change-Log:
 *                      2013-06-26      Created initial class.
 * 
 * *********************************************************************************************************************
 * A form for rendering cameras.
 * *********************************************************************************************************************
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using UberLib.UW;

namespace Uber_Watcher
{
    /// <summary>
    /// A form for rendering cameras.
    /// </summary>
    public partial class FormCameraGrid : Form
    {
        // Single Instance Code ****************************************************************************************
        private static FormCameraGrid f = null;
        public static FormCameraGrid GetInstance()
        {
            if (f == null)
            {
                f = new FormCameraGrid();
                f.FormClosed += delegate { f = null; };
            }
            return f;
        }
        private void FormCameraGrid_FormClosed(object sender, FormClosedEventArgs e)
        {
            f = null;
        }
        // Fields ******************************************************************************************************
        private static CameraManager cm;
        // Methods - Constructors **************************************************************************************
        public FormCameraGrid()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.MouseWheel += new MouseEventHandler(FormCameraGrid_MouseWheel);
        }

        void FormCameraGrid_MouseWheel(object sender, MouseEventArgs e)
        {
            int amount = -(int)(0.01f * (float)e.Delta);
            if (vsbMain.Value + amount < 0)
                vsbMain.Value = 0;
            else if (vsbMain.Value + amount > vsbMain.Maximum)
                vsbMain.Value = vsbMain.Maximum;
            else
                vsbMain.Value += amount;
        }
        // Methods - Event Handlers ************************************************************************************
        private void Form1_Load(object sender, EventArgs e)
        {
            cm = new CameraManager(this);
            cm.reload();
        }
        private void cameraUpdater_Tick(object sender, EventArgs e)
        {
            cm.updateAll();
        }
        private void frmCameraGrid_FormClosing(object sender, FormClosingEventArgs e)
        {
            cm.dispose();
        }
        private void cameraCleaner_Tick(object sender, EventArgs e)
        {
            cm.cleanDeadCameras();
        }
        private void cameraDeadTester_Tick(object sender, EventArgs e)
        {
            cm.testDeadCameras();
        }
        // Methods *****************************************************************************************************
        public void enable()
        {
            this.cameraCleaner.Enabled = this.cameraDeadTester.Enabled = this.cameraUpdater.Enabled = true;
        }
        public void disable()
        {
            this.cameraCleaner.Enabled = this.cameraDeadTester.Enabled = this.cameraUpdater.Enabled = false;
            cm.stopThreads();
        }
        // Methods - Properties ****************************************************************************************
        public static CameraManager CameraManager
        {
            get
            {
                return cm;
            }
        }

        private void vsbMain_ValueChanged(object sender, EventArgs e)
        {
            cm.RenderOffsetY = vsbMain.Value;
        }

        private void bufferSwap_Tick(object sender, EventArgs e)
        {
            cm.renderBufferSwap();
        }
        public int RenderWidth
        {
            get
            {
                return ClientSize.Width - vsbMain.Width;
            }
        }
        public int RenderHeight
        {
            get
            {
                return ClientSize.Height;
            }
        }
    }
}
