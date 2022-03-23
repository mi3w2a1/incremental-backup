namespace IncrementalBackup
{
    partial class FormPartRestore
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
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.TextBoxFolderPath = new System.Windows.Forms.TextBox();
            this.ButtonSelect = new System.Windows.Forms.Button();
            this.ButtonOpenFolder = new System.Windows.Forms.Button();
            this.ButtonFolderUp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(12, 65);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(292, 124);
            this.listBox1.TabIndex = 0;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 12;
            this.listBox2.Location = new System.Drawing.Point(12, 204);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(292, 124);
            this.listBox2.TabIndex = 1;
            // 
            // TextBoxFolderPath
            // 
            this.TextBoxFolderPath.Location = new System.Drawing.Point(12, 12);
            this.TextBoxFolderPath.Name = "TextBoxFolderPath";
            this.TextBoxFolderPath.Size = new System.Drawing.Size(426, 19);
            this.TextBoxFolderPath.TabIndex = 2;
            // 
            // ButtonSelect
            // 
            this.ButtonSelect.Location = new System.Drawing.Point(342, 65);
            this.ButtonSelect.Name = "ButtonSelect";
            this.ButtonSelect.Size = new System.Drawing.Size(133, 23);
            this.ButtonSelect.TabIndex = 3;
            this.ButtonSelect.Text = "選択";
            this.ButtonSelect.UseVisualStyleBackColor = true;
            this.ButtonSelect.Click += new System.EventHandler(this.ButtonSelect_Click);
            // 
            // ButtonOpenFolder
            // 
            this.ButtonOpenFolder.Location = new System.Drawing.Point(342, 204);
            this.ButtonOpenFolder.Name = "ButtonOpenFolder";
            this.ButtonOpenFolder.Size = new System.Drawing.Size(133, 23);
            this.ButtonOpenFolder.TabIndex = 4;
            this.ButtonOpenFolder.Text = "フォルダを開く";
            this.ButtonOpenFolder.UseVisualStyleBackColor = true;
            this.ButtonOpenFolder.Click += new System.EventHandler(this.ButtonOpenFolder_Click);
            // 
            // ButtonFolderUp
            // 
            this.ButtonFolderUp.Location = new System.Drawing.Point(342, 245);
            this.ButtonFolderUp.Name = "ButtonFolderUp";
            this.ButtonFolderUp.Size = new System.Drawing.Size(133, 23);
            this.ButtonFolderUp.TabIndex = 5;
            this.ButtonFolderUp.Text = "上へ移動";
            this.ButtonFolderUp.UseVisualStyleBackColor = true;
            this.ButtonFolderUp.Click += new System.EventHandler(this.ButtonFolderUp_Click);
            // 
            // FormPartRestore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 361);
            this.Controls.Add(this.ButtonFolderUp);
            this.Controls.Add(this.ButtonOpenFolder);
            this.Controls.Add(this.ButtonSelect);
            this.Controls.Add(this.TextBoxFolderPath);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Name = "FormPartRestore";
            this.Text = "FormPartRestore";
            this.Load += new System.EventHandler(this.FormPartRestore_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.TextBox TextBoxFolderPath;
        private System.Windows.Forms.Button ButtonSelect;
        private System.Windows.Forms.Button ButtonOpenFolder;
        private System.Windows.Forms.Button ButtonFolderUp;
    }
}