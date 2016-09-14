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
        public Form1()
        {
            InitializeComponent();
            DataHandler dh = new Utilities.DataHandler();
            WriteLine(dh.loadDataFile());
        }
    }
}
