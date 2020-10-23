using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jira.GetLinkCustomerSatisfaction.PayLoads;
using System.Configuration;
using System.Net;
using System.IO;
using System.Data.SqlServerCe;
using RestSharp.Authenticators;
using System.Data.OleDb;

namespace Jira.GetLinkCustomerSatisfaction
{
    public partial class Form1 : Form
    {
        string nomeArquivoBD = $"{System.AppDomain.CurrentDomain.BaseDirectory.ToString()}db.sdf";
        string connectionString = string.Format("DataSource=\"{0}\"; Password='{1}'", System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "db.sdf", "");
        string idUsuario = string.Empty;
        string senha = string.Empty;


        public Form1()
        {
            InitializeComponent();
        }

        private void btnResgateLink_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder validacoes = Validacoes();

                if (validacoes.Length > 0)
                {
                    MessageBox.Show(validacoes.ToString(), "VALIDAÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {



                    if (chkLembrar.Checked)
                    {
                        SalvarUsuarioSenha();
                        AtualizarUsuarioSenha();
                    }


                    txtLink.Text = ResgatarLink(txtUsuario.Text, txtSenha.Text, txtChamado.Text);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ferramenta apresentou erro {ex.Message}", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private StringBuilder Validacoes()
        {
            StringBuilder mensagens = new StringBuilder();

            if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                mensagens.AppendLine("O Campo Usuário é obrigatório ");
            }
            if (string.IsNullOrEmpty(txtSenha.Text))
            {
                mensagens.AppendLine("O Campo Senha é obrigatório ");
            }
            if (string.IsNullOrEmpty(txtChamado.Text))
            {
                mensagens.AppendLine("O Campo Chamado é obrigatório ");
            }

            return mensagens;
        }

        private string ResgatarLink(string usuario, string senha, string chamado)
        {
   
            string usuarioRede = usuario;
            string senhaRede = senha;
            string configuracaoProxy = ConfigurationManager.AppSettings["proxy"];
            var proxy = new WebProxy(configuracaoProxy, 8080);
            proxy.Credentials = new NetworkCredential(usuarioRede, senhaRede);
            WebRequest.DefaultWebProxy = proxy;

            string urlJira = ConfigurationManager.AppSettings["urljira"];

            var client = new RestClient($"{urlJira}/rest/api/2/issue/{chamado}/properties/feedback.token.key");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            //request.AddHeader("Authorization", "Basic YWxkaWFzOkRvY2tlckAyMDIx");
            request.AddHeader("Cookie", "JSESSIONID=C3C9AC36EA657FE9D9315C65E4B72B61; atlassian.xsrf.token=B7EA-A5BX-0F0X-ZSGY_fa1828ecd4952d5139da6653b4d494df41a70b31_lin");
            request.AddParameter("text/plain", "", ParameterType.RequestBody);
            client.Authenticator = new HttpBasicAuthenticator(usuarioRede, senhaRede);

            try
            {
                IRestResponse response = client.Execute(request);

                ReturnFeedbackTokenKey returnFeedbackTokenKey = Newtonsoft.Json.JsonConvert.DeserializeObject<ReturnFeedbackTokenKey>(response.Content);

                return $"{urlJira}/servicedesk/customer/portal/2/{chamado}/feedback?token={returnFeedbackTokenKey.value.token}";

            }
            catch (Exception ex)
            {
                return "SEM LINK DISPONIVEL";
                //throw;
            }


        }

        private void SalvarUsuarioSenha()
        {

            if (!File.Exists(nomeArquivoBD))
            {
                SqlCeEngine SqlEng = new SqlCeEngine(connectionString);
                SqlEng.CreateDatabase();

                SqlCeConnection cn = new SqlCeConnection(connectionString);
                //verifica se a conexão esta fechada e abre a conexão
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }

                SqlCeCommand cmd;

                string sql = "create table Login("
                                      + "IdUsuario nvarchar (14) not null, "
                                      + "Senha nvarchar (20))";

                cmd = new SqlCeCommand(sql, cn);

                cmd.ExecuteNonQuery();

                sql = $"INSERT INTO Login(IdUsuario, Senha) values('{txtUsuario.Text}','{txtSenha.Text}')";

                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }

                cmd = new SqlCeCommand(sql, cn);

                cmd.ExecuteNonQuery();


            }

        }

