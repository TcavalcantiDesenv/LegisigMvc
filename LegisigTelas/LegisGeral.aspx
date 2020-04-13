<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="LegisGeral.aspx.cs" Inherits="LegisigTelas.LegisGeral" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    <html>
    <head>
        <script type="text/javascript">
            function OnToolbarItemClick(s, e) {
                if (IsCustomExportToolbarCommand(e.item.name)) {
                    e.processOnServer = true;
                    e.usePostBack = true;
                }
            }
            function IsCustomExportToolbarCommand(command) {
                return command == "CustomExportToXLS" || command == "CustomExportToXLSX";
            }
        </script>
        <style type="text/css">
            .truncated {
                white-space: nowrap;
                overflow: hidden;
                text-overflow: ellipsis;
            }
        </style>
        <style type="text/css">
            .customClass {
                text-overflow: ellipsis;
            }
        </style>
        <title></title>
    </head>
    <body>
        <asp:Panel ID="Panel1" runat="server" Visible="false">
            <table>
                <tr>
                    <%--                <td>
                    <dx:ASPxComboBox runat="server" ID="ddlExportMode" Caption="Modo de Exportação: " EnableTheming="True" Theme="DevEx">
                        <RootStyle CssClass="OptionsBottomMargin"></RootStyle>
                        <CaptionCellStyle>
                            <Paddings PaddingRight="4px" />
                        </CaptionCellStyle>
                    </dx:ASPxComboBox>
                </td>--%>
                    <td>
                        <dx:ASPxButton ID="ASPxButton1" runat="server" Theme="DevEx" OnClick="ASPxButton1_Click">
                            <Image IconID="export_exporttopdf_32x32">
                            </Image>
                        </dx:ASPxButton>
                    </td>
                    <td>
                        <dx:ASPxButton ID="ASPxButton4" runat="server" Theme="DevEx" OnClick="ASPxButton4_Click">
                            <Image IconID="export_exporttodoc_32x32">
                            </Image>
                        </dx:ASPxButton>
                    </td>
                    <td>
                        <dx:ASPxButton ID="ASPxButton3" runat="server" Theme="DevEx" OnClick="ASPxButton3_Click">
                            <Image IconID="export_exporttoxls_32x32">
                            </Image>
                        </dx:ASPxButton>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
        <dx:ASPxGridView ID="GridLegisCliente" runat="server" DataCellPrepared="GridLegisCliente_HtmlDataCellPrepared" AutoGenerateColumns="False" DataSourceID="SqlLegisGeral" KeyFieldName="Id" Width="100%" Theme="Office2010Blue" OnCustomColumnDisplayText="GridLegisCliente_CustomColumnDisplayText" OnHtmlDataCellPrepared="GridLegisCliente_HtmlDataCellPrepared">
            <SettingsDetail ShowDetailRow="True" />
            <Templates>
                <DetailRow>
                    <dx:ASPxGridView ID="GridParametros" runat="server" Width="100%" AutoGenerateColumns="False" DataSourceID="SqlParametros" OnBeforePerformDataSelect="GridParametrosClientes_BeforePerformDataSelect" KeyFieldName="Id" Theme="Office2010Silver">
