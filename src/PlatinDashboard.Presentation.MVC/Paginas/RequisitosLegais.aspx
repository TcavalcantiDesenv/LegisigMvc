<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RequisitosLegais.aspx.cs" Inherits="PlatinDashboard.Presentation.MVC.Paginas.RequisitosLegais" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
        <script type="text/javascript">

            function abrir_popup1(s, e) {
                if (e.buttonID == "BtnTeste") {
                    pcAnexo.Show();
                }
            }
            function abrir_popup1(s, e) {
                if (e.buttonID == "BtnArquivo") {
                    cpPopup3.Show();
                }
            }
            function grid_ContextMenu(s, e) {
                var gridCell = document.getElementById('gridCell');
                ASPxClientUtils.AttachEventToElement(gridCell, 'contextmenu', OnGridContextMenu);
            }
            function OnGridContextMenu(evt) {
                menu.ShowAtPos(evt.clientX + ASPxClientUtils.GetDocumentScrollLeft(), evt.clientY + ASPxClientUtils.GetDocumentScrollTop());
                return OnPreventContextMenu(evt);
            }
            function OnPreventContextMenu(evt) {
                return ASPxClientUtils.PreventEventAndBubble(evt);
            }
            function UpdateDetailGrid(s, e) {
                detailGridView.PerformCallback(masterGridView.GetFocusedRowIndex());
            }

            function ShowLoginWindow() {
                pcAnexo.Show();
            }
            function ShowCreateAccountWindow() {
                pcCreateAccount.Show();
                tbUsername.Focus();
            }

    </script>
        <script type="text/javascript">
            function cbCheckAll3_CheckedChanged(s, e) {
                ASPxGridView5.PerformCallback(s.GetChecked().toString());
            }
            function cbCheckAll_CheckedChanged(s, e) {
                GridLegisGeral2.PerformCallback(s.GetChecked().toString());
            }

            function cbCheck_CheckedChanged(s, e, index) {
                GridLegisGeral2.SelectRowOnPage(index, s.GetChecked());
            }
            function cbCheck2_CheckedChanged(s, e, index) {
                GridLegisGeral2.SelectRowOnPage(index, s.GetChecked());
            }
            function cbCheck3_CheckedChanged(s, e, index) {
                ASPxGridView5.SelectRowOnPage(index, s.GetChecked());
            }
    </script>
        <script type="text/javascript">
            function ShowLoginWindow() {
                pcLogin.Show();
            }
            function ShowCreateAccountWindow() {
                pcCreateAccount.Show();
                tbUsername.Focus();
            }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>     
            <asp:Panel ID="Panel2" Visible="false" runat="server">
    <table>
        <tr>
            <td>
                <dx:ASPxComboBox runat="server" ID="ddlCliente" Caption="Importar do Cliente: " EnableTheming="True" Theme="Office2010Silver">
                    <RootStyle CssClass="OptionsBottomMargin"></RootStyle>
                    <CaptionCellStyle>
                        <Paddings PaddingRight="4px" />
                    </CaptionCellStyle>
                </dx:ASPxComboBox>
            </td>
            <td>
                <dx:ASPxButton ID="btnImportar" runat="server" Theme="Office2010Silver" OnClick="btnImportar_Click">
                    <Image IconID="actions_download_16x16">
                    </Image>
                </dx:ASPxButton>
            </td>
            <td>
                <dx:ASPxButton ID="btnIncluirLei" runat="server" Theme="Office2010Silver" OnClick="btnIncluirLei_Click" Text="Adicionar Leis">
                    <Image IconID="spreadsheet_editingmergecellsacross_16x16">
                    </Image>
                </dx:ASPxButton>
            </td>
            <td>
                <dx:ASPxButton ID="ASPxButton3" runat="server" Theme="Office2010Silver" Text="Remover Leis" OnClick="ASPxButton3_Click1">
                    <Image IconID="richedit_closeheaderandfooter_16x16">
                    </Image>
                </dx:ASPxButton>
            </td>
                        <td>
                <dx:ASPxButton ID="btnLicenca" runat="server" Theme="Office2010Silver" Text="Gestão de Licenças" OnClick="btnLicenca_Click" >
                    <Image IconID="chart_3dfullstackedarea_16x16">
                    </Image>
                </dx:ASPxButton>
            </td>
            <td>
                <dx:ASPxButton ID="ASPxButton5" runat="server" Theme="Office2010Silver" OnClick="ASPxButton31_Click" Text="Exportar Espelho de Avaliações">
                    <Image IconID="export_exporttoxls_16x16">
                    </Image>
                </dx:ASPxButton>
            </td>
                        <td>
                <dx:ASPxButton ID="ASPxButton7" runat="server" Theme="Office2010Silver" OnClick="ASPxButton32_Click" Text="Exportar Leis e Parametros">
                    <Image IconID="export_exporttoxls_16x16">
                    </Image>
                </dx:ASPxButton>
            </td>
                        <td>
                <dx:ASPxButton ID="ASPxButton8" runat="server" Theme="Office2010Silver" OnClick="ASPxButton33_Click" Text="Exportar Planos de Ação">
                    <Image IconID="export_exporttoxls_16x16">
                    </Image>
                </dx:ASPxButton>
<%--            </td>
                                    <td>
                <dx:ASPxButton ID="ASPxButton9" runat="server" Theme="Office2010Silver" OnClick="ASPxButton35_Click" Text="Gráficos">
                    <Image IconID="chart_column2_16x16">
                    </Image>
                </dx:ASPxButton>
            </td>--%>
