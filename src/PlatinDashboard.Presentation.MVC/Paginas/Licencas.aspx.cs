using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PlatinDashboard.Presentation.MVC
{
    public partial class Licencas : System.Web.UI.Page
    {
        private DataTable GetData()
        {

            DataTable dt = new DataTable();
            string conexao5 = ConfigurationManager.ConnectionStrings["PortalConnection"].ConnectionString;
            SqlConnection Conn5 = new SqlConnection(conexao5);
            try
            {
                Conn5.Open();
                SqlCommand Cmd5 = new SqlCommand("SELECT C.RazaoSocial, LC.*, G.*  FROM [Clientes] as C, [Legis_Cliente] as LC,[LegisGeral] as G " +
                " where LC.IDCliente=C.N_CLIENTE and " +
                " LC.IDLegisGeral=G.Id and " +
                " LC.IDCliente = @IdCliente", Conn5);
                Cmd5.Parameters.AddWithValue("@IdCliente", Session["IdCli"].ToString());
                SqlDataAdapter Sqlda = new SqlDataAdapter(Cmd5);
                Sqlda.Fill(dt);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

                string msg = "ERRO:";
                msg += ex.Message;

            }
            finally
            {
                Conn5.Close();
            }
            return dt;
        }
        private DataTable GetCliente()
        {

            DataTable dt = new DataTable();
            string conexao5 = ConfigurationManager.ConnectionStrings["PortalConnection"].ConnectionString;
            SqlConnection Conn5 = new SqlConnection(conexao5);
            try
            {
                Conn5.Open();
                SqlCommand Cmd5 = new SqlCommand("SELECT *  FROM [Clientes] " +
                " where N_CLIENTE = @IdCliente", Conn5);
                Cmd5.Parameters.AddWithValue("@IdCliente", Session["IdCli"].ToString());
                SqlDataAdapter Sqlda = new SqlDataAdapter(Cmd5);
                Sqlda.Fill(dt);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

                string msg = "ERRO:";
                msg += ex.Message;

            }
            finally
            {
                Conn5.Close();
            }
            return dt;
        }
        private DataTable GetLicenca(string cliente)
        {

            DataTable dt = new DataTable();
            string conexao5 = ConfigurationManager.ConnectionStrings["PortalConnection"].ConnectionString;
            SqlConnection Conn5 = new SqlConnection(conexao5);
            try
            {
                Conn5.Open();
                SqlCommand Cmd5 = new SqlCommand("SELECT *  FROM [Licencas] " +
                " where IDCliente = @IdCliente", Conn5);
                Cmd5.Parameters.AddWithValue("@IdCliente", cliente);
                SqlDataAdapter Sqlda = new SqlDataAdapter(Cmd5);
                Sqlda.Fill(dt);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

                string msg = "ERRO:";
                msg += ex.Message;

            }
            finally
            {
                Conn5.Close();
            }
            return dt;
        }
        private DataTable GetLicencaAdm()
        {

            DataTable dt = new DataTable();
            string conexao5 = ConfigurationManager.ConnectionStrings["PortalConnection"].ConnectionString;
            SqlConnection Conn5 = new SqlConnection(conexao5);
            try
            {
                Conn5.Open();
                SqlCommand Cmd5 = new SqlCommand("SELECT *  FROM [Licencas]", Conn5);
      //          Cmd5.Parameters.AddWithValue("@IdCliente", cliente);
                SqlDataAdapter Sqlda = new SqlDataAdapter(Cmd5);
                Sqlda.Fill(dt);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

                string msg = "ERRO:";
                msg += ex.Message;

            }
            finally
            {
                Conn5.Close();
            }
            return dt;
        }
        public bool GravaOperacaoUsuario(string Nome, string Login, string Tela, string Operacao, string Conteudo)
        {
            bool gravado = false;
            string connection = ConfigurationManager.ConnectionStrings["PortalConnection"].ConnectionString;
            SqlConnection Conn = new SqlConnection(connection);
            Conn.Open();
            try
            {
                string Hora = Convert.ToString(DateTime.Now.TimeOfDay).Substring(0, 8);
                SqlCommand Cmd = new SqlCommand("insert acessoslog(data,hora,usuario,login,tela,operacao,conteudo) " +
                      " values(@v1,@v2,@v3,@v4,@v5,@v6,@v7) ", Conn);
                Cmd.Parameters.AddWithValue("@v1", DateTime.Now.Date);
                Cmd.Parameters.AddWithValue("@v2", Hora);
                Cmd.Parameters.AddWithValue("@v3", Nome);
                Cmd.Parameters.AddWithValue("@v4", Login);
                Cmd.Parameters.AddWithValue("@v5", Tela);
                Cmd.Parameters.AddWithValue("@v6", Operacao);
                Cmd.Parameters.AddWithValue("@v7", Conteudo);
                Cmd.ExecuteNonQuery();
                Conn.Close();
                gravado = true;
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return gravado;

        }
        public bool PermitirFuncao(string CodPagina, string CodUsuario, string CodFuncao)
        {
            bool permitir = false;
            DataTable dtA = new DataTable();
            string conexao5 = ConfigurationManager.ConnectionStrings["PortalConnection"].ConnectionString;
            SqlConnection Conn5 = new SqlConnection(conexao5);
            try
            {
                Conn5.Open();
                SqlCommand Cmd5 = new SqlCommand("select ua.IdUsuario,ua.IDPagina, ua.Cod_Atribuicao, up.Codigo " +
                  " from usuarios_atribuicoes ua , usuarios_paginas up, acessos ac " +
                  " where ua.IDUsuario = ac.Id and " +
                  " ua.IDPagina = up.id and " +
                  " up.Codigo = '" + CodPagina + "' and " +
                  " up.IdUsuario = '" + CodUsuario + "' and " +
                  " ua.Cod_Atribuicao = '" + CodFuncao + "' and ua.Ativo = 1 ", Conn5);
                SqlDataAdapter Sqlda = new SqlDataAdapter(Cmd5);
                Sqlda.Fill(dtA);
                if (dtA.Rows.Count > 0)
                {
                    permitir = true;
                }
                else
                {
                    permitir = false;
                }
                Conn5.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return permitir;

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string usuario =  Session["IdUser"].ToString();
                string nivel =  Session["Nivel"].ToString();
      //          Session["IDCliente"] = Session["IdCli"].ToString();
                string cliente = Session["IDCliente"].ToString();
                Session["NomeUserCli"] =  Session["Nome"].ToString();
                Session["IdLicenca"] = "0";
               // Session["IDCliente"] = "0";
                Session["CodPagina"] = "0";
         //       if (cliente == "2") cliente = "2096";

                if (nivel == "Gestor" || nivel == "Adm-1" || nivel == "Adm-2" || nivel == "Adm-3")
                {
                    GridLicenca.DataSourceID = "";
                    GridLicenca.DataSource = GetLicencaAdm();
                }
                else
                {
                    GridLicenca.DataSourceID = "";
                    GridLicenca.DataSource = GetLicenca(cliente);
                }
      //          GravaOperacaoUsuario(Session["Nome"].ToString(), Session["Login"].ToString(), "LICENÇAS", "ACESSO A PAGINA", "");///

            }
            //try
            //{
            //    Session["Erro"] = " ";
            //    string CodPagina = "9";
            //    string CodUsuario = Session["IdUser"].ToString();
            //    string CodFuncao = "0"; // acesso
            //    if (PermitirFuncao(CodPagina, CodUsuario, CodFuncao) == false)
            //    {
            //        Response.Redirect("Erro.aspx");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    string Erro = "INFORME AO ADMINISTRADOR O SEGUINTE ERRO: " + ex.ToString();
            //    Session["Erro"] = Erro;
            //    Response.Redirect("Erro.aspx");
            //}
        }

        protected void GridClientes_CommandButtonInitialize(object sender, DevExpress.Web.ASPxGridViewCommandButtonEventArgs e)
        {
            string CodPagina = "9";
            if (e.ButtonType == DevExpress.Web.ColumnCommandButtonType.New)
            {
                string Funcao = "1";
                string usuario = Session["IdUser"].ToString(); // verifica função cadastrar usuario
                if (PermitirFuncao(CodPagina, usuario, Funcao) == true)
                {
                    GravaOperacaoUsuario(Session["Nome"].ToString(), Session["Login"].ToString(), "LICENÇAS", "CADASTRO DE REGISTROS", "");
                    e.Enabled = true;
                }
                else
                {
                    e.Enabled = false;
                }
            }
            if (e.ButtonType == DevExpress.Web.ColumnCommandButtonType.Edit)
            {
                string Funcao = "2";
                string usuario = Session["IdUser"].ToString(); // verifica função cadastrar usuario
                if (PermitirFuncao(CodPagina, usuario, Funcao) == true)
                {
                    GravaOperacaoUsuario(Session["Nome"].ToString(), Session["Login"].ToString(), "LICENÇAS", "EDIÇÃO DE REGISTROS", "");
                    e.Enabled = true;
                }
                else
                {
                    e.Enabled = false;
                }
            }
            if (e.ButtonType == DevExpress.Web.ColumnCommandButtonType.Delete)
            {
                string Funcao = "3";
                string usuario = Session["IdUser"].ToString(); // verifica função cadastrar usuario
                if (PermitirFuncao(CodPagina, usuario, Funcao) == true)
                {
                    GravaOperacaoUsuario(Session["Nome"].ToString(), Session["Login"].ToString(), "LICENÇAS", "EXCLUSÃO DE DE REGISTROS", "");
                    e.Enabled = true;
                }
                else
                {
                    e.Enabled = false;
                }
            }

        }
        protected void CridCondicionantes_BeforePerformDataSelect(object sender, EventArgs e)
        {
            Session["IdLicenca"] = (sender as ASPxGridView).GetMasterRowKeyValue();
        }

        protected void GridLicenca_RowInserted(object sender, DevExpress.Web.Data.ASPxDataInsertedEventArgs e)
        {
            string a = e.NewValues["Condicionante"].ToString();
            try
            {
                Session["IdLicenca"] = e.NewValues["Id"].ToString();
            }
            catch
            {
                Session["IdLicenca"] = 0;
            }

            // pcAnexo.Show();
            if (a == "1")
            {
                ASPxGridView grid = sender as ASPxGridView;
                grid.JSProperties["cpText"] = String.Format("The record {0} was updated", a);

                grid.JSProperties["cpShowPopup"] = true;
            }
        }
        protected void GridLicenca_RowUpdated(object sender, DevExpress.Web.Data.ASPxDataUpdatedEventArgs e)
        {
            string a = e.NewValues["Condicionante"].ToString();
            Session["IdLicenca"] = e.NewValues["Id"].ToString();
            string b = e.NewValues["Id"].ToString();
            if (a == "1")
            {
                ASPxGridView grid = sender as ASPxGridView;
                grid.JSProperties["cpText"] = String.Format(".", b);

                grid.JSProperties["cpShowPopup"] = true;
            }
        }
    }
}