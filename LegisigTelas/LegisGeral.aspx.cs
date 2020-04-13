using DevExpress.Export;
using DevExpress.Web;
using DevExpress.XtraPrinting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LegisigTelas
{
    public partial class LegisGeral : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["CodPagina"] = "0";
                //ddlExportMode.Items.AddRange(Enum.GetNames(typeof(GridViewDetailExportMode)));
                //ddlExportMode.Text = GridViewDetailExportMode.Expanded.ToString();

                DataTable dt = new DataTable();
                string conexao = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                SqlConnection connection = new SqlConnection(conexao);
                connection.Open();
                SqlCommand sqlCmd = new SqlCommand("SELECT *  FROM Config ", connection);
                SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
                sqlDa.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Session["emailpara"] = dt.Rows[0]["emailpara"].ToString().Trim();
                    Session["email"] = dt.Rows[0]["email"].ToString().Trim();
                    Session["senha"] = dt.Rows[0]["senha"].ToString().Trim();
                    Session["porta"] = dt.Rows[0]["porta"].ToString().Trim();
                    Session["semana"] = dt.Rows[0]["semana"].ToString().Trim();
                    Session["periodo"] = dt.Rows[0]["periodo"].ToString().Trim();
                }
                connection.Close();
            }
   
        }


        protected void GridParametrosClientes_BeforePerformDataSelect(object sender, EventArgs e)
        {
            Session["IDLegisGeral"] = (sender as ASPxGridView).GetMasterRowKeyValue();
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
                    cpPopup3.ShowOnPageLoad = true;
                }
            }
            catch
            {
                cpPopup3.ShowOnPageLoad = true;
            }

        }
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
        protected void ASPxButton1_Click(object sender, EventArgs e)
        {
            UpdateExportMode();
            gridExport.WritePdfToResponse();
        }
        protected void ASPxButton4_Click(object sender, EventArgs e)
        {
            UpdateExportMode();
            gridExport.WriteRtfToResponse();
        }
        protected void ASPxButton3_Click(object sender, EventArgs e)
        {
            UpdateExportMode();
            gridExport.WriteXlsxToResponse(new XlsxExportOptionsEx() { ExportType = ExportType.WYSIWYG });
        }
        protected void UpdateExportMode()
        {
            //GridLegisCliente.SettingsDetail.ExportMode = (GridViewDetailExportMode)Enum.Parse(typeof(GridViewDetailExportMode), ddlExportMode.Text);
        }
        protected void GridLegisCliente_HtmlDataCellPrepared(object sender, ASPxGridViewTableDataCellEventArgs e)
        {
            if (e.DataColumn.FieldName == "Dias")
                e.Cell.ForeColor = System.Drawing.Color.Red;
        }
        protected void GridLegisCliente_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
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

            if (e.Column.FieldName == "Dias")
            {
                if (e.DisplayText != "(NOVO)")
                {
                }
            }

            //if (e.Column.FieldName == "Ementa")
            //{
            //    try
            //    {
            //        e.DisplayText = e.Value.ToString().Substring(0, 13);
            //    }
            //    catch (Exception)
            //    {

            //    }

            //}
            //if (e.Column.FieldName == "Tema")
            //{
            //    try
            //    {
            //        e.DisplayText = e.Value.ToString().Substring(0, 13);
            //    }
            //    catch (Exception)
            //    {

            //    }
            //}

        }
    }
}