<%--            <td>
                <dx:ASPxButton ID="btnVoltar" runat="server" Theme="Office2010Silver" OnClick="btnVoltar_Click" AutoPostBack="False" Text="Voltar">
                    <Image IconID="actions_reset2_16x16">
                    </Image>
                </dx:ASPxButton>
            </td>--%>
                        <td>
                <dx:ASPxComboBox runat="server" ID="ddlExportMode" Caption="Modo de Exportação: " Visible="false" EnableTheming="True" Theme="Office2010Silver">
                    <RootStyle CssClass="OptionsBottomMargin"></RootStyle>
                    <CaptionCellStyle>
                        <Paddings PaddingRight="4px" />
                    </CaptionCellStyle>
                </dx:ASPxComboBox>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
            </asp:Panel>
    <dx:ASPxPopupControl ID="pcPlano" runat="server" CloseAction="CloseButton" CloseOnEscape="true" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcPlano"
        HeaderText="Painel de Ação" AllowDragging="True" PopupAnimationType="None" EnableViewState="False">
        <ClientSideEvents PopUp="function(s, e) { ASPxClientEdit.ClearGroup('entryGroup'); tbLogin.Focus(); }" />
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">
                <asp:Panel ID="PanelRequisitos" runat="server">
                    <div class="row">
                        <dx:ASPxButton ID="btn" runat="server" AutoPostBack="False" Text="Consultar plano de ação  para este Parametro.." Visible="False">
                            <ClientSideEvents Click="function(s,e){ popup.PerformCallback(); }" />
                        </dx:ASPxButton>
                        <asp:Panel ID="Panel1" runat="server" Visible="true">
                            <div class="col-sm-12">
                                <div class="panel panel-info">
                                    <div class="panel-heading" style="font-size: large">
                                        <i class="fa fa-bar-chart-o fa-fw"></i>Plano de Ação
                                    </div>
                                </div>
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-sm-12">
                                            <div class="table-responsive">
                                                <table class="table table-bordered table-hover table-striped">
                                                    <thead>
                                                        <tr class="info">
                                                            <th style="width: 100px;">
                                                                <dx:ASPxLabel ID="lblSistema" runat="server" Font-Bold="True" Font-Size="10pt" Text="Análise de Causa" Width="130px">
                                                                </dx:ASPxLabel>
                                                            </th>
                                                            <th style="width: 100px;">
                                                                <dx:ASPxTextBox ID="txtCausa" runat="server" Width="470px">
                                                                    <Border BorderStyle="Outset" />
                                                                </dx:ASPxTextBox>
                                                            </th>
                                                            <th style="width: 100px;">
                                                                <dx:ASPxLabel ID="lblTipo" runat="server" Text="Data" Width="60px" Font-Bold="True" Font-Size="10pt">
                                                                </dx:ASPxLabel>
                                                            </th>
                                                            <th style="width: 100px;">
                                                                <dx:ASPxDateEdit ID="DataCausa" runat="server">
                                                                </dx:ASPxDateEdit>
                                                            </th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <tr class="primary">
                                                            <td style="width: 100px">
                                                                <dx:ASPxLabel ID="lblAmbito" runat="server" Text="Ação de Correção" Width="130px" Font-Bold="True" Font-Size="10pt">
                                                                </dx:ASPxLabel>
                                                            </td>
                                                            <td style="width: 170px" colspan="2">
                                                                <dx:ASPxMemo ID="txtCorrecao" runat="server" Height="80px" Width="470px" HorizontalAlign="Center">
                                                                    <CaptionSettings VerticalAlign="Top" />
                                                                    <Border BorderStyle="Outset" />
                                                                </dx:ASPxMemo>
                                                            </td>
                                                            <td>
                                                                <dx:ASPxLabel ID="lblTipo0" runat="server" Text="Data" Width="60px" Font-Bold="True" Font-Size="10pt">
                                                                </dx:ASPxLabel>
                                                            </td>
                                                            <td style="width: 100px">
                                                                <dx:ASPxDateEdit ID="DataCorrecao" runat="server">
                                                                </dx:ASPxDateEdit>
                                                            </td>
                                                        </tr>

                                                        <tr class="info">
                                                            <th style="width: 100px;">
                                                                <dx:ASPxLabel ID="lblTema" runat="server" Font-Bold="True" Font-Size="10pt" Text="Ações foram eficazes?" Width="140px">
                                                                </dx:ASPxLabel>
                                                            </th>
                                                            <th style="width: 100px;"">
                                                                <dx:ASPxComboBox ID="txtEficacia" Width="470px" runat="server" SelectedIndex="0">
                                                                    <Items>
                                                                        <dx:ListEditItem Selected="True" Text="Sim" Value="Sim" />
                                                                        <dx:ListEditItem Text="Não" Value="Nao" />
                                                                    </Items>
                                                                </dx:ASPxComboBox>
                                                            </th>
                                                            <th class="auto-style4">
                                                                <dx:ASPxLabel ID="lblTipo2" runat="server" Font-Bold="True" Font-Size="10pt" Text="Data" Width="60px">
                                                                </dx:ASPxLabel>
                                                            </th>
                                                            <th style="height: 100px">
                                                                <dx:ASPxDateEdit ID="DataEficadia" runat="server">
                                                                </dx:ASPxDateEdit>
                                                            </th>
                                                        </tr>

                                                        <tr class="primary">
                                                            <td style="width: 100px">
                                                                <dx:ASPxLabel ID="lblEmenta" runat="server" Text="Evidencias de Atendimento" Width="130px" Font-Bold="True" Font-Size="10pt">
                                                                </dx:ASPxLabel>
                                                            </td>
                                                            <td colspan="4">
                                                                <dx:ASPxMemo ID="txtEvidencia" runat="server" Height="80px" Width="100%" HorizontalAlign="Justify">
                                                                    <CaptionSettings VerticalAlign="Top" />
                                                                    <Border BorderStyle="Outset" />
                                                                </dx:ASPxMemo>
                                                            </td>
                                                        </tr>

                                                        <tr class="info">
                                                            <td style="width: 44px; height: 37px;">
                                                                <dx:ASPxLabel ID="lblNumero0" runat="server" Font-Bold="True" Font-Size="10pt" Text="Status Final" Width="130px">
                                                                </dx:ASPxLabel>
                                                            </td>
                                                            <td style="height: 100px" colspan="2">
                                                                <dx:ASPxComboBox ID="txtStatus" runat="server" SelectedIndex="0">
                                                                    <Items>
                                                                        <dx:ListEditItem Selected="True" Text="Atende" Value="Atende" />
                                                                        <dx:ListEditItem Text="Não Atende" Value="Não Atende" />
                                                                        <dx:ListEditItem Text="Em implementação" Value="Implementacao" />
                                                                        <dx:ListEditItem Text="Em Avaliação" Value="Em avaliacao" />
                                                                    </Items>
                                                                </dx:ASPxComboBox>
                                                            </td>
                                                            <td class="auto-style4">
                                                                <asp:Label ID="lblCodParam" runat="server" Text="0" Visible="False"></asp:Label>
                                                            </td>
                                                            <td style="height: 37px">&nbsp;</td>
                                                        </tr>

                                                        <tr class="info">
                                                            <td style="width: 44px; height: 37px;">
                                                                <dx:ASPxLabel ID="ASPxLabel1" runat="server" Font-Bold="True" Font-Size="10pt" Text="Plano de Ação" Width="130px">
                                                                </dx:ASPxLabel>
                                                            </td>
                                                            <td style="width: 170px; height: 37px;" colspan="2">&nbsp;</td>
                                                            <td class="auto-style4">
                                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Id")%>' Visible="true"></asp:Label>
                                                            </td>
                                                            <td style="height: 37px">&nbsp;</td>
                                                        </tr>

                                                        <tr class="primary">
                                                            <td class="auto-style5"></td>
                                                            <td style="width: 100px;">
                                                                <dx:ASPxButton ID="btnGravar1" runat="server" OnClick="ASPxButton3_Click" Text="Gravar" Theme="Office2010Silver" Width="100px">
                                                                </dx:ASPxButton>
                                                            </td>
                                                            <td class="auto-style4">
                                                                <dx:ASPxButton ID="ASPxButton10" runat="server" OnClick="ASPxButton10_Click" Text="Anexo" Theme="Office2010Silver" Width="100px">
                                                                </dx:ASPxButton>
                                                            </td>
                                                            <td class="auto-style4">
                                                                <dx:ASPxButton ID="ASPxButton11" runat="server" OnClick="ASPxButton11_Click" OnCommand="ASPxButton11_Command" Text="Excluir" Theme="Office2010Silver" Width="100px">
                                                                </dx:ASPxButton>
                                                            </td>
                                                            <td class="auto-style4">
                                                                <dx:ASPxButton ID="ASPxButton4" runat="server" Text="Sair" Width="100px" Theme="Office2010Silver" OnClick="ASPxButton4_Click1">
                                                                </dx:ASPxButton>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                                <!-- /.panel-body -->
                            </div>
                        </asp:Panel>

                    </div>
                </asp:Panel>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>

    <dx:ASPxPopupControl ID="PopupControl" runat="server" CloseAction="OuterMouseClick" LoadContentViaCallback="OnFirstShow"
        PopupElementID="ShowButton" PopupVerticalAlign="Below" PopupHorizontalAlign="LeftSides" AllowDragging="True"
        ShowFooter="True" Width="310px" Height="160px" HeaderText="Updatable content" ClientInstanceName="ClientPopupControl" Theme="Office2010Silver">
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl" runat="server">
                <div style="vertical-align: middle">
                    The content of this popup control was updated at<br />
                    <b></b>
                </div>
            </dx:PopupControlContentControl>
        </ContentCollection>
        <FooterTemplate>
            <dx:ASPxButton ID="UpdateButton" runat="server" Text="Update Content" AutoPostBack="False" Style="margin: 6px 6px 6px 210px"
                ClientSideEvents-Click="function(s, e) { ClientPopupControl.PerformCallback(); }" />
        </FooterTemplate>
    </dx:ASPxPopupControl>

    <asp:Panel ID="PanelUsuarios" runat="server">
        <dx:ASPxLabel ID="lblEmpresa" runat="server" Visible="false" Font-Bold="False" Font-Size="15pt" ForeColor="Yellow" Text="xxx" Width="500px">
        </dx:ASPxLabel>

          <dx:ASPxGridView ID="ASPxGridView1" runat="server" OnCustomCallback="master_CustomCallback"  AutoGenerateColumns="False" DataSourceID="SqlLei2" KeyFieldName="IDLegisGeral" KeyboardSupport="True" Theme="Office2010Silver" Width="100%" 
            OnCustomColumnDisplayText="ASPxGridView1_CustomColumnDisplayText" OnCustomButtonCallback="ASPxGridView1_CustomButtonCallback" 
            OnCommandButtonInitialize="ASPxGridView1_CommandButtonInitialize" DataCellPrepared="ASPxGridView1_HtmlDataCellPrepared"
            OnSelectionChanged="ASPxGridView1_SelectionChanged" OnHtmlDataCellPrepared="ASPxGridView1_HtmlDataCellPrepared">
             <ClientSideEvents CustomButtonClick="abrir_popup1()" />
            <ClientSideEvents BeginCallback="function(s, e) {loadingPanel.Show(); }" EndCallback="function(s, e) {loadingPanel.Hide(); }" />
            <SettingsLoadingPanel Mode="Disabled" />
            <SettingsDetail ShowDetailRow="True" />
            <Styles>
              <AlternatingRow Enabled="True"/>
            </Styles>
            <ClientSideEvents CustomButtonClick="function(s, e) {if (e.buttonID == 'btnDetails') OnDetalhesClick(e.visibleIndex);}" />
           <Templates>
              <DetailRow>
                <dx:ASPxGridView ID="ASPxGridView2" runat="server" AutoGenerateColumns="False" ClientInstanceName="masterGridView" DataSourceID="SqlParametro" KeyboardSupport="True" KeyFieldName="Id" OnBeforePerformDataSelect="GridClientes_BeforePerformDataSelect" OnCommandButtonInitialize="ASPxGridView2_CommandButtonInitialize" OnLoad="detailGrid_Load" Theme="Office2010Silver" Width="100%">
                                         <SettingsLoadingPanel Mode="Disabled" />
                                         <SettingsDetail ShowDetailRow="True" />
                                         <SettingsPopup>
                                             <EditForm HorizontalAlign="Center" Modal="True" VerticalAlign="WindowCenter" Width="1000" />
                                             <CustomizationWindow HorizontalAlign="WindowCenter" VerticalAlign="WindowCenter" />
                                         </SettingsPopup>
                                         <SettingsBehavior ConfirmDelete="True" EnableRowHotTrack="True" />
                                         <SettingsPager AlwaysShowPager="True" />
                                         <SettingsEditing EditFormColumnCount="3" Mode="PopupEditForm">
                                         </SettingsEditing>
                                         <Settings ShowHeaderFilterButton="false" ShowTitlePanel="true" />
                    <SettingsDataSecurity AllowDelete="False" AllowInsert="False"></SettingsDataSecurity>

                    <SettingsLoadingPanel Mode="Disabled" />
               <ClientSideEvents BeginCallback="function(s, e) {loadingPanel.Show();}" EndCallback="function(s, e) {loadingPanel.Hide();}" />
                       <Toolbars>
                            <dx:GridViewToolbar ItemAlign="Left" EnableAdaptivity="true">
                                <Items>
                                    <dx:GridViewToolbarItem Command="Edit" Text="Editar" />
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
                       <SettingsSearchPanel CustomEditorID="tbToolbarSearch" />
                        <Columns>
                                             <dx:GridViewDataColumn FieldName="Numero" ReadOnly="false" VisibleIndex="1" />
                                             <dx:GridViewDataColumn Caption="Capitulo" FieldName="Capitulo" ReadOnly="false" VisibleIndex="2" >
                                                 <Settings AllowEllipsisInText="True" />
                                             </dx:GridViewDataColumn>
                                             <dx:GridViewDataCheckColumn FieldName="Obrigacao" VisibleIndex="9">
                                                 <PropertiesCheckEdit ValueChecked="1" ValueType="System.Int32" ValueUnchecked="0">
                                                 </PropertiesCheckEdit>
                                             </dx:GridViewDataCheckColumn>
                                             <dx:GridViewDataCheckColumn FieldName="Aplicavel" VisibleIndex="7">
                                                 <PropertiesCheckEdit ValueChecked="1" ValueType="System.Int32" ValueUnchecked="0">
                                                 </PropertiesCheckEdit>
                                             </dx:GridViewDataCheckColumn>
                                              <dx:GridViewDataCheckColumn FieldName="Conhecimento" VisibleIndex="10">
                                                 <PropertiesCheckEdit ValueChecked="1" ValueType="System.Int32" ValueUnchecked="0">
                                                 </PropertiesCheckEdit>
                                             </dx:GridViewDataCheckColumn>
                                             <dx:GridViewDataColumn FieldName="Id" Visible="false" VisibleIndex="5" />
                                             <dx:GridViewDataColumn FieldName="IDLegisGeral" Visible="false" VisibleIndex="5" />
                                             <dx:GridViewDataMemoColumn FieldName="Parametro" Name="IDCliente" ReadOnly="false" VisibleIndex="4">
                                                    <Settings AllowEllipsisInText="True" />
                                             </dx:GridViewDataMemoColumn>
                                             <dx:GridViewDataMemoColumn FieldName="Item" ReadOnly="false" VisibleIndex="3">
                                                   <Settings AllowEllipsisInText="True" />
                                             </dx:GridViewDataMemoColumn>
                                         </Columns>
                       <EditFormLayoutProperties ColCount="2"  >
                            <Items>
                                <dx:GridViewColumnLayoutItem ColumnName="Aplicavel"  HorizontalAlign="Center" />
                                <dx:GridViewColumnLayoutItem ColumnName="Obrigacao" />
                                <dx:GridViewColumnLayoutItem ColumnName="Conhecimento" />
                                <dx:EditModeCommandLayoutItem ColSpan="2" HorizontalAlign="Center" />
                            </Items>
                        </EditFormLayoutProperties>
                                         <Styles>
                                             <AlternatingRow Enabled="True">
                                             </AlternatingRow>
                                         </Styles>
                                         <SettingsEditing EditFormColumnCount="3" Mode="PopupEditForm" />
                                         <SettingsPopup>
                                             <EditForm HorizontalAlign="WindowCenter" VerticalAlign="WindowCenter" Width="800" />
                                         </SettingsPopup>
                                         <SettingsLoadingPanel Mode="Disabled" />
                                         <SettingsDetail ShowDetailRow="True" />
                                         <SettingsPopup>
                                             <EditForm HorizontalAlign="Center" Modal="True" VerticalAlign="WindowCenter" Width="800" />
                                             <CustomizationWindow HorizontalAlign="WindowCenter" VerticalAlign="WindowCenter" />
                                         </SettingsPopup>
                                         <SettingsBehavior ConfirmDelete="True" EnableRowHotTrack="True" />
                                         <SettingsPager AlwaysShowPager="True" />
                                         <Settings ShowTitlePanel="true" />
                                         <SettingsText Title="Parametros" />
                    <SettingsLoadingPanel Mode="Disabled" />
                                         <ClientSideEvents BeginCallback="function(s, e) {loadingPanel.Show();}" EndCallback="function(s, e) {loadingPanel.Hide();}" />
                                         <Styles>
                                             <AlternatingRow Enabled="True">
                                             </AlternatingRow>
                                         </Styles>
                                         <Templates>
                                             <DetailRow>
                                                 <dx:ASPxGridView ID="ASPxGridView3" runat="server" AutoGenerateColumns="False" ClientInstanceName="detailGridView" DataSourceID="SqlConformidade" KeyboardSupport="True" KeyFieldName="id" OnBeforePerformDataSelect="ASPxGridView3_BeforePerformDataSelect" OnCommandButtonInitialize="ASPxGridView3_CommandButtonInitialize" OnCustomButtonCallback="ASPxGridView3_CustomButtonCallback" OnCustomCallback="ASPxGridView3_CustomCallback" OnFocusedRowChanged="ASPxGridView3_FocusedRowChanged" OnInitNewRow="ASPxGridView3_InitNewRow" OnRowInserting="ASPxGridView3_RowInserting" OnRowUpdating="ASPxGridView3_RowUpdating" OnSelectionChanged="ASPxGridView3_SelectionChanged" Theme="Office2010Silver" Width="100%" EnableTheming="True">
                                                     <SettingsEditing EditFormColumnCount="2" Mode="PopupEditForm" />
                                                     <SettingsLoadingPanel Mode="Disabled" />
                                                     <SettingsDetail ShowDetailRow="True" />
                                                     <SettingsPopup>
                                                         <EditForm HorizontalAlign="Center" Modal="True" VerticalAlign="WindowCenter" Width="800" />
                                                         <CustomizationWindow HorizontalAlign="WindowCenter" VerticalAlign="WindowCenter" />
                                                     </SettingsPopup>
                                                     <SettingsBehavior ConfirmDelete="True" EnableRowHotTrack="True" />
                                                     <SettingsPager AlwaysShowPager="True" />
                                                     <Settings ShowTitlePanel="true" />
                                                     <SettingsText Title="Lançamento de Evidencias" />
                                                     <SettingsSearchPanel ShowApplyButton="True" ShowClearButton="True" />
                                                     <SettingsLoadingPanel Mode="Disabled" />
                                                     <Columns>
                                                     </Columns>
                                                     <ClientSideEvents BeginCallback="function(s, e) {loadingPanel.Show();}" EndCallback="function(s, e) {loadingPanel.Hide(); }" />
                                               <Toolbars>
                                                   <dx:GridViewToolbar ItemAlign="Left">
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
                                               <SettingsSearchPanel CustomEditorID="tbToolbarSearch" />
                                                    <Columns>
                                                        <dx:GridViewCommandColumn VisibleIndex="1" ShowDeleteButton="false" ShowNewButtonInHeader="false" ShowEditButton="false" Visible="False">
                                                            <CustomButtons>
                                                                <dx:GridViewCommandColumnCustomButton ID="btnDetails" Text="ANEXO" />
                                                            </CustomButtons>
                                                        </dx:GridViewCommandColumn>
                                                        <dx:GridViewCommandColumn ShowDeleteButton="false" VisibleIndex="30" ShowNewButtonInHeader="false" ShowEditButton="false"></dx:GridViewCommandColumn>
                                                        <dx:GridViewDataTextColumn FieldName="id" ReadOnly="True" VisibleIndex="2" Visible="False">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="IDCliente" Visible="False" VisibleIndex="3"></dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="IDLegis" Visible="False" VisibleIndex="4"></dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="IDParametros" Visible="False" VisibleIndex="6"></dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="Obrigacao" VisibleIndex="7" Visible="False"></dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="Anexo" VisibleIndex="5" Caption="Anexo" Visible="False"></dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataDateColumn FieldName="ProxAvaliacao" Caption="Proxima Avalia&#231;&#227;o" VisibleIndex="12">
                                                            <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy"></PropertiesDateEdit>
                                                        </dx:GridViewDataDateColumn>
                                                        <dx:GridViewDataDateColumn FieldName="DataValidacao" Caption="Data da Validacao" VisibleIndex="10">
                                                            <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy"></PropertiesDateEdit>
                                                        </dx:GridViewDataDateColumn>
                                                        <dx:GridViewDataDateColumn FieldName="DataAvaliacao" Caption="Data da Avaliacao" VisibleIndex="8">
                                                            <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy"></PropertiesDateEdit>
                                                        </dx:GridViewDataDateColumn>
                                                        <dx:GridViewDataMemoColumn FieldName="Evidencias" Caption="Evidencias de Atendimento" VisibleIndex="14"></dx:GridViewDataMemoColumn>
                                                        <dx:GridViewDataComboBoxColumn Caption="Resultado" FieldName="Resultado" VisibleIndex="13">
                                                            <PropertiesComboBox>
                                                                <Items>
                                                                    <dx:ListEditItem Text="Não Informado" Value="Não Informado" />
                                                                    <dx:ListEditItem Text="Atende" Value="Atende" />
                                                                    <dx:ListEditItem Text="Não atende" Value="Não atende" />
                                                                    <dx:ListEditItem Text="Atende parcial" Value="Atende parcial" />
                                                                    <dx:ListEditItem Text="Em andamento" Value="Em andamento" />
                                                                    <dx:ListEditItem Text="Não Aplicavel" Value="Não Aplicavel" />
                                                                </Items>
                                                            </PropertiesComboBox>
                                                        </dx:GridViewDataComboBoxColumn>

                                                        <dx:GridViewDataComboBoxColumn FieldName="Avaliado" Caption="Avaliado por:" VisibleIndex="9">
                                                            <PropertiesComboBox DataSourceID="SqlAvaliadores" TextField="Usu&#225;rio" ValueField="Usu&#225;rio"></PropertiesComboBox>
                                                        </dx:GridViewDataComboBoxColumn>
                                                        <dx:GridViewDataComboBoxColumn FieldName="Validado" Caption="Validado por:" VisibleIndex="11">
                                                            <PropertiesComboBox DataSourceID="SqlValidadores" TextField="Usu&#225;rio" ValueField="Usu&#225;rio"></PropertiesComboBox>
                                                        </dx:GridViewDataComboBoxColumn>
                                                    </Columns>
                                                     <Styles>
                                                         <AlternatingRow Enabled="True">
                                                         </AlternatingRow>
                                                     </Styles>
                                                         <Templates>
                                                         <DetailRow>
                                                             <dx:ASPxGridView ID="ASPxGridView4" runat="server" AutoGenerateColumns="False" DataSourceID="SqlPlano" KeyboardSupport="True" KeyFieldName="IDAcao" OnBeforePerformDataSelect="ASPxGridView4_BeforePerformDataSelect" Theme="Office2010Silver" Width="100%" EnableTheming="True">
                                                                 <SettingsLoadingPanel Mode="Disabled" />
                                                                 <ClientSideEvents BeginCallback="function(s, e) { loadingPanel.Show();}" EndCallback="function(s, e) {loadingPanel.Hide();}" />
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
                                                                 <SettingsSearchPanel CustomEditorID="tbToolbarSearch" />
                                                                 <Columns>
                                                                     <dx:GridViewDataTextColumn FieldName="id" ReadOnly="True" ShowInCustomizationForm="True" Visible="False" VisibleIndex="1">
                                                                     </dx:GridViewDataTextColumn>
                                                                     <dx:GridViewDataTextColumn FieldName="IDParametros" ShowInCustomizationForm="True" Visible="False" VisibleIndex="2">
                                                                     </dx:GridViewDataTextColumn>
                                                                     <dx:GridViewDataDateColumn FieldName="DataCausa" ShowInCustomizationForm="True" VisibleIndex="4">
                                                                     </dx:GridViewDataDateColumn>
                                                                     <dx:GridViewDataDateColumn FieldName="Prazo" ShowInCustomizationForm="True" VisibleIndex="6">
                                                                     </dx:GridViewDataDateColumn>
                                                                     <dx:GridViewDataTextColumn FieldName="IDCliente" ShowInCustomizationForm="True" Visible="False" VisibleIndex="11">
                                                                     </dx:GridViewDataTextColumn>
                                                                     <dx:GridViewDataTextColumn FieldName="IDLegis" ShowInCustomizationForm="True" Visible="False" VisibleIndex="12">
                                                                     </dx:GridViewDataTextColumn>
                                                                     <dx:GridViewDataMemoColumn FieldName="Causa" VisibleIndex="3">
                                                                           <Settings AllowEllipsisInText="True" />
                                                                     </dx:GridViewDataMemoColumn>
                                                                     <dx:GridViewDataMemoColumn Caption="Ação de Correção" FieldName="Correcao_Corretivas" VisibleIndex="5">
                                                                           <Settings AllowEllipsisInText="True" />
                                                                     </dx:GridViewDataMemoColumn>
                                                                     <dx:GridViewDataTextColumn FieldName="IDCliente" ShowInCustomizationForm="True" Visible="False" VisibleIndex="7">
                                                                     </dx:GridViewDataTextColumn>
                                                                     <dx:GridViewDataTextColumn FieldName="IDLegis" ShowInCustomizationForm="True" Visible="False" VisibleIndex="8">
                                                                     </dx:GridViewDataTextColumn>
                                                                     <dx:GridViewCommandColumn VisibleIndex="0" ShowRecoverButton="False" Visible="False">
                                                                     </dx:GridViewCommandColumn>
                                                                     <dx:GridViewDataMemoColumn Caption="Eficácia" FieldName="Eficacia" VisibleIndex="9">
                                                                     </dx:GridViewDataMemoColumn>
                                                                     <dx:GridViewDataComboBoxColumn Caption="Status Final" FieldName="ResultFinal" VisibleIndex="13">
                                                                         <PropertiesComboBox>
                                                                             <Items>
                                                                                 <dx:ListEditItem Text="Atende" Value="Atende" />
                                                                                 <dx:ListEditItem Text="Não Atende" Value="Não Atende" />
                                                                                 <dx:ListEditItem Text="Em Andamento" Value="Em Andamento" />
                                                                             </Items>
                                                                         </PropertiesComboBox>
                                                                     </dx:GridViewDataComboBoxColumn>
                                                                 </Columns>
                                                                 <Styles>
                                                                     <AlternatingRow Enabled="True">
                                                                     </AlternatingRow>
                                                                 </Styles>
                                                                 <SettingsEditing EditFormColumnCount="2" Mode="PopupEditForm" />
                                                                 <SettingsLoadingPanel Mode="Disabled" />
                                                                 <SettingsDetail ShowDetailRow="False" />
                                                                 <SettingsPopup>
                                                                     <EditForm HorizontalAlign="Center"  Modal="True" VerticalAlign="WindowCenter" Width="800" />
                                                                     <CustomizationWindow HorizontalAlign="WindowCenter" VerticalAlign="WindowCenter" />
                                                                 </SettingsPopup>
                                                                 <SettingsBehavior ConfirmDelete="True" EnableRowHotTrack="True" />
                                                                 <SettingsPager AlwaysShowPager="True" />
                                                                 <Settings ShowTitlePanel="true" />
                                                                 <SettingsText Title="Plano de Ação" />
                                                                 <SettingsLoadingPanel Mode="Disabled" />
                                                                 <ClientSideEvents BeginCallback="function(s, e) {
	                                                                    loadingPanel.Show();
                                                                    }" EndCallback="function(s, e) {
	                                                                    loadingPanel.Hide();
                                                                    }" />
                                                             </dx:ASPxGridView>
                                                         </DetailRow>
                                                     </Templates>
                                                     <SettingsBehavior AllowFocusedRow="True" />
                                                 </dx:ASPxGridView>
                                             </DetailRow>
                                         </Templates>
                                     </dx:ASPxGridView>
              </DetailRow>
          </Templates>
          <SettingsPager AlwaysShowPager="True" />
          <SettingsEditing EditFormColumnCount="3" Mode="PopupEditForm"  />
          <SettingsPopup>
                               <EditForm HorizontalAlign="Center" Modal="True" VerticalAlign="WindowCenter" Width="1000" />
                                 <CustomizationWindow HorizontalAlign="WindowCenter" VerticalAlign="WindowCenter" />
                              </SettingsPopup>
          <Settings ShowHeaderFilterButton="false" ShowTitlePanel="false" />
          <SettingsBehavior AllowFocusedRow="True" AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" ConfirmDelete="false" EnableRowHotTrack="True" ProcessSelectionChangedOnServer="True" />
          <SettingsDataSecurity AllowInsert="False" AllowDelete="False"></SettingsDataSecurity>
          <SettingsPopup>
                 <EditForm HorizontalAlign="Center" Modal="True" VerticalAlign="WindowCenter" Width="600" />
                 <CustomizationWindow HorizontalAlign="WindowCenter" VerticalAlign="WindowCenter" />
              </SettingsPopup>
              <SettingsSearchPanel ShowApplyButton="false" ShowClearButton="false" />
          <SettingsLoadingPanel Mode="Disabled" />
          <SettingsText Title="Legislação do Cliente" />
              <Toolbars>
                            <dx:GridViewToolbar ItemAlign="Left" EnableAdaptivity="true">
                                <Items>
                                    <dx:GridViewToolbarItem Command="Edit" Text="Editar" />
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
          <SettingsSearchPanel CustomEditorID="tbToolbarSearch" />
           <ClientSideEvents CustomButtonClick="function(s, e) {
	        if(e.buttonID == 'BtnArquivo'){
                                 alert('Row index: ' + e.visibleIndex);
                                 window.open('Default2.aspx');
                             }
        }" />
          <Columns>
                                 <dx:GridViewDataTextColumn Caption="Código" FieldName="Id" Visible="False" VisibleIndex="1">
                                 </dx:GridViewDataTextColumn>
                                 <dx:GridViewDataColumn FieldName="Sistema" VisibleIndex="2">
                                       <Settings AllowEllipsisInText="True" />
                                 </dx:GridViewDataColumn>
                                 <dx:GridViewDataColumn FieldName="Ambito" VisibleIndex="3" >
                                  <Settings AllowEllipsisInText="True" />
                                 </dx:GridViewDataColumn>
                                 <dx:GridViewDataColumn FieldName="Estado" VisibleIndex="4" />
                                  <dx:GridViewDataColumn FieldName="Municipio" VisibleIndex="4" />
                                  <dx:GridViewDataColumn FieldName="Pais" VisibleIndex="5" />
                                 <dx:GridViewDataTextColumn FieldName="Orgao" VisibleIndex="6">
                                  <Settings AllowEllipsisInText="True" />
                                 </dx:GridViewDataTextColumn>
                                 <dx:GridViewDataColumn FieldName="Numero" VisibleIndex="7" />
                                 <dx:GridViewDataTextColumn FieldName="Ano" Visible="true" VisibleIndex="8">
                                 </dx:GridViewDataTextColumn>
                                 <dx:GridViewDataTextColumn FieldName="Tipo" Visible="true" VisibleIndex="9">
                                      <Settings AllowEllipsisInText="True" />
                                 </dx:GridViewDataTextColumn>
                                 <dx:GridViewDataMemoColumn FieldName="Ementa" Visible="true" VisibleIndex="10">
                                     <Settings AllowEllipsisInText="True" />
                                 </dx:GridViewDataMemoColumn>
                                 <dx:GridViewDataColumn FieldName="Tema" VisibleIndex="11" >
                                     <Settings AllowEllipsisInText="True" />
                                     </dx:GridViewDataColumn>
                                  <dx:GridViewDataComboBoxColumn Caption="Situação" FieldName="Ativo" VisibleIndex="12"/>
                                  <dx:GridViewDataCheckColumn FieldName="Aplicavel" Caption="Aplicavel" VisibleIndex="25"/>
                                  <dx:GridViewDataTextColumn Caption="Normas" FieldName="Arqpdf" Visible="False" VisibleIndex="14">
                                     <EditFormSettings Visible="True" />
                                  </dx:GridViewDataTextColumn>
                                  <dx:GridViewDataTextColumn FieldName="param" Visible="False" VisibleIndex="22">
                                  </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn AllowTextTruncationInAdaptiveMode="true" VisibleIndex="15">
                                  <EditFormSettings Visible="False" VisibleIndex="15" />
                                    <DataItemTemplate>
                                       <dx:ASPxButton ID="link" runat="server" OnClick="btnLink_Click" Theme="DevEx" Width="30px">
                                         <Image IconID="businessobjects_bolocalization_16x16">
                                         </Image>
                                       </dx:ASPxButton>
                                    </DataItemTemplate>
                                  </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="link" Visible="False" VisibleIndex="16">
                                  <EditFormSettings Visible="True" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn AllowTextTruncationInAdaptiveMode="true" VisibleIndex="20">
                    <EditFormSettings Visible="False" VisibleIndex="20" />
                    <DataItemTemplate>
                        <dx:ASPxButton ID="link2" runat="server" OnClick="btnLink2_Click" Theme="DevEx" Width="30px">
                            <Image IconID="export_exporttopdf_16x16office2013">
                            </Image>
                        </dx:ASPxButton>
                    </DataItemTemplate>
                </dx:GridViewDataTextColumn>
                             </Columns>
                       <EditFormLayoutProperties ColCount="2"  >
                            <Items>
                                <dx:GridViewColumnLayoutItem ColumnName="Aplicavel"  HorizontalAlign="Center" />
                                <dx:EditModeCommandLayoutItem ColSpan="2" HorizontalAlign="Center" />
                            </Items>
                        </EditFormLayoutProperties>
          <Styles>
             <AlternatingRow Enabled="True">
             </AlternatingRow>
          </Styles>
        </dx:ASPxGridView>






      <asp:SqlDataSource ID="SqlCidades" runat="server" ConnectionString="<%$ ConnectionStrings:PortalConnection %>" SelectCommand="SELECT * FROM [Cidade]"></asp:SqlDataSource>
      <asp:SqlDataSource ID="SqlEstados" runat="server" ConnectionString="<%$ ConnectionStrings:PortalConnection %>" SelectCommand="SELECT * FROM [Estado]"></asp:SqlDataSource>
      <asp:SqlDataSource runat="server" ID="SqlOrgao" ConnectionString='<%$ ConnectionStrings:PortalConnection %>' DeleteCommand="DELETE FROM [Orgao] WHERE [Id] = @Id" InsertCommand="INSERT INTO [Orgao] ([Descricao]) VALUES (@Descricao)" SelectCommand="SELECT * FROM [Orgao]" UpdateCommand="UPDATE [Orgao] SET [Descricao] = @Descricao WHERE [Id] = @Id">
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
      <asp:SqlDataSource runat="server" ID="SqlTipos" ConnectionString='<%$ ConnectionStrings:PortalConnection %>' DeleteCommand="DELETE FROM [Tipo] WHERE [Id] = @Id" InsertCommand="INSERT INTO [Tipo] ([Descricao]) VALUES (@Descricao)" SelectCommand="SELECT * FROM [Tipo]" UpdateCommand="UPDATE [Tipo] SET [Descricao] = @Descricao WHERE [Id] = @Id">
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
      <asp:SqlDataSource runat="server" ID="SqlAmbito" ConnectionString='<%$ ConnectionStrings:PortalConnection %>' DeleteCommand="DELETE FROM [Ambito] WHERE [Id] = @Id" InsertCommand="INSERT INTO [Ambito] ([Descricao]) VALUES (@Descricao)" SelectCommand="SELECT * FROM [Ambito]" UpdateCommand="UPDATE [Ambito] SET [Descricao] = @Descricao WHERE [Id] = @Id">
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
      <asp:SqlDataSource runat="server" ID="SqlSistemas" ConnectionString='<%$ ConnectionStrings:PortalConnection %>'
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
        <br />
            <dx:ASPxPopupControl ID="cpPopup3" runat="server" CloseAction="CloseButton" CloseOnEscape="true" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="cpPopup3"
        HeaderText="Endereço da Legislação" AllowDragging="True" PopupAnimationType="Fade" EnableViewState="False" Theme="Office2010Silver">
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl3" runat="server">
                <table style="width: 270px">
                    <tr>
                        <td style="height: 30px">
                            <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="Link da Legislação não cadastrado !" Theme="Office2010Silver"></dx:ASPxLabel>
                        </td>
                    </tr>
                </table>
            </dx:PopupControlContentControl>
        </ContentCollection>
        <Border BorderColor="#003300" BorderStyle="Solid" />
    </dx:ASPxPopupControl>
        <br />

            <dx:ASPxLoadingPanel ID="ASPxLoadingPanel1" runat="server"
        ClientInstanceName="loadingPanel" Modal="True" Theme="Office2003Blue" Text="Processando&amp;hellip;">
    </dx:ASPxLoadingPanel>

    </asp:Panel>


    <asp:SqlDataSource runat="server" ID="SqlAnexo" ConnectionString='<%$ ConnectionStrings:PortalConnection %>' DeleteCommand="DELETE FROM [Anexos] WHERE [id] = @id" InsertCommand="INSERT INTO [Anexos] ([Arquivo], [ContentType], [Data], [IDCliente], [IDLegisGeral], [IDConformidade], [IDParametros]) VALUES (@Arquivo, @ContentType, @Data, @IDCliente, @IDLegisGeral, @IDConformidade, @IDParametros)" SelectCommand="SELECT * FROM [Anexos] WHERE ([IDConformidade] = @IDConformidade)" UpdateCommand="UPDATE [Anexos] SET [Arquivo] = @Arquivo, [ContentType] = @ContentType, [Data] = @Data, [IDCliente] = @IDCliente, [IDLegisGeral] = @IDLegisGeral, [IDConformidade] = @IDConformidade, [IDParametros] = @IDParametros WHERE [id] = @id">
        <DeleteParameters>
            <asp:Parameter Name="id" Type="Int32"></asp:Parameter>
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="Arquivo" Type="String"></asp:Parameter>
            <asp:Parameter Name="ContentType" Type="String"></asp:Parameter>
            <asp:Parameter Name="Data" Type="Object"></asp:Parameter>
            <asp:Parameter Name="IDCliente" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="IDLegisGeral" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="IDConformidade" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="IDParametros" Type="Int32"></asp:Parameter>
        </InsertParameters>
        <SelectParameters>
            <asp:SessionParameter SessionField="IDConformidade" Name="IDConformidade" Type="Int32"></asp:SessionParameter>
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="Arquivo" Type="String"></asp:Parameter>
            <asp:Parameter Name="ContentType" Type="String"></asp:Parameter>
            <asp:Parameter Name="Data" Type="Object"></asp:Parameter>
            <asp:Parameter Name="IDCliente" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="IDLegisGeral" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="IDConformidade" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="IDParametros" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="id" Type="Int32"></asp:Parameter>
        </UpdateParameters>
    </asp:SqlDataSource>
   <asp:SqlDataSource ID="SqlLicenca" runat="server" ConnectionString="<%$ ConnectionStrings:PortalConnection %>"
        DeleteCommand="DELETE FROM [Licencas] WHERE [Id] = @Id"
        InsertCommand="INSERT INTO [Licencas] ([IdCliente], [Licenca], [Orgao], [Numero], [Emissao], [Validade], [Finalidade], [Requisito], [Obs], [Prazo], [Condicionante]) VALUES (@IdCliente, @Licenca, @Orgao, @Numero, @Emissao, @Validade, @Finalidade, @Requisito, @Obs, @prazo, @condicionante)"
        SelectCommand="SELECT * FROM [Licencas] WHERE ([IdCliente] = @IdCliente)" UpdateCommand="UPDATE [Licencas] SET [IdCliente] = @IdCliente, [Licenca] = @Licenca, [Orgao] = @Orgao, [Numero] = @Numero, [Emissao] = @Emissao, [Validade] = @Validade, [Finalidade] = @Finalidade, [Requisito] = @Requisito, [Obs] = @Obs, [prazo] = @prazo, [condicionante] = @condicionante WHERE [Id] = @Id">
        <DeleteParameters>
            <asp:Parameter Name="Id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:SessionParameter Name="IdCliente" SessionField="IDCliente" Type="Int32" />
            <asp:Parameter Name="Licenca" Type="String" />
            <asp:Parameter Name="Orgao" Type="String" />
            <asp:Parameter Name="Numero" Type="String" />
            <asp:Parameter DbType="Date" Name="Emissao" />
            <asp:Parameter Name="Validade" Type="String" />
            <asp:Parameter Name="Finalidade" Type="String" />
            <asp:Parameter Name="Requisito" Type="String" />
             <asp:Parameter Name="prazo" Type="Int32" />
            <asp:Parameter Name="condicionante" Type="Int32" />
            <asp:Parameter Name="Obs" Type="String" />
        </InsertParameters>
        <SelectParameters>
            <asp:SessionParameter Name="IdCliente" SessionField="IDCliente" Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="IdCliente" Type="Int32" />
            <asp:Parameter Name="Licenca" Type="String" />
            <asp:Parameter Name="Orgao" Type="String" />
            <asp:Parameter Name="Numero" Type="String" />
            <asp:Parameter DbType="Date" Name="Emissao" />
            <asp:Parameter Name="Validade" Type="String" />
            <asp:Parameter Name="Finalidade" Type="String" />
            <asp:Parameter Name="Requisito" Type="String" />
            <asp:Parameter Name="prazo" Type="Int32" />
            <asp:Parameter Name="condicionante" Type="Int32" />
            <asp:Parameter Name="Obs" Type="String" />
            <asp:Parameter Name="Id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource runat="server" ID="SqlParametro" ConnectionString='<%$ ConnectionStrings:PortalConnection %>'
        DeleteCommand="DELETE FROM [ParametrosCliente] WHERE [Id] = @Id"
        InsertCommand="INSERT INTO [ParametrosCliente] ([Capitulo], [Item], [Parametro], [Obrigacao], [IDLegisGeral], [IDCliente], [Numero], [Aplicavel], [Conhecimento]) VALUES (@Capitulo, @Item, @Parametro, @Obrigacao, @IDLegisGeral, @IDCliente, @Numero, @Aplicavel, @Conhecimento)"
        SelectCommand="SELECT * FROM [ParametrosCliente] WHERE ([IDLegisGeral] = @IDLegisGeral) and IDCliente = @IDCliente order by Numero"
        UpdateCommand="UPDATE [ParametrosCliente] SET [Obrigacao] = @Obrigacao, [Aplicavel] = @Aplicavel, [Conhecimento] = @Conhecimento WHERE [Id] = @Id">
        <DeleteParameters>
            <asp:Parameter Name="Id" Type="Int32"></asp:Parameter>
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="Capitulo" Type="String"></asp:Parameter>
            <asp:Parameter Name="Item" Type="String"></asp:Parameter>
            <asp:Parameter Name="Parametro" Type="String"></asp:Parameter>
            <asp:Parameter Name="Obrigacao" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="IDLegisGeral" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="IDCliente" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="Numero" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="Aplicavel" Type="Int32" />
             <asp:Parameter Name="Conhecimento" Type="Int32" />
        </InsertParameters>
        <SelectParameters>
            <asp:SessionParameter Name="IDLegisGeral" SessionField="IDLegisGeral" Type="Int32" />
            <asp:SessionParameter Name="IDCliente" SessionField="IdCli" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="Capitulo" Type="String"></asp:Parameter>
            <asp:Parameter Name="Item" Type="String"></asp:Parameter>
            <asp:Parameter Name="Parametro" Type="String"></asp:Parameter>
            <asp:Parameter Name="Obrigacao" Type="Int32" />
            <asp:Parameter Name="IDLegisGeral" Type="Int32" />
            <asp:Parameter Name="IDCliente" Type="Int32" />
            <asp:Parameter Name="Numero" Type="Int32" />
            <asp:Parameter Name="Aplicavel" Type="Int32" />
             <asp:Parameter Name="Conhecimento" Type="Int32" />
            <asp:Parameter Name="Id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource runat="server" ID="SqlLei2" ConnectionString='<%$ ConnectionStrings:PortalConnection %>'
        DeleteCommand="DELETE FROM [LegisGeral] WHERE [Id] = @Id"
        InsertCommand="INSERT INTO [LegisGeral] ([Sistema], [Ambito], [Numero], [Ano], [Orgao], [Tema], [Ementa], [Tipo]) VALUES (@Sistema, @Ambito, @Numero, @Ano, @Orgao, @Tema, @Ementa, @Tipo)"
        SelectCommand="SELECT DATEDIFF(day, G.Data, GETDATE()) as Dias, C.RazaoSocial, LC.*, G.* ,G.Lei as Ativo FROM [Clientes] as C, [Legis_Cliente] as LC,[LegisGeral] as G
