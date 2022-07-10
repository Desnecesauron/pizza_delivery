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
    public partial class Vendas : Form
    {
        string usu;

        public Vendas(string usua)
        {
            InitializeComponent();

            usu = usua;

            lblNome.Text = usu + "!";

        }

        void CarregarGridPesquisa()
        {
            string sql;

            sql = "select id_prod, nome, descr, val from c_sharp_ecommerce_produto where exc='n'";

            sql += " order by nome;";

            DataTable dt = ConexaoBanco.selecionarDataTable(sql);

            dtgPesquisa.DataSource = dt;
        }

        private void Vendas_Load(object sender, EventArgs e)
        {
            CarregarGridPesquisa();
        }

        private void dtgPesquisa_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id_prod, ind;
            string nome, descr, val;

            ind = dtgPesquisa.CurrentRow.Index;

            id_prod = Convert.ToInt32(dtgPesquisa[0, ind].Value.ToString());
            nome = dtgPesquisa[1, ind].Value.ToString();
            descr = dtgPesquisa[2, ind].Value.ToString();
            val = dtgPesquisa[3, ind].Value.ToString();

            FormCompra frm2 = new FormCompra(nome, val, usu);
            frm2.Show();
        }
    }
}
