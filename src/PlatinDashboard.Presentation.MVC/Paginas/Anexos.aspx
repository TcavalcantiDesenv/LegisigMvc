<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Anexos.aspx.cs" Inherits="PlatinDashboard.Presentation.MVC.Paginas.Anexos" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <dx:ASPxFileManager ID="fileManager" runat="server" OnFolderCreating="fileManager_FolderCreating"
                OnItemDeleting="fileManager_ItemDeleting" OnItemMoving="fileManager_ItemMoving"
                OnItemRenaming="fileManager_ItemRenaming" OnFileUploading="fileManager_FileUploading" OnItemCopying="fileManager_ItemCopying" Height="600px" Theme="Office2010Silver">
                <Settings RootFolder="~/Content/Arquivos" ThumbnailFolder="~/Content"
                    AllowedFileExtensions=".jpg,.jpeg,.gif,.rtf,.txt,.avi,.png,.mp3,.xml,.doc,.pdf"
                    InitialFolder="Imagens" />
                <SettingsEditing AllowCreate="true" AllowDelete="true" AllowMove="true" AllowRename="true" AllowCopy="true" AllowDownload="true" />
                <SettingsPermissions>
                    <AccessRules>
                        <dx:FileManagerFolderAccessRule Path="System" Edit="Deny" />
                        <dx:FileManagerFileAccessRule Path="System\*" Download="Deny" />
                    </AccessRules>
                </SettingsPermissions>
                <SettingsFileList ShowFolders="true" ShowParentFolder="true" />
                <SettingsBreadcrumbs Visible="true" ShowParentFolderButton="true" Position="Top" />
                <SettingsUpload UseAdvancedUploadMode="true">
                    <AdvancedModeSettings EnableMultiSelect="true" />
                </SettingsUpload>
            </dx:ASPxFileManager>
        </div>
    </form>
</body>
</html>
