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

namespace Jettison
{
    public partial class Form1 : Form
    {
        DataHandler dh = DataHandler.getInstance();

        public Form1()
        {
            InitializeComponent();
            List<Jettison> all = dh.getAllJettisons();
            foreach(var j in all) {
                addToList(j);
            }
            Register registerForm = new Register();
            registerForm.Show();
        }

        private void btnRegister_Click(object sender, System.EventArgs e)
        {
            Register registerForm = new Register();
            registerForm.Show(this);
        }

        public void addToList(Jettison jettison)
        {
            string[] row = { jettison.Directory, jettison.MaxLife.ToString() };
            ListViewItem item = new ListViewItem(row);
            lstMain.Items.Add(item);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
