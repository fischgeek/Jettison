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

        private static void MonitorThread()
        {
            Jettison.checkJettisons();
        }

        public Form1()
        {
            InitializeComponent();
            updateList();
            monitor.Start();

            WriteLine(Environment.GetEnvironmentVariable("AppData"));

            // setup context menu
            MenuItem menuEdit = new MenuItem() { Text = "Edit" };
            MenuItem menuDelete = new MenuItem() { Text = "Delete" };
            menuEdit.Click += MenuEdit_Click;
            menuDelete.Click += MenuDelete_Click;
            contextMenu.MenuItems.Add(menuEdit);
            contextMenu.MenuItems.Add(menuDelete);
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
            foreach (var j in all) {
                string[] row = { j.Directory, Jettison.getLifeText(j) };
                ListViewItem item = new ListViewItem(row);
                lstMain.Items.Add(item);
            }
            lstMain.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lstMain.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            lstMain.Sort();
        }

        private void deleteList()
        {
            lstMain.Items.Clear();
        }

        private void btnRegister_Click(object sender, System.EventArgs e)
        {
            Register registerForm = new Register();
            registerForm.Show(this);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            monitor.Abort();
        }

        private void lstMain_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) {
                contextMenu.Show(lstMain, lstMain.PointToClient(Cursor.Position));
            }
        }
    }
}
