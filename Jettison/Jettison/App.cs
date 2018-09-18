using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JettisonClassLibrary;
using static System.Diagnostics.Debug;

namespace JettisonApp
{
    public partial class App : Form
    {
        private System.Threading.Thread monitor = new System.Threading.Thread(new System.Threading.ThreadStart(MonitorThread));
        DataHandler dh = DataHandler.GetInstance();
        ContextMenu contextMenu = new ContextMenu();
        private int btnVariant = 1;
        NotifyIcon trayIcon = new NotifyIcon();
        App thisForm;

        private static void MonitorThread()
        {
            JettisonBackground.CheckJettisons();
        }

        public App()
        {
            thisForm = this;
            InitializeComponent();
            this.Icon = Properties.Resources.jettison;
            UpdateList();
            JettisonBackground.trayIcon = trayIcon; 
            monitor.Start();

            // setup context menu
            MenuItem menuEdit = new MenuItem() { Text = "Edit" };
            MenuItem menuDelete = new MenuItem() { Text = "Delete" };
            menuEdit.Click += MenuEdit_Click;
            menuDelete.Click += MenuDelete_Click;
            contextMenu.MenuItems.Add(menuEdit);
            contextMenu.MenuItems.Add(menuDelete);

            // tray icon
            trayIcon.Icon = JettisonApp.Properties.Resources.jettison;
            trayIcon.Text = "Jettison";
            trayIcon.Visible = true;

            // tray menu
            trayIcon.ContextMenuStrip = new ContextMenuStrip();
            trayIcon.ContextMenuStrip.AutoClose = true;
            trayIcon.ContextMenuStrip.ItemClicked += TrayMenu_ItemClicked;
            trayIcon.ContextMenuStrip.Items.Add("Jettison").Font = new Font(Font, FontStyle.Bold);
            trayIcon.ContextMenuStrip.Items.Add("Exit");

            if (dh.ShowMainForm()) {
                this.Visible = true;
            }
        }

        private void TrayMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string clickedItem = e.ClickedItem.Text;
            if (clickedItem == "Jettison") {
                thisForm.Visible = true;
            } else if (clickedItem == "Exit") {
                ExitApp();
            }
        }

        private void MenuDelete_Click(object sender, EventArgs e)
        {
            if (lstMain.SelectedItems.Count > 0) {
                DialogResult result = MessageBox.Show("Are you sure you want to unregister this directory?", "Jettison", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes) {
                    Jettison jettison = dh.GetJettisonByDirectory(lstMain.SelectedItems[0].Text);
                    dh.RemoveDirectory(jettison);
                    UpdateList();
                }
            }
        }

        private void MenuEdit_Click(object sender, EventArgs e)
        {
            if (lstMain.SelectedItems.Count > 0) {
                Jettison jettison = dh.GetJettisonByDirectory(lstMain.SelectedItems[0].Text);
                if (Application.OpenForms["Register"] != null) {
                    Application.OpenForms["Register"].Close();
                }
                Register register = new Register();
                register.SelectedJettison = jettison;
                register.InitEditForm();
                register.Show();
            }
        }

        public void UpdateList()
        {
            DeleteList();
            List<Jettison> all = dh.GetAllJettisons();
            if (all != null) {
                foreach (var j in all) {
                    string[] row = { j.Directory, Jettison.GetLifeText(j) };
                    ListViewItem item = new ListViewItem(row);
                    lstMain.Items.Add(item);
                }
                lstMain.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                lstMain.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                lstMain.Sort();
            }
        }

        private void DeleteList()
        {
            lstMain.Items.Clear();
        }

        public void UpdateStatus(string message)
        {
            //lblStatus.Visible = true;
            //lblStatus.Text = message;
            WriteLine("before timer");
            var d = DateTime.Now; while (DateTime.Now.Subtract(d).TotalSeconds < 3) { }
            //System.Threading.Thread.Sleep(3000);
            WriteLine("after timer");
            //lblStatus.Visible = false;
        }

        public void ShowNotification(string message)
        {
            trayIcon.BalloonTipText = message;
            trayIcon.BalloonTipIcon = ToolTipIcon.Info;
            trayIcon.Visible = true;
            trayIcon.ShowBalloonTip(3000);
        }

        private void App_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dh.CloseToTray()) {
                e.Cancel = true;
                thisForm.Visible = false;
            } else {
                ExitApp();
            }
        }

        private void LstMain_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) {
                contextMenu.Show(lstMain, lstMain.PointToClient(Cursor.Position));
            }
        }

        private void BtnSettings_MouseDown(object sender, MouseEventArgs e)
        {
            btnSettings.Size = new Size(btnSettings.Size.Width - btnVariant, btnSettings.Size.Height - btnVariant);
        }

        private void BtnSettings_MouseUp(object sender, MouseEventArgs e)
        {
            btnSettings.Size = new Size(btnSettings.Size.Width + btnVariant, btnSettings.Size.Height + btnVariant);
        }

        private void BtnSettings_MouseEnter(object sender, EventArgs e)
        {
            btnSettings.BackgroundImage = Properties.Resources.settings_hover;
        }

        private void BtnSettings_MouseLeave(object sender, EventArgs e)
        {
            btnSettings.BackgroundImage = Properties.Resources.settings_normal;
        }

        private void BtnRegister_MouseDown(object sender, MouseEventArgs e)
        {
            btnRegister.Size = new Size(btnRegister.Size.Width - btnVariant, btnRegister.Size.Height - btnVariant);
        }

        private void BtnRegister_MouseUp(object sender, MouseEventArgs e)
        {
            btnRegister.Size = new Size(btnRegister.Size.Width + btnVariant, btnRegister.Size.Height + btnVariant);
        }

        private void BtnRegister_MouseEnter(object sender, EventArgs e)
        {
            btnRegister.BackgroundImage = Properties.Resources.add_hover;
        }

        private void BtnRegister_MouseLeave(object sender, EventArgs e)
        {
            btnRegister.BackgroundImage = Properties.Resources.add_normal;
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Settings"] == null) {
                Settings settings = new Settings();
                settings.Show();
            } else {
                Application.OpenForms["Settings"].BringToFront();
            }
        }

        private void BtnRegister_Click(object sender, System.EventArgs e)
        {
            if (Application.OpenForms["Register"] == null) {
                Register registerForm = new Register();
                registerForm.Show();
            } else {
                Application.OpenForms["Register"].BringToFront();
            }
        }

        private void ExitApp()
        {
            JettisonBackground.PowerOn = false;
            this.FormClosing -= App_FormClosing;
            trayIcon.Visible = false;
            Application.Exit();
        }
    }
}
