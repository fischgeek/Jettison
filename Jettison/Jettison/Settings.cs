using JettisonClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JettisonApp
{
    public partial class Settings : Form
    {
        DataHandler dh = DataHandler.getInstance();

        public Settings()
        {
            InitializeComponent();
            Dictionary<string, bool> settings = dh.getSettings();
            cbxRunOnStartup.Checked = settings["RunOnStartup"];
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            Dictionary<string, bool> settings = new Dictionary<string, bool>();
            settings.Add("RunOnStartup", cbxRunOnStartup.Checked);
            dh.updateSettings(settings);

            JettisonClassLibrary.Jettison.HandleSettings(settings);
            MessageBox.Show("Jettison", "Settings updated!");
            this.Close();
        }

        private void btnCancelSettings_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
    }
}
