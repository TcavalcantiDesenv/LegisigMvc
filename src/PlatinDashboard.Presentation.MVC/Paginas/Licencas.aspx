<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Licencas.aspx.cs" Inherits="PlatinDashboard.Presentation.MVC.Licencas" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">

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
</head>
<body>
    <form id="form1" runat="server">
        <dx:ASPxLabel runat="server" Text="xxx" ForeColor="Yellow" Width="500px" Font-Bold="False" Font-Size="15pt" Visible="false" ID="lblEmpresa"></dx:ASPxLabel>

        <dx:ASPxLabel runat="server" Text="xxx" ForeColor="Yellow" Width="500px" Font-Bold="False" Font-Size="15pt" Visible="false" ID="ASPxLabel1"></dx:ASPxLabel>



        <dx:ASPxGridView ID="GridLicenca" runat="server" AutoGenerateColumns="False" DataSourceID="SqlLicenca" KeyFieldName="Id" OnRowInserted="GridLicenca_RowInserted" OnRowUpdated="GridLicenca_RowUpdated" KeyboardSupport="True" Theme="Office2010Silver" Width="100%">

            <%--        <SettingsCommandButton>
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
        </SettingsCommandButton>--%>

            <SettingsEditing EditFormColumnCount="2" Mode="EditForm"></SettingsEditing>

