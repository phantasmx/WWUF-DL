using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;
using System.Diagnostics;
using System.Net;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using System.Collections.Specialized;

namespace SWUF_DL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string baseURL = @"https://dl.app.w-witch-app.com/AssetBundle/Android/rsc/";
        string catalogURL = @"https://dl.app.w-witch-app.com/AssetBundle/Android/rsc/remote_catalog.json";
        string dataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
        //string dataPath = @"d:\_DEL\SWUF\";
        JavaScriptSerializer js = new JavaScriptSerializer();




        private void buttonDL_Click(object sender, EventArgs e)
        {
            js.MaxJsonLength = int.MaxValue;
            
            byte[] jsonData;
            string fileURL;
            string filePath;
            string fileName;
            int count = 0;
            int total = 0;

            Task.Factory.StartNew(() =>
            {
                groupBoxDL.Invoke(new Action(() => groupBoxDL.Enabled = false));
                using (var client = new WebClient())
                {
                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    client.Headers.Add("user-agent", "SWUF");
                    try
                    {
                        jsonData = client.DownloadData(catalogURL);
                    }
                    catch
                    {
                        MessageBox.Show("Unable to download remote_catalog.json file");
                        return;
                    }
                }
                File.WriteAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "remote_catalog.json"), jsonData);

                if (!Directory.Exists(dataPath))
                {
                    Directory.CreateDirectory(dataPath);
                }

                string jsonText = Encoding.UTF8.GetString(jsonData);
                RemoteCatalog remoteCatalog = (RemoteCatalog)js.Deserialize<RemoteCatalog>(jsonText);
                string[] m_InternalIds = remoteCatalog.m_InternalIds;

                foreach (string line in m_InternalIds)
                {
                    if (line.Contains(".bundle"))
                    {
                        total++;
                    }
                }



                foreach (string line in m_InternalIds)
                {
                    if (line.Contains(".bundle"))
                    {
                        fileName = line.Replace(@"api://AssetBundle/Android/rsc/", "");
                        fileURL = baseURL + fileName;
                        filePath = Path.Combine(dataPath, fileName);

                        using (var client = new WebClient())
                        {
                            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                            client.Headers.Add("user-agent", "AGA");
                            try
                            {
                                client.DownloadFile(fileURL, filePath);
                            }
                            catch
                            {
                                try
                                {
                                    client.DownloadFile(fileURL, filePath);
                                }
                                catch
                                {
                                    continue;
                                }
                            }
                        }
                        count++;
                        buttonDL.Invoke(new Action(() => buttonDL.Text = count.ToString() + "/" + total.ToString()));
                    }
                }
                MessageBox.Show("Downloaded " + count.ToString() + " out of " + total.ToString() + " files");
                buttonDL.Invoke(new Action(() => buttonDL.Text = "Download"));
                groupBoxDL.Invoke(new Action(() => groupBoxDL.Enabled = true));
            });
        }

        public class ProviderData
        {
            public string m_Id { get; set; }
            public ObjectType m_ObjectType { get; set; }
            public string m_Data { get; set; }
        }

        public class ObjectType
        {
            public string m_AssemblyName { get; set; }
            public string m_ClassName { get; set; }
        }

        public class RemoteCatalog
        {
            public string m_LocatorId { get; set; }
            public ProviderData m_InstanceProviderData { get; set; }
            public ProviderData m_SceneProviderData { get; set; }
            public ProviderData[] m_ResourceProviderData { get; set; }
            public string[] m_ProviderIds { get; set; }
            public string[] m_InternalIds { get; set; }
            public string m_KeyDataString { get; set; }
            public string m_BucketDataString { get; set; }
            public string m_EntryDataString { get; set; }
            public string m_ExtraDataString { get; set; }
            public string[] m_Keys { get; set; }
            public ObjectType[] m_resourceTypes { get; set; }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            js.MaxJsonLength = int.MaxValue;

            byte[] jsonData;
            List<string> links = new List<string>();
            string fileURL;
            string fileName;

            Task.Factory.StartNew(() =>
            {
                groupBoxDL.Invoke(new Action(() => groupBoxDL.Enabled = false));
                using (var client = new WebClient())
                {
                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    client.Headers.Add("user-agent", "SWUF");
                    try
                    {
                        jsonData = client.DownloadData(catalogURL);
                    }
                    catch
                    {
                        MessageBox.Show("Unable to download remote_catalog.json file");
                        return;
                    }
                }
                File.WriteAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "remote_catalog.json"), jsonData);

                string jsonText = Encoding.UTF8.GetString(jsonData);
                RemoteCatalog remoteCatalog = (RemoteCatalog)js.Deserialize<RemoteCatalog>(jsonText);
                string[] m_InternalIds = remoteCatalog.m_InternalIds;

                foreach (string line in m_InternalIds)
                {
                    if (line.Contains(".bundle"))
                    {
                        fileName = line.Replace(@"api://AssetBundle/Android/rsc/", "");
                        fileURL = baseURL + fileName;
                        links.Add(fileURL);
                    }
                }

                File.WriteAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Links.txt"), links);

                
                MessageBox.Show("Saved");
                groupBoxDL.Invoke(new Action(() => groupBoxDL.Enabled = true));
            });
        }
    }
}
