using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PlatinDashboard.Presentation.MVC.Paginas
{
    public partial class Importar : System.Web.UI.Page
    {
        public bool ImportaExcel(string COMANDO)
        {
            bool gravado = false;
            string connection = ConfigurationManager.ConnectionStrings["PortalConnection"].ConnectionString;
            SqlConnection Conn = new SqlConnection(connection);
            Conn.Open();
            try
            {
                string Hora = Convert.ToString(DateTime.Now.TimeOfDay).Substring(0, 8);
                SqlCommand Cmd = new SqlCommand(COMANDO, Conn);
                Cmd.ExecuteNonQuery();
                Conn.Close();
                gravado = true;
                lblResultado.Text = "IMPORTAÇÃO EFETUADA COM SUCESSO!!";
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                lblResultado.Text = "ERRO DURANTE A IMPORTAÇÃO: " + ex.Message;
            }

            return gravado;

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["CodPagina"] = "0";

                System.Data.DataTable dtA = new System.Data.DataTable();
                string conexao5 = ConfigurationManager.ConnectionStrings["PortalConnection"].ConnectionString;
                SqlConnection Conn5 = new SqlConnection(conexao5);
                Conn5.Open();
                SqlCommand Cmd5 = new SqlCommand("select  IDENT_CURRENT ('LegisGeral') as Valor ", Conn5);
                SqlDataAdapter Sqlda = new SqlDataAdapter(Cmd5);
                Sqlda.Fill(dtA);
                if (dtA.Rows.Count > 0)
                {
                    int valor = Convert.ToInt32(dtA.Rows[0]["Valor"].ToString().Trim());
                    valor++;
                    lblValor.Text = Convert.ToString(valor);
                }
                else
                {
                    lblValor.Text = "Erro ao recuperar valor!";
                }
                Conn5.Close();
            }
            //try
            //{
            //    Session["Erro"] = " ";
            //    string CodPagina = "19";
            //    string CodUsuario = Session["IdUser"].ToString();
            //    string CodFuncao = "0"; // acesso
            //    //if (PermitirFuncao(CodPagina, CodUsuario, CodFuncao) == false)
            //    //{
            //    //    Response.Redirect("Erro.aspx");
            //    //}
            //}
            //catch (Exception ex)
            //{
            //    string Erro = "INFORME AO ADMINISTRADOR O SEGUINTE ERRO: " + ex.ToString();
            //    Session["Erro"] = Erro;
            //    Response.Redirect("Erro.aspx");
            //}
        }

        protected void ASPxButton1_Click(object sender, EventArgs e)
        {
            string str = "Legisig.xlsx";
            base.Response.ContentType = "application/octet-stream";
            base.Response.AppendHeader("Content-Disposition", string.Concat("attachment;filename=", str));
            base.Response.TransmitFile(base.Server.MapPath(string.Concat("~/Arquivo/", str)));
            base.Response.End();
            //string filename = "~/Arquivo/Legisig.xlsx";
            //try
            //{
            //    string strURL = filename;
            //    WebClient req = new WebClient();
            //    HttpResponse response = HttpContext.Current.Response;
            //    response.Clear();
            //    response.ClearContent();
            //    response.ClearHeaders();
            //    response.Buffer = true;
            //    response.AddHeader("Content-Disposition", "attachment;filename=\"" + Server.MapPath(filename) + " ");
            //    byte[] data = req.DownloadData(Server.MapPath(strURL));
            //    response.BinaryWrite(data);
            //    response.End();
            //}
            //catch (Exception ex)
            //{
            //}

        }

        public bool InserirDados(string comando)
        {
            bool flag = false;
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["PortalConnection"].ConnectionString);
            sqlConnection.Open();
            try
            {
                DateTime now = DateTime.Now;
                Convert.ToString(now.TimeOfDay).Substring(0, 8);
                (new SqlCommand(comando, sqlConnection)).ExecuteNonQuery();
                sqlConnection.Close();
                flag = true;
            }
            catch (SqlException ex)
            {
                this.lblResultado.Text = ex.ToString();
            }
            return flag;
        }

        protected void ASPxButton2_Click(object sender, EventArgs e)
        {
            string connString = "";
            string strFileType = Path.GetExtension(FileUpload1.FileName).ToLower();
            string path = FileUpload1.PostedFile.FileName;
            if (path != "")
            {
                string excelPath = Server.MapPath("~/Content/") + Path.GetFileName(FileUpload1.PostedFile.FileName);
                if (FileUpload1.HasFile)
                {
                    try
                    {
                        //if (FileUpload1.PostedFile.ContentType == "xlsx/xls")
                        //{
                        if (FileUpload1.PostedFile.ContentLength < 1102400)
                        {
                            string filename = Path.GetFileName(FileUpload1.FileName);
                            FileUpload1.SaveAs(Server.MapPath("~/Content/") + filename);
                            lblResultado.Text = "Dados csrregados com sucessso!!!!";
                        }
                        else
                            lblResultado.Text = "TAMANHO IRREGULAR AO CARREGAR PLANILHA!!!!!";
                        //}
                        //else
                        //    lblResultado.Text = "Upload status: Only JPEG files are accepted!";
                    }
                    catch (Exception ex)
                    {
                        lblResultado.Text = "ERRO AO CARREGAR PLANILHA: " + ex.Message;
                    }
                }


                if (strFileType.Trim() == ".xls")
                {
                    connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
                }
                else if (strFileType.Trim() == ".xlsx")
                {
                    // connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + excelPath + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
                    connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excelPath + ";Extended Properties='Excel 12.0 Xml;HDR=YES;'";
                    //  connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                }
                // conStr = String.Format(conStr, FilePath, isHDR);
                OleDbConnection connExcel = new OleDbConnection(connString);
                OleDbCommand cmdExcel = new OleDbCommand();
                OleDbDataAdapter oda = new OleDbDataAdapter();
                DataTable dt = new DataTable();
                cmdExcel.Connection = connExcel;

                //Get the name of First Sheet
                connExcel.Open();
                DataTable dtExcelSchema;
                dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string SheetName = "Lei$";// dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                string SheetName2 = "Parametro$";// dtExcelSchema.Rows[1]["TABLE_NAME"].ToString();
                connExcel.Close();

                try
                {
                    //Read Data from First Sheet  ++++ LEIS ++++
                    string COMANDO = "";
                    connExcel.Open();
                    cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";
                    oda.SelectCommand = cmdExcel;
                    oda.Fill(dt);
                    foreach (DataRow Row in dt.Rows)
                    {
                        string CODIGO = Row["Id"].ToString().Trim();
                        string SISTEMA = Row["SISTEMA"].ToString().Trim();
                        string AMBITO = Row["AMBITO"].ToString().Trim();
                        string ESTADO = Row["ESTADO"].ToString().Trim();
                        string MUNICIPIO = Row["MUNICIPIO"].ToString().Trim();
                        string NUMERO = Row["NUMERO"].ToString().Trim();
                        string ANO = Row["ANO"].ToString().Trim();
                        string ORGAO = Row["ORGAO"].ToString().Trim();
                        string TEMA = Row["TEMA"].ToString().Trim();
                        string EMENTA = Row["EMENTA"].ToString().Trim();
                        string TIPO = Row["TIPO"].ToString().Trim();
                        string SITUACAO = Row["STATUS"].ToString().Trim();
                        string DATA = Row["DATA"].ToString().Trim();
                        string LINK = Row["LINK"].ToString().Trim();
                        string NORMAS = Row["NORMAS"].ToString().Trim();
                        string DATA2 = "7/1/2017 4:27:27 AM";

                        DateTime.Now.ToString().Trim();//2017-06-20 02/12/2018
                                                       // DATA2 = DATA2.Substring(6, 4) + "-" + DATA2.Substring(3, 2) + "-" + DATA2.Substring(0, 2);

                        if (SISTEMA != "")
                        {
                            COMANDO = COMANDO + "  INSERT INTO[dbo].[LegisGeral] ([Id], [Sistema], [Ambito], [Numero], [Ano], [Orgao], [Tema], [Ementa], [Tipo], [lei], [Link], [Estado], [Municipio], [Pais], [Data], [Arqpdf]) " +
                            " VALUES('" + CODIGO + "','" + SISTEMA + "','" + AMBITO + "','" + NUMERO + "','" + ANO + "','" + ORGAO + "','" + TEMA + "','" + EMENTA + "','" + TIPO + "','" + SITUACAO + "','" + LINK + "','" + ESTADO + "','" + MUNICIPIO + "','Brasil','" + DATA2 + "','" + NORMAS + "')  ";
                        }
                    }
                    connExcel.Close();

                    string SQL = "SET IDENTITY_INSERT [dbo].[LegisGeral] ON " + COMANDO + " SET IDENTITY_INSERT [dbo].[LegisGeral] OFF";
                    SQL = SQL.Replace("d'", "d");
                    ImportaExcel(SQL);
                    //lblResultado.Text = SQL;
                }
                catch (Exception ex)
                {
                    lblResultado.Text = "ERRO DURANTE IMPORTAÇÃO DE LEIS: " + ex.Message;
                    return;
                }
                //Read Data from First Sheet  ++++ PARAMETROS ++++
                try
                {
                    string COMANDO = "";
                    connExcel.Open();
                    cmdExcel.CommandText = "SELECT * From [" + SheetName2 + "]";
                    oda.SelectCommand = cmdExcel;
                    oda.Fill(dt);
                    foreach (DataRow Row2 in dt.Rows)
                    {
                        string CODIGO = Row2["Id"].ToString().Trim();
                        string CAPITULO = Row2["CAPITULO"].ToString().Trim();
                        string ITEM = Row2["ITEM"].ToString().Trim();
                        string PARAMETROS = Row2["PARAMETRO"].ToString().Trim();
                        string OBRIGACAO = Row2["Obrigacao"].ToString().Trim();
                        if (OBRIGACAO == "Sim") OBRIGACAO = "1";
                        if (OBRIGACAO == "Não") OBRIGACAO = "0";
                        string CONHECIMENTO = Row2["Conhecimento"].ToString().Trim();
                        if (CONHECIMENTO == "Sim") CONHECIMENTO = "1";
                        if (CONHECIMENTO == "Não") CONHECIMENTO = "0";

                        if (ITEM != "")
                        {
                            COMANDO = COMANDO + " INSERT INTO[dbo].[Parametros] ([IDLegisGeral],[Capitulo], [Item], [Parametro], [Obrigacao], [Conhecimento]) " +
                                " VALUES('" + CODIGO + "','" + CAPITULO + "','" + ITEM + "','" + PARAMETROS + "','" + OBRIGACAO + "','" + CONHECIMENTO + "')";
                        }
                    }
                    connExcel.Close();
                    string SQL2 = COMANDO;// "SET IDENTITY_INSERT [dbo].[Parametros] ON " + COMANDO + " SET IDENTITY_INSERT [dbo].[Parametros] OFF";
                    SQL2 = SQL2.Replace("d'", "d");
                    ImportaExcel(SQL2);

                }
                catch (Exception ex)
                {
                    lblResultado.Text = "ERRO DURANTE IMPORTAÇÃO DE PARAMETROS: " + ex.Message;
                    return;
                }

            }
            else
            {
                lblResultado.Text = "ESCOLHA ALGUMA PLANILHA ANTES DE IMPORTAR!";
                return;
            }




        }


        protected void FileUpload1_DataBinding(object sender, EventArgs e)
        {
            //Upload and save the file
            string excelPath = Server.MapPath("~/Content/") + Path.GetFileName(FileUpload1.PostedFile.FileName);
            FileUpload1.SaveAs(excelPath);

            string conString = string.Empty;
            string extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
            switch (extension)
            {
                case ".xls": //Excel 97-03
                    conString = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                    break;
                case ".xlsx": //Excel 07 or higher
                    conString = ConfigurationManager.ConnectionStrings["Excel07ConString"].ConnectionString;
                    break;

            }
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            string SQL2 = "DBCC CHECKIDENT('LegisGeral', RESEED, " + txtNumero.Text + ");";

            ImportaExcel(SQL2);

            lblResultado.Text = "NUMERAÇÃO ENVIADA!! (ATUALIZE A PÁGINA PARA VISUALIZAR)";
        }

        protected void ASPxButton3_Click(object sender, EventArgs e)
        {
            Session["pdf"] = "apostila.pdf";
            Response.Redirect("VerPdf.aspx");
            //  urIframe.Attributes.Add("src", "apostila.pdf");
            //Stream stream = GetResourceStream("LoadDocumentFromStream.Demo.pdf");
            //pdfViewer1.LoadDocument(stream);
        }
    }
}