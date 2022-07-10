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
    public partial class Login : Form
    {
        string stringConexao = "Server = 127.0.0.1; " +
                "Database = c_sharp; Port = 5433; " +
                "User ID = postgres; password = postgres ";

        NpgsqlConnection cn = new NpgsqlConnection();


        void limpa_tela()
        {
            txtSen.Text = null;
            txtUsu.Text = null;
            txtUsu.Focus();
        }
        void limpa_telaa()
        {
            txtSen.Text = null;
            txtUsu.Text = null;
        }

        public Login()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Cadastro frm = new Cadastro();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtUsu.Text))
            {
                MessageBox.Show("Deve ser informado o nome \nde login do usuário !!! \n\n",
                "Login de usuários",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                txtUsu.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txtSen.Text))
            {
                MessageBox.Show("Deve ser informado a senha \nde login do usuário !!! \n\n",
                "Login de usuários",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                txtUsu.Focus();
                return;
            }
            try
            {
                string sql;

                sql = "select * from c_sharp_ecommerce_usuario where nome = @id";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@id", txtUsu.Text);
                NpgsqlDataReader dr = cmd.ExecuteReader();

                string confirmasenha;
                string excluido;
                string excluidop = "n";

                if (txtUsu.Text == "adm" && txtSen.Text == "adm123")
                {
                    MessageBox.Show("Bem-vindo, ADM!\n",
                        "Confirmação de cadastro",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    limpa_tela();

                    Op_dev frm1 = new Op_dev();
                    frm1.Show();
                }

                else if (dr.Read())
                {
                    //txtUsu.Text = (string)dr["nome"];
                    confirmasenha = (string)dr["senha"];
                    excluido = (string)dr["exc"];
                    if(confirmasenha == txtSen.Text && excluidop==excluido)
                    {
                        MessageBox.Show("Cadastro confirmado, bem-vindo!\n",
                            "Confirmação de cadastro",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        Vendas frm = new Vendas(txtUsu.Text);
                        frm.Show();

                        limpa_telaa();

                    }
                    else
                    {
                        MessageBox.Show("Senha e/ou usuário incorretos!\n",
                            "Confirmação de cadastro",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
                    }
                }
                else
                {

                    MessageBox.Show("Cadastro não encontrado ou possivelmente excluído !!! \n\n",
                        "Pesquisa de cadastros",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                        
                }
                dr.Close();



            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao pesquisar os dados do usuário !!! \n\n" +
                    "Mais detalhes: " + ex.Message,
                    "Login de usuários",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                
            }
        }


        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            if(txtSen.Text=="" && txtUsu.Text=="")
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
            if(txtSen.UseSystemPasswordChar == true)
            {
                txtSen.UseSystemPasswordChar = false;
            }
            else
            {
                txtSen.UseSystemPasswordChar = true;
            }
        }

        private void Login_Load(object sender, EventArgs e)
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

        private void txtSen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.Focus();
            }
        }

        private void txtUsu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSen.Focus();
            }
        }
    }
}
