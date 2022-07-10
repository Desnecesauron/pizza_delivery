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
    public partial class Cadastro : Form
    {

        string stringConexao = "Server = 127.0.0.1;" +
                "Database = c_sharp; Port = 5433;" +
                "User ID = postgres; password = postgres; ";

        NpgsqlConnection cn = new NpgsqlConnection();


        void limpa_tela()
        {
            txtCpf.Text = null;
            txtEmail.Text = null;
            txtNome.Text = null;
            txtSenha.Text = null;
            txtNome.Focus();
        }

        public Cadastro()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cpf = txtCpf.Text;
            if(txtCpf.Text== "   .   .   -")
            {
                cpf = "";
            }

            try
            {
                string sql;
                if (String.IsNullOrEmpty(txtNome.Text) || String.IsNullOrEmpty(txtSenha.Text))
                {
                    MessageBox.Show("Deve ser informado o nome \ne senha para cadastro de usuário !!! \n\n",
                    "Cadastro de usuários",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                    txtNome.Focus();
                    return;
                }
                //sql = "insert into fabricante (nome) values (@nome)";
                //sql = "insert into c_sharp_ecommerce_usuario (nome, senha, cpf, datan) values (@nome, @senha, @cpf, @datan)";
                //sql = "insert into c_sharp_ecommerce_usuario (nome, senha, cpf, datan, exc) values (@nome, @senha, @cpf, '2003-06-26', 'n')";
                sql = "insert into c_sharp_ecommerce_usuario (nome, senha, cpf, email, exc) values (@nome, @senha, @cpf, @email, 'n')";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, cn);

                //string dataa = string.Format('dd/MM/aaaa', txtDatan.Text);

                cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                cmd.Parameters.AddWithValue("@senha", txtSenha.Text);
                cmd.Parameters.AddWithValue("@cpf", cpf);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);

                cmd.ExecuteNonQuery();

                limpa_tela();

                MessageBox.Show("Usuário salvo com sucesso !! \n\n",
                "Cadastro de usuários",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao salvar os dados do usuário !!! \n\n" +
                    "Mais detalhes: " + ex.Message,
                    "Inserção de usuários",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);


            }
        }

        private void Cadastro_Load(object sender, EventArgs e)
        {

            try
            {
                cn.ConnectionString = stringConexao;
                cn.Open();
            }
            catch(NpgsqlException ex)
            {
                MessageBox.Show("Problemas ao conectar com o banco de dados! \n\n" +
                    "Mais detalhes: " + ex.Message,
                    "Cadastro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                this.Close();
            }
            
        }

        private void Cadastro_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(txtNome.Text=="" && txtSenha.Text=="" && txtCpf.Text== "   .   .   -" && txtEmail.Text == "")
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (txtSenha.UseSystemPasswordChar == true)
            {
                txtSenha.UseSystemPasswordChar = false;
            }
            else
            {
                txtSenha.UseSystemPasswordChar = true;
            }
        }
    }
}

/*

            string stringConexao = "Server = 200.145.153.175;" +
                        "Database = cliente; Port = 5432;" +
                        "User ID = c04cesargomes; password = Nuncanemvi#10;";



*/