where
LC.IDCliente=C.Id and 
LC.IDLegisGeral=G.Id and 
LC.IDCliente = @IdCli order by G.Numero" 
                UpdateCommand="UPDATE [Legis_Cliente] SET [Aplicavel] = @Aplicavel WHERE [IDLegisGeral] = @IDLegisGeral and IDCliente = @IdCli">
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
        </InsertParameters>
        <SelectParameters>
            <asp:SessionParameter Name="IdCli" SessionField="IdCli" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="Aplicavel" Type="String"></asp:Parameter>
            <asp:SessionParameter Name="IdCli" SessionField="IdCli" />
            <asp:SessionParameter Name="IDLegisGeral" SessionField="IDLegisGeral" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="Sqlplano" runat="server" ConnectionString='<%$ ConnectionStrings:PortalConnection %>'
        DeleteCommand="DELETE FROM [PlanoAcao] WHERE [IDAcao] = @IDAcao"
        InsertCommand="INSERT INTO [PlanoAcao] ([IDParametros], [Causa], [DataCausa], [Correcao_Corretivas], [Prazo], [Eficacia], [DataEficacia], [Evidencias], [ResultFinal], [IDCliente], [IDLegis], [IDAcao]) VALUES (@IDParametros, @Causa, @DataCausa, @Correcao_Corretivas, @Prazo, @Eficacia, @DataEficacia, @Evidencias, @ResultFinal, @IDCliente, @IDLegis, @IDAcao)"
        SelectCommand="SELECT * FROM [PlanoAcao] WHERE ([IDAcao] = @IDAcao)"
        UpdateCommand="UPDATE [PlanoAcao] SET [IDParametros] = @IDParametros,[IDAcao] = @IDAcao, [Causa] = @Causa, [DataCausa] = @DataCausa, [Correcao_Corretivas] = @Correcao_Corretivas, [Prazo] = @Prazo, [Eficacia] = @Eficacia, [DataEficacia] = @DataEficacia, [Evidencias] = @Evidencias, [ResultFinal] = @ResultFinal, [IDCliente] = @IDCliente, [IDLegis] = @IDLegis WHERE [id] = @id">
        <DeleteParameters>
            <asp:SessionParameter SessionField="IDAcao" Name="IDAcao" Type="Int32"></asp:SessionParameter>
            <asp:Parameter Name="id" Type="Int32"></asp:Parameter>
        </DeleteParameters>
        <InsertParameters>
            <asp:SessionParameter SessionField="Id" Name="IDParametros" Type="Int32"></asp:SessionParameter>
            <asp:Parameter Name="Causa" Type="String"></asp:Parameter>
            <asp:Parameter Name="DataCausa" Type="DateTime"></asp:Parameter>
            <asp:Parameter Name="Correcao_Corretivas" Type="String"></asp:Parameter>
            <asp:Parameter Name="Prazo" Type="DateTime"></asp:Parameter>
            <asp:Parameter Name="Eficacia" Type="String"></asp:Parameter>
            <asp:Parameter Name="DataEficacia" Type="DateTime"></asp:Parameter>
            <asp:Parameter Name="Evidencias" Type="String"></asp:Parameter>
            <asp:Parameter Name="ResultFinal" Type="String"></asp:Parameter>
            <asp:SessionParameter SessionField="IDCliente" Name="IDCliente" Type="Int32"></asp:SessionParameter>
            <asp:SessionParameter SessionField="IDLegisGeral" Name="IDLegis" Type="Int32"></asp:SessionParameter>
            <asp:SessionParameter SessionField="IDAcao" Name="IDAcao" Type="Int32"></asp:SessionParameter>
        </InsertParameters>
        <SelectParameters>
            <asp:SessionParameter SessionField="IDAcao" Name="IDAcao"></asp:SessionParameter>
        </SelectParameters>
        <UpdateParameters>
            <asp:SessionParameter SessionField="Id" Name="IDParametros" Type="Int32"></asp:SessionParameter>
            <asp:SessionParameter SessionField="IDAcao" Name="IDAcao" Type="Int32"></asp:SessionParameter>
            <asp:Parameter Name="Causa" Type="String"></asp:Parameter>
            <asp:Parameter Name="DataCausa" Type="DateTime"></asp:Parameter>
            <asp:Parameter Name="Correcao_Corretivas" Type="String"></asp:Parameter>
            <asp:Parameter Name="Prazo" Type="DateTime"></asp:Parameter>
            <asp:Parameter Name="Eficacia" Type="String"></asp:Parameter>
            <asp:Parameter Name="DataEficacia" Type="DateTime"></asp:Parameter>
            <asp:Parameter Name="Evidencias" Type="String"></asp:Parameter>
            <asp:Parameter Name="ResultFinal" Type="String"></asp:Parameter>
            <asp:SessionParameter SessionField="IDCliente" Name="IDCliente" Type="Int32"></asp:SessionParameter>
            <asp:SessionParameter SessionField="IDLegisGeral" Name="IDLegis" Type="Int32"></asp:SessionParameter>
            <asp:Parameter Name="id" Type="Int32"></asp:Parameter>
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource runat="server" ID="SqlUsuarios" ConnectionString='<%$ ConnectionStrings:PortalConnection %>'
        DeleteCommand="DELETE FROM [Acessos] WHERE [Id] = @Id"
        InsertCommand="INSERT INTO [Acessos] ([IDCliente], [Nome], [Cargo], [Setor], [Email], [Celular], [Fone], [Nivel], [Login], [Senha], [Imagem]) VALUES (@IDCliente, @Nome, @Cargo, @Setor, @Email, @Celular, @Fone, @Nivel, @Login, @Senha, @Imagem)"
        SelectCommand="SELECT * FROM [Acessos] where Nivel like '%Adm%'"
        UpdateCommand="UPDATE [Acessos] SET [IDCliente] = @IDCliente, [Nome] = @Nome, [Cargo] = @Cargo, [Setor] = @Setor, [Email] = @Email, [Celular] = @Celular, [Fone] = @Fone, [Nivel] = @Nivel, [Login] = @Login, [Senha] = @Senha, [Imagem] = @Imagem WHERE [Id] = @Id">
        <DeleteParameters>
            <asp:Parameter Name="Id" Type="Int32"></asp:Parameter>
        </DeleteParameters>
        <InsertParameters>
            <asp:SessionParameter SessionField="IdCliente" Name="IDCliente" Type="Int32"></asp:SessionParameter>
            <asp:Parameter Name="Nome" Type="String"></asp:Parameter>
            <asp:Parameter Name="Cargo" Type="String"></asp:Parameter>
            <asp:Parameter Name="Setor" Type="String"></asp:Parameter>
            <asp:Parameter Name="Email" Type="String"></asp:Parameter>
            <asp:Parameter Name="Celular" Type="String"></asp:Parameter>
            <asp:Parameter Name="Fone" Type="String"></asp:Parameter>
            <asp:Parameter Name="Nivel" Type="String"></asp:Parameter>
            <asp:Parameter Name="Login" Type="String"></asp:Parameter>
            <asp:Parameter Name="Senha" Type="String"></asp:Parameter>
            <asp:Parameter Name="Imagem" Type="String"></asp:Parameter>
        </InsertParameters>
        <UpdateParameters>
            <asp:SessionParameter SessionField="IdCliente" Name="IDCliente" Type="Int32"></asp:SessionParameter>
            <asp:Parameter Name="Nome" Type="String"></asp:Parameter>
            <asp:Parameter Name="Cargo" Type="String"></asp:Parameter>
            <asp:Parameter Name="Setor" Type="String"></asp:Parameter>
            <asp:Parameter Name="Email" Type="String"></asp:Parameter>
            <asp:Parameter Name="Celular" Type="String"></asp:Parameter>
            <asp:Parameter Name="Fone" Type="String"></asp:Parameter>
            <asp:Parameter Name="Nivel" Type="String"></asp:Parameter>
            <asp:Parameter Name="Login" Type="String"></asp:Parameter>
            <asp:Parameter Name="Senha" Type="String"></asp:Parameter>
            <asp:Parameter Name="Imagem" Type="String"></asp:Parameter>
            <asp:Parameter Name="Id" Type="Int32"></asp:Parameter>
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlConformidade" runat="server" ConnectionString="<%$ ConnectionStrings:PortalConnection %>"
        SelectCommand="SELECT * FROM [Conformidade] WHERE ([IDParametros] = @IDParametros)" OnSelecting="SqlClienteADM_Selecting"
        DeleteCommand="DELETE FROM [Conformidade] WHERE [id] = @id"
        InsertCommand="INSERT INTO [Conformidade] ([IDCliente], [IDLegis], [IDParametros], [Obrigacao], [Evidencias], [DataAvaliacao], [Avaliado], [Anexo], [DataValidacao], [Validado], [ProxAvaliacao], [Resultado]) VALUES (@IDCliente, @IDLegis, @IDParametros, @Obrigacao, @Evidencias, @DataAvaliacao, @Avaliado, @Anexo, @DataValidacao, @Validado, @ProxAvaliacao, @Resultado)"
        UpdateCommand="UPDATE [Conformidade] SET [IDCliente] = @IDCliente, [IDLegis] = @IDLegis, [IDParametros] = @IDParametros, [Obrigacao] = @Obrigacao, [Evidencias] = @Evidencias, [DataAvaliacao] = @DataAvaliacao, [Avaliado] = @Avaliado, [Anexo] = @Anexo, [DataValidacao] = @DataValidacao, [Validado] = @Validado, [ProxAvaliacao] = @ProxAvaliacao, [Resultado] = @Resultado WHERE [id] = @id">
        <DeleteParameters>
            <asp:Parameter Name="id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:SessionParameter Name="IDCliente" SessionField="IDCliente" Type="Int32" />
            <asp:SessionParameter Name="IDLegis" SessionField="IDLegisGeral" Type="Int32" />
            <asp:SessionParameter Name="IDParametros" SessionField="IDParametros" Type="Int32" />
            <asp:Parameter Name="Obrigacao" Type="Int32" />
            <asp:Parameter Name="Evidencias" Type="String" />
            <asp:Parameter Name="DataAvaliacao" Type="DateTime" />
            <asp:Parameter Name="Avaliado" Type="String" />
            <asp:Parameter Name="Anexo" Type="String" />
            <asp:Parameter Name="DataValidacao" Type="DateTime" />
            <asp:Parameter Name="Validado" Type="String" />
            <asp:Parameter Name="ProxAvaliacao" Type="DateTime" />
            <asp:Parameter Name="Resultado" Type="String" />
        </InsertParameters>
        <SelectParameters>
            <asp:SessionParameter Name="IDParametros" SessionField="IDParametros" Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:SessionParameter Name="IDCliente" SessionField="IDCliente" Type="Int32" />
            <asp:SessionParameter Name="IDLegis" SessionField="IDLegisGeral" Type="Int32" />
            <asp:SessionParameter Name="IDParametros" SessionField="IDParametros" Type="Int32" />
            <asp:Parameter Name="Obrigacao" Type="Int32" />
            <asp:Parameter Name="Evidencias" Type="String" />
            <asp:Parameter Name="DataAvaliacao" Type="DateTime" />
            <asp:Parameter Name="Avaliado" Type="String" />
            <asp:Parameter Name="Anexo" Type="String" />
            <asp:Parameter Name="DataValidacao" Type="DateTime" />
            <asp:Parameter Name="Validado" Type="String" />
            <asp:Parameter Name="ProxAvaliacao" Type="DateTime" />
            <asp:Parameter Name="Resultado" Type="String" />
            <asp:Parameter Name="id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlClienteADM" runat="server" ConnectionString="<%$ ConnectionStrings:PortalConnection %>"
        SelectCommand="SELECT * FROM [ClientesADM] WHERE ([IdUsuario] = @IdUsuario)"
        OnSelecting="SqlClienteADM_Selecting"
        DeleteCommand="DELETE FROM [ClientesADM] WHERE [Id] = @Id"
        InsertCommand="INSERT INTO [ClientesADM] ([N_Cliente], [IdUsuario], [NomeFantasia], [RazaoSocial], [CNPJ], [IE], [Endereco], [Bairro], [Cidade], [CEP], [Estado], [HomePage], [Fone1], [Fone2], [Fone3], [Fone4], [DataCadastro]) VALUES (@N_Cliente, @IdUsuario, @NomeFantasia, @RazaoSocial, @CNPJ, @IE, @Endereco, @Bairro, @Cidade, @CEP, @Estado, @HomePage, @Fone1, @Fone2, @Fone3, @Fone4, @DataCadastro)" ProviderName="System.Data.SqlClient" UpdateCommand="UPDATE [ClientesADM] SET [N_Cliente] = @N_Cliente, [IdUsuario] = @IdUsuario, [NomeFantasia] = @NomeFantasia, [RazaoSocial] = @RazaoSocial, [CNPJ] = @CNPJ, [IE] = @IE, [Endereco] = @Endereco, [Bairro] = @Bairro, [Cidade] = @Cidade, [CEP] = @CEP, [Estado] = @Estado, [HomePage] = @HomePage, [Fone1] = @Fone1, [Fone2] = @Fone2, [Fone3] = @Fone3, [Fone4] = @Fone4, [DataCadastro] = @DataCadastro WHERE [Id] = @Id">
        <DeleteParameters>
            <asp:Parameter Name="Id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="N_Cliente" Type="String" />
            <asp:Parameter Name="IdUsuario" Type="Int32" />
            <asp:Parameter Name="NomeFantasia" Type="String" />
            <asp:Parameter Name="RazaoSocial" Type="String" />
            <asp:Parameter Name="CNPJ" Type="String" />
            <asp:Parameter Name="IE" Type="String" />
            <asp:Parameter Name="Endereco" Type="String" />
            <asp:Parameter Name="Bairro" Type="String" />
            <asp:Parameter Name="Cidade" Type="String" />
            <asp:Parameter Name="CEP" Type="String" />
            <asp:Parameter Name="Estado" Type="String" />
            <asp:Parameter Name="HomePage" Type="String" />
            <asp:Parameter Name="Fone1" Type="String" />
            <asp:Parameter Name="Fone2" Type="String" />
            <asp:Parameter Name="Fone3" Type="String" />
            <asp:Parameter Name="Fone4" Type="String" />
            <asp:Parameter Name="DataCadastro" Type="String" />
        </InsertParameters>
        <SelectParameters>
            <asp:SessionParameter Name="IdUsuario" SessionField="IdUsuario" Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="N_Cliente" Type="String" />
            <asp:Parameter Name="IdUsuario" Type="Int32" />
            <asp:Parameter Name="NomeFantasia" Type="String" />
            <asp:Parameter Name="RazaoSocial" Type="String" />
            <asp:Parameter Name="CNPJ" Type="String" />
            <asp:Parameter Name="IE" Type="String" />
            <asp:Parameter Name="Endereco" Type="String" />
            <asp:Parameter Name="Bairro" Type="String" />
            <asp:Parameter Name="Cidade" Type="String" />
            <asp:Parameter Name="CEP" Type="String" />
            <asp:Parameter Name="Estado" Type="String" />
            <asp:Parameter Name="HomePage" Type="String" />
            <asp:Parameter Name="Fone1" Type="String" />
            <asp:Parameter Name="Fone2" Type="String" />
            <asp:Parameter Name="Fone3" Type="String" />
            <asp:Parameter Name="Fone4" Type="String" />
            <asp:Parameter Name="DataCadastro" Type="String" />
            <asp:Parameter Name="Id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlClientes" runat="server" ConnectionString="<%$ ConnectionStrings:PortalConnection %>"
        SelectCommand="SELECT * FROM [Clientes] ">

    </asp:SqlDataSource>
    <asp:SqlDataSource runat="server" ID="SqlUsuariosCli" ConnectionString='<%$ ConnectionStrings:PortalConnection %>'
        SelectCommand="SELECT * FROM [Acessos] WHERE ([IDCliente] = @IDCliente)" DeleteCommand="DELETE FROM [Acessos] WHERE [Id] = @Id" InsertCommand="INSERT INTO [Acessos] ([IDCliente], [Nome], [Cargo], [Setor], [Email], [Celular], [Fone], [Nivel], [Login], [Senha], [Imagem]) VALUES (@IDCliente, @Nome, @Cargo, @Setor, @Email, @Celular, @Fone, @Nivel, @Login, @Senha, @Imagem)" UpdateCommand="UPDATE [Acessos] SET [IDCliente] = @IDCliente, [Nome] = @Nome, [Cargo] = @Cargo, [Setor] = @Setor, [Email] = @Email, [Celular] = @Celular, [Fone] = @Fone, [Nivel] = @Nivel, [Login] = @Login, [Senha] = @Senha, [Imagem] = @Imagem WHERE [Id] = @Id">
        <DeleteParameters>
            <asp:Parameter Name="Id" Type="Int32"></asp:Parameter>
        </DeleteParameters>
        <InsertParameters>
            <asp:SessionParameter SessionField="IDCliente" Name="IDCliente" Type="Int32" DefaultValue="1"></asp:SessionParameter>
            <asp:Parameter Name="Nome" Type="String"></asp:Parameter>
            <asp:Parameter Name="Cargo" Type="String"></asp:Parameter>
            <asp:Parameter Name="Setor" Type="String"></asp:Parameter>
            <asp:Parameter Name="Email" Type="String"></asp:Parameter>
            <asp:Parameter Name="Celular" Type="String"></asp:Parameter>
            <asp:Parameter Name="Fone" Type="String"></asp:Parameter>
            <asp:Parameter Name="Nivel" Type="String"></asp:Parameter>
            <asp:Parameter Name="Login" Type="String"></asp:Parameter>
            <asp:Parameter Name="Senha" Type="String"></asp:Parameter>
            <asp:Parameter Name="Imagem" Type="String"></asp:Parameter>
        </InsertParameters>
        <SelectParameters>
            <asp:SessionParameter SessionField="IDCliente" Name="IDCliente" Type="Int32" DefaultValue="1"></asp:SessionParameter>
        </SelectParameters>
        <UpdateParameters>
            <asp:SessionParameter SessionField="IDCliente" Name="IDCliente" Type="Int32" DefaultValue="1"></asp:SessionParameter>
            <asp:Parameter Name="Nome" Type="String"></asp:Parameter>
            <asp:Parameter Name="Cargo" Type="String"></asp:Parameter>
            <asp:Parameter Name="Setor" Type="String"></asp:Parameter>
            <asp:Parameter Name="Email" Type="String"></asp:Parameter>
            <asp:Parameter Name="Celular" Type="String"></asp:Parameter>
            <asp:Parameter Name="Fone" Type="String"></asp:Parameter>
            <asp:Parameter Name="Nivel" Type="String"></asp:Parameter>
            <asp:Parameter Name="Login" Type="String"></asp:Parameter>
            <asp:Parameter Name="Senha" Type="String"></asp:Parameter>
            <asp:Parameter Name="Imagem" Type="String"></asp:Parameter>
            <asp:Parameter Name="Id" Type="Int32"></asp:Parameter>
        </UpdateParameters>
    </asp:SqlDataSource>
                <asp:SqlDataSource runat="server" ID="SqlLegisGeral" ConnectionString='<%$ ConnectionStrings:PortalConnection %>'
        SelectCommand="SELECT * FROM [LegisGeral]">

   </asp:SqlDataSource>

    <dx:ASPxPopupControl ID="pcAnexo" runat="server" CloseAction="CloseButton" CloseOnEscape="true" Modal="True"
            PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="pcAnexo"
            HeaderText="Lançamento de Anexos" AllowDragging="True" PopupAnimationType="None" EnableViewState="False">
            <HeaderStyle HorizontalAlign="Center" />
            <ContentCollection>
                <dx:PopupControlContentControl runat="server">
                    <table style="width: 465px">
                        <tr>
                            <td style="text-align: left; height: 14px;" class="dxflEmptyItem_Office2003Olive">
                                <asp:FileUpload ID="FileUpload1" runat="server" Width="300px" />
                            </td>
                            <td class="dxflEmptyItem_Office2003Olive" style="text-align: left; height: 14px;">
                                <asp:Button ID="btnUpload" runat="server" Text="Enviar Arquivo" OnClick="Upload" /></td>
                        </tr>
                        <tr>
                            <td style="text-align: center">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="text-align: center" colspan="2" class="dxflEmptyItem_Office2003Olive">
                                <asp:SqlDataSource runat="server" ID="SqlArquivos" ConnectionString='<%$ ConnectionStrings:PortalConnection %>' SelectCommand="SELECT * FROM [Anexos] WHERE ([IDConformidade] = @IDConformidade)">
                                    <SelectParameters>
                                        <asp:SessionParameter Name="IDConformidade" SessionField="IDConformidade" Type="Int32" />
                                    </SelectParameters>
                                </asp:SqlDataSource> 

                                <dx:ASPxGridView ID="GridAnexo" runat="server" Theme="Youthful" DataSourceID="SqlArquivos" Width="100%">
                                    <Columns>
                                        <dx:GridViewDataTextColumn FieldName="id" ReadOnly="True" VisibleIndex="0" Visible="False">
                                            <EditFormSettings Visible="False"></EditFormSettings>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Arquivo" VisibleIndex="1"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="ContentType" VisibleIndex="2" Caption="Extensão"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="IDCliente" VisibleIndex="3" Visible="false"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="IDLegisGeral" VisibleIndex="4" Visible="false"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="IDConformidade" VisibleIndex="5" Visible="false"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="IDParametros" VisibleIndex="6" Visible="false"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Width="15%" Caption="Baixar" VisibleIndex="7">
                                            <DataItemTemplate>
                                                <asp:LinkButton ID="lnkDownload" runat="server" Text="Download" OnClick="DownloadFile"
                                                    CommandArgument='<%# Eval("Id") %>'></asp:LinkButton>
                                            </DataItemTemplate>
                                        </dx:GridViewDataTextColumn>

                                    </Columns>
                                </dx:ASPxGridView>

                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: center" colspan="2" class="dxflEmptyItem_Office2003Olive">
                                <dx:ASPxButton ID="ASPxButton1" runat="server" AutoPostBack="False" Text="FECHAR" Width="100px" OnClick="ASPxButton1_Click">
                                </dx:ASPxButton>
                            </td>
                        </tr>

                    </table>
                </dx:PopupControlContentControl>
            </ContentCollection>
        </dx:ASPxPopupControl>
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
    <dx:ASPxPopupControl ID="ASPxPopupControl3" runat="server" ClientInstanceName="popupControl" Height="580px" Modal="True" CloseAction="CloseButton" Width="1000px" AllowDragging="True" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" HeaderText="Gestão de Licenças">
            <ContentCollection>
                <dx:PopupControlContentControl runat="server">
                       <dx:ASPxGridView ID="GridLicenca" runat="server" AutoGenerateColumns="False" DataSourceID="SqlLicenca" KeyFieldName="Id" KeyboardSupport="True" Theme="Office2010Silver" Width="100%">
     <Toolbars>
                            <dx:GridViewToolbar ItemAlign="Left" EnableAdaptivity="true">
                                <Items>
                                    <dx:GridViewToolbarItem Command="New" Text="Cadastrar" />
                                    <dx:GridViewToolbarItem Command="Edit" Text="Editar" />
                                    <dx:GridViewToolbarItem Command="Delete" Text="Excluir" />
                                    <dx:GridViewToolbarItem Command="Refresh" Text="Atualizar" BeginGroup="true" />
                                </Items>
                            </dx:GridViewToolbar>
                        </Toolbars>
                           <Columns>
            <dx:GridViewDataTextColumn FieldName="Id" AdaptivePriority="1" ReadOnly="True" Visible="False">
                <EditFormSettings Visible="False" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Licenca" Caption="Documento Legal" AdaptivePriority="3" EditFormSettings-VisibleIndex="3">
