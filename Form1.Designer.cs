namespace IncrementalBackup
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.listView1 = new System.Windows.Forms.ListView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ConfigMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RegistFolderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ChangeFolderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UnregistFolderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StartBackupMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RestoreFilesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 27);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(479, 188);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ConfigMenuItem,
            this.StartBackupMenuItem,
            this.RestoreFilesMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(503, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ConfigMenuItem
            // 
            this.ConfigMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RegistFolderMenuItem,
            this.ChangeFolderMenuItem,
            this.UnregistFolderMenuItem});
            this.ConfigMenuItem.Name = "ConfigMenuItem";
            this.ConfigMenuItem.Size = new System.Drawing.Size(43, 20);
            this.ConfigMenuItem.Text = "設定";
            // 
            // RegistFolderMenuItem
            // 
            this.RegistFolderMenuItem.Name = "RegistFolderMenuItem";
            this.RegistFolderMenuItem.Size = new System.Drawing.Size(180, 22);
            this.RegistFolderMenuItem.Text = "フォルダを登録";
            this.RegistFolderMenuItem.Click += new System.EventHandler(this.RegistFolderMenuItem_Click);
            // 
            // ChangeFolderMenuItem
            // 
            this.ChangeFolderMenuItem.Name = "ChangeFolderMenuItem";
            this.ChangeFolderMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ChangeFolderMenuItem.Text = "登録内容を変更";
            this.ChangeFolderMenuItem.Click += new System.EventHandler(this.ChangeFolderMenuItem_Click);
            // 
            // UnregistFolderMenuItem
            // 
            this.UnregistFolderMenuItem.Name = "UnregistFolderMenuItem";
            this.UnregistFolderMenuItem.Size = new System.Drawing.Size(180, 22);
            this.UnregistFolderMenuItem.Text = "登録内容を削除";
            this.UnregistFolderMenuItem.Click += new System.EventHandler(this.UnregistFolderMenuItem_Click);
            // 
            // StartBackupMenuItem
            // 
            this.StartBackupMenuItem.Name = "StartBackupMenuItem";
            this.StartBackupMenuItem.Size = new System.Drawing.Size(96, 20);
            this.StartBackupMenuItem.Text = "バックアップ開始";
            this.StartBackupMenuItem.Click += new System.EventHandler(this.StartBackupMenuItem_Click);
            // 
            // RestoreFilesMenuItem
            // 
            this.RestoreFilesMenuItem.Name = "RestoreFilesMenuItem";
            this.RestoreFilesMenuItem.Size = new System.Drawing.Size(127, 20);
            this.RestoreFilesMenuItem.Text = "バックアップ先から復元";
            this.RestoreFilesMenuItem.Click += new System.EventHandler(this.RestoreFilesMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 225);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ConfigMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RegistFolderMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ChangeFolderMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UnregistFolderMenuItem;
        private System.Windows.Forms.ToolStripMenuItem StartBackupMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RestoreFilesMenuItem;
    }
}

