using PCLConvert.Util;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace PCLConvert
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private ComponentResourceManager resourceManager = null;

        private string GetResourceString(string key)
        {
            return resourceManager.GetString(key);
        }

        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, GetResourceString("$this.Text"), MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ShowInfoMessage(string message)
        {
            MessageBox.Show(message, GetResourceString("$this.Text"), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool ConfirmAction(string message)
        {
            var result = MessageBox.Show(message, GetResourceString("$this.Text"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            return (result == DialogResult.OK);
        }

        private void ButtonSelectPclSource_Click(object sender, EventArgs e)
        {
            if (openFileDialogSelectSource.ShowDialog() == DialogResult.OK)
            {
                textBoxPclSourcePath.Text = openFileDialogSelectSource.FileName;
            }
        }

        private void ButtonSelectPdfDest_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxPclSourcePath.Text) && 
                string.IsNullOrEmpty(textBoxPdfDestPath.Text))
            {
                var outputFileName = Path.GetFileNameWithoutExtension(textBoxPclSourcePath.Text);
                if (!string.IsNullOrEmpty(outputFileName))
                {
                    openFileDialogSelectDest.FileName = outputFileName;
                }
            }

            if (!string.IsNullOrEmpty(textBoxPdfDestPath.Text))
            {
                var outputfileName = Path.GetFileName(textBoxPdfDestPath.Text);
                if (!string.IsNullOrEmpty(outputfileName))
                {
                    openFileDialogSelectDest.FileName = outputfileName;
                }
            }

            if (openFileDialogSelectDest.ShowDialog() == DialogResult.OK)
            {
                textBoxPdfDestPath.Text = openFileDialogSelectDest.FileName;
            }
        }

        private void ButtonConvert_Click(object sender, EventArgs e)
        {
            // validations
            var sourceFilePath = textBoxPclSourcePath.Text.Trim();
            var destFilePath = textBoxPdfDestPath.Text.Trim();
            if (String.IsNullOrEmpty(sourceFilePath))
            {
                ShowErrorMessage(GetResourceString("MsgNeedToSelectPCLFile"));
                return;
            }
            if (!File.Exists(sourceFilePath))
            {
                ShowErrorMessage(GetResourceString("MsgPCLFileNotExist"));
                return;
            }
            if(String.IsNullOrEmpty(destFilePath))
            {
                ShowErrorMessage(GetResourceString("MsgNeedToSelectPDFFile"));
                return;
            }
            if (File.Exists(destFilePath))
            {
                if (!ConfirmAction(GetResourceString("MsgOverwritePDFFile")))
                {
                    return;
                }
            }

            if (PCLConvertManager.Instance.ConvertToPDF(sourceFilePath, destFilePath, out string errorMessage))
            {
                if (ConfigManager.Instance.IsOpenAfterConvert)
                {
                    try
                    {
                        Process.Start(destFilePath);
                    }
                    catch (Exception)
                    {
                        ShowInfoMessage(GetResourceString("MsgConvertSuccess"));
                    }
                }
                else
                {
                    ShowInfoMessage(GetResourceString("MsgConvertSuccess"));
                }

            }
            else
            {
                ShowErrorMessage(errorMessage);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            RefreshBySettings();
        }

        private void RefreshBySettings()
        {
            openPDFAfterConvertToolStripMenuItem.Checked = ConfigManager.Instance.IsOpenAfterConvert;

            var language = ConfigManager.Instance.Language;
            englishToolStripMenuItem.Checked = (language == ConfigManager.LangEnglish);
            simplifiedChineseToolStripMenuItem.Checked = (language == ConfigManager.LangSimplifiedChinese);
            traditionalChineseToolStripMenuItem.Checked = (language == ConfigManager.LangTraditionalChinese);

            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
            MultiLanguage.LoadLanguage(this, typeof(MainForm));
            resourceManager = new ComponentResourceManager(typeof(MainForm));
        }

        private void OpenPDFAfterConvertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var newValue = !ConfigManager.Instance.IsOpenAfterConvert;
            ConfigManager.Instance.SaveOpenAfterConvert(newValue);

            RefreshBySettings();
        }

        private void LanguageStripMenuItem_Click(object sender, EventArgs e)
        {
            var item = sender as ToolStripMenuItem;
            var newValue = item.Tag.ToString();

            if (newValue != ConfigManager.Instance.Language)
            {
                ConfigManager.Instance.SaveLange(newValue);
                RefreshBySettings();
            }
        }
    }
}
