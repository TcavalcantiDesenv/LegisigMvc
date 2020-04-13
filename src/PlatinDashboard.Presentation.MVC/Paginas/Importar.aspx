<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Importar.aspx.cs" Inherits="PlatinDashboard.Presentation.MVC.Paginas.Importar" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="~/Scripts/viewsjs/index.js"></script>
    <script src="~/Scripts/viewsjs/companyindex.js"></script>
    <script src="~/Scripts/viewsjs/changeclient.js"></script>
    <script>
        $(document).ready(function () {
            loadClientes();
            initializeCompanyTable();
        });
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <link href="~/Content/bootstrap-theme.min.css" rel="stylesheet" />
        <link href="../Content/bootstrap.min.css" rel="stylesheet" />
        <div>
            <div class="card">
                <div class="card-body">
                    <div class="container">
                        <div class="row">
                            <section class="col-md-8 marginTop40">
                                <h3>Importação de Leis e Parametros</h3>
                                <p>
                                    Desabile o acesso às telas de cadastro de Leis e Parametros dos usuários Adm-1 para evitar alteração do código sequencial.
                                </p>
                                <p>
                                    Ao utilizar a planilha de importação leve em conta o Numero sequencial a partir de:
                <dx:ASPxLabel ID="lblValor" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Red" Text="0000" Theme="PlasticBlue">
                </dx:ASPxLabel>
                                </p>
                                <h3>Enviar Planilha Cadastrada</h3>
                                <p>
                                    <a>Planilha :  
                        <asp:FileUpload ID="FileUpload1" runat="server" OnDataBinding="FileUpload1_DataBinding" />
                                    </a>
                                </p>
                                <p>
                                    &nbsp;
                                </p>
                                <h3>Corrigir Numeração</h3>
                                <p>
                                    <a>Proximo Numero :  
                        <asp:TextBox ID="txtNumero" runat="server"></asp:TextBox>
                                    </a>
                                </p>
                                <p>
                                    <dx:ASPxButton ID="btnEnviar" runat="server" Text="Corrigir" OnClick="btnEnviar_Click" Theme="Aqua"></dx:ASPxButton>
                                </p>
                                <hr class="marginTop40 visible-sm visible-xs" />
                            </section>
                            <aside class="col-md-4 marginTop40">
                                <h3>Planilha de importação</h3>
                                <p>
                                    Faça o download padrão de importação obedecendo rigorosamente a estrutura e o relacionamento entre os códigos de leis e parametros.<br />
                                    <br />

                                    <a>
                                        <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Baixar Planilha" Theme="DevEx" OnClick="ASPxButton1_Click">
                                        </dx:ASPxButton>
                                    </a>
                                </p>
                                <p>
                                    <a>
                                        <dx:ASPxButton ID="ASPxButton2" runat="server" Text="Iniciar Importação" Theme="DevEx" OnClick="ASPxButton2_Click">
                                        </dx:ASPxButton>
                                    </a>
                                </p>

                                <p>
                                    &nbsp;
                                </p>

                            </aside>

                            <aside class="col-md-4 marginTop40">
                                <p>
                                    <dx:ASPxLabel ID="lblResultado" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Red" Text=" " Theme="PlasticBlue">
                                    </dx:ASPxLabel>
                                </p>
                            </aside>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </form>
</body>
</html>
