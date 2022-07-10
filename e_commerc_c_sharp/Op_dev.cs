using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace e_commerc_c_sharp
{
    public partial class Op_dev : Form
    {
        public Op_dev()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExcClientes frm = new ExcClientes();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Op_dev2 frm2 = new Op_dev2();
            frm2.Show();
        }
    }
}