<EditFormSettings VisibleIndex="3"></EditFormSettings>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Orgao" AdaptivePriority="4" EditFormSettings-VisibleIndex="4">
<EditFormSettings VisibleIndex="4"></EditFormSettings>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Numero" AdaptivePriority="5" EditFormSettings-VisibleIndex="5">
<EditFormSettings VisibleIndex="5"></EditFormSettings>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="Emissao" Width="90px" AdaptivePriority="6" EditFormSettings-VisibleIndex="6">
                 <PropertiesDateEdit DisplayFormatString="yyyy-MM-dd"></PropertiesDateEdit>
<EditFormSettings VisibleIndex="6"></EditFormSettings>
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataDateColumn FieldName="Validade" Width="90px" AdaptivePriority="7" AllowTextTruncationInAdaptiveMode="true">
                 <PropertiesDateEdit DisplayFormatString="yyyy-MM-dd"></PropertiesDateEdit>
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataComboBoxColumn FieldName="Prazo" Caption="Prazo de Alerta" AdaptivePriority="8" EditFormSettings-VisibleIndex="8">
                <PropertiesComboBox Width="200px">
                    <Items>
                        <dx:ListEditItem Text="15 dias" Value="15" />
                        <dx:ListEditItem Text="30 dias" Value="30" />
                        <dx:ListEditItem Text="60 dias" Value="60" />
                        <dx:ListEditItem Text="90 dias" Value="90" />
                        <dx:ListEditItem Text="120 dias" Value="120" />
                        <dx:ListEditItem Text="180 dias" Value="180" />
                    </Items>
                </PropertiesComboBox>

