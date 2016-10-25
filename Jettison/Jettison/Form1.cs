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
    public partial class Form1 : Form
    {
        private System.Threading.Thread monitor = new System.Threading.Thread(new System.Threading.ThreadStart(MonitorThread));
        DataHandler dh = DataHandler.getInstance();
        ContextMenu contextMenu = new ContextMenu();
        private int btnVariant = 1;
        NotifyIcon trayIcon = new NotifyIcon();
        Form1 thisForm;

        private static void MonitorThread()
        {
            JettisonBackground.checkJettisons();
        }

        public Form1()
        {
            thisForm = this;
            InitializeComponent();
            updateList();
            monitor.Start();
            WriteLine(this.WindowState.ToString());

            // setup context menu
            MenuItem menuEdit = new MenuItem() { Text = "Edit" };
            MenuItem menuDelete = new MenuItem() { Text = "Delete" };
            menuEdit.Click += MenuEdit_Click;
            menuDelete.Click += MenuDelete_Click;
            contextMenu.MenuItems.Add(menuEdit);
            contextMenu.MenuItems.Add(menuDelete);

            // tray icon
            trayIcon.Icon = JettisonApp.Properties.Resources.jettison_32;
            trayIcon.Text = "Jettison";
            trayIcon.Visible = true;

            // tray menu
            trayIcon.ContextMenuStrip = new ContextMenuStrip();
            trayIcon.ContextMenuStrip.AutoClose = true;
            trayIcon.ContextMenuStrip.ItemClicked += TrayMenu_ItemClicked;
            trayIcon.ContextMenuStrip.Items.Add("Jettison").Font = new Font(Font, FontStyle.Bold);
            trayIcon.ContextMenuStrip.Items.Add("Exit");

            if (dh.showMainForm()) {
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
                    Jettison jettison = dh.getJettisonByDirectory(lstMain.SelectedItems[0].Text);
                    dh.removeDirectory(jettison);
                    updateList();
                }
            }
        }

        private void MenuEdit_Click(object sender, EventArgs e)
        {
            if (lstMain.SelectedItems.Count > 0) {
                Jettison jettison = dh.getJettisonByDirectory(lstMain.SelectedItems[0].Text);
                Register register = new Register();
                register.selectedJettison = jettison;
                register.initEditForm();
                register.Show();
            }
        }

        public void updateList()
        {
            deleteList();
            List<Jettison> all = dh.getAllJettisons();
            if (all != null) {
                foreach (var j in all) {
                    string[] row = { j.Directory, Jettison.getLifeText(j) };
                    ListViewItem item = new ListViewItem(row);
                    lstMain.Items.Add(item);
                }
                lstMain.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                lstMain.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                lstMain.Sort();
            }
        }

        private void deleteList()
        {
            lstMain.Items.Clear();
        }

        public void updateStatus(string message)
        {
            lblStatus.Visible = true;
            lblStatus.Text = message;
            WriteLine("before timer");
            var d = DateTime.Now; while (DateTime.Now.Subtract(d).TotalSeconds < 3) { }
            //System.Threading.Thread.Sleep(3000);
            WriteLine("after timer");
            lblStatus.Visible = false;
        }

        public void showNotification(string message)
        {
            trayIcon.BalloonTipText = message;
            trayIcon.BalloonTipIcon = ToolTipIcon.Info;
            trayIcon.Visible = true;
            trayIcon.ShowBalloonTip(3000);
        }

        private void btnRegister_Click(object sender, System.EventArgs e)
        {
            Register registerForm = new Register();
            registerForm.Show(this);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dh.closeToTray()) {
                e.Cancel = true;
                thisForm.Visible = false;
            } else {
                ExitApp();
            }
        }

        private void lstMain_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) {
                contextMenu.Show(lstMain, lstMain.PointToClient(Cursor.Position));
            }
        }

        private void btnSettings_MouseDown(object sender, MouseEventArgs e)
        {
            btnSettings.Size = new Size(btnSettings.Size.Width - btnVariant, btnSettings.Size.Height - btnVariant);
        }

        private void btnSettings_MouseUp(object sender, MouseEventArgs e)
        {
            btnSettings.Size = new Size(btnSettings.Size.Width + btnVariant, btnSettings.Size.Height + btnVariant);
        }

        private void btnSettings_MouseEnter(object sender, EventArgs e)
        {
            btnSettings.BackgroundImage = Properties.Resources.settings_hover;
        }

        private void btnSettings_MouseLeave(object sender, EventArgs e)
        {
            btnSettings.BackgroundImage = Properties.Resources.settings_normal;
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.Show();
        }

        private void ExitApp()
        {
            JettisonBackground.PowerOn = false;
            this.FormClosing -= Form1_FormClosing;
            trayIcon.Visible = false;
            Application.Exit();
        }
    }
}