<%--            <Columns>
                <dx:GridViewCommandColumn ShowEditButton="True" ShowDeleteButton="True" ShowNewButtonInHeader="True" ShowInCustomizationForm="True" VisibleIndex="19" Visible="False"></dx:GridViewCommandColumn>
                <dx:GridViewDataTextColumn FieldName="Id" ReadOnly="True" ShowInCustomizationForm="True" AdaptivePriority="1" Visible="False" VisibleIndex="10">
                    <EditFormSettings Visible="False"></EditFormSettings>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="Licenca" ShowInCustomizationForm="True" AdaptivePriority="3" Caption="Licen&#231;a/Documento Legal" VisibleIndex="10">
                    <EditFormSettings VisibleIndex="3"></EditFormSettings>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="Orgao" ShowInCustomizationForm="True" AdaptivePriority="4" VisibleIndex="11">
                    <EditFormSettings VisibleIndex="4"></EditFormSettings>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="Numero" ShowInCustomizationForm="True" AdaptivePriority="5" VisibleIndex="12">
                    <EditFormSettings VisibleIndex="5"></EditFormSettings>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn FieldName="Emissao" ShowInCustomizationForm="True" AdaptivePriority="6" VisibleIndex="13">
                    <PropertiesDateEdit DisplayFormatString="yyyy-MM-dd" EditFormatString="yyyy-MM-dd" EditFormat="Custom" DisplayFormatInEditMode="True"></PropertiesDateEdit>

                    <EditFormSettings VisibleIndex="6"></EditFormSettings>
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataDateColumn FieldName="Validade" ShowInCustomizationForm="True" AdaptivePriority="7" AllowTextTruncationInAdaptiveMode="True" VisibleIndex="14">
                    <PropertiesDateEdit DisplayFormatString="yyyy-MM-dd" EditFormatString="yyyy-MM-dd"></PropertiesDateEdit>
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataComboBoxColumn FieldName="Prazo" ShowInCustomizationForm="True" AdaptivePriority="8" Caption="Prazo de Alerta" VisibleIndex="15">
                    <PropertiesComboBox Width="200px">
                        <Items>
                            <dx:ListEditItem Text="15 dias" Value="15"></dx:ListEditItem>
                            <dx:ListEditItem Text="30 dias" Value="30"></dx:ListEditItem>
                            <dx:ListEditItem Text="60 dias" Value="60"></dx:ListEditItem>
                            <dx:ListEditItem Text="90 dias" Value="90"></dx:ListEditItem>
                            <dx:ListEditItem Text="120 dias" Value="120"></dx:ListEditItem>
                            <dx:ListEditItem Text="180 dias" Value="180"></dx:ListEditItem>
                        </Items>
                    </PropertiesComboBox>

                    <EditFormSettings VisibleIndex="8"></EditFormSettings>
                </dx:GridViewDataComboBoxColumn>
                <dx:GridViewDataMemoColumn FieldName="Obs" ShowInCustomizationForm="True" AdaptivePriority="10" Caption="Observa&#231;&#227;o" VisibleIndex="16">
                    <EditFormSettings VisibleIndex="10"></EditFormSettings>
                </dx:GridViewDataMemoColumn>
                <dx:GridViewDataComboBoxColumn FieldName="IdCliente" ShowInCustomizationForm="True" AdaptivePriority="2" Caption="Cliente" VisibleIndex="17">
                    <PropertiesComboBox DataSourceID="SqlCliente" TextField="RazaoSocial" ValueField="Id"></PropertiesComboBox>

                    <EditFormSettings VisibleIndex="11"></EditFormSettings>
                </dx:GridViewDataComboBoxColumn>
                <dx:GridViewDataComboBoxColumn FieldName="Condicionante" ShowInCustomizationForm="True" AdaptivePriority="9" Caption="Com Condicionantes ?" VisibleIndex="18">
                    <PropertiesComboBox Width="200px">
                        <Items>
                            <dx:ListEditItem Text="Sim" Value="1"></dx:ListEditItem>
                            <dx:ListEditItem Text="N&#227;o" Value="0"></dx:ListEditItem>
                        </Items>
                    </PropertiesComboBox>

                    <EditFormSettings VisibleIndex="9"></EditFormSettings>
                </dx:GridViewDataComboBoxColumn>
                <dx:GridViewCommandColumn ShowEditButton="True" ShowDeleteButton="True" ShowNewButtonInHeader="True" ShowInCustomizationForm="True" Visible="False" VisibleIndex="20"></dx:GridViewCommandColumn>
                <dx:GridViewDataTextColumn FieldName="Id" ReadOnly="True" ShowInCustomizationForm="True" AdaptivePriority="1" Visible="False" VisibleIndex="9">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="Licenca" ShowInCustomizationForm="True" AdaptivePriority="3" Caption="Licen&#231;a/Documento Legal" VisibleIndex="0">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="Orgao" ShowInCustomizationForm="True" AdaptivePriority="4" VisibleIndex="1">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="Numero" ShowInCustomizationForm="True" AdaptivePriority="5" VisibleIndex="2">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn FieldName="Emissao" ShowInCustomizationForm="True" AdaptivePriority="6" VisibleIndex="3">
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataDateColumn FieldName="Validade" ShowInCustomizationForm="True" AdaptivePriority="7" AllowTextTruncationInAdaptiveMode="True" VisibleIndex="4">
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataComboBoxColumn FieldName="Prazo" ShowInCustomizationForm="True" AdaptivePriority="8" Caption="Prazo de Alerta" VisibleIndex="5">
                </dx:GridViewDataComboBoxColumn>
                <dx:GridViewDataMemoColumn FieldName="Obs" ShowInCustomizationForm="True" AdaptivePriority="10" Caption="Observa&#231;&#227;o" VisibleIndex="6">
                </dx:GridViewDataMemoColumn>
                <dx:GridViewDataComboBoxColumn FieldName="IdCliente" ShowInCustomizationForm="True" AdaptivePriority="2" Caption="Cliente" VisibleIndex="7">
                </dx:GridViewDataComboBoxColumn>
                <dx:GridViewDataComboBoxColumn FieldName="Condicionante" ShowInCustomizationForm="True" AdaptivePriority="9" Caption="Com Condicionantes ?" VisibleIndex="8">
                </dx:GridViewDataComboBoxColumn>
            </Columns>--%>

            <ClientSideEvents EndCallback="function (s, e) {
                if (s.cpShowPopup)
                {
                    delete s.cpShowPopup;
                    lbl.SetText(s.cpText);
                    popup.Show();
                }
            }" />
            <SettingsDetail ShowDetailRow="True" />
            <Templates>
                <DetailRow>
                    <dx:ASPxGridView ID="CridCondicionantes" runat="server" Width="100%" AutoGenerateColumns="False" DataSourceID="SqlCondicionantes" KeyFieldName="Id" OnBeforePerformDataSelect="CridCondicionantes_BeforePerformDataSelect" Theme="Office2010Silver">
                        <SettingsLoadingPanel Mode="Default" />
                        <SettingsEditing EditFormColumnCount="2" Mode="EditForm">
                        </SettingsEditing>
                        <SettingsDetail ShowDetailRow="True" />
                        <SettingsPager AlwaysShowPager="True" />
                        <SettingsEditing EditFormColumnCount="2" Mode="EditForm" />
                        <Settings ShowTitlePanel="true" />
                        <SettingsBehavior AllowFocusedRow="True" AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" ConfirmDelete="True" EnableRowHotTrack="True" ProcessSelectionChangedOnServer="True" />
                        <%--                    <SettingsCommandButton>
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
                    </SettingsCommandButton>--%>
                        <SettingsPopup>
                            <EditForm HorizontalAlign="Center" Modal="True" VerticalAlign="WindowCenter" Width="600" />
                            <CustomizationWindow HorizontalAlign="WindowCenter" VerticalAlign="WindowCenter" />
                        </SettingsPopup>
                        <SettingsText Title="Gestão de Condicionantes" />

                        <%--               <Columns>
                            <dx:GridViewCommandColumn ShowEditButton="True" ShowDeleteButton="True" ShowNewButtonInHeader="True" ShowInCustomizationForm="True" AllowTextTruncationInAdaptiveMode="True" Visible="False" VisibleIndex="12"></dx:GridViewCommandColumn>
                            <dx:GridViewDataTextColumn FieldName="IdLicenca" ShowInCustomizationForm="True" AdaptivePriority="12" AllowTextTruncationInAdaptiveMode="True" Visible="False" VisibleIndex="0"></dx:GridViewDataTextColumn>
                        </Columns>--%>
           <%--             <Columns>
                            <dx:GridViewCommandColumn ShowEditButton="True" ShowDeleteButton="True" ShowNewButtonInHeader="True" ShowInCustomizationForm="True" AllowTextTruncationInAdaptiveMode="True" Visible="False" VisibleIndex="1"></dx:GridViewCommandColumn>
                            <dx:GridViewDataTextColumn FieldName="Numero" ShowInCustomizationForm="True" AdaptivePriority="2" AllowTextTruncationInAdaptiveMode="True" Width="100px" Caption="N&#186;" VisibleIndex="2"></dx:GridViewDataTextColumn>
                            <dx:GridViewDataMemoColumn FieldName="Descricao" ShowInCustomizationForm="True" AdaptivePriority="3" AllowTextTruncationInAdaptiveMode="True" Width="300px" Caption="Descri&#231;&#227;o da Exigencia" VisibleIndex="3">
                            </dx:GridViewDataMemoColumn>
                            <dx:GridViewDataTextColumn FieldName="Avaliacao" ShowInCustomizationForm="True" AdaptivePriority="4" AllowTextTruncationInAdaptiveMode="True" Width="100px" Caption="Avalia&#231;&#227;o e Analise" VisibleIndex="4">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Controles" ShowInCustomizationForm="True" AdaptivePriority="5" AllowTextTruncationInAdaptiveMode="True" Caption="Controles Existentes" VisibleIndex="5">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Responsavel" ShowInCustomizationForm="True" AdaptivePriority="6" AllowTextTruncationInAdaptiveMode="True" VisibleIndex="6">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="MeiosAnalise" ShowInCustomizationForm="True" AdaptivePriority="7" AllowTextTruncationInAdaptiveMode="True" Caption="Meios de Analise" VisibleIndex="7">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="FrequenciaMonotora" ShowInCustomizationForm="True" AdaptivePriority="8" AllowTextTruncationInAdaptiveMode="True" Caption="Frequencia de Monitoramento" VisibleIndex="8"></dx:GridViewDataTextColumn>
                            <dx:GridViewDataComboBoxColumn FieldName="Situacao" ShowInCustomizationForm="True" AdaptivePriority="9" AllowTextTruncationInAdaptiveMode="True" Caption="Situa&#231;&#227;o" VisibleIndex="9">
                            </dx:GridViewDataComboBoxColumn>
                            <dx:GridViewDataComboBoxColumn FieldName="AplicavelPrazo" ShowInCustomizationForm="True" AdaptivePriority="9" AllowTextTruncationInAdaptiveMode="True" Caption="Possue Prazo de Validade?" VisibleIndex="10">
                            </dx:GridViewDataComboBoxColumn>
                            <dx:GridViewDataDateColumn FieldName="Data" ShowInCustomizationForm="True" AdaptivePriority="10" AllowTextTruncationInAdaptiveMode="True" Caption="Data de Validade:" VisibleIndex="11"></dx:GridViewDataDateColumn>
                            <dx:GridViewDataComboBoxColumn FieldName="Alerta" ShowInCustomizationForm="True" AdaptivePriority="11" AllowTextTruncationInAdaptiveMode="True" Caption="Prazo de Alerta" VisibleIndex="12">
                            </dx:GridViewDataComboBoxColumn>
                            <dx:GridViewDataTextColumn FieldName="IdLicenca" ShowInCustomizationForm="True" AdaptivePriority="12" AllowTextTruncationInAdaptiveMode="True" Visible="False" VisibleIndex="0"></dx:GridViewDataTextColumn>
                        </Columns>--%>
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
                            <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0" Visible="false"  AllowTextTruncationInAdaptiveMode="true">
                            </dx:GridViewCommandColumn>
                            <dx:GridViewDataTextColumn FieldName="Id" ReadOnly="True" Visible="false" AdaptivePriority="1" AllowTextTruncationInAdaptiveMode="true">
                                <EditFormSettings Visible="False" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Nº" FieldName="Numero" Width="100" AdaptivePriority="2" AllowTextTruncationInAdaptiveMode="true">
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
                            <dx:GridViewDataDateColumn Caption="Data de Validade:" FieldName="Data" AdaptivePriority="10" AllowTextTruncationInAdaptiveMode="true">
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

            <SettingsEditing EditFormColumnCount="2" Mode="PopupEditForm" />

            <Settings ShowTitlePanel="true" />
            <SettingsBehavior ConfirmDelete="True" EnableRowHotTrack="True"
                AllowSelectByRowClick="True"
                ProcessSelectionChangedOnServer="True"
                AllowFocusedRow="True"
                AllowSelectSingleRowOnly="True" />
            <SettingsPopup>
                <EditForm HorizontalAlign="Center" Modal="True" VerticalAlign="WindowCenter" Width="600" />
                <CustomizationWindow HorizontalAlign="WindowCenter" VerticalAlign="WindowCenter" />
            </SettingsPopup>
            <SettingsLoadingPanel Mode="ShowAsPopup" />
            <SettingsText Title="Gestão de Licenças e outros Documentos Legais" />

            <Columns>
                <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="9" Visible="False">
                </dx:GridViewCommandColumn>
                <dx:GridViewDataTextColumn FieldName="Id" AdaptivePriority="1" ReadOnly="True" Visible="False">
                    <EditFormSettings Visible="False" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="Licenca" Caption="Licença/Documento Legal" AdaptivePriority="3" EditFormSettings-VisibleIndex="3" VisibleIndex="0">
                          <Settings AllowEllipsisInText="True" />
                    <EditFormSettings VisibleIndex="3"></EditFormSettings>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="Orgao" AdaptivePriority="4" EditFormSettings-VisibleIndex="4" VisibleIndex="1">
                          <Settings AllowEllipsisInText="True" />
                    <EditFormSettings VisibleIndex="4"></EditFormSettings>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="Numero" AdaptivePriority="5" EditFormSettings-VisibleIndex="5" VisibleIndex="2">
                    <EditFormSettings VisibleIndex="5"></EditFormSettings>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn FieldName="Emissao" AdaptivePriority="6" EditFormSettings-VisibleIndex="6" VisibleIndex="3">
                    <PropertiesDateEdit DisplayFormatString="yyyy-MM-dd" DisplayFormatInEditMode="True" EditFormat="Custom" EditFormatString="yyyy-MM-dd">
                    </PropertiesDateEdit>

                    <EditFormSettings VisibleIndex="6"></EditFormSettings>
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataDateColumn FieldName="Validade" AdaptivePriority="7" AllowTextTruncationInAdaptiveMode="true" VisibleIndex="4">
                    <PropertiesDateEdit DisplayFormatString="yyyy-MM-dd" EditFormatString="yyyy-MM-dd">
                    </PropertiesDateEdit>
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataComboBoxColumn FieldName="Prazo" Caption="Prazo de Alerta" AdaptivePriority="8" EditFormSettings-VisibleIndex="8" VisibleIndex="5">
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
                <dx:GridViewDataMemoColumn FieldName="Obs" Caption="Observação" AdaptivePriority="10" EditFormSettings-VisibleIndex="10" VisibleIndex="6">
                          <Settings AllowEllipsisInText="True" />
                    <EditFormSettings VisibleIndex="10"></EditFormSettings>
                </dx:GridViewDataMemoColumn>
                <dx:GridViewDataComboBoxColumn Caption="Cliente" FieldName="IdCliente" ShowInCustomizationForm="True" AdaptivePriority="2" EditFormSettings-VisibleIndex="11" VisibleIndex="7">
                          <Settings AllowEllipsisInText="True" />
                    <PropertiesComboBox DataSourceID="SqlCliente" TextField="RazaoSocial" ValueField="Id">
                    </PropertiesComboBox>

                    <EditFormSettings VisibleIndex="11"></EditFormSettings>
                </dx:GridViewDataComboBoxColumn>
                <dx:GridViewDataComboBoxColumn Caption="Com Condicionantes ?" FieldName="Condicionante" ShowInCustomizationForm="True" AdaptivePriority="9" EditFormSettings-VisibleIndex="9" VisibleIndex="8">
                    <PropertiesComboBox Width="200px">
                        <Items>
                            <dx:ListEditItem Text="Sim" Value="1" />
                            <dx:ListEditItem Text="Não" Value="0" />
                        </Items>
                    </PropertiesComboBox>

                    <EditFormSettings VisibleIndex="9"></EditFormSettings>
                </dx:GridViewDataComboBoxColumn>
            </Columns>

            <Toolbars>
                <dx:GridViewToolbar ItemAlign="Left" EnableAdaptivity="true">
                    <Items>
                        <dx:GridViewToolbarItem Command="New" Text="Cadastrar" />
                        <dx:GridViewToolbarItem Command="Edit" Text="Editar" />
                        <dx:GridViewToolbarItem Command="Delete" Text="Excluir" />
                        <dx:GridViewToolbarItem Command="Refresh" Text="Atualizar" BeginGroup="true" />
                        <dx:GridViewToolbarItem Text="Exportar" Image-IconID="actions_download_16x16office2013" BeginGroup="true">
                            <Items>
                                <dx:GridViewToolbarItem Name="CustomExportToXLS" Text="Export to XLS(WYSIWYG)" Image-IconID="export_exporttoxls_16x16office2013">
                                    <Image IconID="export_exporttoxls_16x16office2013"></Image>
                                </dx:GridViewToolbarItem>
                                <dx:GridViewToolbarItem Name="CustomExportToXLSX" Text="Export to XLSX(WYSIWYG)" Image-IconID="export_exporttoxlsx_16x16office2013">
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

        <asp:SqlDataSource ID="SqlLicenca" runat="server" ConnectionString="<%$ ConnectionStrings:PortalConnection %>"
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
                <asp:Parameter Name="Emissao" Type="DateTime" />
                <asp:Parameter Name="Validade" Type="DateTime" />
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
                <asp:Parameter Name="Emissao" Type="DateTime" />
                <asp:Parameter Name="Validade" Type="DateTime" />
                <asp:Parameter Name="Finalidade" Type="String" />
                <asp:Parameter Name="Requisito" Type="String" />
                <asp:Parameter Name="Obs" Type="String" />
                <asp:Parameter Name="Prazo" Type="Int32" />
                <asp:Parameter Name="Condicionante" Type="Int32"></asp:Parameter>
                <asp:Parameter Name="Id" Type="Int32"></asp:Parameter>
            </UpdateParameters>
        </asp:SqlDataSource>

        <asp:SqlDataSource ID="SqlCliente" runat="server" ConnectionString='<%$ ConnectionStrings:PortalConnection %>'
            SelectCommand="SELECT * FROM [Clientes] ORDER BY [RazaoSocial]">

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
                                <asp:Button ID="btnUpload" runat="server" Text="Enviar Arquivo" /></td>
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



                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: center" colspan="2" class="dxflEmptyItem_Office2003Olive">
                                <dx:ASPxButton ID="ASPxButton1" runat="server" AutoPostBack="False" Text="FECHAR" Width="100px">
                                </dx:ASPxButton>
                            </td>
                        </tr>

                    </table>
                </dx:PopupControlContentControl>
            </ContentCollection>
        </dx:ASPxPopupControl>

        <dx:ASPxPopupControl ID="popup" runat="server" ClientInstanceName="popup" CloseOnEscape="true" Modal="True"
            PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter"
            HeaderText="Cadastro de Condicionantes" AllowDragging="True" PopupAnimationType="None" EnableViewState="False">
            <HeaderStyle HorizontalAlign="Center" />

            <ContentCollection>
                <dx:PopupControlContentControl runat="server">
                    <dx:ASPxLabel ID="lbl" runat="server" ClientInstanceName="lbl" Text="ASPxLabel">
                    </dx:ASPxLabel>
                    <dx:ASPxGridView ID="ASPxGridView1" runat="server" Width="100%" Theme="Youthful" DataSourceID="SqlCond2" AutoGenerateColumns="False" KeyFieldName="Id">
                        <SettingsBehavior ConfirmDelete="True" EnableRowHotTrack="True"
                            AllowSelectByRowClick="True"
                            ProcessSelectionChangedOnServer="True"
                            AllowFocusedRow="True"
                            AllowSelectSingleRowOnly="True" />
                        <Columns>
                            <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0" AllowTextTruncationInAdaptiveMode="true">
                            </dx:GridViewCommandColumn>
                            <dx:GridViewDataTextColumn FieldName="Id" ReadOnly="True" Visible="false" AdaptivePriority="1" AllowTextTruncationInAdaptiveMode="true">
                                <EditFormSettings Visible="False" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Nº" FieldName="Numero" Width="100" AdaptivePriority="2" AllowTextTruncationInAdaptiveMode="true">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataMemoColumn Caption="Descrição da Exigencia" Width="300" FieldName="Descricao" AdaptivePriority="3" AllowTextTruncationInAdaptiveMode="true">
                            </dx:GridViewDataMemoColumn>
                            <dx:GridViewDataTextColumn Caption="Avaliação e Analise" Width="100" FieldName="Avaliacao" AdaptivePriority="4" AllowTextTruncationInAdaptiveMode="true">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Controles Existentes" FieldName="Controles" AdaptivePriority="5" AllowTextTruncationInAdaptiveMode="true">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Responsavel" AdaptivePriority="6" AllowTextTruncationInAdaptiveMode="true">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Meios de Analise" FieldName="MeiosAnalise" AdaptivePriority="7" AllowTextTruncationInAdaptiveMode="true">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Frequencia de Monitoramento" FieldName="FrequenciaMonotora" AdaptivePriority="8" AllowTextTruncationInAdaptiveMode="true">
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
                            <%--                    <dx:GridViewDataTextColumn FieldName="IdLicenca" Visible="false" AdaptivePriority="12" AllowTextTruncationInAdaptiveMode="true">
                        </dx:GridViewDataTextColumn>--%>
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

                    <%--     <dx:ASPxGridView ID="GridCondicionantes" runat="server" Width="100%" AutoGenerateColumns="False" DataSourceID="SqlCond2" KeyFieldName="Id" Theme="Youthful">
                            <SettingsLoadingPanel Mode="Default" />
                            <SettingsEditing EditFormColumnCount="2" Mode="EditForm">
                            </SettingsEditing>
                            <SettingsDetail ShowDetailRow="false" />
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
                                <EditForm HorizontalAlign="Center" Modal="True" VerticalAlign="WindowCenter" Width="600" />
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
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataMemoColumn Caption="Descrição da Exigencia" Width="300" FieldName="Descricao" AdaptivePriority="3" AllowTextTruncationInAdaptiveMode="true">
                        </dx:GridViewDataMemoColumn>
                        <dx:GridViewDataTextColumn Caption="Avaliação e Analise" Width="100" FieldName="Avaliacao" AdaptivePriority="4" AllowTextTruncationInAdaptiveMode="true">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Controles Existentes" FieldName="Controles" AdaptivePriority="5" AllowTextTruncationInAdaptiveMode="true">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Responsavel" AdaptivePriority="6" AllowTextTruncationInAdaptiveMode="true">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Meios de Analise" FieldName="MeiosAnalise" AdaptivePriority="7" AllowTextTruncationInAdaptiveMode="true">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Frequencia de Monitoramento" FieldName="FrequenciaMonotora" AdaptivePriority="8" AllowTextTruncationInAdaptiveMode="true">
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
                        </dx:GridViewDataTextColumn>
                    </Columns>
                        </dx:ASPxGridView>--%>
                    <asp:SqlDataSource runat="server" ID="SqlCond2" ConnectionString='<%$ ConnectionStrings:PortalConnection %>'
                        DeleteCommand="DELETE FROM [Condicionantes] WHERE [Id] = @Id"
                        InsertCommand="INSERT INTO [Condicionantes] ([Numero], [Descricao], [Avaliacao], [Controles], [Responsavel], [MeiosAnalise], [FrequenciaMonotora], [Situacao], [AplicavelPrazo], [Data], [Alerta], [IdLicenca]) VALUES (@Numero, @Descricao, @Avaliacao, @Controles, @Responsavel, @MeiosAnalise, @FrequenciaMonotora, @Situacao, @AplicavelPrazo, @Data, @Alerta, @IdLicenca)"
                        SelectCommand="SELECT * FROM [Condicionantes] "
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
                </dx:PopupControlContentControl>
            </ContentCollection>
        </dx:ASPxPopupControl>
    </form>
</body>
</html>