<EditFormSettings VisibleIndex="8"></EditFormSettings>
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataMemoColumn FieldName="Obs" Caption="Observação" AdaptivePriority="10" EditFormSettings-VisibleIndex="10">
<EditFormSettings VisibleIndex="10"></EditFormSettings>
            </dx:GridViewDataMemoColumn>
            <dx:GridViewDataComboBoxColumn Caption="Cliente" FieldName="IdCliente" ShowInCustomizationForm="True" AdaptivePriority="2" EditFormSettings-VisibleIndex="11">
                <PropertiesComboBox DataSourceID="SqlCliente" TextField="RazaoSocial" ValueField="Id">
                </PropertiesComboBox>

<EditFormSettings VisibleIndex="11"></EditFormSettings>
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataComboBoxColumn Caption="Com Condicionantes ?" FieldName="Condicionante" ShowInCustomizationForm="True" AdaptivePriority="9" EditFormSettings-VisibleIndex="9">
                <PropertiesComboBox Width="200px">
                    <Items>
                        <dx:ListEditItem Text="Sim" Value="1" />
                        <dx:ListEditItem Text="Não" Value="0" />
                    </Items>
                </PropertiesComboBox>

<EditFormSettings VisibleIndex="9"></EditFormSettings>
            </dx:GridViewDataComboBoxColumn>
        </Columns>
                            <SettingsSearchPanel CustomEditorID="tbToolbarSearch" />
        <Styles>
            <AlternatingRow Enabled="True">
            </AlternatingRow>
        </Styles>

        <SettingsEditing EditFormColumnCount="2" Mode="PopupEditForm" />
        <SettingsLoadingPanel Mode="Disabled" />
        <SettingsDetail ShowDetailRow="True" />
        <SettingsPopup>
            <EditForm HorizontalAlign="Center" Modal="True" VerticalAlign="WindowCenter" Width="600" />
            <CustomizationWindow HorizontalAlign="WindowCenter" VerticalAlign="WindowCenter" />
        </SettingsPopup>
        <SettingsBehavior ConfirmDelete="True" EnableRowHotTrack="True"
            AllowSelectByRowClick="True"
            ProcessSelectionChangedOnServer="True"
            AllowFocusedRow="True"
            AllowSelectSingleRowOnly="True" />
        <Templates>
            <DetailRow>
                <dx:ASPxGridView ID="CridCondicionantes" runat="server" Width="100%" AutoGenerateColumns="False" DataSourceID="SqlCondicionantes" KeyFieldName="Id" OnBeforePerformDataSelect="CridCondicionantes_BeforePerformDataSelect" Theme="Office2010Silver">
                    <SettingsLoadingPanel Mode="Disabled" />
                    <SettingsEditing EditFormColumnCount="2" Mode="EditForm">
                    </SettingsEditing>
                    <SettingsDetail ShowDetailRow="True" />
                    <SettingsPager AlwaysShowPager="True" />
                    <SettingsEditing EditFormColumnCount="2" Mode="EditForm" />
                    <Settings ShowTitlePanel="true" />
                    <SettingsBehavior AllowFocusedRow="True" AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" ConfirmDelete="True" EnableRowHotTrack="True" ProcessSelectionChangedOnServer="True" />
                    <SettingsCommandButton>
                        <NewButton Text="Novo">
                        </NewButton>
                        <CancelButton Text="Cancelar">
                        </CancelButton>
                        <EditButton Text="Editar">
                        </EditButton>
                        <DeleteButton Text="Excluir">
                        </DeleteButton>
                        <UpdateButton Text="Gravar">
                        </UpdateButton>
                    </SettingsCommandButton>
                    <SettingsPopup>
                        <EditForm HorizontalAlign="Center" Modal="True" VerticalAlign="WindowCenter" Width="800" />
                        <CustomizationWindow HorizontalAlign="WindowCenter" VerticalAlign="WindowCenter" />
                    </SettingsPopup>
                    <SettingsText Title="Gestão de Condicionantes" />
                    <Columns>
                        <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0" AllowTextTruncationInAdaptiveMode="true">
                        </dx:GridViewCommandColumn>
                        <dx:GridViewDataTextColumn FieldName="Id" ReadOnly="True" Visible="false" AdaptivePriority="1" AllowTextTruncationInAdaptiveMode="true">
                            <EditFormSettings Visible="False" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Nº" FieldName="Numero" Width="100" AdaptivePriority="2" AllowTextTruncationInAdaptiveMode="true">
                              <Settings AllowEllipsisInText="True" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataMemoColumn Caption="Descrição da Exigencia" Width="300" FieldName="Descricao" AdaptivePriority="3" AllowTextTruncationInAdaptiveMode="true">
                              <Settings AllowEllipsisInText="True" />
                        </dx:GridViewDataMemoColumn>
                        <dx:GridViewDataTextColumn Caption="Avaliação e Analise" Width="100" FieldName="Avaliacao" AdaptivePriority="4" AllowTextTruncationInAdaptiveMode="true">
                              <Settings AllowEllipsisInText="True" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Controles Existentes" FieldName="Controles" AdaptivePriority="5" AllowTextTruncationInAdaptiveMode="true">
                              <Settings AllowEllipsisInText="True" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Responsavel" AdaptivePriority="6" AllowTextTruncationInAdaptiveMode="true">
                              <Settings AllowEllipsisInText="True" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Meios de Analise" FieldName="MeiosAnalise" AdaptivePriority="7" AllowTextTruncationInAdaptiveMode="true">
                              <Settings AllowEllipsisInText="True" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Frequencia de Monitoramento" FieldName="FrequenciaMonotora" AdaptivePriority="8" AllowTextTruncationInAdaptiveMode="true">
                              <Settings AllowEllipsisInText="True" />
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataComboBoxColumn Caption="Situação" FieldName="Situacao" AdaptivePriority="9" AllowTextTruncationInAdaptiveMode="true">
                            <PropertiesComboBox Width="200px">
                                <Items>
                                    <dx:ListEditItem Text="Atente" Value="Atente" />
                                    <dx:ListEditItem Text="Não Atende" Value="Nao Atende" />
                                    <dx:ListEditItem Text="Em Andamento" Value="Em Andamento" />
                                    <dx:ListEditItem Text="Em Análise" Value="Em Analise" />
                                </Items>
                            </PropertiesComboBox>
                        </dx:GridViewDataComboBoxColumn>
                        <dx:GridViewDataComboBoxColumn Caption="Possue Prazo de Validade?" FieldName="AplicavelPrazo" AdaptivePriority="9" AllowTextTruncationInAdaptiveMode="true">
                            <PropertiesComboBox Width="200px">
                                <Items>
                                    <dx:ListEditItem Text="Aplicavel" Value="1" />
                                    <dx:ListEditItem Text="Não Aplicavel" Value="0" />
                                </Items>
                            </PropertiesComboBox>
                        </dx:GridViewDataComboBoxColumn>
                        <dx:GridViewDataDateColumn FieldName="Data" AdaptivePriority="10" AllowTextTruncationInAdaptiveMode="true">
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataComboBoxColumn Caption="Prazo de Alerta" FieldName="Alerta" AdaptivePriority="11" AllowTextTruncationInAdaptiveMode="true">
                            <PropertiesComboBox Width="200px">
                                <Items>
                                    <dx:ListEditItem Text="15 dias" Value="15" />
                                    <dx:ListEditItem Text="30 dias" Value="30" />
                                    <dx:ListEditItem Text="60 dias" Value="60" />
                                    <dx:ListEditItem Text="90 dias" Value="90" />
                                    <dx:ListEditItem Text="120 dias" Value="120" />
                                    <dx:ListEditItem Text="180 dias" Value="180" />
                                </Items>
                            </PropertiesComboBox>
                        </dx:GridViewDataComboBoxColumn>
                        <dx:GridViewDataTextColumn FieldName="IdLicenca" Visible="false" AdaptivePriority="12" AllowTextTruncationInAdaptiveMode="true">
                              <Settings AllowEllipsisInText="True" />
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <Styles>
                        <AlternatingRow Enabled="True">
                        </AlternatingRow>
                    </Styles>
                </dx:ASPxGridView>
            </DetailRow>
        </Templates>
        <SettingsPager AlwaysShowPager="True" />
        <SettingsEditing EditFormColumnCount="2" Mode="EditForm"></SettingsEditing>

        <Settings ShowTitlePanel="true" />
        <SettingsText Title="Gestão de Licenças e outros Documentos Legais" />
        <Columns>

        </Columns>
        <SettingsCommandButton>
            <NewButton Text="Novo">
            </NewButton>
            <CancelButton Text="Cancelar">
            </CancelButton>
            <EditButton Text="Editar">
            </EditButton>
            <DeleteButton Text="Excluir">
            </DeleteButton>
            <UpdateButton Text="Gravar">
            </UpdateButton>
        </SettingsCommandButton>
    </dx:ASPxGridView>

    <asp:SqlDataSource runat="server" ID="SqlCondicionantes" ConnectionString='<%$ ConnectionStrings:PortalConnection %>' 
        DeleteCommand="DELETE FROM [Condicionantes] WHERE [Id] = @Id" 
        InsertCommand="INSERT INTO [Condicionantes] ([Numero], [Descricao], [Avaliacao], [Controles], [Responsavel], [MeiosAnalise], [FrequenciaMonotora], [Situacao], [AplicavelPrazo], [Data], [Alerta], [IdLicenca]) VALUES (@Numero, @Descricao, @Avaliacao, @Controles, @Responsavel, @MeiosAnalise, @FrequenciaMonotora, @Situacao, @AplicavelPrazo, @Data, @Alerta, @IdLicenca)" 
        SelectCommand="SELECT * FROM [Condicionantes] WHERE ([IdLicenca] = @IdLicenca)" 
        UpdateCommand="UPDATE [Condicionantes] SET [Numero] = @Numero, [Descricao] = @Descricao, [Avaliacao] = @Avaliacao, [Controles] = @Controles, [Responsavel] = @Responsavel, [MeiosAnalise] = @MeiosAnalise, [FrequenciaMonotora] = @FrequenciaMonotora, [Situacao] = @Situacao, [AplicavelPrazo] = @AplicavelPrazo, [Data] = @Data, [Alerta] = @Alerta, [IdLicenca] = @IdLicenca WHERE [Id] = @Id">
        <DeleteParameters>
            <asp:Parameter Name="Id" Type="Int32"></asp:Parameter>
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="Numero" Type="String"></asp:Parameter>
            <asp:Parameter Name="Descricao" Type="String"></asp:Parameter>
            <asp:Parameter Name="Avaliacao" Type="String"></asp:Parameter>
            <asp:Parameter Name="Controles" Type="String"></asp:Parameter>
            <asp:Parameter Name="Responsavel" Type="String"></asp:Parameter>
            <asp:Parameter Name="MeiosAnalise" Type="String"></asp:Parameter>
            <asp:Parameter Name="FrequenciaMonotora" Type="String"></asp:Parameter>
            <asp:Parameter Name="Situacao" Type="String"></asp:Parameter>
            <asp:Parameter Name="AplicavelPrazo" Type="String"></asp:Parameter>
            <asp:Parameter DbType="Date" Name="Data"></asp:Parameter>
            <asp:Parameter Name="Alerta" Type="Int32"></asp:Parameter>
            <asp:SessionParameter SessionField="IdLicenca" Name="IdLicenca" Type="Int32"></asp:SessionParameter>
        </InsertParameters>
        <SelectParameters>
            <asp:SessionParameter SessionField="IdLicenca" Name="IdLicenca" Type="Int32"></asp:SessionParameter>
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="Numero" Type="String"></asp:Parameter>
            <asp:Parameter Name="Descricao" Type="String"></asp:Parameter>
            <asp:Parameter Name="Avaliacao" Type="String"></asp:Parameter>
            <asp:Parameter Name="Controles" Type="String"></asp:Parameter>
            <asp:Parameter Name="Responsavel" Type="String"></asp:Parameter>
            <asp:Parameter Name="MeiosAnalise" Type="String"></asp:Parameter>
            <asp:Parameter Name="FrequenciaMonotora" Type="String"></asp:Parameter>
            <asp:Parameter Name="Situacao" Type="String"></asp:Parameter>
            <asp:Parameter Name="AplicavelPrazo" Type="String"></asp:Parameter>
            <asp:Parameter DbType="Date" Name="Data"></asp:Parameter>
            <asp:Parameter Name="Alerta" Type="Int32"></asp:Parameter>
            <asp:SessionParameter SessionField="IdLicenca" Name="IdLicenca" Type="Int32"></asp:SessionParameter>
            <asp:Parameter Name="Id" Type="Int32"></asp:Parameter>
        </UpdateParameters>
    </asp:SqlDataSource>



    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PortalConnection %>"
        DeleteCommand="DELETE FROM [Licencas] WHERE [Id] = @Id"
        InsertCommand="INSERT INTO [Licencas] ([IdCliente], [Licenca], [Orgao], [Numero], [Emissao], [Validade], [Finalidade], [Requisito], [Obs], [Prazo], [Condicionante]) VALUES (@IdCliente, @Licenca, @Orgao, @Numero, @Emissao, @Validade, @Finalidade, @Requisito, @Obs, @Prazo, @Condicionante)"
        SelectCommand="SELECT * FROM [Licencas]" UpdateCommand="UPDATE [Licencas] SET [IdCliente] = @IdCliente, [Licenca] = @Licenca, [Orgao] = @Orgao, [Numero] = @Numero, [Emissao] = @Emissao, [Validade] = @Validade, [Finalidade] = @Finalidade, [Requisito] = @Requisito, [Obs] = @Obs, [Prazo] = @Prazo, [Condicionante] = @Condicionante WHERE [Id] = @Id">
        <DeleteParameters>
            <asp:Parameter Name="Id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="IdCliente" Type="Int32"></asp:Parameter>

            <asp:Parameter Name="Licenca" Type="String" />
            <asp:Parameter Name="Orgao" Type="String" />
            <asp:Parameter Name="Numero" Type="String" />
            <asp:Parameter DbType="Date" Name="Emissao" />
            <asp:Parameter Name="Validade" Type="String" />
            <asp:Parameter Name="Finalidade" Type="String" />
            <asp:Parameter Name="Requisito" Type="String" />
            <asp:Parameter Name="Obs" Type="String" />
            <asp:Parameter Name="Prazo" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="Condicionante" Type="Int32"></asp:Parameter>
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="IdCliente" Type="Int32" />
            <asp:Parameter Name="Licenca" Type="String" />
            <asp:Parameter Name="Orgao" Type="String" />
            <asp:Parameter Name="Numero" Type="String" />
            <asp:Parameter DbType="Date" Name="Emissao" />
            <asp:Parameter Name="Validade" Type="String" />
            <asp:Parameter Name="Finalidade" Type="String" />
            <asp:Parameter Name="Requisito" Type="String" />
            <asp:Parameter Name="Obs" Type="String" />
            <asp:Parameter Name="Prazo" Type="Int32" />
            <asp:Parameter Name="Condicionante" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="Id" Type="Int32"></asp:Parameter>
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlCliente" runat="server" ConnectionString='<%$ ConnectionStrings:PortalConnection %>'
        SelectCommand="SELECT * FROM [Clientes]  WHERE ([Id] = @Id) ORDER BY [RazaoSocial]">
                <SelectParameters>
          <asp:SessionParameter Name="Id" SessionField="IdCli" />
        </SelectParameters>
       
    </asp:SqlDataSource>
                       <br />
                    <table style="border: none">
                        <tr>
                            <td>
                                <dx:ASPxButton ID="ASPxButton2" runat="server" AutoPostBack="False" Text="Excluir" Width="80px" OnClick="btnExcluir_Click" Visible="False">
                                </dx:ASPxButton>
                            </td>
                            <td>
                                <dx:ASPxButton ID="ASPxButton6" runat="server" AutoPostBack="False" ClientInstanceName="btnCancel"
                                    Text="Sair" Width="80px">
                                    <ClientSideEvents Click="function(s, e) {
	popupControl.Hide();
}" />
                                </dx:ASPxButton>
                            </td>
                        </tr>
                    </table>
                </dx:PopupControlContentControl>
            </ContentCollection>
        </dx:ASPxPopupControl>
 
    <asp:SqlDataSource ID="SqlValidadores" runat="server" ConnectionString="<%$ ConnectionStrings:PortalConnection %>" SelectCommand="SELECT * FROM [Validadores] where (operacao = 'Avalia' and [IdCliente] = @IdCliente) or ( operacao = 'Ambos' and  [IdCliente] = @IdCliente) ">
                                                                                <SelectParameters>
                                                                                    <asp:SessionParameter Name="IdCliente" SessionField="IdCliente" Type="Int32" />
                                                                                </SelectParameters>
                                                                            </asp:SqlDataSource>
   
    <asp:SqlDataSource ID="SqlAvaliadores" runat="server" ConnectionString="<%$ ConnectionStrings:PortalConnection %>" SelectCommand="SELECT * FROM [Validadores] where (operacao = 'Valida' and [IdCliente] = @IdCliente) or ( operacao = 'Ambos' and  [IdCliente] = @IdCliente) ">
                                                                                <SelectParameters>
                                                                                    <asp:SessionParameter Name="IdCliente" SessionField="IdCliente" Type="Int32" />
                                                                                </SelectParameters>
                                                                            </asp:SqlDataSource>
   
    <dx:ASPxPopupControl ID="cpPopup5" runat="server" CloseAction="CloseButton" CloseOnEscape="true" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="cpPopup3"
        HeaderText="Endereço da Legislação" AllowDragging="True" PopupAnimationType="Fade" EnableViewState="False" Theme="Office2010Silver">
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
                <table style="width: 270px">
                    <tr>
                        <td style="height: 30px">
                            <dx:ASPxLabel ID="ASPxLabel3" runat="server" Text="Link da Legislação não cadastrado !" Theme="Office2010Silver"></dx:ASPxLabel>
                        </td>
                    </tr>
                </table>
            </dx:PopupControlContentControl>
        </ContentCollection>
        <Border BorderColor="#003300" BorderStyle="Solid" />
    </dx:ASPxPopupControl>
   
    <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" ClientInstanceName="popupControl" Height="580px" Modal="True" CloseAction="CloseButton" Width="1000px" AllowDragging="True" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" HeaderText="Adicionar 100 Leis de Clientes por Página">
            <ContentCollection>
                <dx:PopupControlContentControl runat="server">
                    <dx:ASPxGridView ID="GridLegisGeral2" runat="server" ClientInstanceName="GridLegisGeral2" Width="100%" DataSourceID="SqlLegisGeral" AutoGenerateColumns="False" KeyFieldName="Id" Theme="Office2010Silver" OnCustomCallback="GridLegisGeral2_CustomCallback">
                        <SettingsSearchPanel Visible="True"></SettingsSearchPanel>
                        <SettingsBehavior AllowFocusedRow="True" EnableRowHotTrack="True" />
                        <SettingsSearchPanel Visible="true" />
                        <Settings ShowTitlePanel="false" ShowStatusBar="Visible" VerticalScrollableHeight="400" VerticalScrollBarMode="Auto" />
                        <SettingsText Title="LEIS DE CLIENTES" />
                                                          <Styles>
                <AlternatingRow Enabled="True">
                </AlternatingRow>
            </Styles>
                        <Columns>
                            <dx:GridViewDataTextColumn Caption="#" VisibleIndex="0">
                                <HeaderTemplate>
                                    <dx:ASPxCheckBox ID="cbCheckAll" runat="server" OnInit="cbCheckAll_Init">
                                    </dx:ASPxCheckBox>
                                </HeaderTemplate>
                                <DataItemTemplate>
                                    <dx:ASPxCheckBox ID="cbCheck" runat="server" OnInit="cbCheck_Init">
                                    </dx:ASPxCheckBox>
                                </DataItemTemplate>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Aplicavel" visible ="false" VisibleIndex="10">
                                <DataItemTemplate>
                                    <dx:ASPxCheckBox ID="cbCheck2" runat="server">
                                    </dx:ASPxCheckBox>
                                </DataItemTemplate>
                            </dx:GridViewDataTextColumn>

               <%--                  <dx:GridViewDataComboBoxColumn Caption="Possue Prazo de Validade?" FieldName="AplicavelPrazo" AdaptivePriority="9" AllowTextTruncationInAdaptiveMode="true">
                            <PropertiesComboBox Width="200px">
                                <Items>
                                    <dx:ListEditItem Text="Aplicavel" Value="1" />
                                    <dx:ListEditItem Text="Não Aplicavel" Value="0" />
                                </Items>
                            </PropertiesComboBox>
                        </dx:GridViewDataComboBoxColumn>--%>