        private void AtualizarUsuarioSenha()
        {
            string sql;

            if (txtSenha.Text != senha || txtUsuario.Text != idUsuario)
            {
                sql = $"UPDATE Login set idUsuario = '{txtUsuario.Text}', senha = '{txtSenha.Text}'";

                SqlCeConnection cn = new SqlCeConnection(connectionString);
                //verifica se a conexão esta fechada e abre a conexão
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }

                SqlCeCommand cmd;

                cmd = new SqlCeCommand(sql, cn);

                cmd.ExecuteNonQuery();

                idUsuario = txtUsuario.Text;
                senha = txtSenha.Text;
            }
        }
        private void CarregaUsuarioSenha()
        {
            try
            {
                if (File.Exists(nomeArquivoBD))
                {
                    SqlCeConnection cn = new SqlCeConnection(connectionString);

                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }

                    SqlCeCommand cmd = new SqlCeCommand("Login", cn);
                    cmd.CommandType = CommandType.TableDirect;

                    // Pega a tabela
                    SqlCeDataReader reader = cmd.ExecuteReader();

                    DataTable dt = new DataTable();

                    dt.Load(reader);

                    idUsuario = dt.Rows[0][0].ToString();
                    senha = dt.Rows[0][1].ToString();

                    txtUsuario.Text = idUsuario;
                    txtSenha.Text = senha;
                    chkLembrar.Checked = true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Processo apresentou erro {ex.Message}", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CarregaUsuarioSenha();
        }

        private void btnProcessarPlanilha_Click(object sender, EventArgs e)
        {
            try
            {
                VisibleBotoesFalse();  
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    AtualizarPlanilhaComLink(openFileDialog1.FileName, txtUsuario.Text, txtSenha.Text);
                }

                MessageBox.Show("Processamento concluido com sucesso", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                VisibleBotoesTrue();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Processo apresentou o seguinte erro {ex.Message}", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void VisibleBotoesFalse()
        {
            btnProcessarPlanilha.Visible = false;
            btnResgateLink.Visible = false;
            progressBar1.Visible = true;
            lblProcessando.Visible = true;
        }

        private void VisibleBotoesTrue()
        {
            btnProcessarPlanilha.Visible = true;
            btnResgateLink.Visible = true;
            progressBar1.Visible = false;
            lblProcessando.Visible = false;
        }

        private void AtualizarPlanilhaComLink(string arquivo,string usuario, string senha)
        {
            OleDbConnection _olecon;
            OleDbCommand _oleCmd;
            OleDbCommand _oleUpdate;
            string _Arquivo = arquivo;//@"C:\Ticket\WORKLOG.xlsx";
            String _Consulta;

            String _StringConexao = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={_Arquivo};Extended Properties='Excel 12.0 Xml;HDR=YES;ReadOnly=False';";

            string usuarioRede = usuario;
            string senhaRede = senha;
            string configuracaoProxy = ConfigurationManager.AppSettings["proxy"];
            var proxy = new WebProxy(configuracaoProxy, 8080);
            proxy.Credentials = new NetworkCredential(usuarioRede, senhaRede);
            WebRequest.DefaultWebProxy = proxy;


            _olecon = new OleDbConnection(_StringConexao);
            _olecon.Open();

            _oleCmd = new OleDbCommand();
            _oleCmd.Connection = _olecon;
            _oleCmd.CommandType = System.Data.CommandType.Text;

            _oleCmd.CommandText = "SELECT Chave, Link  FROM[PESQUISA$]";
            OleDbDataReader reader = _oleCmd.ExecuteReader();

            _oleUpdate = new OleDbCommand();
            _oleUpdate.Connection = _olecon;
            _oleUpdate.CommandType = System.Data.CommandType.Text;

            DataTable dt = new DataTable();
            dt.Load(reader);


            progressBar1.Maximum = dt.Rows.Count;
            progressBar1.Value = 0;

            foreach (DataRow linha in dt.Rows)
            {
                progressBar1.Value = progressBar1.Value + 1;

                string link = ResgatarLink(usuario, senha, linha["Chave"].ToString());

                _Consulta = "UPDATE [PESQUISA$] ";
                _Consulta += $"SET Link = '{link}' ";
                _Consulta += $"WHERE Chave = '{linha["Chave"].ToString()}'";
      
                _oleUpdate.CommandText = _Consulta;
                _oleUpdate.ExecuteNonQuery();


            }

            reader.Close();
            _olecon.Close();
            _olecon.Dispose();

        }
    }
}
