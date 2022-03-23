namespace IncrementalBackup
{
    partial class FormRestore
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.ButtonRemoveRestorePoint = new System.Windows.Forms.Button();
            this.CheckBoxIsPartFiles = new System.Windows.Forms.CheckBox();
            this.ButtonSelectFileFolder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(13, 13);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(302, 340);
            this.listBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(321, 77);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "復元先フォルダを選択";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(321, 107);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(135, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "復元";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ButtonRemoveRestorePoint
            // 
            this.ButtonRemoveRestorePoint.Location = new System.Drawing.Point(321, 155);
            this.ButtonRemoveRestorePoint.Name = "ButtonRemoveRestorePoint";
            this.ButtonRemoveRestorePoint.Size = new System.Drawing.Size(135, 23);
            this.ButtonRemoveRestorePoint.TabIndex = 3;
            this.ButtonRemoveRestorePoint.Text = "復元ポイントを削除する";
            this.ButtonRemoveRestorePoint.UseVisualStyleBackColor = true;
            this.ButtonRemoveRestorePoint.Click += new System.EventHandler(this.ButtonRemoveRestorePoint_Click);
            // 
            // CheckBoxIsPartFiles
            // 
            this.CheckBoxIsPartFiles.AutoSize = true;
            this.CheckBoxIsPartFiles.Location = new System.Drawing.Point(321, 13);
            this.CheckBoxIsPartFiles.Name = "CheckBoxIsPartFiles";
            this.CheckBoxIsPartFiles.Size = new System.Drawing.Size(176, 16);
            this.CheckBoxIsPartFiles.TabIndex = 4;
            this.CheckBoxIsPartFiles.Text = "一部のファイル・フォルダだけ復元";
            this.CheckBoxIsPartFiles.UseVisualStyleBackColor = true;
            this.CheckBoxIsPartFiles.CheckedChanged += new System.EventHandler(this.CheckBoxIsPartFiles_CheckedChanged);
            // 
            // ButtonSelectFileFolder
            // 
            this.ButtonSelectFileFolder.Location = new System.Drawing.Point(321, 35);
            this.ButtonSelectFileFolder.Name = "ButtonSelectFileFolder";
            this.ButtonSelectFileFolder.Size = new System.Drawing.Size(135, 23);
            this.ButtonSelectFileFolder.TabIndex = 5;
            this.ButtonSelectFileFolder.Text = "復元対象を指定する";
            this.ButtonSelectFileFolder.UseVisualStyleBackColor = true;
            this.ButtonSelectFileFolder.Click += new System.EventHandler(this.ButtonSelectFileFolder_Click);
            // 
            // FormRestore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 365);
            this.Controls.Add(this.ButtonSelectFileFolder);
            this.Controls.Add(this.CheckBoxIsPartFiles);
            this.Controls.Add(this.ButtonRemoveRestorePoint);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormRestore";
            this.Text = "FormRestore";
            this.Load += new System.EventHandler(this.FormRestore_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button ButtonRemoveRestorePoint;
        private System.Windows.Forms.CheckBox CheckBoxIsPartFiles;
        private System.Windows.Forms.Button ButtonSelectFileFolder;
    }
}