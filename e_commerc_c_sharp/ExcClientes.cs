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
    public partial class ExcClientes : Form
    {

        void CarregarGridPesquisa()
        {
            string sql;

            sql = "select id_usu, nome, email, exc from c_sharp_ecommerce_usuario";

            sql += " order by nome;";

            DataTable dt = ConexaoBanco.selecionarDataTable(sql);

            dtgPesquisa.DataSource = dt;
        }



        string stringConexao = "Server = 127.0.0.1;" +
        "Database = c_sharp; Port = 5433;" +
        "User ID = postgres; password = postgres; ";

        NpgsqlConnection cn = new NpgsqlConnection();

        public ExcClientes()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void ExcClientes_Load(object sender, EventArgs e)
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

            CarregarGridPesquisa();

        }

        private void dtgPesquisa_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int indice = dtgPesquisa.CurrentRow.Index;

            int id = Convert.ToInt32(dtgPesquisa[0, indice].Value.ToString());

            string sn = dtgPesquisa[3, indice].Value.ToString();

            if(sn=="s")
            {
                sn = "n";
            }
            else
            {
                sn = "s";
            }

            string sql;
            try
            {

                sql = "update c_sharp_ecommerce_usuario set exc=@sn where id_usu=@id;";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, cn);

                cmd.Parameters.AddWithValue("@sn", sn);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();


                MessageBox.Show("Usuário alterado com sucesso !! \n\n",
                "Cadastro de usuários",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

                CarregarGridPesquisa();

            }

            catch (NpgsqlException ex)
            {
                MessageBox.Show("Ocorreu um erro ao excluir o usuário !!! \n\n" +
                    "Mais detalhes: " + ex.Message,
                    "Inserção de usuários",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);


            }


        }

        private void ExcClientes_FormClosing(object sender, FormClosingEventArgs e)
        {
            cn.Dispose();
            cn.Close();
            cn = null;
        }
    }
}