<%--                        <SettingsCommandButton>
                            <NewButton Text="Novo">
                            </NewButton>
                            <UpdateButton Text="Gravar">
                            </UpdateButton>
                            <CancelButton Text="Cancelar">
                            </CancelButton>
                            <EditButton Text="Editar">
                            </EditButton>
                            <DeleteButton Text="Excluir">
                            </DeleteButton>
                        </SettingsCommandButton>--%>
                        <SettingsLoadingPanel Mode="Disabled" />
                        <ClientSideEvents BeginCallback="function(s, e) {loadingPanel.Show();}"
                            EndCallback="function(s, e) {loadingPanel.Hide();}" />

                        <Toolbars>
                            <dx:GridViewToolbar ItemAlign="Left" EnableAdaptivity="true">
                                <Items>
                                    <dx:GridViewToolbarItem Command="New" Text="Cadastrar" />
                                    <dx:GridViewToolbarItem Command="Edit" Text="Editar" />
                                    <dx:GridViewToolbarItem Command="Delete" Text="Excluir" />
                                    <dx:GridViewToolbarItem Command="Refresh" Text="Atualizar" BeginGroup="true" />
                                    <dx:GridViewToolbarItem Text="Exportar" Image-IconID="actions_download_16x16office2013" BeginGroup="true">
                                        <Items>
                                            <dx:GridViewToolbarItem Name="CustomExportToXLS" Text="Export to XLS(WYSIWYG)" Image-IconID="export_exporttoxls_16x16office2013" />
                                            <dx:GridViewToolbarItem Name="CustomExportToXLSX" Text="Export to XLSX(WYSIWYG)" Image-IconID="export_exporttoxlsx_16x16office2013" />
                                        </Items>
                                    </dx:GridViewToolbarItem>
                                    <dx:GridViewToolbarItem BeginGroup="true">
                                        <Template>
                                            <dx:ASPxButtonEdit ID="tbToolbarSearch" runat="server" NullText="buscar..." Height="100%">
                                                <Buttons>
                                                    <dx:SpinButtonExtended Image-IconID="find_find_16x16gray" />
                                                </Buttons>
                                            </dx:ASPxButtonEdit>
                                        </Template>
                                    </dx:GridViewToolbarItem>
                                </Items>
                            </dx:GridViewToolbar>
                        </Toolbars>

                        <Columns>
                            <dx:GridViewDataTextColumn FieldName="Id" ReadOnly="True" VisibleIndex="3" Visible="False">
                                <EditFormSettings Visible="False" />
                            </dx:GridViewDataTextColumn>
                            <%--                        <dx:GridViewDataTextColumn Caption="Codigo" FieldName="IDLegisGeral" VisibleIndex="0" Visible="true">
                        </dx:GridViewDataTextColumn>--%>
                            <dx:GridViewDataTextColumn FieldName="Capitulo" Caption="Título da Lei" VisibleIndex="2">
                                   <Settings AllowEllipsisInText="True" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Item" Caption="Capítulo da Lei" VisibleIndex="3">
                                   <Settings AllowEllipsisInText="True" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataMemoColumn FieldName="Parametro" PropertiesMemoEdit-Height="150px" Caption="Descrição" VisibleIndex="4">
                                   <Settings AllowEllipsisInText="True" />
                            </dx:GridViewDataMemoColumn>
                            <dx:GridViewDataTextColumn FieldName="Numero" VisibleIndex="5">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataCheckColumn FieldName="Obrigacao" VisibleIndex="6">
                                <PropertiesCheckEdit ValueType="System.Int32" ValueChecked="1" ValueUnchecked="0"></PropertiesCheckEdit>
                            </dx:GridViewDataCheckColumn>
                            <dx:GridViewDataCheckColumn FieldName="Aplicavel" Caption="Aplicavel" VisibleIndex="7">
                                <PropertiesCheckEdit ValueType="System.Int32" ValueChecked="1" ValueUnchecked="0"></PropertiesCheckEdit>
                            </dx:GridViewDataCheckColumn>
                            <dx:GridViewDataCheckColumn FieldName="Conhecimento" Caption="Conhecimento" VisibleIndex="8">
                                <PropertiesCheckEdit ValueType="System.Int32" ValueChecked="1" ValueUnchecked="0"></PropertiesCheckEdit>
                            </dx:GridViewDataCheckColumn>
                            <dx:GridViewDataTextColumn FieldName="IDCliente" VisibleIndex="11" Visible="False">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="lei" VisibleIndex="10" Visible="False">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="param" VisibleIndex="9" Visible="False">
                            </dx:GridViewDataTextColumn>
                        </Columns>
                        
                        <SettingsSearchPanel CustomEditorID="tbToolbarSearch" />
                        <EditFormLayoutProperties ColCount="2">
                            <Items>
                                <dx:GridViewColumnLayoutItem ColumnName="Capitulo" />
                                <dx:GridViewColumnLayoutItem ColumnName="Item" />
                                <dx:GridViewColumnLayoutItem ColumnName="Parametro" />
                                <dx:GridViewColumnLayoutItem ColumnName="Numero" />
                                <dx:EditModeCommandLayoutItem ColSpan="2" HorizontalAlign="Right" />
                            </Items>
                        </EditFormLayoutProperties>

                        <Styles>
                            <AlternatingRow Enabled="True">
                            </AlternatingRow>
                        </Styles>
                        <Settings ShowHeaderFilterButton="true" ShowFooter="True" ShowTitlePanel="True" />
                        <%-- ShowTitlePanel="True"--%>
                        <SettingsBehavior AllowFocusedRow="True" EnableRowHotTrack="True" />

                        <SettingsSearchPanel Visible="True" />
                        <SettingsText Title="Parametros" />
                    </dx:ASPxGridView>
                </DetailRow>
            </Templates>
            <%--  ShowTitlePanel="True"--%>
            <Settings ShowHeaderFilterButton="true" ShowFooter="True" />
            <SettingsBehavior AllowFocusedRow="True" EnableRowHotTrack="True" />
            <SettingsLoadingPanel Mode="Disabled" />
            <ClientSideEvents BeginCallback="function(s, e) {
	loadingPanel.Show();
}"
                EndCallback="function(s, e) {
	loadingPanel.Hide();
}" />
            <Columns>
                <dx:GridViewCommandColumn ShowDeleteButton="True" VisibleIndex="0" ShowNewButtonInHeader="True" ShowEditButton="True" Visible="False">
                    <CustomButtons>

                    </CustomButtons>
                </dx:GridViewCommandColumn>

                <dx:GridViewDataTextColumn Caption="Codigo" FieldName="Id" Visible="false" ReadOnly="True" VisibleIndex="1">
                    <EditFormSettings Visible="False"></EditFormSettings>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataComboBoxColumn FieldName="Sistema" VisibleIndex="2">
                    <Settings AllowEllipsisInText="True" />
                    <PropertiesComboBox DataSourceID="SqlSistemas" TextField="Sistema" ValueField="Sistema"></PropertiesComboBox>
                </dx:GridViewDataComboBoxColumn>
                <dx:GridViewDataComboBoxColumn FieldName="Ambito" VisibleIndex="3">
                    <PropertiesComboBox DataSourceID="SqlAmbito" TextField="Descricao" ValueField="Descricao"></PropertiesComboBox>
                </dx:GridViewDataComboBoxColumn>
                <dx:GridViewDataComboBoxColumn FieldName="Estado" VisibleIndex="4">
                    <PropertiesComboBox DataSourceID="SqlEstados" TextField="Nome" ValueField="Nome"></PropertiesComboBox>
                </dx:GridViewDataComboBoxColumn>
                <dx:GridViewDataComboBoxColumn FieldName="Municipio" VisibleIndex="5">
                    <Settings AllowEllipsisInText="True" />
                    <PropertiesComboBox DataSourceID="SqlCidades" TextField="Nome" ValueField="Nome"></PropertiesComboBox>
                </dx:GridViewDataComboBoxColumn>
                <dx:GridViewDataTextColumn FieldName="Pais" VisibleIndex="6"></dx:GridViewDataTextColumn>
                <dx:GridViewDataComboBoxColumn FieldName="Orgao" VisibleIndex="7">
                    <Settings AllowEllipsisInText="True" />
                    <PropertiesComboBox DataSourceID="SqlOrgao" TextField="Descricao" ValueField="Descricao"></PropertiesComboBox>
                </dx:GridViewDataComboBoxColumn>
                <dx:GridViewDataTextColumn FieldName="Numero" VisibleIndex="8"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="Ano" VisibleIndex="9"></dx:GridViewDataTextColumn>
                <dx:GridViewDataComboBoxColumn FieldName="Tipo" VisibleIndex="10">
                    <Settings AllowEllipsisInText="True" />
                    <PropertiesComboBox DataSourceID="SqlTipos" TextField="Descricao" ValueField="Descricao"></PropertiesComboBox>
                </dx:GridViewDataComboBoxColumn>
                <dx:GridViewDataMemoColumn FieldName="Ementa" Width="100px" VisibleIndex="11">
                    <Settings AllowEllipsisInText="True" />
                </dx:GridViewDataMemoColumn>
                <dx:GridViewDataMemoColumn FieldName="Tema" VisibleIndex="12">
                    <Settings AllowEllipsisInText="True" />
                </dx:GridViewDataMemoColumn>
                <dx:GridViewDataComboBoxColumn Caption="Situação" FieldName="lei" VisibleIndex="13">
                    <PropertiesComboBox>
                        <Items>
                            <dx:ListEditItem Text="Ativo" Value="Ativo" />
                            <dx:ListEditItem Text="Cancelado" Value="Cancelado" />
                            <dx:ListEditItem Text="Revogado" Value="Revogado" />
                            <dx:ListEditItem Text="Alterado" Value="Alterado" />
                        </Items>
                    </PropertiesComboBox>
                </dx:GridViewDataComboBoxColumn>
                <dx:GridViewDataTextColumn FieldName="Arqpdf" Caption="Normas" Visible="False" VisibleIndex="15">
                    <EditFormSettings Visible="True"></EditFormSettings>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn VisibleIndex="16" AllowTextTruncationInAdaptiveMode="true">
                    <EditFormSettings Visible="False" VisibleIndex="15" />
                    <DataItemTemplate>
                        <dx:ASPxButton ID="link" runat="server" Width="30px" OnClick="btnLink_Click" Theme="DevEx">
                            <Image IconID="businessobjects_bolocalization_16x16">
                            </Image>
                        </dx:ASPxButton>
                    </DataItemTemplate>
                </dx:GridViewDataTextColumn>

                <dx:GridViewDataTextColumn FieldName="link" VisibleIndex="17" Visible="False">
                    <EditFormSettings Visible="True"></EditFormSettings>
                </dx:GridViewDataTextColumn>


                <dx:GridViewDataColumn FieldName="Dias" Caption="Status" Visible="true" VisibleIndex="14">
                    <EditFormSettings Visible="False"></EditFormSettings>
                </dx:GridViewDataColumn>

                <dx:GridViewDataTextColumn VisibleIndex="19" AllowTextTruncationInAdaptiveMode="true">
                    <EditFormSettings Visible="False" VisibleIndex="20" />
                    <DataItemTemplate>
                        <dx:ASPxButton ID="link2" runat="server" Width="30px" OnClick="btnLink2_Click" Theme="DevEx">
                            <Image IconID="export_exporttopdf_16x16office2013">
                            </Image>
                        </dx:ASPxButton>
                    </DataItemTemplate>
                </dx:GridViewDataTextColumn>

                <dx:GridViewDataTextColumn FieldName="param" VisibleIndex="22" Visible="False">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataButtonEditColumn VisibleIndex="21">
                </dx:GridViewDataButtonEditColumn>
            </Columns>
               <SettingsSearchPanel CustomEditorID="tbToolbarSearch" />
            <Toolbars>
                <dx:GridViewToolbar ItemAlign="Left" EnableAdaptivity="true">
                    <Items>
                        <dx:GridViewToolbarItem Command="New" Text="Cadastrar" />
                        <dx:GridViewToolbarItem Command="Edit" Text="Editar" />
                        <dx:GridViewToolbarItem Command="Delete" Text="Excluir" />
