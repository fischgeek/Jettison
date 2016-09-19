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
        DataHandler dh = DataHandler.getInstance();

        public Form1()
        {
            InitializeComponent();
            updateList();
            // temp
            Register registerForm = new Register();
            registerForm.Show(this);
        }

        public void updateList()
        {
            deleteList();
            List<Jettison> all = dh.getAllJettisons();
            foreach (var j in all) {
                string[] row = { j.Directory, j.MaxLife.ToString() };
                ListViewItem item = new ListViewItem(row);
                lstMain.Items.Add(item);
            }
            lstMain.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lstMain.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
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
            
        }
    }
}