<%--              <dx:GridViewDataTextColumn FieldName="Id" Caption="Cod." ReadOnly="True" VisibleIndex="0">
                                <EditFormSettings Visible="False" />
                            </dx:GridViewDataTextColumn>--%>
                            <dx:GridViewDataTextColumn FieldName="Sistema" VisibleIndex="1">
                                 <Settings AllowEllipsisInText="True" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Ambito" VisibleIndex="2">
                                 <Settings AllowEllipsisInText="True" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Estado" VisibleIndex="3">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Municipio" VisibleIndex="4">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Numero" VisibleIndex="5">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Ano" VisibleIndex="6">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Orgao" VisibleIndex="7">
                                 <Settings AllowEllipsisInText="True" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Tema" VisibleIndex="8">
                                 <Settings AllowEllipsisInText="True" />
                            </dx:GridViewDataTextColumn>
                            <%--<dx:GridViewDataTextColumn FieldName="Ementa" VisibleIndex="7">
                            </dx:GridViewDataTextColumn>--%>
                            <dx:GridViewDataTextColumn FieldName="Tipo" VisibleIndex="9">
                                 <Settings AllowEllipsisInText="True" />
                            </dx:GridViewDataTextColumn>

                        </Columns>
                        <SettingsPager PageSize="100" AlwaysShowPager="True" NumericButtonCount="100">
                            <PageSizeItemSettings Caption="100 Itens por Pagina:">
                            </PageSizeItemSettings>
                        </SettingsPager>
                    </dx:ASPxGridView>
                    <table style="border: none">
                        <tr>
                            <td>
                                <dx:ASPxButton ID="btnOK" runat="server" AutoPostBack="False" Text="Inserir" Width="80px" OnClick="btnOK_Click">
                                </dx:ASPxButton>
                            </td>
                            <td>
                                <dx:ASPxButton ID="btnCancel" runat="server" AutoPostBack="False" ClientInstanceName="btnCancel"
                                    Text="Cancel" Width="80px" Visible="False">
                                    <ClientSideEvents Click="function(s, e) {
	popupControl.Hide();
}" />
                                </dx:ASPxButton>
                            </td>
                        </tr>
                    </table>
                </dx:PopupControlContentControl>
            </ContentCollection>
        </dx:ASPxPopupControl>

    <dx:ASPxPopupControl ID="ASPxPopupControl2" runat="server" ClientInstanceName="popupControl" Height="580px" Modal="True" CloseAction="CloseButton" Width="1000px" AllowDragging="True" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" HeaderText="Excluir Leis de Clientes - 100 itens por Página">
            <ContentCollection>
                <dx:PopupControlContentControl runat="server">
                    <dx:ASPxGridView ID="ASPxGridView5" runat="server" DataSourceID="SqlLei2" ClientInstanceName="ASPxGridView5" Width="100%" AutoGenerateColumns="False" KeyFieldName="Id" Theme="Office2010Silver" OnCustomCallback="ASPxGridView5_CustomCallback">
                        <SettingsSearchPanel Visible="True"></SettingsSearchPanel>
                        <SettingsBehavior AllowFocusedRow="True" EnableRowHotTrack="True" />
                        <Settings ShowTitlePanel="false" ShowStatusBar="Visible" VerticalScrollableHeight="400" VerticalScrollBarMode="Auto" />
                        <SettingsText Title="REMOVER LEIS DE CLIENTES" />
                                  <Styles>
                <AlternatingRow Enabled="True">
                </AlternatingRow>
            </Styles>
                        <Columns>
                            <dx:GridViewDataTextColumn Caption="#" VisibleIndex="0">
                                <HeaderTemplate>
                                    <dx:ASPxCheckBox ID="cbCheckAll3" runat="server" OnInit="cbCheckAll3_Init">
                                    </dx:ASPxCheckBox>
                                </HeaderTemplate>
                                <DataItemTemplate>
                                    <dx:ASPxCheckBox ID="cbCheck3" runat="server" OnInit="cbCheck3_Init">
                                    </dx:ASPxCheckBox>
                                </DataItemTemplate>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Id" Caption="Cod." ReadOnly="True" VisibleIndex="0">
                                <EditFormSettings Visible="False" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Sistema" VisibleIndex="1">
                                  <Settings AllowEllipsisInText="True" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Ambito" VisibleIndex="2">
                                  <Settings AllowEllipsisInText="True" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Numero" VisibleIndex="3">
                                  <Settings AllowEllipsisInText="True" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Ano" VisibleIndex="4">
                                  <Settings AllowEllipsisInText="True" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Orgao" VisibleIndex="5">
                                  <Settings AllowEllipsisInText="True" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Tema" VisibleIndex="6">
                                  <Settings AllowEllipsisInText="True" />
                            </dx:GridViewDataTextColumn>
                               <dx:GridViewDataTextColumn FieldName="Tipo" VisibleIndex="8">
                                     <Settings AllowEllipsisInText="True" />
                            </dx:GridViewDataTextColumn>
                        </Columns>
                        <SettingsPager PageSize="100" AlwaysShowPager="True" NumericButtonCount="100">
                            <PageSizeItemSettings Caption="100 Itens por Pagina:">
                            </PageSizeItemSettings>
                        </SettingsPager>
                    </dx:ASPxGridView>
                    <table style="border: none">
                        <tr>
                            <td>
                                <dx:ASPxButton ID="btnExcluir" runat="server" AutoPostBack="False" Text="Excluir" Width="80px" OnClick="btnExcluir_Click">
                                </dx:ASPxButton>
                            </td>

                        </tr>
                    </table>
                </dx:PopupControlContentControl>
            </ContentCollection>
        </dx:ASPxPopupControl>

    <asp:Label ID="lblNomeUser" runat="server" Visible="false" Text=".."></asp:Label>
    <asp:Label ID="lblIdUsuario" runat="server" Visible="false" Text="0"></asp:Label>


    <dx:ASPxGridView ID="EspelhoLegisig" runat="server" Visible="false" DataSourceID="SqlExportacao" AutoGenerateColumns="False" Theme="Office2010Silver">
        <Columns>
             <dx:GridViewDataTextColumn FieldName="IDCliente" VisibleIndex="0"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="sistema" VisibleIndex="0"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Ambito" VisibleIndex="1"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Cidade" VisibleIndex="2"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Estado" VisibleIndex="3"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Pais" VisibleIndex="4"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Orgao" VisibleIndex="5"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Numero" VisibleIndex="6"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Ano" VisibleIndex="7"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Tipo" VisibleIndex="8"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Exigencia" VisibleIndex="9"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Assunto" VisibleIndex="10"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Valida&#231;&#227;o" VisibleIndex="11"></dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="DataAvaliacao" VisibleIndex="12"></dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="Classificacao" VisibleIndex="13"></dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="ProxAvaliacao" VisibleIndex="14"></dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="Resultado" VisibleIndex="15"></dx:GridViewDataTextColumn>          
        </Columns>
    </dx:ASPxGridView>
      <dx:ASPxGridViewExporter ID="gridExport" runat="server"  GridViewID="EspelhoLegisig"></dx:ASPxGridViewExporter>
      <asp:SqlDataSource runat="server" ID="SqlExportacao" ConnectionString='<%$ ConnectionStrings:PortalConnection %>'    
        
 SelectCommand=" SELECT  LC.IDCliente,PC.IDCliente,LG.sistema, LG.Ambito, LG.Municipio as Cidade, LG.Estado, LG.Pais,LG.Orgao,LG.Numero,LG.Ano,LG.Tipo,LG.Ementa as Exigencia, LG.Tema as Assunto, C.Evidencias as Validação, C.DataAvaliacao,
