
namespace IncrementalBackup
{
    partial class FormBackupProgress
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
            Invoke((System.Action)(() => {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }));
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.progressBarGetSourceFiles = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBarGetBackupFiles = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.progressBarBackupFiles = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.progressBarBackupFolders = new System.Windows.Forms.ProgressBar();
            this.label5 = new System.Windows.Forms.Label();
            this.progressBarDifferenceFile = new System.Windows.Forms.ProgressBar();
            this.label6 = new System.Windows.Forms.Label();
            this.progressBarLogFile = new System.Windows.Forms.ProgressBar();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // progressBarGetSourceFiles
            // 
            this.progressBarGetSourceFiles.Location = new System.Drawing.Point(13, 43);
            this.progressBarGetSourceFiles.Name = "progressBarGetSourceFiles";
            this.progressBarGetSourceFiles.Size = new System.Drawing.Size(485, 23);
            this.progressBarGetSourceFiles.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "バックアップ元のファイル・フォルダの取得";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "バックアップをとるファイルとフォルダの確認";
            // 
            // progressBarGetBackupFiles
            // 
            this.progressBarGetBackupFiles.Location = new System.Drawing.Point(13, 98);
            this.progressBarGetBackupFiles.Name = "progressBarGetBackupFiles";
            this.progressBarGetBackupFiles.Size = new System.Drawing.Size(485, 23);
            this.progressBarGetBackupFiles.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "ファイルのバックアップの進行状況";
            // 
            // progressBarBackupFiles
            // 
            this.progressBarBackupFiles.Location = new System.Drawing.Point(13, 206);
            this.progressBarBackupFiles.Name = "progressBarBackupFiles";
            this.progressBarBackupFiles.Size = new System.Drawing.Size(485, 23);
            this.progressBarBackupFiles.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "フォルダのバックアップの進行状況";
            // 
            // progressBarBackupFolders
            // 
            this.progressBarBackupFolders.Location = new System.Drawing.Point(13, 151);
            this.progressBarBackupFolders.Name = "progressBarBackupFolders";
            this.progressBarBackupFolders.Size = new System.Drawing.Size(485, 23);
            this.progressBarBackupFolders.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 298);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(148, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "差分レポート作成の進行状況";
            // 
            // progressBarDifferenceFile
            // 
            this.progressBarDifferenceFile.Location = new System.Drawing.Point(13, 316);
            this.progressBarDifferenceFile.Name = "progressBarDifferenceFile";
            this.progressBarDifferenceFile.Size = new System.Drawing.Size(485, 23);
            this.progressBarDifferenceFile.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 243);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(139, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "ログファイル作成の進行状況";
            // 
            // progressBarLogFile
            // 
            this.progressBarLogFile.Location = new System.Drawing.Point(13, 261);
            this.progressBarLogFile.Name = "progressBarLogFile";
            this.progressBarLogFile.Size = new System.Drawing.Size(485, 23);
            this.progressBarLogFile.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(526, 316);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "中止";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormBackupProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 351);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.progressBarDifferenceFile);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.progressBarLogFile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.progressBarBackupFiles);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.progressBarBackupFolders);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.progressBarGetBackupFiles);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBarGetSourceFiles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormBackupProgress";
            this.Text = "FormBackupProgress";
            this.Load += new System.EventHandler(this.FormBackupProgress_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        protected System.Windows.Forms.ProgressBar progressBarGetSourceFiles;
        private System.Windows.Forms.ProgressBar progressBarGetBackupFiles;
        private System.Windows.Forms.ProgressBar progressBarBackupFolders;
        private System.Windows.Forms.ProgressBar progressBarBackupFiles;
        private System.Windows.Forms.ProgressBar progressBarLogFile;
        private System.Windows.Forms.ProgressBar progressBarDifferenceFile;
    }
}