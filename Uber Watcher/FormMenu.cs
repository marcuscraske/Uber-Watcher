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
 *      Path:           /FormMenu.cs
 * 
 *      Change-Log:
 *                      2013-06-26      Created initial class.
 * 
 * *********************************************************************************************************************
 * The menu form displayed on application launch.
 * *********************************************************************************************************************
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace Uber_Watcher
{
    /// <summary>
    /// The menu form displayed on application launch.
    /// </summary>
    public partial class FormMenu : Form
    {
        // Methods - Constructors **************************************************************************************
        public FormMenu()
        {
            InitializeComponent();
        }
        // Methods - Event Handlers ************************************************************************************
        private void buttExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void buttAbout_Click(object sender, EventArgs e)
        {
            FormAbout f = FormAbout.GetInstance();
            f.Show();
        }
        private void buttDebug_Click(object sender, EventArgs e)
        {
            FormDebug f = FormDebug.GetInstance();
            f.Show();
        }
        private void buttSettings_Click(object sender, EventArgs e)
        {
            FormSettings f = FormSettings.GetInstance();
            f.Show();
        }
        private void buttCameraList_Click(object sender, EventArgs e)
        {
            FormCameraList f = FormCameraList.GetInstance();
            f.Show();
        }
        private void buttDump_Click(object sender, EventArgs e)
        {
            string dir = (AppDomain.CurrentDomain.BaseDirectory.EndsWith("\\") ? AppDomain.CurrentDomain.BaseDirectory : AppDomain.CurrentDomain.BaseDirectory + "/").Replace("\\", "/") + "dump";
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            Process.Start(dir);
        }
        private void FormMenu_Load(object sender, EventArgs e)
        {
            FormCameraGrid f = FormCameraGrid.GetInstance();
            f.Show();
            this.Text += Version.Major + "." + Version.Minor + "." + Version.Build;
        }
        private void FormMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void buttCameraMonitor_Click(object sender, EventArgs e)
        {
            FormCameraGrid f = FormCameraGrid.GetInstance();
            f.Show();
        }

        private void buttStopDumping_Click(object sender, EventArgs e)
        {
            FormCameraGrid.CameraManager.stopDumping();
        }

    }
}
