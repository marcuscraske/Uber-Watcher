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
 *      Path:           /FormCameraList.cs
 * 
 *      Change-Log:
 *                      2013-06-26      Created initial class.
 * 
 * *********************************************************************************************************************
 * A form for managing cameras.
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
    /// A form for managing cameras.
    /// </summary>
    public partial class FormCameraList : Form
    {
        // Single Instance Code ****************************************************************************************
        private static FormCameraList f = null;
        public static FormCameraList GetInstance()
        {
            if (f == null)
            {
                f = new FormCameraList();
                f.FormClosed += delegate { f = null; };
            }
            return f;
        }
        private void FormCameraList_FormClosed(object sender, FormClosedEventArgs e)
        {
            f = null;
        }
        // Fields ******************************************************************************************************
        Dictionary<string,Camera> cameras = new Dictionary<string,Camera>();
        // Methods - Constructors **************************************************************************************
        public FormCameraList()
        {
            InitializeComponent();
        }
        // Methods *****************************************************************************************************
        public string buildCameraItem(Camera cam)
        {
            return (cam.Title == null || cam.Title.Length == 0 ? "Untitled" : cam.Title) + " : " + cam.URL;
        }
        public Camera getCamera(string item)
        {
            return cameras[item.Substring(item.IndexOf(':') + 2)];
        }
        public void getItemData(object rawItem, ref string title, ref string url)
        {
            string item = rawItem as string;
            int index = item.IndexOf(':');
            title = item.Substring(0, index - 1);
            url = item.Substring(index + 2);
        }
        // Methods - Event Handlers ************************************************************************************
        private void FormCameraList_Load(object sender, EventArgs e)
        {
            FormCameraGrid f = FormCameraGrid.GetInstance();
            f.Hide();
            f.disable();
            // Build list of cameras
            foreach (Camera c in FormCameraGrid.CameraManager.Cameras)
                if(!cameras.ContainsKey(c.URL))
                    cameras.Add(c.URL, c);
            foreach (Camera c in FormCameraGrid.CameraManager.CamerasDead)
                if (!cameras.ContainsKey(c.URL))
                    cameras.Add(c.URL, c);
            // Add each camera to the listbox
            foreach (KeyValuePair<string, Camera> kv in cameras)
                lbCameras.Items.Add(buildCameraItem(kv.Value));
        }
        private void buttClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FormCameraList_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormCameraGrid f = FormCameraGrid.GetInstance();
            f.enable();
            f.Show();
        }
        private void buttRemove_Click(object sender, EventArgs e)
        {
            List<object> buffer = new List<object>();
            foreach (object v in lbCameras.SelectedItems)
            {
                string s = v as string;
                cameras.Remove(s.Substring(s.IndexOf(':') + 2));
                buffer.Add(v);
            }
            foreach (object v in buffer)
                lbCameras.Items.Remove(v);
        }
        private void buttRemoveDead_Click(object sender, EventArgs e)
        {
            foreach (KeyValuePair<string, Camera> kv in cameras)
            {
                if (kv.Value.FailCounter > CameraManager.CAMERA_FAILCOUNTER_THRESHOLD)
                    lbCameras.Items.Remove(buildCameraItem(kv.Value));
            }
        }
        private void buttEdit_Click(object sender, EventArgs e)
        {
            if (lbCameras.SelectedItems.Count != 1)
            {
                MessageBox.Show("You must only select one camera!");
                return;
            }
            // Get the selected item, remove it and put it in the add url/title textboxes
            object item = lbCameras.SelectedItem;
            lbCameras.Items.Remove(item);
            string title = null, url = null;
            getItemData(item, ref title, ref url);
            txtAddTitle.Text = title;
            txtAddUrl.Text = url;
        }
        private void buttAdd_Click(object sender, EventArgs e)
        {
            string title = txtAddTitle.Text;
            string url = txtAddUrl.Text;
            if (title.Length == 0 || url.Length == 0)
                return;
            // Validate title characters as alpha-numeric, space, hyphen, under-scroll
            foreach (char c in title)
            {
                if(c != ' ' && c != '_' && c != '-' && !(c >= 48 && c <= 57) && !(c >= 65 && c <= 90) && !(c >= 97 && c <= 122))
                {
                    MessageBox.Show("Title may only contain alpha-numeric, space ( ), hypen (-) or/and under-scroll (_) characters!");
                    return;
                }
            }
            // Validate URL
            Uri t = null;
            if (!System.Uri.TryCreate(url, UriKind.Absolute, out t) && MessageBox.Show("Invalid URL; continue? (may be dangerous)", "Warning", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                return;
            // Add the item
            lbCameras.Items.Add(title + " : " + url);
            txtAddTitle.Text = txtAddUrl.Text = string.Empty;
        }
        private void buttMassAdd_Click(object sender, EventArgs e)
        {
            Uri t = null;
            foreach(string line in txtCopypasta.Text.Replace("\r", "").Split('\n'))
            {
                if(System.Uri.TryCreate(line, UriKind.Absolute, out t))
                    lbCameras.Items.Add("Untitled : " + line);
            }
        }
        private void buttDump_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            string title = null, url = null;
            foreach (object item in lbCameras.Items)
            {
                getItemData(item, ref title, ref url);
                sb.AppendLine(url);
            }
            txtCopypasta.Text = sb.ToString();
        }
        private void buttSaveClose_Click(object sender, EventArgs e)
        {
            // Write data to the configuration file
            XmlWriterSettings xs = new XmlWriterSettings();
            xs.Indent = true;
            xs.NewLineOnAttributes = true;
            XmlWriter x = XmlWriter.Create("list.xml", xs);
            x.WriteStartDocument();
            x.WriteStartElement("list");
            string title = null, url = null;
            foreach (object item in lbCameras.Items)
            {
                getItemData(item, ref title, ref url);
                x.WriteStartElement("item");
                // -- Title
                x.WriteStartElement("title");
                x.WriteCData(title.Length == 0 || title == "Untitled" ? string.Empty : title);
                x.WriteEndElement();
                // -- URL
                x.WriteStartElement("url");
                x.WriteCData(url);
                x.WriteEndElement();
                x.WriteEndElement();
            }
            x.WriteEndElement();
            x.WriteEndDocument();
            x.Flush();
            x.Close();
            // Inform the camera manager to reload
            FormCameraGrid.CameraManager.reload();
            // Close
            Close();
        }

        
    }
}
