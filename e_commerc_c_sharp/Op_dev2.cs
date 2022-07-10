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
    public partial class Op_dev2 : Form
    {

        void CarregarGridPesquisa()
        {
            string sql;

            sql = "select id_prod, nome, descr, val, exc from c_sharp_ecommerce_produto";

            sql += " order by nome;";

            DataTable dt = ConexaoBanco.selecionarDataTable(sql);

            dtgPesquisa.DataSource = dt;
        }

        void CarregarGridPesquisaa(string wheree)
        {
            string sql;

            sql = "select id_prod, nome, descr, val, exc from c_sharp_ecommerce_produto";

            sql += wheree;

            sql += " order by nome;";

            DataTable dt = ConexaoBanco.selecionarDataTable(sql);

            dtgPesquisa.DataSource = dt;
        }


        public Op_dev2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProdutoAll frm2 = new ProdutoAll(1, 0, null, null, null, null);
            frm2.Show();
        }

        private void btnPesq_Click(object sender, EventArgs e)
        {
            string wheree = "";

            if(!String.IsNullOrEmpty(txtNome.Text))
            {
                wheree = " where upper(nome) like '" + txtNome.Text.ToUpper() + "%'";
            }
            if(!String.IsNullOrEmpty(txtId.Text))
            {
                wheree = " where id_prod = " + txtId.Text;
            }

            CarregarGridPesquisaa(wheree);

            
        }

        private void Op_dev2_Load(object sender, EventArgs e)
        {
            CarregarGridPesquisa();
        }

        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtNome.Text = "";

            if (char.IsNumber(e.KeyChar) || e.KeyChar=='\b')
                e.Handled = false;
            else
                e.Handled = true;

        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtId.Text = "";

            if (!char.IsNumber(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;

        }

        private void dtgPesquisa_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id_prod, ind;
            string nome, descr, val, exc;

            ind = dtgPesquisa.CurrentRow.Index;

            id_prod = Convert.ToInt32(dtgPesquisa[0, ind].Value.ToString());
            nome = dtgPesquisa[1, ind].Value.ToString();
            descr = dtgPesquisa[2, ind].Value.ToString();
            val = dtgPesquisa[3, ind].Value.ToString();
            exc = dtgPesquisa[4, ind].Value.ToString();

            ProdutoAll frm2 = new ProdutoAll(2, id_prod, nome, descr, val, exc);
            frm2.Show();
        }

        private void txtAtualizar_Click(object sender, EventArgs e)
        {
            CarregarGridPesquisa();
        }
    }
}
