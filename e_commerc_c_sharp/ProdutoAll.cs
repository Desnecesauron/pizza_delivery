using Npgsql;
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
    public partial class ProdutoAll : Form
    {

        string stringConexao = "Server = 127.0.0.1;" +
                "Database = c_sharp; Port = 5433;" +
                "User ID = postgres; password = postgres; ";

        NpgsqlConnection cn = new NpgsqlConnection();

        void limpa_tela()
        {
            txtDesc.Text = null;
            txtId.Text = null;
            txtNome.Text = null;
            txtVal.Text = null;
            txtExc.Text = null;
        }

        public ProdutoAll(int op, int id_prod, string nome, string descr, string val, string exc)
        {
            InitializeComponent();
            if(op==1)
            {
                txtDesc.Enabled = false;
                txtId.Enabled = false;
                txtNome.Enabled = false;
                txtVal.Enabled = false;
                txtExc.Enabled = false;
                btnCan.Enabled = false;
                btnNovo.Enabled = true;
                btnSa.Enabled = true;
                btnSave.Enabled = false;
            }
            else
            {
                txtDesc.Enabled = true;
                txtId.Enabled = false;
                txtNome.Enabled = true;
                txtVal.Enabled = true;
                txtExc.Enabled = true;
                btnCan.Enabled = true;
                btnNovo.Enabled = false;
                btnSa.Enabled = true;
                btnSave.Enabled = true;

                txtId.Text = id_prod.ToString();
                txtNome.Text = nome;
                txtDesc.Text = descr;
                txtVal.Text = val;
                txtExc.Text = exc;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            limpa_tela();
            txtDesc.Enabled = false;
            txtId.Enabled = false;
            txtNome.Enabled = false;
            txtVal.Enabled = false;
            txtExc.Enabled = false;
            btnCan.Enabled = false;
            btnNovo.Enabled = true;
            btnSa.Enabled = true;
            btnSave.Enabled = false;
            btnNovo.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limpa_tela();

            txtDesc.Enabled = true;
            txtId.Enabled = false;
            txtNome.Enabled = true;
            txtVal.Enabled = true;
            txtExc.Enabled = true;
            btnCan.Enabled = true;
            btnNovo.Enabled = false;
            btnSa.Enabled = true;
            btnSave.Enabled = true;

            txtNome.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 'n' || e.KeyChar == 's' || e.KeyChar == '\b')
                e.Handled = false;
            else
                e.Handled = true;
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtNome.Text) || String.IsNullOrEmpty(txtDesc.Text) || String.IsNullOrEmpty(txtVal.Text) || String.IsNullOrEmpty(txtExc.Text))
                {
                    MessageBox.Show("Deve ser informado todos os campos para cadastro de produto !! \n\n",
                    "Cadastro de produtos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                    txtNome.Focus();
                    return;
                }

                string sql;

                if(txtId.Text=="")
                {
                    sql = "insert into c_sharp_ecommerce_produto (nome, descr, val, exc) values (@nome, @descr, @val, @exc)";

                    NpgsqlCommand cmd = new NpgsqlCommand(sql, cn);

                    cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                    cmd.Parameters.AddWithValue("@descr", txtDesc.Text);
                    cmd.Parameters.AddWithValue("@val", txtVal.Text);
                    cmd.Parameters.AddWithValue("@exc", txtExc.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Produto salvo com sucesso !! \n\n",
                    "Cadastro de produtos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                }
                else
                {
                    sql = "update c_sharp_ecommerce_produto set nome=@nome, descr=@descr, val=@val, exc=@exc  where id_prod=@id";

                    NpgsqlCommand cmd = new NpgsqlCommand(sql, cn);

                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtId.Text));
                    cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                    cmd.Parameters.AddWithValue("@descr", txtDesc.Text);
                    cmd.Parameters.AddWithValue("@val", txtVal.Text);
                    cmd.Parameters.AddWithValue("@exc", txtExc.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Produto alterado com sucesso !! \n\n",
                    "Cadastro de produtos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                }


            }
            catch (Exception ex)
            {

                MessageBox.Show("Ocorreu um erro ao salvar os dados do produto !!! \n\n" +
                    "Mais detalhes: " + ex.Message,
                    "Salvamento de produtos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

            }
            finally
            {
                limpa_tela();
                txtDesc.Enabled = false;
                txtId.Enabled = false;
                txtNome.Enabled = false;
                txtVal.Enabled = false;
                txtExc.Enabled = false;
                btnCan.Enabled = false;
                btnNovo.Enabled = true;
                btnSa.Enabled = true;
                btnSave.Enabled = false;
                btnNovo.Focus();
            }
        }

        private void ProdutoAll_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (txtDesc.Text == "" && txtExc.Text == "" && txtId.Text=="" && txtNome.Text=="")
            {
                cn.Dispose();
                cn.Close();
                cn = null;
            }
            else
            {
                DialogResult resposta;
                resposta = MessageBox.Show("Deseja realmente sair? \n\n",
                "Sair",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

                if (resposta == DialogResult.Yes)
                {
                    cn.Dispose();
                    cn.Close();
                    cn = null;
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void ProdutoAll_Load(object sender, EventArgs e)
        {
            try
            {
                cn.ConnectionString = stringConexao;
                cn.Open();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show("Problemas ao conectar com o banco de dados! \n\n" +
                    "Mais detalhes: " + ex.Message,
                    "Cadastro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                this.Close();
            }
        }
    }
}
