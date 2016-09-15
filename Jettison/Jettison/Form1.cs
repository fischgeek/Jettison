using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jettison.Utilities;
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
                string[] row = {j.Directory, j.MaxLife.ToString()};
                ListViewItem item = new ListViewItem(row);
                lstMain.Items.Add(item);
            }

            Register registerForm = new Register();
            registerForm.Show();
        }

        private void btnRegister_Click(object sender, System.EventArgs e)
        {
            Register registerForm = new Register();
            registerForm.Show();
        }
    }
}
