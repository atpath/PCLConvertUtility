namespace PCLConvert
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelPclFilePath = new System.Windows.Forms.Label();
            this.textBoxPclSourcePath = new System.Windows.Forms.TextBox();
            this.buttonSelectPclSource = new System.Windows.Forms.Button();
            this.buttonSelectPdfDest = new System.Windows.Forms.Button();
            this.textBoxPdfDestPath = new System.Windows.Forms.TextBox();
            this.labelPdfDestPath = new System.Windows.Forms.Label();
            this.buttonConvert = new System.Windows.Forms.Button();
            this.openFileDialogSelectSource = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogSelectDest = new System.Windows.Forms.OpenFileDialog();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simplifiedChineseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.traditionalChineseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openPDFAfterConvertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelPclFilePath
            // 
            this.labelPclFilePath.AutoSize = true;
            this.labelPclFilePath.Location = new System.Drawing.Point(9, 43);
            this.labelPclFilePath.Name = "labelPclFilePath";
            this.labelPclFilePath.Size = new System.Drawing.Size(99, 15);
            this.labelPclFilePath.TabIndex = 0;
            this.labelPclFilePath.Text = "PCL Source File:";
            // 
            // textBoxPclSourcePath
            // 
            this.textBoxPclSourcePath.Location = new System.Drawing.Point(138, 40);
            this.textBoxPclSourcePath.Name = "textBoxPclSourcePath";
            this.textBoxPclSourcePath.Size = new System.Drawing.Size(412, 21);
            this.textBoxPclSourcePath.TabIndex = 1;
            // 
            // buttonSelectPclSource
            // 
            this.buttonSelectPclSource.Location = new System.Drawing.Point(556, 40);
            this.buttonSelectPclSource.Name = "buttonSelectPclSource";
            this.buttonSelectPclSource.Size = new System.Drawing.Size(39, 21);
            this.buttonSelectPclSource.TabIndex = 2;
            this.buttonSelectPclSource.Text = "...";
            this.buttonSelectPclSource.UseVisualStyleBackColor = true;
            this.buttonSelectPclSource.Click += new System.EventHandler(this.ButtonSelectPclSource_Click);
            // 
            // buttonSelectPdfDest
            // 
            this.buttonSelectPdfDest.Location = new System.Drawing.Point(556, 78);
            this.buttonSelectPdfDest.Name = "buttonSelectPdfDest";
            this.buttonSelectPdfDest.Size = new System.Drawing.Size(39, 21);
            this.buttonSelectPdfDest.TabIndex = 5;
            this.buttonSelectPdfDest.Text = "...";
            this.buttonSelectPdfDest.UseVisualStyleBackColor = true;
            this.buttonSelectPdfDest.Click += new System.EventHandler(this.ButtonSelectPdfDest_Click);
            // 
            // textBoxPdfDestPath
            // 
            this.textBoxPdfDestPath.Location = new System.Drawing.Point(138, 78);
            this.textBoxPdfDestPath.Name = "textBoxPdfDestPath";
            this.textBoxPdfDestPath.Size = new System.Drawing.Size(412, 21);
            this.textBoxPdfDestPath.TabIndex = 4;
            // 
            // labelPdfDestPath
            // 
            this.labelPdfDestPath.AutoSize = true;
            this.labelPdfDestPath.Location = new System.Drawing.Point(9, 81);
            this.labelPdfDestPath.Name = "labelPdfDestPath";
            this.labelPdfDestPath.Size = new System.Drawing.Size(123, 15);
            this.labelPdfDestPath.TabIndex = 3;
            this.labelPdfDestPath.Text = "PDF Destination File:";
            // 
            // buttonConvert
            // 
            this.buttonConvert.Location = new System.Drawing.Point(138, 121);
            this.buttonConvert.Name = "buttonConvert";
            this.buttonConvert.Size = new System.Drawing.Size(110, 23);
            this.buttonConvert.TabIndex = 6;
            this.buttonConvert.Text = "Convert to PDF";
            this.buttonConvert.UseVisualStyleBackColor = true;
            this.buttonConvert.Click += new System.EventHandler(this.ButtonConvert_Click);
            // 
            // openFileDialogSelectSource
            // 
            this.openFileDialogSelectSource.Filter = "SPL files|*.SPL|PCL files|*.PCL|All files|*.*";
            this.openFileDialogSelectSource.Title = "Select source pcl file";
            // 
            // openFileDialogSelectDest
            // 
            this.openFileDialogSelectDest.CheckFileExists = false;
            this.openFileDialogSelectDest.Filter = "PDF files|*.PDF";
            this.openFileDialogSelectDest.Title = "Select output PDF file name";
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(654, 25);
            this.menuStripMain.TabIndex = 8;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.languageToolStripMenuItem,
            this.openPDFAfterConvertToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(66, 21);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishToolStripMenuItem,
            this.simplifiedChineseToolStripMenuItem,
            this.traditionalChineseToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            this.languageToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.languageToolStripMenuItem.Text = "Language";
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            this.englishToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.englishToolStripMenuItem.Tag = "en-US";
            this.englishToolStripMenuItem.Text = "English";
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.LanguageStripMenuItem_Click);
            // 
            // simplifiedChineseToolStripMenuItem
            // 
            this.simplifiedChineseToolStripMenuItem.Name = "simplifiedChineseToolStripMenuItem";
            this.simplifiedChineseToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.simplifiedChineseToolStripMenuItem.Tag = "zh-CN";
            this.simplifiedChineseToolStripMenuItem.Text = "Simplified Chinese";
            this.simplifiedChineseToolStripMenuItem.Click += new System.EventHandler(this.LanguageStripMenuItem_Click);
            // 
            // traditionalChineseToolStripMenuItem
            // 
            this.traditionalChineseToolStripMenuItem.Name = "traditionalChineseToolStripMenuItem";
            this.traditionalChineseToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.traditionalChineseToolStripMenuItem.Tag = "zh-TW";
            this.traditionalChineseToolStripMenuItem.Text = "Traditional Chinese";
            this.traditionalChineseToolStripMenuItem.Click += new System.EventHandler(this.LanguageStripMenuItem_Click);
            // 
            // openPDFAfterConvertToolStripMenuItem
            // 
            this.openPDFAfterConvertToolStripMenuItem.Checked = true;
            this.openPDFAfterConvertToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.openPDFAfterConvertToolStripMenuItem.Name = "openPDFAfterConvertToolStripMenuItem";
            this.openPDFAfterConvertToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.openPDFAfterConvertToolStripMenuItem.Text = "Open PDF After Convert";
            this.openPDFAfterConvertToolStripMenuItem.Click += new System.EventHandler(this.OpenPDFAfterConvertToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 176);
            this.Controls.Add(this.buttonConvert);
            this.Controls.Add(this.buttonSelectPdfDest);
            this.Controls.Add(this.textBoxPdfDestPath);
            this.Controls.Add(this.labelPdfDestPath);
            this.Controls.Add(this.buttonSelectPclSource);
            this.Controls.Add(this.textBoxPclSourcePath);
            this.Controls.Add(this.labelPclFilePath);
            this.Controls.Add(this.menuStripMain);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStripMain;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PCL Convert";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPclFilePath;
        private System.Windows.Forms.TextBox textBoxPclSourcePath;
        private System.Windows.Forms.Button buttonSelectPclSource;
        private System.Windows.Forms.Button buttonSelectPdfDest;
        private System.Windows.Forms.TextBox textBoxPdfDestPath;
        private System.Windows.Forms.Label labelPdfDestPath;
        private System.Windows.Forms.Button buttonConvert;
        private System.Windows.Forms.OpenFileDialog openFileDialogSelectSource;
        private System.Windows.Forms.OpenFileDialog openFileDialogSelectDest;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openPDFAfterConvertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simplifiedChineseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem traditionalChineseToolStripMenuItem;
    }
}