<%--                         <dx:GridViewToolbarItem Command="Update" Text="Gravar" />--%>
                        <dx:GridViewToolbarItem Command="Refresh" Text="Atualizar" BeginGroup="true" />
                        <dx:GridViewToolbarItem Text="Exportar" Image-IconID="actions_download_16x16office2013" BeginGroup="true">
                            <Items>
                                <dx:GridViewToolbarItem Name="CustomExportToXLS" Text="Export to XLS(WYSIWYG)" Image-IconID="export_exporttoxls_16x16office2013" >
<Image IconID="export_exporttoxls_16x16office2013"></Image>
                                </dx:GridViewToolbarItem>
                                <dx:GridViewToolbarItem Name="CustomExportToXLSX" Text="Export to XLSX(WYSIWYG)" Image-IconID="export_exporttoxlsx_16x16office2013" >
<Image IconID="export_exporttoxlsx_16x16office2013"></Image>
                                </dx:GridViewToolbarItem>
                            </Items>

<Image IconID="actions_download_16x16office2013"></Image>
                        </dx:GridViewToolbarItem>
                        <dx:GridViewToolbarItem BeginGroup="true">
                            <Template>
                                <dx:ASPxButtonEdit ID="tbToolbarSearch" runat="server" NullText="buscar..." Height="100%">
                                    <Buttons>
                                        <dx:SpinButtonExtended Image-IconID="find_find_16x16gray" />
                                    </Buttons>
                                </dx:ASPxButtonEdit>
                            </Template>
                        </dx:GridViewToolbarItem>
                    </Items>
                </dx:GridViewToolbar>
            </Toolbars>

            <Styles>
                <AlternatingRow Enabled="True">
                </AlternatingRow>
            </Styles>
            <TotalSummary>
                <dx:ASPxSummaryItem DisplayFormat="Nº de Registros: {0}" FieldName="IDLegisGeral" ShowInColumn="ID Legis Geral" SummaryType="Count" />
            </TotalSummary>
        </dx:ASPxGridView>

        <dx:ASPxLoadingPanel ID="ASPxLoadingPanel1" runat="server"
            ClientInstanceName="loadingPanel" Modal="True" Theme="SoftOrange" Text="Processando&amp;hellip;">
        </dx:ASPxLoadingPanel>

        <dx:ASPxPopupControl ID="cpPopup3" runat="server" CloseAction="CloseButton" CloseOnEscape="true" Modal="True"
            PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="cpPopup3"
            HeaderText="Endereço da Legislação" AllowDragging="True" PopupAnimationType="Fade" EnableViewState="False" Theme="DevEx">
            <ContentCollection>
                <dx:PopupControlContentControl ID="PopupControlContentControl3" runat="server">
                    <table style="width: 270px">
                        <tr>
                            <td style="height: 30px">
                                <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="Link da Legislação não cadastrado !" Theme="DevEx"></dx:ASPxLabel>
                            </td>
                        </tr>
                    </table>
                </dx:PopupControlContentControl>
            </ContentCollection>
            <Border BorderColor="#003300" BorderStyle="Solid" />
        </dx:ASPxPopupControl>

        <dx:ASPxGridViewExporter ID="gridExport" runat="server" GridViewID="GridLegisCliente"></dx:ASPxGridViewExporter>

        <asp:SqlDataSource runat="server" ID="SqlSistemas" ConnectionString='<%$ ConnectionStrings:ConnectionString %>'
            DeleteCommand="DELETE FROM [Sistemas] WHERE [Id] = @Id"
            InsertCommand="INSERT INTO [Sistemas] ([Sistema]) VALUES (@Sistema)"
            SelectCommand="SELECT * FROM [Sistemas]"
            UpdateCommand="UPDATE [Sistemas] SET [Sistema] = @Sistema WHERE [Id] = @Id">
            <DeleteParameters>
                <asp:Parameter Name="Id" Type="Int32"></asp:Parameter>
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Sistema" Type="String"></asp:Parameter>
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Sistema" Type="String"></asp:Parameter>
                <asp:Parameter Name="Id" Type="Int32"></asp:Parameter>
            </UpdateParameters>
        </asp:SqlDataSource>


        <asp:SqlDataSource ID="SqlLegisGeral" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            SelectCommand="SELECT DATEDIFF(day, Data, GETDATE()) as Dias, * FROM [LegisGeral] order by Id desc,Numero asc" DeleteCommand="DELETE FROM [LegisGeral] WHERE [Id] = @Id"
            InsertCommand="INSERT INTO [LegisGeral] ([Sistema], [Ambito], [Numero], [Ano], [Orgao], [Tema], [Ementa], [Tipo], [lei], [param], [link], [DATA], [Localidade], [Estado], [Pais], [Municipio], [Arqpdf]) VALUES (@Sistema, @Ambito, @Numero, @Ano, @Orgao, @Tema, @Ementa, @Tipo, @lei, @param, @link, dateadd(day,28,getdate()), @Localidade, @Estado, @Pais, @Municipio, @Arqpdf)"
            UpdateCommand="UPDATE [LegisGeral] SET [Sistema] = @Sistema, [Ambito] = @Ambito, [Numero] = @Numero, [Ano] = @Ano, [Orgao] = @Orgao, [Tema] = @Tema, [Ementa] = @Ementa, [Tipo] = @Tipo, [lei] = @lei, [param] = @param, [link] = @link, [Data] = dateadd(day,28,getdate()), [Localidade] = @Localidade, [Estado] = @Estado, [Arqpdf] = @Arqpdf, [Pais] = @Pais, [Municipio] = @Municipio WHERE [Id] = @Id">
            <DeleteParameters>
                <asp:Parameter Name="Id" Type="Int32"></asp:Parameter>
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Sistema" Type="String"></asp:Parameter>
                <asp:Parameter Name="Ambito" Type="String"></asp:Parameter>
                <asp:Parameter Name="Numero" Type="String"></asp:Parameter>
                <asp:Parameter Name="Ano" Type="String"></asp:Parameter>
                <asp:Parameter Name="Orgao" Type="String"></asp:Parameter>
                <asp:Parameter Name="Tema" Type="String"></asp:Parameter>
                <asp:Parameter Name="Ementa" Type="String"></asp:Parameter>
                <asp:Parameter Name="Tipo" Type="String"></asp:Parameter>
                <asp:Parameter Name="lei" Type="String"></asp:Parameter>
                <asp:Parameter Name="param" Type="String"></asp:Parameter>
                <asp:Parameter Name="link" Type="String"></asp:Parameter>
                <asp:Parameter Name="Localidade" Type="String"></asp:Parameter>
                <asp:Parameter Name="Estado" Type="String"></asp:Parameter>
                <asp:Parameter Name="Pais" Type="String"></asp:Parameter>
                <asp:Parameter Name="Municipio" Type="String"></asp:Parameter>
                <asp:Parameter Name="Arqpdf" Type="String"></asp:Parameter>
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Sistema" Type="String"></asp:Parameter>
                <asp:Parameter Name="Ambito" Type="String"></asp:Parameter>
                <asp:Parameter Name="Numero" Type="String"></asp:Parameter>
                <asp:Parameter Name="Ano" Type="String"></asp:Parameter>
                <asp:Parameter Name="Orgao" Type="String"></asp:Parameter>
                <asp:Parameter Name="Tema" Type="String"></asp:Parameter>
                <asp:Parameter Name="Ementa" Type="String"></asp:Parameter>
                <asp:Parameter Name="Tipo" Type="String"></asp:Parameter>
                <asp:Parameter Name="lei" Type="String"></asp:Parameter>
                <asp:Parameter Name="param" Type="String"></asp:Parameter>
                <asp:Parameter Name="Id" Type="Int32"></asp:Parameter>
                <asp:Parameter Name="link" Type="String"></asp:Parameter>
                <asp:Parameter Name="Localidade" Type="String"></asp:Parameter>
                <asp:Parameter Name="Estado" Type="String"></asp:Parameter>
                <asp:Parameter Name="Pais" Type="String"></asp:Parameter>
                <asp:Parameter Name="Municipio" Type="String"></asp:Parameter>
                <asp:Parameter Name="Arqpdf" Type="String"></asp:Parameter>
            </UpdateParameters>
        </asp:SqlDataSource>


        <asp:SqlDataSource ID="SqlParametros" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            SelectCommand="SELECT * FROM [Parametros] WHERE ([IDLegisGeral] = @IDLegisGeral)"
            DeleteCommand="DELETE FROM [Parametros] WHERE [Id] = @Id"
            InsertCommand="INSERT INTO [Parametros] ([Capitulo], [Item], [Parametro], [Obrigacao], [IDLegisGeral], [IDCliente], [Numero], [Aplicavel], [lei], [param], [Conhecimento]) VALUES (@Capitulo, @Item, @Parametro, @Obrigacao, @IDLegisGeral, @IDCliente, @Numero, @Aplicavel, @lei, @param, @Conhecimento)"
            UpdateCommand="UPDATE [Parametros] SET [Capitulo] = @Capitulo, [Item] = @Item, [Parametro] = @Parametro, [Obrigacao] = @Obrigacao, [IDLegisGeral] = @IDLegisGeral, [IDCliente] = @IDCliente, [Numero] = @Numero, [Aplicavel] = @Aplicavel, [lei] = @lei,[Conhecimento] = @Conhecimento, [param] = @param WHERE [Id] = @Id">
            <DeleteParameters>
                <asp:Parameter Name="Id" Type="Int32"></asp:Parameter>
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Capitulo" Type="String"></asp:Parameter>
                <asp:Parameter Name="Item" Type="String"></asp:Parameter>
                <asp:Parameter Name="Parametro" Type="String"></asp:Parameter>
                <asp:Parameter Name="Obrigacao" Type="Int32"></asp:Parameter>
                <asp:SessionParameter SessionField="IDLegisGeral" Name="IDLegisGeral" Type="Int32"></asp:SessionParameter>
                <asp:Parameter Name="IDCliente" Type="Int32"></asp:Parameter>
                <asp:Parameter Name="Numero" Type="Int32"></asp:Parameter>
                <asp:Parameter Name="Aplicavel" Type="Int32"></asp:Parameter>
                <asp:Parameter Name="Conhecimento" Type="Int32"></asp:Parameter>
                <asp:Parameter Name="lei" Type="String"></asp:Parameter>
                <asp:Parameter Name="param" Type="String"></asp:Parameter>
            </InsertParameters>
            <SelectParameters>
                <asp:SessionParameter SessionField="IDLegisGeral" Name="IDLegisGeral" Type="Int32"></asp:SessionParameter>
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="Capitulo" Type="String"></asp:Parameter>
                <asp:Parameter Name="Item" Type="String"></asp:Parameter>
                <asp:Parameter Name="Parametro" Type="String"></asp:Parameter>
                <asp:Parameter Name="Obrigacao" Type="Int32"></asp:Parameter>
                <asp:SessionParameter SessionField="IDLegisGeral" Name="IDLegisGeral" Type="Int32"></asp:SessionParameter>
                <asp:Parameter Name="IDCliente" Type="Int32"></asp:Parameter>
                <asp:Parameter Name="Numero" Type="Int32"></asp:Parameter>
                <asp:Parameter Name="Conhecimento" Type="Int32"></asp:Parameter>
                <asp:Parameter Name="Aplicavel" Type="Int32"></asp:Parameter>
                <asp:Parameter Name="lei" Type="String"></asp:Parameter>
                <asp:Parameter Name="param" Type="String"></asp:Parameter>
                <asp:Parameter Name="Id" Type="Int32"></asp:Parameter>
            </UpdateParameters>
        </asp:SqlDataSource>

        <asp:SqlDataSource ID="SqlCidades" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Cidade]"></asp:SqlDataSource>

        <asp:SqlDataSource runat="server" ID="SqlAmbito" ConnectionString='<%$ ConnectionStrings:ConnectionString %>' DeleteCommand="DELETE FROM [Ambito] WHERE [Id] = @Id" InsertCommand="INSERT INTO [Ambito] ([Descricao]) VALUES (@Descricao)" SelectCommand="SELECT * FROM [Ambito]" UpdateCommand="UPDATE [Ambito] SET [Descricao] = @Descricao WHERE [Id] = @Id">
            <DeleteParameters>
                <asp:Parameter Name="Id" Type="Int32"></asp:Parameter>
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Descricao" Type="String"></asp:Parameter>
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Descricao" Type="String"></asp:Parameter>
                <asp:Parameter Name="Id" Type="Int32"></asp:Parameter>
            </UpdateParameters>
        </asp:SqlDataSource>

        <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:ConnectionString %>'
            DeleteCommand="DELETE FROM [Sistemas] WHERE [Id] = @Id"
            InsertCommand="INSERT INTO [Sistemas] ([Sistema]) VALUES (@Sistema)"
            SelectCommand="SELECT * FROM [Sistemas]"
            UpdateCommand="UPDATE [Sistemas] SET [Sistema] = @Sistema WHERE [Id] = @Id">
            <DeleteParameters>
                <asp:Parameter Name="Id" Type="Int32"></asp:Parameter>
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Sistema" Type="String"></asp:Parameter>
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Sistema" Type="String"></asp:Parameter>
                <asp:Parameter Name="Id" Type="Int32"></asp:Parameter>
            </UpdateParameters>
        </asp:SqlDataSource>

        <asp:SqlDataSource ID="SqlEstados" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Estado]"></asp:SqlDataSource>
        <asp:SqlDataSource runat="server" ID="SqlTipos" ConnectionString='<%$ ConnectionStrings:ConnectionString %>' DeleteCommand="DELETE FROM [Tipo] WHERE [Id] = @Id" InsertCommand="INSERT INTO [Tipo] ([Descricao]) VALUES (@Descricao)" SelectCommand="SELECT * FROM [Tipo]" UpdateCommand="UPDATE [Tipo] SET [Descricao] = @Descricao WHERE [Id] = @Id">
            <DeleteParameters>
                <asp:Parameter Name="Id" Type="Int32"></asp:Parameter>
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Descricao" Type="String"></asp:Parameter>
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Descricao" Type="String"></asp:Parameter>
                <asp:Parameter Name="Id" Type="Int32"></asp:Parameter>
            </UpdateParameters>
        </asp:SqlDataSource>

        <asp:SqlDataSource runat="server" ID="SqlOrgao" ConnectionString='<%$ ConnectionStrings:ConnectionString %>' DeleteCommand="DELETE FROM [Orgao] WHERE [Id] = @Id" InsertCommand="INSERT INTO [Orgao] ([Descricao]) VALUES (@Descricao)" SelectCommand="SELECT * FROM [Orgao]" UpdateCommand="UPDATE [Orgao] SET [Descricao] = @Descricao WHERE [Id] = @Id">
            <DeleteParameters>
                <asp:Parameter Name="Id" Type="Int32"></asp:Parameter>
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Descricao" Type="String"></asp:Parameter>
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Descricao" Type="String"></asp:Parameter>
                <asp:Parameter Name="Id" Type="Int32"></asp:Parameter>
            </UpdateParameters>
        </asp:SqlDataSource>

    </body>
    </html>
</asp:Content>
