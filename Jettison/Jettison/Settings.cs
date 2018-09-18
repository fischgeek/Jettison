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
        DataHandler dh = DataHandler.GetInstance();

        public Settings()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.jettison;
            Dictionary<string, bool> settings = dh.GetSettings();
            if (settings.ContainsKey("RunOnStartup"))
            {
                cbxRunOnStartup.Checked = settings["RunOnStartup"];
            }
            if (settings.ContainsKey("ShowOnStart"))
            {
                cbxShowOnStart.Checked = settings["ShowOnStart"];
            } else {
                cbxShowOnStart.Checked = true;
            }
            if (settings.ContainsKey("CloseToTray"))
            {
                cbxCloseToTray.Checked = true;
            }
            if (settings.ContainsKey("LogHistory"))
            {
                cbxLogHistory.Checked = settings["LogHistory"];
            }
            if (settings.ContainsKey("DisplayAlerts"))
            {
                cbxDisplayMessage.Checked = settings["DisplayAlerts"];
            }
        }

        private void BtnSaveSettings_Click(object sender, EventArgs e)
        {
            Dictionary<string, bool> settings = new Dictionary<string, bool>();
            settings.Add("RunOnStartup", cbxRunOnStartup.Checked);
            settings.Add("ShowOnStart", cbxShowOnStart.Checked);
            settings.Add("CloseToTray", cbxCloseToTray.Checked);
            settings.Add("LogHistory", cbxLogHistory.Checked);
            settings.Add("DisplayAlerts", cbxDisplayMessage.Checked);
            dh.UpdateSettings(settings);

            Jettison.HandleSettings(settings);
            this.Close();
            //App form = Application.OpenForms["App"] as App;
            //form.updateStatus("testing");
            //MessageBox.Show("Settings updated!", "Jettison");
        }

        private void BtnCancelSettings_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
    }
}
