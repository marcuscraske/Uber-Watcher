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
 *      Path:           /FormDebug.cs
 * 
 *      Change-Log:
 *                      2013-06-26      Created initial class.
 * 
 * *********************************************************************************************************************
 * A form for debug information.
 * *********************************************************************************************************************
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Uber_Watcher
{
    /// <summary>
    /// A form for debug information.
    /// </summary>
    public partial class FormDebug : Form
    {
        // Single Instance Code ****************************************************************************************
        private static FormDebug f = null;
        public static FormDebug GetInstance()
        {
            if (f == null)
            {
                f = new FormDebug();
                f.FormClosed += delegate { f = null; };
            }
            return f;
        }
        private void FormDebug_FormClosed(object sender, FormClosedEventArgs e)
        {
            f = null;
        }
        // Methods - Constructors **************************************************************************************
        public FormDebug()
        {
            InitializeComponent();
        }
        // Methods - Event Handlers ************************************************************************************
        private void updater_Tick(object sender, EventArgs e)
        {
            this.lbCamerasActive.Text = FormCameraGrid.CameraManager.DebugCameras.ToString();
            this.lbCamerasDead.Text = FormCameraGrid.CameraManager.DebugCamerasDead.ToString();
            this.lbDataUsage.Text = getBytesString((float)FormCameraGrid.CameraManager.DebugTotalBytes);
            this.lbTotalImages.Text = FormCameraGrid.CameraManager.DebugTotalFrames.ToString();
        }
        // Methods *****************************************************************************************************
        public static void write(string message)
        {
            try
            {
                if (f == null)
                    return;
                f.Invoke((MethodInvoker)delegate()
                {
                    f.lbDebugMessages.Items.Add(message);
                    f.lbDebugMessages.SelectedIndex = f.lbDebugMessages.Items.Count - 1;
                });
            }
            catch { }
        }
        /// <summary>
        /// Converts bytes to the largest possible unit of bytes available to make it more human-readable.
        /// </summary>
        /// <param name="bytes">Total number of bytes.</param>
        /// <returns>Bytes parameter formatted into a larger unit of bytes.</returns>
        public static string getBytesString(float bytes)
        {
            const float kiolobyte = 1024.0f;
            const float megabyte = 1048576.0f;
            const float gigabyte = 1073741824.0f;
            const float terrabyte = 1099511627776.0f;
            const float petabyte = 1125899906842624.0f;

            if (bytes < kiolobyte)
                return bytes + " B";
            else if (bytes < megabyte)
                return (bytes / kiolobyte).ToString("0.##") + " KB";
            else if (bytes < gigabyte)
                return (bytes / megabyte).ToString("0.##") + " MB";
            else if (bytes < terrabyte)
                return (bytes / gigabyte).ToString("0.##") + " GB";
            else if (bytes < petabyte)
                return (bytes / terrabyte).ToString("0.##") + "TB";
            else
                return (bytes / petabyte).ToString("0.##") + " PB";
        }
    }
}
