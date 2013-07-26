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
 *      Path:           /FormAbout.cs
 * 
 *      Change-Log:
 *                      2013-06-26      Created initial class.
 * 
 * *********************************************************************************************************************
 * An about form.
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

namespace Uber_Watcher
{
    /// <summary>
    /// An about form.
    /// </summary>
    public partial class FormAbout : Form
    {
        // Single Instance Code ****************************************************************************************
        private static FormAbout f = null;
        public static FormAbout GetInstance()
        {
            if (f == null)
            {
                f = new FormAbout();
                f.FormClosed += delegate { f = null; };
            }
            return f;
        }
        private void FormAbout_FormClosing(object sender, FormClosingEventArgs e)
        {
            f = null;
        }
        // Methods - Constructors **************************************************************************************
        public FormAbout()
        {
            InitializeComponent();
        }
        // Methods - Events Handlers ***********************************************************************************
        private void buttClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void linkGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(linkGithub.Text);
        }
        private void FormAbout_Load(object sender, EventArgs e)
        {
            lbVersion.Text += Version.Major + "." + Version.Minor + "." + Version.Build;
        }
    }
}