CASE  
  WHEN PC.Aplicavel IN (1) THEN 'Aplicavel' 
  ELSE 'Não Aplicavel' 
END as Classificacao,C.ProxAvaliacao,C.Resultado
FROM LegisGeral as LG,Legis_Cliente as LC, ParametrosCliente as PC, Conformidade as C
where LG.Id = LC.IDLegisGeral and
LC.IDLegisGeral = PC.IDLegisGeral and
PC.Id = C.IDParametros and 
LC.IDCliente = PC.IDCliente and
LC.IDCliente = @IDCliente 

 union 
 
 
 SELECT  LC.IDCliente,PC.IDCliente,LG.sistema, LG.Ambito, LG.Municipio as Cidade, LG.Estado, LG.Pais,LG.Orgao,LG.Numero,LG.Ano,LG.Tipo,LG.Ementa as Exigencia, LG.Tema as Assunto, ' ' as Validação, '' as DataAvaliacao,'' as Classificacao, '' as ProxAvaliacao, ''as Resultado
FROM LegisGeral as LG,Legis_Cliente as LC, ParametrosCliente as PC
where LG.Id = LC.IDLegisGeral and
LC.IDLegisGeral = PC.IDLegisGeral and
LC.IDCliente = PC.IDCliente and
LC.IDCliente = @IDCliente">               
              <SelectParameters>
            <asp:SessionParameter SessionField="IDCliente" Name="IDCliente" Type="Int32"></asp:SessionParameter>
        </SelectParameters>
    </asp:SqlDataSource>
      <dx:ASPxGridView ID="EspelhoLeisParametros" runat="server" Visible="False" DataSourceID="SqlExportacao2" AutoGenerateColumns="False" Theme="Office2010Silver">
        <Columns>
             <dx:GridViewDataTextColumn FieldName="IDCliente" VisibleIndex="0"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="sistema" VisibleIndex="1"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Ambito" VisibleIndex="2"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Cidade" VisibleIndex="3"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Estado" VisibleIndex="4"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Pais" VisibleIndex="5"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Orgao" VisibleIndex="6"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Numero" VisibleIndex="7"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Ano" VisibleIndex="8"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Tipo" VisibleIndex="9"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Exigencia" VisibleIndex="10"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Assunto" VisibleIndex="11"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Capitulo" VisibleIndex="12"></dx:GridViewDataTextColumn>
             <dx:GridViewDataTextColumn FieldName="Parametro" VisibleIndex="13">
             </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Obrigacao" VisibleIndex="14" ReadOnly="True"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Numero" VisibleIndex="15"></dx:GridViewDataTextColumn>          
             <dx:GridViewDataTextColumn FieldName="Aplicavel" ReadOnly="True" VisibleIndex="16">
             </dx:GridViewDataTextColumn>
             <dx:GridViewDataTextColumn FieldName="Conhecimento" ReadOnly="True" VisibleIndex="17">
             </dx:GridViewDataTextColumn>
        </Columns>
    </dx:ASPxGridView>
      <dx:ASPxGridViewExporter ID="gridExport2" runat="server"  GridViewID="EspelhoLeisParametros"></dx:ASPxGridViewExporter>
      <asp:SqlDataSource runat="server" ID="SqlExportacao2" ConnectionString='<%$ ConnectionStrings:PortalConnection %>'    
        
 SelectCommand="SELECT  LC.IDCliente,LG.sistema, LG.Ambito, LG.Municipio as Cidade, LG.Estado, LG.Pais,LG.Orgao,LG.Numero as Numero,LG.Ano,LG.Tipo,LG.Ementa as Exigencia, LG.Tema as Assunto, PC.Capitulo, PC.Parametro, 
