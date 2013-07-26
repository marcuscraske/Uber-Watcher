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
 *      Path:           /FormSettings.cs
 * 
 *      Change-Log:
 *                      2013-06-26      Created initial class.
 * 
 * *********************************************************************************************************************
 * A form for handling the application's user-settings.
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
using System.Xml;

namespace Uber_Watcher
{
    /// <summary>
    /// A form for handling the application's user-settings.
    /// </summary>
    public partial class FormSettings : Form
    {
        // Single Instance Code ****************************************************************************************
        private static FormSettings f = null;
        public static FormSettings GetInstance()
        {
            if (f == null)
            {
                f = new FormSettings();
                f.FormClosed += delegate { f = null; };
            }
            return f;
        }
        private void FormCameraList_FormClosed(object sender, FormClosedEventArgs e)
        {
            f = null;
        }
        // Methods - Constructors **************************************************************************************
        public FormSettings()
        {
            InitializeComponent();
        }
        // Methods - Event Handlers ************************************************************************************
        private void FormSettings_Load(object sender, EventArgs e)
        {
            // Load settings
            // -- Style: style
            if (cbStyle.Items.Count == 0)
            {
                foreach (string s in Enum.GetNames(typeof(CameraManager.RenderStyle)))
                    cbStyle.Items.Add(s);
            }
            cbStyle.SelectedText = FormCameraGrid.CameraManager.GridStyle.ToString();
            // -- Style: camera width
            txtCamWidth.Text = FormCameraGrid.CameraManager.GridSizeWidth.ToString();
            // -- Style: camera height
            txtCamHeight.Text = FormCameraGrid.CameraManager.GridSizeHeight.ToString();
            // -- Style: columns
            txtColumns.Text = FormCameraGrid.CameraManager.GridColumns.ToString();
            // -- Intervals: updating
            FormCameraGrid f = FormCameraGrid.GetInstance();
            txtUpdating.Text = f.cameraUpdater.Interval.ToString();
            // -- Intervals: retest
            txtRetest.Text = f.cameraDeadTester.Interval.ToString();
            // -- Intervals: hide
            txtHide.Text = f.cameraDeadTester.Interval.ToString();
        }
        private void buttClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void buttSave_Click(object sender, EventArgs e)
        {
            // Validate data
            if (cbStyle.Text.Length == 0)
            {
                invalid("Incorrect value for grid-style style!");
                return;
            }
            else if (!validRange(txtCamWidth.Text, 1, int.MaxValue))
            {
                invalid("Incorrect value for grid-style camera width!");
                return;
            }
            else if (!validRange(txtCamHeight.Text, 1, int.MaxValue))
            {
                invalid("Incorrect value for grid-style camera height!");
                return;
            }
            else if (!validRange(txtColumns.Text, 1, int.MaxValue))
            {
                invalid("Incorrect value for grid-style columns!");
                return;
            }
            else if (!validRange(txtUpdating.Text, 1, int.MaxValue))
            {
                invalid("Incorrect value for camera-intervals image updating!");
                return;
            }
            else if (!validRange(txtRetest.Text, 1, int.MaxValue))
            {
                invalid("Incorrect value for camera-intervals re-test dead cameras!");
                return;
            }
            else if (!validRange(txtHide.Text, 1, int.MaxValue))
            {
                invalid("Incorrect value for camera-intervals hide dead cameras!");
                return;
            }
            // Save settings
            XmlWriterSettings xs = new XmlWriterSettings();
            xs.Indent = true;
            xs.NewLineOnAttributes = true;
            XmlWriter x = XmlWriter.Create("settings.xml", xs);
            x.WriteStartDocument();
            x.WriteStartElement("settings");

            // -- Style: style
            x.WriteStartElement("style");
            x.WriteCData(cbStyle.Text);
            x.WriteEndElement();
            // -- Style: camera-width
            x.WriteStartElement("width");
            x.WriteCData(txtCamWidth.Text);
            x.WriteEndElement();
            // -- Style: camera-height
            x.WriteStartElement("height");
            x.WriteCData(txtCamHeight.Text);
            x.WriteEndElement();
            // -- Style: columns
            x.WriteStartElement("columns");
            x.WriteCData(txtColumns.Text);
            x.WriteEndElement();
            // -- Intervals: updating
            x.WriteStartElement("updating");
            x.WriteCData(txtUpdating.Text);
            x.WriteEndElement();
            // -- Intervals: retest
            x.WriteStartElement("retest");
            x.WriteCData(txtRetest.Text);
            x.WriteEndElement();
            // -- Intervals: hide
            x.WriteStartElement("hide");
            x.WriteCData(txtHide.Text);
            x.WriteEndElement();

            x.WriteEndElement();
            x.WriteEndDocument();
            x.Flush();
            x.Close();
            // Apply to camera manager
            FormCameraGrid.CameraManager.reloadSettings(false);
            // Close
            Close();
        }
        // Methods *****************************************************************************************************
        private void invalid(string msg)
        {
            MessageBox.Show(msg, "Invalid Value");
        }
        private bool validRange(string source, int min, int max)
        {
            int t;
            return int.TryParse(source, out t) && t >= min && t <= max;
        }


    }
}
