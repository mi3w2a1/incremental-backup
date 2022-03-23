namespace IncrementalBackup
{
    partial class FormFolder
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SourceFolderPathTextBox = new System.Windows.Forms.TextBox();
            this.TargetFolderPathTextBox = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.MemoTextBox = new System.Windows.Forms.TextBox();
            this.ExtensionsTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "バックアップ元";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "バックアップ先";
            // 
            // SourceFolderPathTextBox
            // 
            this.SourceFolderPathTextBox.Location = new System.Drawing.Point(16, 30);
            this.SourceFolderPathTextBox.Name = "SourceFolderPathTextBox";
            this.SourceFolderPathTextBox.Size = new System.Drawing.Size(453, 19);
            this.SourceFolderPathTextBox.TabIndex = 2;
            this.SourceFolderPathTextBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.SourceFolderPathTextBox_DragDrop);
            this.SourceFolderPathTextBox.DragOver += new System.Windows.Forms.DragEventHandler(this.SourceFolderPathTextBox_DragOver);
            // 
            // TargetFolderPathTextBox
            // 
            this.TargetFolderPathTextBox.Location = new System.Drawing.Point(16, 75);
            this.TargetFolderPathTextBox.Name = "TargetFolderPathTextBox";
            this.TargetFolderPathTextBox.Size = new System.Drawing.Size(453, 19);
            this.TargetFolderPathTextBox.TabIndex = 3;
            this.TargetFolderPathTextBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.TargetFolderPathTextBox_DragDrop);
            this.TargetFolderPathTextBox.DragOver += new System.Windows.Forms.DragEventHandler(this.TargetFolderPathTextBox_DragOver);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(16, 200);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 4;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(107, 200);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "CANCEL";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // MemoTextBox
            // 
            this.MemoTextBox.Location = new System.Drawing.Point(19, 169);
            this.MemoTextBox.Name = "MemoTextBox";
            this.MemoTextBox.Size = new System.Drawing.Size(453, 19);
            this.MemoTextBox.TabIndex = 9;
            // 
            // ExtensionsTextBox
            // 
            this.ExtensionsTextBox.Location = new System.Drawing.Point(19, 124);
            this.ExtensionsTextBox.Name = "ExtensionsTextBox";
            this.ExtensionsTextBox.Size = new System.Drawing.Size(453, 19);
            this.ExtensionsTextBox.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "メモ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "除外する拡張子";
            // 
            // FormFolder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 235);
            this.Controls.Add(this.MemoTextBox);
            this.Controls.Add(this.ExtensionsTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.TargetFolderPathTextBox);
            this.Controls.Add(this.SourceFolderPathTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormFolder";
            this.Text = "FormFolder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox SourceFolderPathTextBox;
        private System.Windows.Forms.TextBox TargetFolderPathTextBox;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox MemoTextBox;
        private System.Windows.Forms.TextBox ExtensionsTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}