CASE  
  WHEN PC.Obrigacao IN (1) THEN 'Sim' 
  ELSE 'Não' 
END as Obrigacao, 
PC.Numero, 
CASE  
  WHEN PC.Aplicavel IN (1) THEN 'Sim' 
  ELSE 'Não' 
END as Aplicavel, 
CASE  
  WHEN PC.Conhecimento IN (1) THEN 'Sim' 
  ELSE 'Não' 
END as Conhecimento
FROM LegisGeral as LG,Legis_Cliente as LC, ParametrosCliente as PC
where LG.Id = LC.IDLegisGeral and
LC.IDLegisGeral = PC.IDLegisGeral and
LC.IDCliente = PC.IDCliente and
LC.IDCliente =  @IDCliente order by pc.id">               
              <SelectParameters>
            <asp:SessionParameter SessionField="IDCliente" Name="IDCliente" Type="Int32"></asp:SessionParameter>
        </SelectParameters>
    </asp:SqlDataSource>



      <dx:ASPxGridView ID="EspelhoPlanoAcao" runat="server" Visible="False" DataSourceID="SqlExportacao3" AutoGenerateColumns="False" Theme="Office2010Silver">
        <Columns>
             <dx:GridViewDataTextColumn FieldName="IDCliente" VisibleIndex="0" ReadOnly="True"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="IDCliente1" VisibleIndex="1" ReadOnly="True"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="sistema" VisibleIndex="2" ReadOnly="True"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Ambito" VisibleIndex="3" ReadOnly="True"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Cidade" VisibleIndex="4" ReadOnly="True"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Estado" VisibleIndex="5" ReadOnly="True"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Pais" VisibleIndex="6" ReadOnly="True"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Orgao" VisibleIndex="7" ReadOnly="True"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Numero" VisibleIndex="8" ReadOnly="True"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Ano" VisibleIndex="9" ReadOnly="True"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Tipo" VisibleIndex="10" ReadOnly="True"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Exigencia" VisibleIndex="11" ReadOnly="True"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Assunto" VisibleIndex="12" ReadOnly="True"></dx:GridViewDataTextColumn>
             <dx:GridViewDataTextColumn FieldName="Classificacao" ReadOnly="True" VisibleIndex="13">
             </dx:GridViewDataTextColumn>
             <dx:GridViewDataTextColumn FieldName="Causa" ReadOnly="True" VisibleIndex="14">
             </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="DataCausa" VisibleIndex="15" ReadOnly="True"></dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="Correcao_Corretivas" VisibleIndex="16" ReadOnly="True"></dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="Prazo" VisibleIndex="17" ReadOnly="True"></dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="Eficacia" VisibleIndex="18" ReadOnly="True"></dx:GridViewDataTextColumn>          
             <dx:GridViewDataDateColumn FieldName="DataEficacia" ReadOnly="True" VisibleIndex="19">
             </dx:GridViewDataDateColumn>
             <dx:GridViewDataTextColumn FieldName="Evidencias" ReadOnly="True" VisibleIndex="20">
             </dx:GridViewDataTextColumn>
             <dx:GridViewDataTextColumn FieldName="ResultFinal" ReadOnly="True" VisibleIndex="21">
             </dx:GridViewDataTextColumn>
        </Columns>
    </dx:ASPxGridView>
      <dx:ASPxGridViewExporter ID="gridExport3" runat="server"  GridViewID="EspelhoPlanoAcao"></dx:ASPxGridViewExporter>
      <asp:SqlDataSource runat="server" ID="SqlExportacao3" ConnectionString='<%$ ConnectionStrings:PortalConnection %>'    
        
 SelectCommand=" SELECT distinct LC.IDCliente,PC.IDCliente,LG.sistema, LG.Ambito, LG.Municipio as Cidade, LG.Estado, LG.Pais,LG.Orgao,LG.Numero,LG.Ano,LG.Tipo,LG.Ementa as Exigencia, LG.Tema as Assunto, 
CASE  
  WHEN PC.Aplicavel IN (1) THEN 'Aplicavel' 
  ELSE 'Não Aplicavel' 
END as Classificacao,PA.Causa,PA.DataCausa, PA.Correcao_Corretivas, PA.Prazo, PA.Eficacia, PA.DataEficacia,PA.Evidencias,PA.ResultFinal
FROM LegisGeral as LG,Legis_Cliente as LC, ParametrosCliente as PC, PlanoAcao as PA
where LG.Id = LC.IDLegisGeral and
LC.IDLegisGeral = PC.IDLegisGeral and
PC.Id = PA.IDParametros and 
LC.IDCliente = PC.IDCliente and
PC.IDCliente = PA.IDCliente and 
LC.IDCliente = @IDCliente 

union

SELECT distinct LC.IDCliente,PC.IDCliente,LG.sistema, LG.Ambito, LG.Municipio as Cidade, LG.Estado, LG.Pais,LG.Orgao,LG.Numero,LG.Ano,LG.Tipo,LG.Ementa as Exigencia, LG.Tema as Assunto, 
CASE  
  WHEN PC.Aplicavel IN (1) THEN 'Aplicavel' 
  ELSE 'Não Aplicavel' 
END as Classificacao, '' as A,'' as B, '' as B,'' as V, '' as X, '' as ZZ,'' as QQ,'' as HH
FROM LegisGeral as LG,Legis_Cliente as LC, ParametrosCliente as PC
where LG.Id = LC.IDLegisGeral and
LC.IDLegisGeral = PC.IDLegisGeral and
LC.IDCliente = PC.IDCliente and
LC.IDCliente = @IDCliente ">               
              <SelectParameters>
            <asp:SessionParameter SessionField="IDCliente" Name="IDCliente" Type="Int32"></asp:SessionParameter>
        </SelectParameters>
    </asp:SqlDataSource>

        </div>
    </form>
</body>
</html>
