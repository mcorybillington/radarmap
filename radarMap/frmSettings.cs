using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace radarMap
{
    public partial class frmSettings : Form
    {
        private bool _hasChanges = false;

        public frmSettings()
        {
            InitializeComponent();

            Properties.Settings.Default.PropertyChanged += Default_PropertyChanged;
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            propertyGrid1.SelectedObject = Properties.Settings.Default;
        }

        private void frmSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_hasChanges)
            {
                var diagResult = MessageBox.Show(this, "Would you like to save changes", "Save?", MessageBoxButtons.YesNo);
                if (diagResult == DialogResult.Yes)
                {
                    Properties.Settings.Default.Save();
                    Form1.ActiveForm.Refresh();
                    
                }
                else
                {
                    Properties.Settings.Default.Reload();
                }
            }
            
        }

        private void Default_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            _hasChanges = true;
        }
    }
}
