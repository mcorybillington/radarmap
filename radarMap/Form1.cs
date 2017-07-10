using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace radarMap
{
    public partial class Form1 : Form
    {
        private Image backgroundImage = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void settingsToolStripSettings_Click(object sender, EventArgs e)
        {
            using (var settingsForm = new frmSettings())
            {
                settingsForm.ShowDialog(this);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                using (var client = new WebClient())
                {
                    var data = client.DownloadData(
                        $"http://api.wunderground.com/api/{Properties.Settings.Default.WUApi_Key}/radar/image.gif?centerlat={Properties.Settings.Default.Center_Lat}&centerlon={Properties.Settings.Default.Center_Lon}&radius={Properties.Settings.Default.Radius}&width=1200&height=1200&newmaps=1&smooth=1");

                    var ms = new MemoryStream(data);

                        backgroundImage = System.Drawing.Image.FromStream(ms);
                        this.BackgroundImage = backgroundImage;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to download radar");
            }
        }
    }
}
