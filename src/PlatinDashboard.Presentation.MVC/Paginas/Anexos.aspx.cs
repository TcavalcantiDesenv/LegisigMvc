using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PlatinDashboard.Presentation.MVC.Paginas
{
    public partial class Anexos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ApplyFileManagerSettings();
            }

            //DemoHelper.Instance.PrepareControlOptions(OptionsFormLayout, new ControlOptionsSettings
            //{
            //    ColumnMinWidth = 300,
            //    RightBlockWidth = 320,
            //    ColumnCountMode = RecalculateColumnCountMode.RootGroup
            //});
        }

        protected void fileManager_FileUploading(object sender, FileManagerFileUploadEventArgs e)
        {
            ValidateSiteEdit(e);
        }

        protected void fileManager_ItemRenaming(object sender, FileManagerItemRenameEventArgs e)
        {
            ValidateSiteEdit(e);
        }

        protected void fileManager_ItemMoving(object sender, FileManagerItemMoveEventArgs e)
        {
            ValidateSiteEdit(e);
        }

        protected void fileManager_ItemDeleting(object sender, FileManagerItemDeleteEventArgs e)
        {
            ValidateSiteEdit(e);
        }

        protected void fileManager_FolderCreating(object sender, FileManagerFolderCreateEventArgs e)
        {
            ValidateSiteEdit(e);
        }

        protected void fileManager_ItemCopying(object sender, FileManagerItemCopyEventArgs e)
        {
            ValidateSiteEdit(e);
        }


        void ApplyFileManagerSettings()
        {
            fileManager.SettingsEditing.AllowMove = true;
            fileManager.SettingsEditing.AllowDelete = true;
            fileManager.SettingsEditing.AllowRename = true;
            fileManager.SettingsEditing.AllowCreate = true;
            fileManager.SettingsEditing.AllowCopy = true;
            fileManager.SettingsEditing.AllowDownload = true;
            fileManager.SettingsToolbar.ShowPath = true;
            fileManager.SettingsToolbar.ShowFilterBox = true;
            fileManager.SettingsFolders.ShowLockedFolderIcons = true;
            fileManager.SettingsFolders.ShowFolderIcons = true;
            fileManager.SettingsFolders.EnableCallBacks = true;
            fileManager.SettingsFolders.Visible = true;
            fileManager.SettingsUpload.Enabled = true;
            fileManager.SettingsFileList.ShowFolders = true;
            fileManager.SettingsFileList.ShowParentFolder = true;
            fileManager.SettingsBreadcrumbs.Visible = true;
            fileManager.SettingsBreadcrumbs.ShowParentFolderButton = true;
            fileManager.SettingsUpload.UseAdvancedUploadMode = true;// cbUploadMultiSelect.Checked;
            fileManager.SettingsUpload.AdvancedModeSettings.EnableMultiSelect = true;// cbUploadMultiSelect.Checked;
                                                                                     //   fileManager.Settings.RootFolder = "~/Content/Trabalhos/Aprendiz";
        }

        void ValidateSiteEdit(FileManagerActionEventArgsBase e)
        {
            //e.Cancel = true;// Utils.IsSiteMode;
            //e.ErrorText = "Erro";// Utils.GetReadOnlyMessageText();
        }
    }
}