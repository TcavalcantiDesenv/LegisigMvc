using DevExpress.Export;
using DevExpress.Web;
using DevExpress.XtraPrinting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PlatinDashboard.Presentation.MVC.Paginas
{
    public partial class RequisitosLegais : System.Web.UI.Page
    {
        //  string ID = "";
        // IFormatProvider culture = new CultureInfo("pt-BR", true);
        CultureInfo culture = CultureInfo.CreateSpecificCulture("pt-BR");
        protected void Page_Load(object sender, EventArgs e)
        {
            ddlExportMode.Items.AddRange(Enum.GetNames(typeof(GridViewDetailExportMode)));
            ddlExportMode.Text = GridViewDetailExportMode.Expanded.ToString();
            Session["Erro"] = "";
            Session["Regra"] = "0";
            DataTable dtP = new DataTable();
            string conexao5 = ConfigurationManager.ConnectionStrings["PortalConnection"].ConnectionString;
            SqlConnection Conn5 = new SqlConnection(conexao5);
            try
            {
                Conn5.Open();
                SqlCommand Cmd5 = new SqlCommand("SELECT count(P.ResultFinal) as Atende" +
                " FROM [Clientes] as C, [Legis_Cliente] as LC,[LegisGeral] as G, PlanoAcao as P " +
                " where  " +
                " LC.IDLegisGeral=G.Id and " +
                " LC.IDLegisGeral = P.IDLegis " +
                " and P.ResultFinal = 'Atende' ", Conn5);
                SqlDataAdapter Sqlda = new SqlDataAdapter(Cmd5);
                Sqlda.Fill(dtP);
                if (dtP.Rows.Count > 0)
                {
                    // lblNAtende.Text = dtP.Rows[0]["Atende"].ToString()+" Atende";
                }
                else
                {

                }
                Conn5.Close();
            }
            catch (Exception ex)
            {
                string erro = ex.Message ;
            }

            try
            {
                if (!Page.IsPostBack)
                {
                    string usuario = Session["IdUser"].ToString();
                    string nivel = Session["Nivel"].ToString();
                    Session["IDCliente"] = Session["IdCli"].ToString();
                    string cliente = Session["IdCli"].ToString();
                    Session["NomeUserCli"] = Session["Nome"].ToString();

                    if(nivel == "Adm-1" || nivel == "Adm-2" || nivel == "Adm-3" || nivel == "Gestor" )
                    {
                        Panel2.Visible = true;
                    }

                    DataTable dtA = new DataTable();
                    string conexao51 = ConfigurationManager.ConnectionStrings["PortalConnection"].ConnectionString;
                    SqlConnection Conn51 = new SqlConnection(conexao51);
                    try
                    {
                        Conn51.Open();
                        SqlCommand Cmd51 = new SqlCommand("select * from clientes order by nomefantasia ", Conn51);
                        SqlDataAdapter Sqlda = new SqlDataAdapter(Cmd51);
                        Sqlda.Fill(dtA);
                        if (dtA.Rows.Count > 0)
                        {
                            ddlCliente.DataSource = dtA;
                            ddlCliente.ValueField = "id";//dtA.Rows[0]["Id"].ToString(); ;
                            ddlCliente.TextField = "NomeFantasia";//dtA.Rows[0]["NomeFantasia"].ToString();
                            ddlCliente.DataBind();
                        }

                        Conn51.Close();
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    { }

                    DataTable dtE = new DataTable();
                    string conexaoE = ConfigurationManager.ConnectionStrings["PortalConnection"].ConnectionString;
                    SqlConnection ConnE = new SqlConnection(conexaoE);
                    try
                    {
                        ConnE.Open();
                        SqlCommand CmdE = new SqlCommand(@"SELECT LC.IDCliente,LG.sistema, LG.Ambito, LG.Municipio as Cidade, LG.Estado, LG.Pais,LG.Orgao,LG.Numero,LG.Ano,LG.Tipo,LG.Ementa as Exigencia, LG.Tema as Assunto, C.Evidencias as Validação, C.DataAvaliacao,CASE  
                          WHEN PC.Aplicavel IN(1) THEN 'Aplicavel'
                          ELSE 'Não Aplicavel'
                        END as Classificacao, C.ProxAvaliacao, C.Resultado
                        FROM LegisGeral as LG, Legis_Cliente as LC, ParametrosCliente as PC, Conformidade as C
                        where LG.Id = LC.IDLegisGeral and
                        LC.IDLegisGeral = PC.IDLegisGeral and
                        PC.Id = C.IDParametros and
                        LC.IDCliente = '" + cliente + "' ", ConnE);
                        SqlDataAdapter Sqlda = new SqlDataAdapter(CmdE);
                        Sqlda.Fill(dtE);
                        if (dtE.Rows.Count > 0)
                        {
                            //EspelhoLegisig.DataSourceID = "";
                            //EspelhoLegisig.DataSource = dtE;
                            //EspelhoLegisig.DataBind();
                        }

                        ConnE.Close();
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    { }

                    DataTable dt0 = new DataTable();
                    string conexao = ConfigurationManager.ConnectionStrings["PortalConnection"].ConnectionString;
                    SqlConnection connection = new SqlConnection(conexao);
                    connection.Open();
                    SqlCommand sqlCmd = new SqlCommand("SELECT *  FROM Config ", connection);
                    SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
                    sqlDa.Fill(dt0);
                    if (dt0.Rows.Count > 0)
                    {
                        Session["emailpara"] = dt0.Rows[0]["emailpara"].ToString().Trim();
                        Session["email"] = dt0.Rows[0]["email"].ToString().Trim();
                        Session["senha"] = dt0.Rows[0]["senha"].ToString().Trim();
                        Session["porta"] = dt0.Rows[0]["porta"].ToString().Trim();
                        Session["semana"] = dt0.Rows[0]["semana"].ToString().Trim();
                        Session["periodo"] = dt0.Rows[0]["periodo"].ToString().Trim();
                    }
                    connection.Close();

                    #region ADM 2 e 3
                    if (nivel == "Adm-2" || nivel == "Adm-3") //se for administrador
                    {
                        Session["Regra"] = "1";
                        DataTable dt = GetCliente23();
                        if (dt.Rows.Count > 0)
                        {
                            Session["RazaoSocial"] = dt.Rows[0]["RazaoSocial"].ToString();

                            Session["IDLegisGeral"] = "0"; //dt.Rows[0]["IDLegisGeral"].ToString();
                            lblEmpresa.Text = dt.Rows[0]["RazaoSocial"].ToString();
                            ASPxGridView1.SettingsText.Title = "LEGISIG - " + lblEmpresa.Text;
                            GetLeisCliente(cliente);
                            GravaOperacaoUsuario(Session["Nome"].ToString(), Session["Login"].ToString(), "ACESSO A TELA DE USUARIO", "OPERAÇÃO PERMITIDA PARA " + Session["Nome"].ToString().ToUpper(), "");
                        }
                        else
                        {
                            GravaOperacaoUsuario(Session["Nome"].ToString(), Session["Login"].ToString(), "ACESSO A TELA DE USUARIO", "OPERAÇÃO NÃO PERMITIDA PARA " + Session["Nome"].ToString().ToUpper(), "");
                        }
                    }
                    #endregion
                    #region ADM 1
                    if (nivel == "Adm-1") //se for administrador
                    {
                        Session["Regra"] = "1";
                        DataTable dt = GetCliente();
                        if (dt.Rows.Count > 0)
                        {
                            Session["RazaoSocial"] = dt.Rows[0]["RazaoSocial"].ToString();
                            Session["IDCliente"] = Session["IdCli"].ToString();// dt.Rows[0]["N_Cliente"].ToString();
                            Session["IDLegisGeral"] = "0"; //dt.Rows[0]["IDLegisGeral"].ToString();
                            lblEmpresa.Text = dt.Rows[0]["RazaoSocial"].ToString();
                            ASPxGridView1.SettingsText.Title = "LEGISIG - " + lblEmpresa.Text;
                            // ASPxGridView4.DataBind();
         //                   GravaOperacaoUsuario(Session["Nome"].ToString(), Session["Login"].ToString(), "ACESSO A TELA DE USUARIO", "OPERAÇÃO PERMITIDA PARA " + Session["Nome"].ToString().ToUpper(), "");
                        }
                        else
                        {
                            GravaOperacaoUsuario(Session["Nome"].ToString(), Session["Login"].ToString(), "ACESSO A TELA DE USUARIO", "OPERAÇÃO NÃO PERMITIDA PARA " + Session["Nome"].ToString().ToUpper(), "");
                        }
                    }

                    #endregion
                    #region Gestor
                    if (nivel == "Gestor") //se for administrador
                    {
                        Session["Regra"] = "1";
                        DataTable dt = GetCliente();
                        if (dt.Rows.Count > 0)
                        {
                            Session["RazaoSocial"] = dt.Rows[0]["RazaoSocial"].ToString();
                            Session["IDCliente"] = Session["IdCli"].ToString();// dt.Rows[0]["N_Cliente"].ToString();
                            Session["IDLegisGeral"] = "0"; //dt.Rows[0]["IDLegisGeral"].ToString();
                            lblEmpresa.Text = dt.Rows[0]["RazaoSocial"].ToString();
                            ASPxGridView1.SettingsText.Title = "LEGISIG - " + lblEmpresa.Text;
                            // ASPxGridView4.DataBind();
                            //GravaOperacaoUsuario(Session["Nome"].ToString(), Session["Login"].ToString(), "ACESSO A TELA DE USUARIO", "OPERAÇÃO PERMITIDA PARA " + Session["Nome"].ToString().ToUpper(), "");
                        }
                        else
                        {
                            //GravaOperacaoUsuario(Session["Nome"].ToString(), Session["Login"].ToString(), "ACESSO A TELA DE USUARIO", "OPERAÇÃO NÃO PERMITIDA PARA " + Session["Nome"].ToString().ToUpper(), "");
                        }
                    }
                    if (nivel == "G-1"|| nivel == "G-2" || nivel == "G-3"  ) //se for administrador
                    {
                        Session["Regra"] = "1";
                        DataTable dt = GetCliente();
                        if (dt.Rows.Count > 0)
                        {
                            Session["RazaoSocial"] = dt.Rows[0]["RazaoSocial"].ToString();
                            Session["IdCliente"] = Session["IdCli"].ToString();// dt.Rows[0]["N_Cliente"].ToString();
                            Session["IDLegisGeral"] = "0"; //dt.Rows[0]["IDLegisGeral"].ToString();
                            lblEmpresa.Text = dt.Rows[0]["RazaoSocial"].ToString();
                            ASPxGridView1.SettingsText.Title = "LEGISIG - " + lblEmpresa.Text;
                            // ASPxGridView4.DataBind();
                            //GravaOperacaoUsuario(Session["Nome"].ToString(), Session["Login"].ToString(), "ACESSO A TELA DE USUARIO", "OPERAÇÃO PERMITIDA PARA " + Session["Nome"].ToString().ToUpper(), "");
                        }
                        else
                        {
                            //GravaOperacaoUsuario(Session["Nome"].ToString(), Session["Login"].ToString(), "ACESSO A TELA DE USUARIO", "OPERAÇÃO NÃO PERMITIDA PARA " + Session["Nome"].ToString().ToUpper(), "");
                        }
                    }
                    #endregion
                    //     ASPxGridView1.SettingsText.Title = "LEGISIG - " + Session["RazaoSocial"].ToString();


                }
            }
            catch (Exception ex)
            {
                Response.Redirect("Erro.aspx");
            }
        }


        bool needToSelectAll;
        protected void btnLink_Click(object sender, EventArgs e)
        {
            ASPxButton btnLink = (ASPxButton)sender;
            GridViewDataItemTemplateContainer container = (GridViewDataItemTemplateContainer)btnLink.NamingContainer;
            object[] values = (object[])container.Grid.GetRowValues(container.VisibleIndex, new string[] { "lei", "link" });
            try
            {
                string valor = values[1].ToString();
                if (valor != "")
                {
                    Response.Write("<script>window.open('" + valor + "','_blank');</script>");
                }
                else
                {
                    cpPopup3.ShowOnPageLoad = true;
                }
            }
            catch
            {
                cpPopup3.ShowOnPageLoad = true;
            }

        }
        protected void UpdateExportMode()
        {
            EspelhoLegisig.SettingsDetail.ExportMode = (GridViewDetailExportMode)Enum.Parse(typeof(GridViewDetailExportMode), ddlExportMode.Text);
        }

        protected void ASPxButton31_Click(object sender, EventArgs e)
        {
            UpdateExportMode();
            gridExport.WriteXlsxToResponse(new XlsxExportOptionsEx() { ExportType = ExportType.WYSIWYG });
        }
        protected void ASPxButton32_Click(object sender, EventArgs e)
        {
            UpdateExportMode();
            gridExport2.WriteXlsxToResponse(new XlsxExportOptionsEx() { ExportType = ExportType.WYSIWYG });
        }
        protected void ASPxButton33_Click(object sender, EventArgs e)
        {
            UpdateExportMode();
            gridExport3.WriteXlsxToResponse(new XlsxExportOptionsEx() { ExportType = ExportType.WYSIWYG });
        }

        protected void btnLink2_Click(object sender, EventArgs e)
        {
            ASPxButton btnLink = (ASPxButton)sender;
            GridViewDataItemTemplateContainer container = (GridViewDataItemTemplateContainer)btnLink.NamingContainer;
            object[] values = (object[])container.Grid.GetRowValues(container.VisibleIndex, new string[] { "lei", "Arqpdf" });
            try
            {
                string valor = values[1].ToString();
                if (valor != "")
                {
                    //   Response.Write("<script>window.open('" + valor + "','_blank');</script>");
                    Session["pdf"] = valor;
                    Response.Redirect("VerPdf.aspx");
                    //   Response.Write("<script>window.open('VerPdf.aspx','_blank');</script>");
                }
                else
                {
                    cpPopup5.ShowOnPageLoad = true;
                }
            }
            catch
            {
                cpPopup5.ShowOnPageLoad = true;
            }

        }
        protected void cbCheckAll_Init(object sender, EventArgs e)
        {
            ASPxCheckBox cb = (ASPxCheckBox)sender;
            cb.ClientSideEvents.CheckedChanged = string.Format("cbCheckAll_CheckedChanged");
            cb.Checked = needToSelectAll;
        }
        protected void cbCheckAll3_Init(object sender, EventArgs e)
        {
            ASPxCheckBox cb = (ASPxCheckBox)sender;
            cb.ClientSideEvents.CheckedChanged = string.Format("cbCheckAll3_CheckedChanged");
            cb.Checked = needToSelectAll;
        }
        protected void cbCheck_Init(object sender, EventArgs e)
        {
            ASPxCheckBox cb = (ASPxCheckBox)sender;
            GridViewDataItemTemplateContainer container = (GridViewDataItemTemplateContainer)cb.NamingContainer;

            cb.ClientInstanceName = string.Format("cbCheck{0}", container.VisibleIndex);
            cb.Checked = GridLegisGeral2.Selection.IsRowSelected(container.VisibleIndex);
            cb.ClientSideEvents.CheckedChanged = string.Format("function (s, e) {{ cbCheck_CheckedChanged(s,e, {0}); }}", container.VisibleIndex);

            DataRow row = GridLegisGeral2.GetDataRow(container.VisibleIndex);
            cb.Visible = IsCheckBoxVisibleCriteria(row);
        }
        protected void cbCheck2_Init(object sender, EventArgs e)
        {
            ASPxCheckBox cb = (ASPxCheckBox)sender;
            GridViewDataItemTemplateContainer container = (GridViewDataItemTemplateContainer)cb.NamingContainer;

            cb.ClientInstanceName = string.Format("cbCheck2{0}", container.VisibleIndex);
            cb.Checked = GridLegisGeral2.Selection.IsRowSelected(container.VisibleIndex);
            cb.ClientSideEvents.CheckedChanged = string.Format("function (s, e) {{ cbCheck2_CheckedChanged(s,e, {0}); }}", container.VisibleIndex);

            DataRow row = GridLegisGeral2.GetDataRow(container.VisibleIndex);
            cb.Visible = IsCheckBoxVisibleCriteria(row);
        }
        protected void cbCheck3_Init(object sender, EventArgs e)
        {
            ASPxCheckBox cb = (ASPxCheckBox)sender;
            GridViewDataItemTemplateContainer container = (GridViewDataItemTemplateContainer)cb.NamingContainer;

            cb.ClientInstanceName = string.Format("cbCheck3{0}", container.VisibleIndex);
            cb.Checked = ASPxGridView5.Selection.IsRowSelected(container.VisibleIndex);
            cb.ClientSideEvents.CheckedChanged = string.Format("function (s, e) {{ cbCheck3_CheckedChanged(s,e, {0}); }}", container.VisibleIndex);

            DataRow row = ASPxGridView5.GetDataRow(container.VisibleIndex);
            cb.Visible = IsCheckBoxVisibleCriteria(row);
        }
        public bool InsereLeisAoCliente(string IDCliente, string IDLegisGeral, string Aplicavel)
        {
            bool flag = false;
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["PortalConnection"].ConnectionString);
            sqlConnection.Open();
            try
            {
                DateTime now = DateTime.Now;
                Convert.ToString(now.TimeOfDay).Substring(0, 8);
                SqlCommand sqlCommand = new SqlCommand("insert Legis_Cliente(IDCliente,IDLegisGeral,Aplicavel,IdProduto,IDSubProduto)  values(@v1,@v2,@v3,@v4,@v5) ", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@v1", IDCliente);
                sqlCommand.Parameters.AddWithValue("@v2", IDLegisGeral);
                sqlCommand.Parameters.AddWithValue("@v3", Aplicavel);
                sqlCommand.Parameters.AddWithValue("@v4", "1");
                sqlCommand.Parameters.AddWithValue("@v5", "1");

                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                flag = true;
            }
            catch (SqlException)
            {
            }
            return flag;
        }
        public bool InsereParametroCliente(string Capitulo, string Item, string Parametro, string Obrigacao, string IDLegisGeral, string IDCliente, string Numero)
        {
            bool flag = false;
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["PortalConnection"].ConnectionString);
            sqlConnection.Open();
            try
            {
                DateTime now = DateTime.Now;
                Convert.ToString(now.TimeOfDay).Substring(0, 8);
                SqlCommand sqlCommand = new SqlCommand("insert ParametrosCliente(Capitulo,Item,Parametro,Obrigacao,IDLegisGeral,IDCliente,Numero,Aplicavel)  values(@v1,@v2,@v3,@v4,@v5,@v6,@v7,@v8) ", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@v1", Capitulo);
                sqlCommand.Parameters.AddWithValue("@v2", Item);
                sqlCommand.Parameters.AddWithValue("@v3", Parametro);
                sqlCommand.Parameters.AddWithValue("@v4", Obrigacao);
                sqlCommand.Parameters.AddWithValue("@v5", IDLegisGeral);
                sqlCommand.Parameters.AddWithValue("@v6", IDCliente);
                sqlCommand.Parameters.AddWithValue("@v7", Numero);
                sqlCommand.Parameters.AddWithValue("@v8", "0");
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                flag = true;
            }
            catch (SqlException sqlException)
            {
            }
            return flag;
        }
        public bool PesquisaLeiCliente(string IDLegisGeral, string IDCliente)
        {
            bool flag = false;

            DataTable dt = new DataTable();
            string conexao = ConfigurationManager.ConnectionStrings["PortalConnection"].ConnectionString;
            SqlConnection connection = new SqlConnection(conexao);
            connection.Open();
            SqlCommand sqlCmd = new SqlCommand("select IDCliente,IDLegisGeral from Legis_Cliente where IDCliente = @v1 and IDLegisGeral = @v2 ", connection);
            sqlCmd.Parameters.AddWithValue("@v1", IDCliente);
            sqlCmd.Parameters.AddWithValue("@v2", IDLegisGeral);
            SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
            //  sqlCmd.Parameters.AddWithValue("@id", IdEmpresa);
            sqlDa.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                flag = true;
            }
            else
            {
                flag = false;
            }
            connection.Close();
            return flag;
        }
        public bool DeleteParametrosCliente(string idcliente, string idlei)
        {
            bool flag = false;
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["PortalConnection"].ConnectionString);
            sqlConnection.Open();
            try
            {
                SqlCommand sqlCommand = new SqlCommand("delete from ParametrosCliente where IDLegisGeral = @v1 and IDCliente = @v2 ", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@v1", idlei);
                sqlCommand.Parameters.AddWithValue("@v2", idcliente);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                flag = true;
            }
            catch (Exception exception)
            {
            }
            return flag;
        }
        public bool ExcluiLeisDoCliente(string IDCliente, string IDLegisGeral)
        {
            bool flag = false;
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["PortalConnection"].ConnectionString);
            sqlConnection.Open();
            try
            {
                DateTime now = DateTime.Now;
                Convert.ToString(now.TimeOfDay).Substring(0, 8);
                SqlCommand sqlCommand = new SqlCommand("delete from Legis_Cliente where IDCliente = @v1 and IDLegisGeral = @v2", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@v1", IDCliente);
                sqlCommand.Parameters.AddWithValue("@v2", IDLegisGeral);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();

                flag = true;
            }
            catch (SqlException)
            {
            }
            return flag;
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
        protected void ASPxGridView1_CommandButtonInitialize(object sender, DevExpress.Web.ASPxGridViewCommandButtonEventArgs e)
        {
        }
        protected void ASPxGridView2_CommandButtonInitialize(object sender, DevExpress.Web.ASPxGridViewCommandButtonEventArgs e)
        {
            string CodPagina = "8";
            if (e.ButtonType == DevExpress.Web.ColumnCommandButtonType.Edit)
            {
                string Funcao = "2";
                string usuario = Session["IdUser"].ToString();// Permitir aplicar Parametro
                if (PermitirFuncao(CodPagina, usuario, Funcao) == true)
                {
                    e.Enabled = true;
                }
                else
                {
                    e.Enabled = false;
                }
            }

        }
        protected void ASPxGridView3_CommandButtonInitialize(object sender, DevExpress.Web.ASPxGridViewCommandButtonEventArgs e)
        {
            string CodPagina = "8";
            if (e.ButtonType == DevExpress.Web.ColumnCommandButtonType.New)
            {
                string Funcao = "1";
                string usuario = Session["IdUser"].ToString(); // Permitir Lançamento de Evidencias	
                if (PermitirFuncao(CodPagina, usuario, Funcao) == true)
                {
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
                string usuario = Session["IdUser"].ToString(); // Editar Lançamento de Evidencias
                if (PermitirFuncao(CodPagina, usuario, Funcao) == true)
                {
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
                string usuario = Session["IdUser"].ToString(); // Excluir Lançamento de Evidencias
                if (PermitirFuncao(CodPagina, usuario, Funcao) == true)
                {
                    e.Enabled = true;
                }
                else
                {
                    e.Enabled = false;
                }
            }

        }
        private DataTable GetConformidade(string IDCli, string IDLegis, string IDParam)
        {
            DataTable dt = new DataTable();
            string conexao5 = ConfigurationManager.ConnectionStrings["PortalConnection"].ConnectionString;
            SqlConnection Conn5 = new SqlConnection(conexao5);
            try
            {
                Conn5.Open();
                SqlCommand Cmd5 = new SqlCommand("Select * from Conformidade where IDCliente = '" + IDCli + "' and IDLegis = '" + IDLegis + "' and IDParametros = '" + IDParam + "' ", Conn5);
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
                " where ID = @IdCliente", Conn5);
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
        private DataTable GetCliente23()
        {

            DataTable dt = new DataTable();
            string conexao5 = ConfigurationManager.ConnectionStrings["PortalConnection"].ConnectionString;
            SqlConnection Conn5 = new SqlConnection(conexao5);
            try
            {
                Conn5.Open();
                SqlCommand Cmd5 = new SqlCommand("SELECT *  FROM [ClientesADM] " +
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
        public void GetLeisCliente(string IdCli)
        {
            ASPxGridView ASPxGridView4 = new ASPxGridView();
            //Page.Controls.Add(grd);
            //form1.Controls.Add(grd);
            //grd.ControlStyle.Font.Size = 9;
            string conexao5 = ConfigurationManager.ConnectionStrings["PortalConnection"].ConnectionString;
            SqlConnection Conn5 = new SqlConnection(conexao5);
            Conn5.Open();
            SqlCommand cmd4grid = new SqlCommand("SELECT C.RazaoSocial, LC.*, G.*  FROM [Clientes] as C, " +
            "    [Legis_Cliente] as LC,[LegisGeral] as G " +
            " where LC.IDCliente=C.N_cliente and " +
            " LC.IDLegisGeral=G.Id and " +
            " LC.IDCliente = '" + IdCli + "' ", Conn5);
            SqlDataAdapter dad = new SqlDataAdapter(cmd4grid);
            DataTable dt = new DataTable();
            dad.Fill(dt);
            ASPxGridView4.DataSource = dt;
            ASPxGridView4.DataBind();
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
            catch (System.Data.SqlClient.SqlException)
            {

            }

            return gravado;

        }
        private bool IsCheckBoxVisibleCriteria(DataRow row)
        {
            try
            {
                return !row["Sistema"].ToString().Contains("*");
            }
            catch
            {
                return false;
            }
            //        
        }
        public class Person
        {
            public int Id { get; set; }
            public string Sistema { get; set; }
        }
           protected void ASPxGridView1_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridViewTableRowEventArgs e)
        {
            if (e.RowType != GridViewRowType.Data) return;
            int value = (int)e.GetValue("Ativo");
            if (value == 1) e.Row.ForeColor = System.Drawing.Color.Navy;
            if (value == 0) e.Row.BackColor = System.Drawing.Color.LightCoral;
        }
        protected void ASPxGridView1_BeforePerformDataSelect(object sender, EventArgs e)
        {
            Session["IDLegisGeral"] = (sender as ASPxGridView).GetMasterRowKeyValue();
        }
        protected void ASPxGridView2_BeforePerformDataSelect(object sender, EventArgs e)
        {
            Session["IDLegisGeral"] = (sender as ASPxGridView).GetMasterRowKeyValue();
        }
        protected void master_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            string[] data = e.Parameters.Split('|');
            if (data.Length == 3 && data[0] == "select")
                ProcessSelection(int.Parse(data[1]), data[2] == "T");
        }
        void ProcessSelection(int index, bool state)
        {
            ASPxGridView1.DataBind();
            ASPxGridView1.Selection.SetSelection(index, state);
            ASPxGridView detail = ASPxGridView1.FindDetailRowTemplateControl(index, "detail") as ASPxGridView;
            if (detail != null)
            {
                if (state)
                    detail.Selection.SelectAll();
                else
                    detail.Selection.UnselectAll();
            }
        }
        protected void ASPxGridView3_BeforePerformDataSelect(object sender, EventArgs e)
        {
            Session["IDParametros"] = (sender as ASPxGridView).GetMasterRowKeyValue();
            Session["IdParam"] = Session["IDParametros"].ToString();
            string usuario = Session["IdUser"].ToString();
        }
        protected void ASPxGridView4_BeforePerformDataSelect(object sender, EventArgs e)
        {
            Session["id"] = (sender as ASPxGridView).GetMasterRowKeyValue();
            Session["IDConformidade"] = (sender as ASPxGridView).GetMasterRowKeyValue();
            Session["IDAcao"] = (sender as ASPxGridView).GetMasterRowKeyValue();
        }
        ASPxGridView gridView;
        protected void detailGrid_Load(object sender, EventArgs e)
        {

            gridView = sender as ASPxGridView;
            gridView.SelectionChanged += new EventHandler(Grid_SelectionChanged);

        }
        private static int invoiceID;
        protected void ASPxGridView3_SelectionChanged(object sender, EventArgs e)
        {
            invoiceID = Convert.ToInt32(gridView.GetSelectedFieldValues("id")[0].ToString());
            invoiceID = Convert.ToInt32(gridView.GetSelectedFieldValues("id")[0]);
            Session["IDConformidade"] = gridView.GetSelectedFieldValues("id")[0];
        }
        protected void Grid_SelectionChanged(object sender, EventArgs e)
        {
            invoiceID = Convert.ToInt32(ASPxGridView1.GetSelectedFieldValues("Id")[0].ToString());
            Session["IDLegisGeralC"] = ASPxGridView1.GetSelectedFieldValues("IDLegisGeral")[0].ToString();
            Session["IdUserEmp"] = ASPxGridView1.GetSelectedFieldValues("Id")[0].ToString();
        }
        protected void GridUsuariosCli_BeforePerformDataSelect(object sender, EventArgs e)
        {
            Session["Id"] = (sender as ASPxGridView).GetMasterRowKeyValue();
            Session["IDParametros"] = (sender as ASPxGridView).GetMasterRowKeyValue();
        }
        protected void GridClientes_BeforePerformDataSelect(object sender, EventArgs e)
        {
            Session["IDLegisGeral"] = (sender as ASPxGridView).GetMasterRowKeyValue();
        }
        protected void SqlClienteADM_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }
        protected void pmRowMenu_ItemClick(object source, MenuItemEventArgs e)
        {

        }
        private void BindGrid()
        {
            string conf = "0";
            try
            {
                conf = Session["IDConformidade"].ToString();
            }
            catch
            {
                conf = "0";
            }
            string conexao3 = ConfigurationManager.ConnectionStrings["PortalConnection"].ConnectionString;
            SqlConnection connection3 = new SqlConnection(conexao3);
            connection3.Open();
            string ADDStr3 = "select * from Anexos where IDConformidade = '" + conf + "' ";
            SqlCommand ADDCmd3 = new SqlCommand(ADDStr3, connection3);
            SqlDataReader Dr3 = ADDCmd3.ExecuteReader();
            //  SqlArquivos.SelectCommand = ADDStr3;
            try
            {
                //  GridAnexo.DataSourceID = "";
                //  GridAnexo.DataSource = SqlArquivos;
                //  GridAnexo.DataBind();
            }
            finally
            {
                //  Dr.Close();
            }
            connection3.Close();
        }
        private void GetAnexo(string IdConformidade)
        {
            string conf = Session["IDConformidade"].ToString();
            string conexao3 = ConfigurationManager.ConnectionStrings["PortalConnection"].ConnectionString;
            SqlConnection connection3 = new SqlConnection(conexao3);
            connection3.Open();
            string ADDStr3 = "select * from Anexos where IDConformidade = '" + IdConformidade + "' ";
            SqlCommand ADDCmd3 = new SqlCommand(ADDStr3, connection3);
            SqlDataReader Dr3 = ADDCmd3.ExecuteReader();
            //SqlArquivos.SelectCommand = ADDStr3;
            try
            {
                //  GridAnexo.DataSourceID = "";
                //  GridAnexo.DataSource = SqlArquivos;
                //  GridAnexo.DataBind();
            }
            finally
            {
                //  Dr.Close();
            }
            connection3.Close();
        }
        protected void Upload(object sender, EventArgs e)
        {
            string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
            string contentType = FileUpload1.PostedFile.ContentType;
            using (Stream fs = FileUpload1.PostedFile.InputStream)
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    try
                    {
                        Session["IDC"] = Session["IDConformidade"].ToString();
                        byte[] bytes = br.ReadBytes((Int32)fs.Length);
                        string constr = ConfigurationManager.ConnectionStrings["PortalConnection"].ConnectionString;
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            string query = "insert into Anexos (Arquivo, ContentType, Data, IDCliente, IDLegisGeral, IDConformidade, IDParametros " +
") values (@Arquivo, @ContentType, @Data, @IDCliente, @IDLegisGeral, @IDConformidade, @IDParametros)";
                            using (SqlCommand cmd = new SqlCommand(query))
                            {
                                cmd.Connection = con;
                                con.Open();

                                cmd.Parameters.AddWithValue("@Arquivo", filename);
                                cmd.Parameters.AddWithValue("@ContentType", "");
                                cmd.Parameters.AddWithValue("@Data", bytes);
                                cmd.Parameters.AddWithValue("@IDCliente", Session["IdCli"].ToString());
                                cmd.Parameters.AddWithValue("@IDLegisGeral", Session["IDLegisGeral"].ToString());
                                cmd.Parameters.AddWithValue("@IDConformidade", Session["IDConformidade"].ToString());
                                cmd.Parameters.AddWithValue("@IDParametros", Session["IDParametros"].ToString());
                                cmd.ExecuteNonQuery();

                                con.Close();
                                Session["IDConformidade"] = "0";
                            }

                            string ID = Session["IDC"].ToString();
                            GetAnexo(ID);
                            //    lblConfirma.Text = "Arquivo " + filename + " enviado com sucesso !!!";
                            //    pcConfirma.ShowOnPageLoad = true;
                            pcAnexo.ShowOnPageLoad = false;
                        }
                    }
                    catch
                    {
                        //lblConfirma.Text = "Erro no envio do arquivo Anexo !!!";
                        // pcConfirma.ShowOnPageLoad = true;
                        //  Page.ClientScript.RegisterStartupScript(this.GetType(), "Window", "window.alert('Erro na atruição de empresas !!!');", true);
                    }
                }
            }
            //   Response.Redirect(Request.Url.AbsoluteUri);
        }
        protected void DownloadFile(object sender, EventArgs e)
        {
            int id = int.Parse((sender as LinkButton).CommandArgument);
            byte[] bytes;
            string fileName, contentType;
            string constr = ConfigurationManager.ConnectionStrings["PortalConnection"].ConnectionString;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "select Arquivo, Data, ContentType from Anexos where id=@Id";
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            sdr.Read();
                            bytes = (byte[])sdr["Data"];
                            contentType = sdr["ContentType"].ToString();
                            fileName = sdr["Arquivo"].ToString();
                        }
                        con.Close();
                    }

                }

                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = contentType;
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
                Response.BinaryWrite(bytes);
                Response.Flush();
                Response.End();

                // lblConfirma.Text = "Download do arquivo " + fileName + " concluido com sucesso!!!";
                // pcConfirma.ShowOnPageLoad = true;

            }
            catch
            {
                ///   lblConfirma.Text = "Erro durante o download do arquivo Anexo !!!";
                //pcConfirma.ShowOnPageLoad = true;
                //  Page.ClientScript.RegisterStartupScript(this.GetType(), "Window", "window.alert('Erro na atruição de empresas !!!');", true);
            }
        }
        protected void ASPxPopupMenu1_ItemClick(object source, MenuItemEventArgs e)
        {
            if ((e.Item.ToString() == "Plano de Ação"))
            {
                try
                {
                    string parametro = Session["Id"].ToString();
                    Session["IdParametro"] = Session["Id"].ToString();
                    pcPlano.ShowOnPageLoad = true;
                }
                catch
                {
                    // lblConfirma.Text = "Clique antes no (+) do Item de Evidencia para cadastrar o Plano de Ação !!";
                    //   pcConfirma.ShowOnPageLoad = true;
                }
            }
            if ((e.Item.ToString() == "Inserir Anexo"))
            {
                string abrir = Session["IDConformidade"].ToString();
                if (abrir == "0")
                {
                    //   lblConfirma.Text = "Por favor abra o Grid de Plano de Ação antes de chamar os Anexos!";
                    //    pcConfirma.ShowOnPageLoad = true;
                }
                else
                {
                    BindGrid();
                    pcAnexo.ShowOnPageLoad = true;
                }
            }
        }
        protected void BtnGravaAtividades_Click(object sender, EventArgs e)
        {
            string usuario = Session["IdUser"].ToString();
            string NomeFantasia = "";
            string IdCliente = "";
            string RazaoSocial = "";
            string CNPJ = "";
            //   string IdEmpresa = txtEmpresa.Value.ToString();
            //   lblIdUsuario.Text = Session["IdUserEmp"].ToString();
            try
            {
                DataTable dt = new DataTable();
                string conexao = ConfigurationManager.ConnectionStrings["PortalConnection"].ConnectionString;
                SqlConnection connection = new SqlConnection(conexao);
                connection.Open();
                SqlCommand sqlCmd = new SqlCommand("SELECT *  FROM Clientes where Id = @id ", connection);
                SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
                //  sqlCmd.Parameters.AddWithValue("@id", IdEmpresa);
                sqlDa.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    IdCliente = dt.Rows[0]["N_Cliente"].ToString().Trim();
                    NomeFantasia = dt.Rows[0]["NomeFantasia"].ToString().Trim();
                    RazaoSocial = dt.Rows[0]["RazaoSocial"].ToString().Trim();
                    CNPJ = dt.Rows[0]["CNPJ"].ToString().Trim();
                }
                connection.Close();

                //   string NomeEmpresa = txtEmpresa.Text;
                conexao = ConfigurationManager.ConnectionStrings["PortalConnection"].ConnectionString;
                SqlConnection Conn = new SqlConnection(conexao);
                Conn.Open();
                SqlCommand Cmd = new SqlCommand("insert ClientesADM(N_Cliente,IdUsuario,NomeFantasia,RazaoSocial,CNPJ) " +
                " values(@v1,@v2,@v3,@v4,@v5)", Conn);
                Cmd.Parameters.AddWithValue("@v1", IdCliente);
                Cmd.Parameters.AddWithValue("@v2", lblIdUsuario.Text);
                Cmd.Parameters.AddWithValue("@v3", NomeFantasia);
                Cmd.Parameters.AddWithValue("@v4", RazaoSocial);
                Cmd.Parameters.AddWithValue("@v5", CNPJ);
                Cmd.ExecuteNonQuery();
                //  lblConfirma.Text = "Empresa atribuida com sucesso!!!!";
                //   pcConfirma.ShowOnPageLoad = true;
                // Page.ClientScript.RegisterStartupScript(this.GetType(), "Window", "window.alert('Empresa atribuida com sucesso!');", true);
                //   pcLancaEmpresa.ShowOnPageLoad = false;
                Conn.Close();
            }
            catch
            {
                //  lblConfirma.Text = "Erro na atruição de empresas !!!";
                //   pcConfirma.ShowOnPageLoad = true;
                //  Page.ClientScript.RegisterStartupScript(this.GetType(), "Window", "window.alert('Erro na atruição de empresas !!!');", true);
            }
            /*  }
              else
              {
                  Page.ClientScript.RegisterStartupScript(this.GetType(), "Window", "window.alert('Usuário sem permissão para esta função !!!');", true);
              }*/
        }
        protected void BtnSair_Click(object sender, EventArgs e)
        {
            //    pcLancaEmpresa.ShowOnPageLoad = false;
        }
        protected void ASPxButton2_Click(object sender, EventArgs e)
        {
            pcAnexo.ShowOnPageLoad = false;
        }
        protected void ASPxButton3_Click(object sender, EventArgs e)
        {
            try
            {
                string cliente = Session["IDCliente"].ToString();
                string conexao1 = ConfigurationManager.ConnectionStrings["PortalConnection"].ConnectionString;
                SqlConnection Conn1 = new SqlConnection(conexao1);
                Conn1.Open();
                SqlCommand Cmd1 = new SqlCommand("insert PlanoAcao(IDParametros,Causa,DataCausa,Correcao_Corretivas,Prazo,Eficacia " +
      " ,DataEficacia,Evidencias,ResultFinal,IDCliente,IDLegis,IDAcao) " + //,IDAcao) " +
                " values(@v1,@v2,@v3,@v4,@v5,@v6,@v7,@v8,@v9,@v10,@v11,@v12) ", Conn1); //,@v12) ", Conn1);
                Cmd1.Parameters.AddWithValue("@v1", Session["IdParam"].ToString());// Session["IdParametro"].ToString());
                Cmd1.Parameters.AddWithValue("@v2", txtCausa.Text);
                Cmd1.Parameters.AddWithValue("@v3", DataCausa.Date);
                Cmd1.Parameters.AddWithValue("@v4", txtCorrecao.Text);
                Cmd1.Parameters.AddWithValue("@v5", DataCorrecao.Date);
                Cmd1.Parameters.AddWithValue("@v6", txtEficacia.Text);
                Cmd1.Parameters.AddWithValue("@v7", DataEficadia.Date);
                Cmd1.Parameters.AddWithValue("@v8", txtEvidencia.Text);
                Cmd1.Parameters.AddWithValue("@v9", txtStatus.Text);
                Cmd1.Parameters.AddWithValue("@v10", cliente);
                Cmd1.Parameters.AddWithValue("@v11", Session["IDLegisGeral"].ToString());
                Cmd1.Parameters.AddWithValue("@v12", Session["IDConformidade"].ToString());// Session["IDAcao"].ToString());
                Cmd1.ExecuteNonQuery(); // executa o metodo insert‏

                //   lblConfirma.Text = "Plano de Ação regsitrado com sucesso !";
                pcPlano.ShowOnPageLoad = false;
                //    pcConfirma.ShowOnPageLoad = true;
                Conn1.Close();
            }
            catch (Exception ex)
            {
                //  lblConfirma.Text = "Erro ao cadastrar Plano de Ação!" + ex;
                //  pcConfirma.ShowOnPageLoad = true;
            }
        }
        protected void ASPxButton4_Click1(object sender, EventArgs e)
        {
            pcPlano.ShowOnPageLoad = false;
        }
        protected void ASPxButton9_Click(object sender, EventArgs e)
        {
            //pcConfirma.ShowOnPageLoad = false;
        }
        protected void ASPxGridView3_FocusedRowChanged(object sender, EventArgs e)
        {
            // Session["IDConformidade"] = ASPxGridView3.GetSelectedFieldValues("NomeFantasia")[0].ToString();

        }
        protected void ASPxButton1_Click(object sender, EventArgs e)
        {
            pcAnexo.ShowOnPageLoad = false;
        }
        private string PopulateBody(string userName, string title, string url, string description, string Item, string Capitulo, string Parametro, string Evidencia, string Data, string Avaliado, string Resultado)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Server.MapPath("~/EmailTemplate.htm")))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{UserName}", userName);
            body = body.Replace("{Title}", title);
            body = body.Replace("{Url}", url);
            body = body.Replace("{Description}", description);
            body = body.Replace("{Item}", Item);
            body = body.Replace("{Capitulo}", Capitulo);
            body = body.Replace("{Parametro}", Parametro);
            body = body.Replace("{Evidencia}", Evidencia);
            body = body.Replace("{Data}", Data);
            body = body.Replace("{Avaliado}", Avaliado);
            body = body.Replace("{Resultado}", Resultado);
            return body;
        }
        private void SendHtmlFormattedEmail(string recepientEmail, string subject, string body)
        {
            string EmailPadrao = ConfigurationManager.AppSettings["EPadrao"];
            string emails = Session["Email"].ToString();
            emails = EmailPadrao + ',' + emails;
            using (MailMessage mailMessage = new MailMessage())
            {
                try
                {
                    mailMessage.From = new MailAddress(ConfigurationManager.AppSettings["UserName"]);
                    mailMessage.Subject = subject;
                    mailMessage.Body = body;
                    mailMessage.IsBodyHtml = true;
                    mailMessage.To.Add(emails);// new MailAddress(ConfigurationManager.AppSettings["Emais"]));
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = ConfigurationManager.AppSettings["Host"];
                    smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);
                    System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                    NetworkCred.UserName = ConfigurationManager.AppSettings["UserName"];
                    NetworkCred.Password = ConfigurationManager.AppSettings["Password"];
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = int.Parse(ConfigurationManager.AppSettings["Port"]);

                    smtp.Send(mailMessage);
                }
                catch (Exception ex)
                {
                    //   lblConfirma.Text = "Erro durante o envio de email =: " + ex;
                    //   pcConfirma.ShowOnPageLoad = true;
                }
            }
        }
        protected void ASPxGridView3_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            string txtSistema = "";
            string txtAmbito = "";
            string txtNumero = "";
            string txtAno = "";
            string txtOrgao = "";
            string txtTema = "";
            string txtEmenta = "";
            string txtTipo = "";
            string capitulo = "";
            string item = "";
            string parametro = "";
            string emails = Session["Email"].ToString();
            string Nome = "";
            string EmailAdm = "";
            try
            {
                var IDLegis = Session["IDLegisGeral"].ToString();// e.NewValues["IDLegis"];

                string idcliente = Session["IDCliente"].ToString();
                DataTable dt6a = new DataTable();
                string conexao6a = ConfigurationManager.ConnectionStrings["PortalConnection"].ConnectionString;
                SqlConnection Conn6a = new SqlConnection(conexao6a);
                Conn6a.Open();
                SqlCommand ADDCmd6a = new SqlCommand("Select Nome,Email FROM [Acessos] where IDCliente = " + idcliente + " ", Conn6a);
                SqlDataAdapter dra = new SqlDataAdapter(ADDCmd6a);
                dra.Fill(dt6a);

                if (dt6a.Rows.Count > 0)
                {
                    Nome = dt6a.Rows[0]["Nome"].ToString().Trim();
                    Session["NomeUserCli"] = dt6a.Rows[0]["Nome"].ToString().Trim();
                    EmailAdm = dt6a.Rows[0]["Email"].ToString().Trim();
                }

                EmailAdm = EmailAdm + "," + emails;
                Session["Email"] = EmailAdm;
                var resultado = e.NewValues["Resultado"];
                //   var IDLegis = e.NewValues["IDLegis"];

                var IDParametros = e.NewValues["IDParametros"];
                var Evidencias = e.NewValues["Evidencias"];
                var Data = e.NewValues["DataValidacao"];
                var Resultado = e.NewValues["Resultado"];
                var Avaliado = e.NewValues["Avaliado"];
                Conn6a.Close();

                // string Pesquisar = "";
                DataTable dt = new DataTable();
                string conexao = ConfigurationManager.ConnectionStrings["PortalConnection"].ConnectionString;
                SqlConnection connection = new SqlConnection(conexao);
                connection.Open();
                SqlCommand sqlCmd = new SqlCommand("SELECT * FROM LegisGeral where Id = @IDLegis", connection);
                SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
                sqlCmd.Parameters.AddWithValue("@IDLegis", IDLegis);
                sqlDa.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    txtSistema = dt.Rows[0]["Sistema"].ToString().Trim();
                    txtAmbito = dt.Rows[0]["Ambito"].ToString().Trim();
                    txtNumero = dt.Rows[0]["Numero"].ToString().Trim();
                    txtAno = dt.Rows[0]["Ano"].ToString().Trim();
                    txtOrgao = dt.Rows[0]["Orgao"].ToString().Trim();
                    txtTema = dt.Rows[0]["Tema"].ToString().Trim();
                    txtEmenta = dt.Rows[0]["Ementa"].ToString().Trim();
                    txtTipo = dt.Rows[0]["Tipo"].ToString().Trim();
                    connection.Close();

                    DataTable dt6 = new DataTable();
                    string conexao6 = ConfigurationManager.ConnectionStrings["PortalConnection"].ConnectionString;
                    SqlConnection Conn6 = new SqlConnection(conexao6);
                    Conn6.Open();
                    SqlCommand ADDCmd = new SqlCommand("Select * from Parametros where IDLegisGeral = '" + IDLegis + "' ", Conn6);
                    SqlDataAdapter dr = new SqlDataAdapter(ADDCmd);
                    dr.Fill(dt6);

                    if (dt6.Rows.Count > 0)
                    {
                        capitulo = dt6.Rows[0]["Capitulo"].ToString().Trim();
                        item = dt6.Rows[0]["Item"].ToString().Trim();
                        parametro = dt6.Rows[0]["Parametro"].ToString().Trim();
                        Conn6.Close();
                    }
                }

                string ListaEmaiils = ConfigurationManager.AppSettings["Emails"];

                //*************************************************************************************
                if (resultado.ToString() == "Não Atende")
                {
                    string body = this.PopulateBody(" " + Nome + " ",
                         "Informamos que o seguinte item: " + item + " encontra-se neste momento com o status <b>'Não Atente'</b>.",
                         "Pedimos que atue diretamete neste caso atuando dentro das ações necessárias para resolução do mesmo.",
                         "Uma vez averiguado o problema, favor alterar o status para a devida situação dos seguintes parametros: ",
                     " " + item + " ",
                     " " + capitulo + "  ",
                     " " + parametro + " ",
                     " " + Evidencias.ToString() + " ",
                     " " + Data.ToString() + " ",
                     " " + Avaliado.ToString() + " ",
                     " " + Resultado + " ");
                    //   this.SendHtmlFormattedEmail(ListaEmaiils, "Aviso de Não Conformidade - LEGISIG", body);
                    this.SendHtmlFormattedEmail(EmailAdm, "Aviso de Não Conformidade - LEGISIG", body);
                }
            }
            catch
            {
                //  lblConfirma.Text = "Por favor selecione um Item de Patâmetro ! ";
                //  pcConfirma.ShowOnPageLoad = true;
                //  Page.ClientScript.RegisterStartupScript(this.GetType(), "Window", "window.alert('Erro na atruição de empresas !!!');", true);
            }
        }
        protected void ASPxGridView3_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            string txtSistema = "";
            string txtAmbito = "";
            string txtNumero = "";
            string txtAno = "";
            string txtOrgao = "";
            string txtTema = "";
            string txtEmenta = "";
            string txtTipo = "";
            string capitulo = "";
            string item = "";
            string parametro = "";
            string emails = Session["Email"].ToString();
            string Nome = "";
            string EmailAdm = "";

            string idcliente = Session["IDCliente"].ToString();
            DataTable dt6a = new DataTable();
            string conexao6a = ConfigurationManager.ConnectionStrings["PortalConnection"].ConnectionString;
            SqlConnection Conn6a = new SqlConnection(conexao6a);
            Conn6a.Open();
            SqlCommand ADDCmd6a = new SqlCommand("Select Nome,Email FROM [Acessos] where IDCliente = " + idcliente + " ", Conn6a);
            SqlDataAdapter dra = new SqlDataAdapter(ADDCmd6a);
            dra.Fill(dt6a);

            if (dt6a.Rows.Count > 0)
            {
                Nome = dt6a.Rows[0]["Nome"].ToString().Trim();
                EmailAdm = dt6a.Rows[0]["Email"].ToString().Trim();
            }

            EmailAdm = EmailAdm + "," + emails;
            Session["Email"] = EmailAdm;
            var resultado = e.NewValues["Resultado"];
            var IDLegis = e.NewValues["IDLegis"];
            var IDParametros = e.NewValues["IDParametros"];
            var Evidencias = e.NewValues["Evidencias"];
            var Data = e.NewValues["DataValidacao"];
            var Resultado = e.NewValues["Resultado"];
            var Avaliado = e.NewValues["Avaliado"];
            Conn6a.Close();

            // string Pesquisar = "";
            DataTable dt = new DataTable();
            string conexao = ConfigurationManager.ConnectionStrings["PortalConnection"].ConnectionString;
            SqlConnection connection = new SqlConnection(conexao);
            connection.Open();
            SqlCommand sqlCmd = new SqlCommand("SELECT * FROM LegisGeral where Id = @IDLegis", connection);
            SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
            sqlCmd.Parameters.AddWithValue("@IDLegis", IDLegis);
            sqlDa.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                txtSistema = dt.Rows[0]["Sistema"].ToString().Trim();
                txtAmbito = dt.Rows[0]["Ambito"].ToString().Trim();
                txtNumero = dt.Rows[0]["Numero"].ToString().Trim();
                txtAno = dt.Rows[0]["Ano"].ToString().Trim();
                txtOrgao = dt.Rows[0]["Orgao"].ToString().Trim();
                txtTema = dt.Rows[0]["Tema"].ToString().Trim();
                txtEmenta = dt.Rows[0]["Ementa"].ToString().Trim();
                txtTipo = dt.Rows[0]["Tipo"].ToString().Trim();
                connection.Close();

                DataTable dt6 = new DataTable();
                string conexao6 = ConfigurationManager.ConnectionStrings["PortalConnection"].ConnectionString;
                SqlConnection Conn6 = new SqlConnection(conexao6);
                Conn6.Open();
                SqlCommand ADDCmd = new SqlCommand("Select * from Parametros where IDLegisGeral = '" + IDLegis + "' ", Conn6);
                SqlDataAdapter dr = new SqlDataAdapter(ADDCmd);
                dr.Fill(dt6);

                if (dt6.Rows.Count > 0)
                {
                    capitulo = dt6.Rows[0]["Capitulo"].ToString().Trim();
                    item = dt6.Rows[0]["Item"].ToString().Trim();
                    parametro = dt6.Rows[0]["Parametro"].ToString().Trim();
                    Conn6.Close();
                }
            }

            string ListaEmaiils = ConfigurationManager.AppSettings["Emails"];

            //*************************************************************************************
            if (resultado.ToString() == "Não Atende")
            {
                string body = this.PopulateBody(" " + Nome + " ",
                     "Informamos que o seguinte item: " + item + " encontra-se neste momento com o status <b>'Não Atente'</b>.",
                     "Pedimos que atue diretamete neste caso atuando dentro das ações necessárias para resolução do mesmo.",
                     "Uma vez averiguado o problema, favor alterar o status para a devida situação dos seguintes parametros: ",
                 " " + item + " ",
                 " " + capitulo + "  ",
                 " " + parametro + " ",
                 " " + Evidencias.ToString() + " ",
                 " " + Data.ToString() + " ",
                 " " + Avaliado.ToString() + " ",
                 " " + Resultado + " ");
                //   this.SendHtmlFormattedEmail(ListaEmaiils, "Aviso de Não Conformidade - LEGISIG", body);
                this.SendHtmlFormattedEmail(EmailAdm, "Aviso de Não Conformidade - LEGISIG", body);
            }
        }
        protected void ASPxGridView3_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
        }
        protected void ASPxButton10_Click(object sender, EventArgs e)
        {
            BindGrid();
            pcAnexo.ShowOnPageLoad = true;
        }
        protected void ASPxButton11_Command(object sender, CommandEventArgs e)
        {

        }
        protected void ASPxButton11_Click(object sender, EventArgs e)
        {
            string Parametro = Session["IdParametro"].ToString();
            string Cliente = Session["IDCliente"].ToString();
            string LegisGeral = Session["IDLegisGeral"].ToString();
            string conexao4 = ConfigurationManager.ConnectionStrings["PortalConnection"].ConnectionString;
            SqlConnection Conn4 = new SqlConnection(conexao4);
            Conn4.Open();
            SqlCommand Cmd4 = new SqlCommand("delete [PlanoAcao] where IDCliente = @v1 and IDLegis = @v2  and IDAcao = @v3", Conn4);
            Cmd4.Parameters.AddWithValue("@v1", Cliente);
            Cmd4.Parameters.AddWithValue("@v2", LegisGeral);
            Cmd4.Parameters.AddWithValue("@v3", Parametro);
            Cmd4.ExecuteNonQuery();
            Conn4.Close();
        }
        protected void Grid_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            // string atributos = "";
            var Nivel = e.NewValues["Nivel"];
        }
        protected void Validado_Init(object sender, EventArgs e)
        {
            ASPxTextBox textbox = (ASPxTextBox)sender;
            GridViewEditFormTemplateContainer templatecontainer = (GridViewEditFormTemplateContainer)textbox.NamingContainer;
            ASPxGridView grid = templatecontainer.Grid;
            string CodPagina = "8";
            string Funcao = "2";
            string usuario = Session["IdUser"].ToString(); // Permitir Validar
            if (PermitirFuncao(CodPagina, usuario, Funcao) == true)
            {
                if (grid.IsEditing)
                {
                    textbox.Enabled = true;
                }
                if (grid.IsNewRowEditing)
                {
                    textbox.Enabled = true;
                }
            }
            else
            {
                if (grid.IsEditing)
                {
                    textbox.Enabled = false;
                }
                if (grid.IsNewRowEditing)
                {
                    textbox.Enabled = false;
                }
            }
        }
        protected void Avaliado_Init(object sender, EventArgs e)
        {
            ASPxTextBox textbox = (ASPxTextBox)sender;
            GridViewEditFormTemplateContainer templatecontainer = (GridViewEditFormTemplateContainer)textbox.NamingContainer;
            ASPxGridView grid = templatecontainer.Grid;
            string CodPagina = "8";
            string Funcao = "2";
            string usuario = Session["IdUser"].ToString(); // Permitir Avaliar
            if (PermitirFuncao(CodPagina, usuario, Funcao) == true)
            {
                if (grid.IsEditing)
                {
                    textbox.Enabled = true;
                }
                if (grid.IsNewRowEditing)
                {
                    textbox.Enabled = true;
                }
            }
            else
            {
                if (grid.IsEditing)
                {
                    textbox.Enabled = false;
                }
                if (grid.IsNewRowEditing)
                {
                    textbox.Enabled = false;
                }
            }
        }
        protected void DValidado_Init(object sender, EventArgs e)
        {
            ASPxDateEdit Data = (ASPxDateEdit)sender;
            GridViewEditFormTemplateContainer templatecontainer = (GridViewEditFormTemplateContainer)Data.NamingContainer;
            ASPxGridView grid = templatecontainer.Grid;
            string CodPagina = "8";
            string Funcao = "2";
            string usuario = Session["IdUser"].ToString(); // Permitir Validar
            if (PermitirFuncao(CodPagina, usuario, Funcao) == true)
            {
                if (grid.IsEditing)
                {
                    Data.Enabled = true;
                }
                if (grid.IsNewRowEditing)
                {
                    Data.Enabled = true;
                }
            }
            else
            {
                if (grid.IsEditing)
                {
                    Data.Enabled = false;
                }
                if (grid.IsNewRowEditing)
                {
                    Data.Enabled = false;
                }
            }
        }
        protected void DAvaliado_Init(object sender, EventArgs e)
        {
            ASPxDateEdit Data = (ASPxDateEdit)sender;
            GridViewEditFormTemplateContainer templatecontainer = (GridViewEditFormTemplateContainer)Data.NamingContainer;
            ASPxGridView grid = templatecontainer.Grid;
            string CodPagina = "8";
            string Funcao = "2";
            string usuario = Session["IdUser"].ToString(); // Permitir Avaliar
            if (PermitirFuncao(CodPagina, usuario, Funcao) == true)
            {
                if (grid.IsEditing)
                {
                    Data.Enabled = true;
                }
                if (grid.IsNewRowEditing)
                {
                    Data.Enabled = true;
                }
            }
            else
            {
                if (grid.IsEditing)
                {
                    Data.Enabled = false;
                }
                if (grid.IsNewRowEditing)
                {
                    Data.Enabled = false;
                }
            }
        }
        protected void ASPxGridView3_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {
            string Nome = Session["Nome"].ToString();
            string Regra = Session["Regra"].ToString();
            string CodPagina = "8";
            string Funcao = "1";
            string usuario = Session["IdUser"].ToString(); // Permitir Validar	
            if (PermitirFuncao(CodPagina, usuario, Funcao) == true)
            {
                e.NewValues["Validado"] = Nome;
            }
            else
            {
                e.NewValues["Validado"] = "";
            }

            string Funcao2 = "1";
            string usuario2 = Session["IdUser"].ToString(); // Permitir Avalidar	
            if (PermitirFuncao(CodPagina, usuario2, Funcao2) == true)
            {
                e.NewValues["Avaliado"] = Nome;
            }
            else
            {
                e.NewValues["Avaliado"] = "";
            }
        }
        protected void ASPxGridView3_CustomButtonCallback(object sender, ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            ASPxGridView grid = (ASPxGridView)sender;
            try
            {
                string keyValue = Session["IDConformidade"].ToString();// grid.GetRowValues(e.VisibleIndex, "EmployeeID").ToString();
                ASPxGridView.RedirectOnCallback(string.Format("Anexo.aspx?id={0}", keyValue));
            }
            catch { }
        }
        protected void btn_Click(object sender, EventArgs e)
        {
            ASPxButton btnLink = (ASPxButton)sender;
            GridViewDataItemTemplateContainer container = (GridViewDataItemTemplateContainer)btnLink.NamingContainer;
            object[] values = (object[])container.Grid.GetRowValues(container.VisibleIndex, new string[] { "lei", "link" });
            try
            {
                string valor = values[1].ToString();
                if (valor != "")
                {
                    Response.Write("<script>window.open('" + valor + "','_blank');</script>");
                }
                else
                {
                    cpPopup3.ShowOnPageLoad = true;
                }
            }
            catch
            {
                cpPopup3.ShowOnPageLoad = true;
            }

        }
        protected void ASPxGridView1_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
        {
            int Periodo = Convert.ToInt32(Session["periodo"].ToString());
            if (e.Column.FieldName == "Dias")
            {
                if (Convert.ToInt32(e.Value) > 0 && Convert.ToInt32(e.Value) < Periodo)
                {
                    e.DisplayText = "(NOVO)";
                }
                else
                {
                    e.DisplayText = " ";
                }
            }
        }
        protected void ASPxGridView1_HtmlDataCellPrepared(object sender, ASPxGridViewTableDataCellEventArgs e)
        {

        }
        protected void ASPxGridView1_SelectionChanged(object sender, EventArgs e)
        {
            invoiceID = Convert.ToInt32(ASPxGridView1.GetSelectedFieldValues("Id")[0].ToString());
            Session["IDLegisGeralC"] = ASPxGridView1.GetSelectedFieldValues("IDLegisGeral")[0].ToString();
            Session["IdUserEmp"] = ASPxGridView1.GetSelectedFieldValues("Id")[0].ToString();
        }
        protected void ASPxGridView1_CustomButtonCallback(object sender, ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            string IDCliente = "";
            string IDLegis = "";
            string IDParametros = "";
            string Obrigacao = "";
            string Evidencias = "";
            string DataAvaliacao = "";
            string Avaliado = "";
            string Anexo = "";
            string DataValidacao = "";
            string Validado = "";
            string ProxAvaliacao = "";
            string Resultado = "";

            if (e.ButtonID != "Avaliar") return;
            string Funcao = "22";
            string usuario = Session["IdUser"].ToString(); // verifica função cadastrar usuario
            //if (PermitirFuncao(usuario, Funcao) == true)
            //{
            //    txtValidado.Enabled = true;
            //    txtDataValidado.Enabled = true;
            //    txtProximaAvaliacao.Enabled = true;
            //    txtResultado.Enabled = true;
            //    txtEvidencias.Enabled = true;
            //}
            //else
            //{
            //    txtValidado.Enabled = false;
            //    txtDataValidado.Enabled = false;
            //    txtProximaAvaliacao.Enabled = false;
            //    txtResultado.Enabled = false;
            //    txtEvidencias.Enabled = false;
            //}
            //lblIdParametro.Text = Session["IDParametros"].ToString();
            //// lblIdConformidade.Text = Session["IDConformidade"].ToString();
            //Session["IDParametros"] = Session["IDParametros"].ToString();
            //lblIdLegis.Text = Session["IDLegisGeral"].ToString();
            //lblIdCliente.Text = Session["IDCli"].ToString();
            //txtAvaliado.Text = Session["Nome"].ToString();
            //txtValidado.Text = Session["Nome"].ToString();
            //pcAvaliarG1.ShowOnPageLoad = true;

            string lblIdCliente = "0";
            string lblIdLegis = "0";
            string lblIdParametro = "0";

            DataTable dt2 = GetConformidade(lblIdCliente, lblIdLegis, lblIdParametro);
            if (dt2.Rows.Count > 0)
            {
                Session["IDConformidade"] = dt2.Rows[0]["id"].ToString();
                IDCliente = dt2.Rows[0]["IDCliente"].ToString();
                Session["IDCliente"] = IDCliente;
                IDLegis = dt2.Rows[0]["IDLegis"].ToString();
                IDParametros = dt2.Rows[0]["IDParametros"].ToString();
                Session["IDParametros"] = dt2.Rows[0]["IDParametros"].ToString();
                Obrigacao = dt2.Rows[0]["Obrigacao"].ToString();
                //txtEvidencias.Text = dt2.Rows[0]["Evidencias"].ToString();
                //txtDataAvaliado.Date = Convert.ToDateTime(dt2.Rows[0]["DataAvaliacao"].ToString());
                //txtAvaliado.Text = dt2.Rows[0]["Avaliado"].ToString();
                ////Anexo = dt2.Rows[0]["Anexo"].ToString();
                //txtDataValidado.Date = Convert.ToDateTime(dt2.Rows[0]["DataValidacao"].ToString());
                //txtValidado.Text = dt2.Rows[0]["Validado"].ToString();
                //txtProximaAvaliacao.Date = Convert.ToDateTime(dt2.Rows[0]["ProxAvaliacao"].ToString());
                //txtResultado.Text = dt2.Rows[0]["Resultado"].ToString();
                //GridAnexo2.DataBind();
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string conexao5 = ConfigurationManager.ConnectionStrings["PortalConnection"].ConnectionString;
            SqlConnection Conn5 = new SqlConnection(conexao5);
            try
            {
                Conn5.Open();
                SqlCommand Cmd5 = new SqlCommand("select * from Legis_Cliente", Conn5);
                SqlDataAdapter Sqlda = new SqlDataAdapter(Cmd5);
                Sqlda.Fill(dt);
                Conn5.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            needToSelectAll = true;

            bool insere = false;

            ASPxGridView gridView = new ASPxGridView();
            int startIndex = GridLegisGeral2.PageIndex * GridLegisGeral2.SettingsPager.PageSize;
            int endIndex = Math.Min(GridLegisGeral2.VisibleRowCount, startIndex + GridLegisGeral2.SettingsPager.PageSize);

            for (int i = startIndex; i < endIndex; i++)
            {
                if (needToSelectAll)
                {
                    ASPxCheckBox cb = (ASPxCheckBox)GridLegisGeral2.FindRowCellTemplateControl(i, (GridViewDataColumn)GridLegisGeral2.Columns["#"], "cbCheck");
                    ASPxCheckBox cb2 = (ASPxCheckBox)GridLegisGeral2.FindRowCellTemplateControl(i, (GridViewDataColumn)GridLegisGeral2.Columns["Aplicavel"], "cbCheck2");
                    if (cb.Checked)
                    {
                        DataRow row = GridLegisGeral2.GetDataRow(i);
                        string idLei = row[0].ToString();
                        string idCliente = Session["IdCli"].ToString(); //Convert.ToString(ddlCliente.Value); // SelectedIndex.ToString();
                        string Aplicavel = "0";
                        //      if (cb2.Checked) Aplicavel = "1";
                        insere = PesquisaLeiCliente(idLei, idCliente); // pesquisa se a lei ja existe para o cliente 
                        if (insere == false) InsereLeisAoCliente(idCliente, idLei, Aplicavel); // se o serualtado for true ignora inclusao, false insere

                        string str = idLei;// this.Session["IDLegisGeral"].ToString();
                        string str1 = idCliente;// e.NewValues["IDCliente"].ToString();

                        if (insere == false)
                        {
                            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["PortalConnection"].ConnectionString);
                            sqlConnection.Open();
                            SqlDataReader sqlDataReader = (new SqlCommand(string.Concat(" SELECT * FROM Parametros where IDLegisGeral = '", str, "' "), sqlConnection)).ExecuteReader();
                            int num = 1;
                            while (sqlDataReader.Read())
                            {
                                string str2 = sqlDataReader["Capitulo"].ToString();
                                string str3 = sqlDataReader["Item"].ToString();
                                string str4 = sqlDataReader["Parametro"].ToString();


                                InsereParametroCliente(str2, str3, str4, "0", str, str1, Convert.ToString(num));
                                num++;
                            }
                            sqlConnection.Close();
                        }

                        GridLegisGeral2.Selection.SetSelection(i, IsCheckBoxVisibleCriteria(row));

                    }
                }
                else
                    GridLegisGeral2.Selection.SetSelection(i, needToSelectAll);
            }

            ASPxPopupControl1.ShowOnPageLoad = false;
            //  Response.Redirect("LegisCliente.aspx");
        }

        protected void GridLegisGeral2_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            needToSelectAll = false;
            bool.TryParse(e.Parameters, out needToSelectAll);

            ASPxGridView gridView = (ASPxGridView)sender;

            int startIndex = gridView.PageIndex * gridView.SettingsPager.PageSize;
            int endIndex = Math.Min(gridView.VisibleRowCount, startIndex + gridView.SettingsPager.PageSize);

            for (int i = startIndex; i < endIndex; i++)
            {
                if (needToSelectAll)
                {
                    ASPxCheckBox cb = (ASPxCheckBox)gridView.FindRowCellTemplateControl(i, (GridViewDataColumn)gridView.Columns["#"], "cbCheck");
                    DataRow row = gridView.GetDataRow(i);
                    gridView.Selection.SetSelection(i, IsCheckBoxVisibleCriteria(row));
                }
                else
                    gridView.Selection.SetSelection(i, needToSelectAll);
            }

        }
        protected void ASPxGridView5_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            needToSelectAll = false;
            bool.TryParse(e.Parameters, out needToSelectAll);

            ASPxGridView gridView = (ASPxGridView)sender;

            int startIndex = gridView.PageIndex * gridView.SettingsPager.PageSize;
            int endIndex = Math.Min(gridView.VisibleRowCount, startIndex + gridView.SettingsPager.PageSize);

            for (int i = startIndex; i < endIndex; i++)
            {
                if (needToSelectAll)
                {
                    ASPxCheckBox cb = (ASPxCheckBox)gridView.FindRowCellTemplateControl(i, (GridViewDataColumn)gridView.Columns["#"], "cbCheck");
                    DataRow row = gridView.GetDataRow(i);
                    gridView.Selection.SetSelection(i, IsCheckBoxVisibleCriteria(row));
                }
                else
                    gridView.Selection.SetSelection(i, needToSelectAll);
            }

        }

        protected void btnIncluirLei_Click(object sender, EventArgs e)
        {
            ASPxPopupControl1.ShowOnPageLoad = true;
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("LegisCliente.aspx");
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string conexao5 = ConfigurationManager.ConnectionStrings["PortalConnection"].ConnectionString;
            SqlConnection Conn5 = new SqlConnection(conexao5);
            try
            {
                Conn5.Open();
                SqlCommand Cmd5 = new SqlCommand("select * from Legis_Cliente", Conn5);
                SqlDataAdapter Sqlda = new SqlDataAdapter(Cmd5);
                Sqlda.Fill(dt);
                Conn5.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            needToSelectAll = true;

            ASPxGridView gridView = new ASPxGridView();
            int startIndex = ASPxGridView5.PageIndex * ASPxGridView5.SettingsPager.PageSize;
            int endIndex = Math.Min(ASPxGridView5.VisibleRowCount, startIndex + ASPxGridView5.SettingsPager.PageSize);

            for (int i = startIndex; i < endIndex; i++)
            {
                if (needToSelectAll)
                {
                    ASPxCheckBox cb = (ASPxCheckBox)ASPxGridView5.FindRowCellTemplateControl(i, (GridViewDataColumn)ASPxGridView5.Columns["#"], "cbCheck3");
                    //ASPxCheckBox cb2 = (ASPxCheckBox)ASPxGridView5.FindRowCellTemplateControl(i, (GridViewDataColumn)ASPxGridView5.Columns["Aplicavel"], "cbCheck3");
                    if (cb.Checked)
                    {
                        DataRow row = ASPxGridView5.GetDataRow(i);
                        string idLei = row[9].ToString();
                        string cliente = Session["IdCli"].ToString();
                        string idCliente = cliente;
                        ExcluiLeisDoCliente(idCliente, idLei);
                        ASPxGridView5.Selection.SetSelection(i, IsCheckBoxVisibleCriteria(row));

                        string str = "";
                        string str1 = cliente;
                        string str2 = idLei;
                        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["PortalConnection"].ConnectionString);
                        sqlConnection.Open();
                        SqlDataReader sqlDataReader = (new SqlCommand(string.Concat(" SELECT * FROM Legis_Cliente where IdCliente = '", str1, "' and IDLegisGeral = '", str2, "' "), sqlConnection)).ExecuteReader();
                        while (sqlDataReader.Read())
                        {
                            str = sqlDataReader["IDCliente"].ToString();
                            str1 = sqlDataReader["IDLegisGeral"].ToString();
                            this.DeleteParametrosCliente(str, str1);
                        }
                        sqlConnection.Close();



                    }
                }
                else
                    ASPxGridView5.Selection.SetSelection(i, needToSelectAll);
            }


            // TODO: your code is here to process the popup window's data at the server
            //   txtMain.Text = txtPopup.Text;
            ASPxPopupControl2.ShowOnPageLoad = false;
            //  Response.Redirect("LegisCliente.aspx");
        }

        protected void ASPxButton3_Click1(object sender, EventArgs e)
        {
            ASPxPopupControl2.ShowOnPageLoad = true;
        }

        protected void btnImportar_Click(object sender, EventArgs e)
        {
            string idCliente2 = Convert.ToString(ddlCliente.Value);
            DataTable dt = new DataTable();
            string conexao5 = ConfigurationManager.ConnectionStrings["PortalConnection"].ConnectionString;
            SqlConnection Conn5 = new SqlConnection(conexao5);
            try
            {
                Conn5.Open();
                SqlCommand Cmd5 = new SqlCommand("select * from Legis_Cliente where IDCliente = '" + idCliente2 + "' ", Conn5);
                SqlDataAdapter Sqlda = new SqlDataAdapter(Cmd5);
                Sqlda.Fill(dt);
                Conn5.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            needToSelectAll = true;

            ASPxGridView gridView = new ASPxGridView();
            int startIndex = GridLegisGeral2.PageIndex * GridLegisGeral2.SettingsPager.PageSize;
            int endIndex = Math.Min(GridLegisGeral2.VisibleRowCount, startIndex + GridLegisGeral2.SettingsPager.PageSize);

            for (int i = startIndex; i < endIndex; i++)
            {
                if (needToSelectAll)
                {
                    ASPxCheckBox cb = (ASPxCheckBox)GridLegisGeral2.FindRowCellTemplateControl(i, (GridViewDataColumn)GridLegisGeral2.Columns["#"], "cbCheck");
                    ASPxCheckBox cb2 = (ASPxCheckBox)GridLegisGeral2.FindRowCellTemplateControl(i, (GridViewDataColumn)GridLegisGeral2.Columns["Aplicavel"], "cbCheck2");

                    DataRow row = GridLegisGeral2.GetDataRow(i);
                    string idLei = row[0].ToString();
                    string idCliente = Session["IdCli"].ToString(); //Convert.ToString(ddlCliente.Value); // SelectedIndex.ToString();
                    string Aplicavel = "0";
                    //     if (cb2.Checked) Aplicavel = "1";
                    InsereLeisAoCliente(idCliente, idLei, Aplicavel);

                    string str = idLei;// this.Session["IDLegisGeral"].ToString();
                    string str1 = idCliente;// e.NewValues["IDCliente"].ToString();
                    SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["PortalConnection"].ConnectionString);
                    sqlConnection.Open();
                    string comandostr = " SELECT * FROM Parametros where IDLegisGeral = '" + str + "' ";
                    SqlDataReader sqlDataReader = (new SqlCommand(comandostr, sqlConnection)).ExecuteReader();
                    int num = 1;
                    while (sqlDataReader.Read())
                    {
                        string str2 = sqlDataReader["Capitulo"].ToString();
                        string str3 = sqlDataReader["Item"].ToString();
                        string str4 = sqlDataReader["Parametro"].ToString();
                        this.InsereParametroCliente(str2, str3, str4, "0", str, str1, Convert.ToString(num));
                        num++;
                    }
                    sqlConnection.Close();


                    GridLegisGeral2.Selection.SetSelection(i, IsCheckBoxVisibleCriteria(row));


                }
                else
                    GridLegisGeral2.Selection.SetSelection(i, needToSelectAll);
            }
            ASPxPopupControl2.ShowOnPageLoad = false;
            //  Response.Redirect("LegisCliente.aspx");
        }

        protected void btnLicenca_Click(object sender, EventArgs e)
        {
            ASPxPopupControl3.ShowOnPageLoad = true;
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

        protected void ASPxButton35_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/HomeCli.aspx");
        }
    }
}