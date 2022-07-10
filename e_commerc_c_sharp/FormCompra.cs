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
    public partial class FormCompra : Form
    {
        string name, usuario;

        double val;

        public FormCompra(string nome, string valo, string usu)
        {
            InitializeComponent();

            name = nome;
            val = Convert.ToDouble(valo);

            lblPizza.Text = name;

            usuario = usu;

        }

        private void btnFecha_Click(object sender, EventArgs e)
        {
            string valf;

            valf = Convert.ToString(val * Convert.ToDouble(quantPizza.Value));


            this.Close();
            MessageBox.Show("Compra realizada com sucesso!\n" + "Detalhes" +
                " da compra:\n" + quantPizza.Value + " pizza(s) de " +
                name + "\n" + "Valor total: " + valf + "\nComprador: " + usuario,
                "Compra(s) de pizza de " + name,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}
