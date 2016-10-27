using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using static System.Diagnostics.Debug;
using JettisonClassLibrary;

namespace JettisonApp
{
    public partial class Register : Form
    {
        DataHandler dh = DataHandler.getInstance();
        SaveFileDialog sfd = new SaveFileDialog();
        public Jettison selectedJettison { get; set; }

        public Register()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.jettison;

            // setup folder dialog
            sfd.FileOk += Sfd_FileOk;
            sfd.Title = "Select a folder";
        }

        public void initEditForm()
        {
            if (selectedJettison != null && !string.IsNullOrEmpty(selectedJettison.Id)) {
                populateFormControls();
                btnRegister.Text = "Update";
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            sfd.FileName = "Select a folder";
            sfd.ShowDialog();
        }

        private void Sfd_FileOk(object sender, CancelEventArgs e)
        {
            Regex regex = new Regex(@"^(.*[\\])");
            Match match = regex.Match(sfd.FileName);
            string registeredDirectory = match.Value.TrimEnd('\\');
            txtDirectory.Text = registeredDirectory;
        }

        private void rbCustom_CheckedChanged(object sender, EventArgs e)
        {
            setCustomLifeControls(rbCustom.Checked);
        }

        private void setCustomLifeControls(bool enable = true)
        {
            txtCustomLife.Enabled = enable;
            rbCustomLifeSeconds.Enabled = enable;
            rbCustomLifeMinutes.Enabled = enable;
            rbCustomLifeHours.Enabled = enable;

            if (!enable) {
                txtCustomLife.Text = string.Empty;
                rbCustomLifeSeconds.Checked = false;
                rbCustomLifeMinutes.Checked = false;
                rbCustomLifeHours.Checked = false;
            } else {
                txtCustomLife.Focus();
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (isFormValid()) {
                //Jettison jettison = Jettison.MakeMeAThing((string alert) => MessageBox.Show(alert));
                Jettison jettison = new Jettison();
                jettison.Id = dh.generateNewId();

                int maxLife = 0;
                int customLife = 0;
                int customLifeDuration = 0;

                if (rb24Hours.Checked) {
                    maxLife = 1;
                } else if (rb48Hours.Checked) {
                    maxLife = 2;
                } else if (rb72Hours.Checked) {
                    maxLife = 3;
                } else if (rbCustom.Checked) {
                    maxLife = 4;
                    customLife = Convert.ToInt32(txtCustomLife.Text);
                    if (rbCustomLifeSeconds.Checked) {
                        customLifeDuration = 1;
                    } else if (rbCustomLifeMinutes.Checked) {
                        customLifeDuration = 2;
                    } else if (rbCustomLifeHours.Checked) {
                        customLifeDuration = 3;
                    }
                }

                string message = "Directory registered successfully!";

                if (selectedJettison != null) {
                    jettison = selectedJettison;
                    message = "Updated successfully!";
                }

                jettison.Directory = txtDirectory.Text;
                jettison.MaxLife = maxLife;
                jettison.CustomLife = customLife;
                jettison.CustomLifeDuration = customLifeDuration;
                jettison.Recycle = cbxRecycleFiles.Checked;
                dh.registerDirectory(jettison);

                Form1 form = Application.OpenForms["Form1"] as Form1;
                form.updateList();
                MessageBox.Show(message, "Jettison");
                this.Close();
            }
        }

        private bool isFormValid()
        {
            string errorMsg = string.Empty;
            if (string.IsNullOrEmpty(txtDirectory.Text)) {
                errorMsg = "Please make sure you've properly selected a folder.";
            }

            if (!Directory.Exists(txtDirectory.Text)) {
                errorMsg = "Please check that your folder's path is valid.";
            }

            if (!rb24Hours.Checked && !rb48Hours.Checked && !rb72Hours.Checked && !rbCustom.Checked) {
                errorMsg = "Please select a duration for files to live in this folder.";
            }

            if (rbCustom.Checked) {
                if (string.IsNullOrEmpty(txtCustomLife.Text)) {
                    errorMsg = "Please provide a custom life duration value.";
                }

                if (!rbCustomLifeSeconds.Checked && !rbCustomLifeMinutes.Checked && !rbCustomLifeHours.Checked) {
                    errorMsg = "Please select a custom life unit of time.";
                }
            }

            if (string.IsNullOrWhiteSpace(errorMsg)) {
                lblError.Text = string.Empty;
                lblError.Visible = false;
                return true;
            }

            lblError.Text = errorMsg;
            lblError.Visible = true;
            return false;
        }

        private void populateFormControls()
        {
            txtDirectory.Text = selectedJettison.Directory;
            if (selectedJettison.MaxLife == 1) {
                rb24Hours.Checked = true;
            } else if (selectedJettison.MaxLife == 2) {
                rb48Hours.Checked = true;
            } else if (selectedJettison.MaxLife == 3) {
                rb72Hours.Checked = true;
            } else if (selectedJettison.MaxLife == 4) {
                rbCustom.Checked = true;
                txtCustomLife.Enabled = true;
                rbCustomLifeSeconds.Enabled = true;
                rbCustomLifeMinutes.Enabled = true;
                rbCustomLifeHours.Enabled = true;
                txtCustomLife.Text = selectedJettison.CustomLife.ToString();
                if (selectedJettison.CustomLifeDuration == 1) {
                    rbCustomLifeSeconds.Checked = true;
                } else if (selectedJettison.CustomLifeDuration == 2) {
                    rbCustomLifeMinutes.Checked = true;
                } else if (selectedJettison.CustomLifeDuration == 3) {
                    rbCustomLifeHours.Checked = true;
                }
            }
        }
    }
}
