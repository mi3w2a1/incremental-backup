using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

namespace IncrementalBackup
{
    public partial class FormFolder : Form
    {
        public FormFolder()
        {
            InitializeComponent();

            buttonOK.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;
        }

        public string SourceFolderPath = "";
        public string TargetFolderPath = "";

        //protected override void OnLoad(EventArgs e)
        //{
        //    SourceFolderPathTextBox.Text = SourceFolderPath;
        //    TargetFolderPathTextBox.Text = TargetFolderPath;

        //    SourceFolderPathTextBox.AllowDrop = true;
        //    TargetFolderPathTextBox.AllowDrop = true;

        //    base.OnLoad(e);
        //}

        //private void buttonOK_Click(object sender, EventArgs e)
        //{
        //    SourceFolderPath = SourceFolderPathTextBox.Text;
        //    TargetFolderPath = TargetFolderPathTextBox.Text;
        //}

        private void SourceFolderPathTextBox_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] vs = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (vs.Length == 1 && Directory.Exists(vs[0]))
                {
                    SourceFolderPathTextBox.Text = vs[0];
                    return;
                }
            }
            e.Effect = DragDropEffects.None;
        }

        private void SourceFolderPathTextBox_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] vs = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (vs.Length == 1 && Directory.Exists(vs[0]))
                {
                    e.Effect = DragDropEffects.Copy;
                    return;
                }
            }
            e.Effect = DragDropEffects.None;
        }

        private void TargetFolderPathTextBox_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] vs = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (vs.Length == 1 && Directory.Exists(vs[0]))
                {
                    TargetFolderPathTextBox.Text = vs[0];
                    return;
                }
            }
            e.Effect = DragDropEffects.None;
        }

        private void TargetFolderPathTextBox_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] vs = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (vs.Length == 1 && Directory.Exists(vs[0]))
                {
                    e.Effect = DragDropEffects.Copy;
                    return;
                }
            }
            e.Effect = DragDropEffects.None;
        }

        public string[] Extensions = null;
        public string Memo = "";

        protected override void OnLoad(EventArgs e)
        {
            SourceFolderPathTextBox.Text = SourceFolderPath;
            TargetFolderPathTextBox.Text = TargetFolderPath;

            SourceFolderPathTextBox.AllowDrop = true;
            TargetFolderPathTextBox.AllowDrop = true;

            // 追加
            if (Extensions != null)
                ExtensionsTextBox.Text = String.Join(", ", Extensions);
            MemoTextBox.Text = Memo;

            base.OnLoad(e);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            SourceFolderPath = SourceFolderPathTextBox.Text;
            TargetFolderPath = TargetFolderPathTextBox.Text;

            string str = ExtensionsTextBox.Text;
            str = str.Replace(" ", "");
            str = str.Replace("　", "");
            Extensions = str.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            Memo = MemoTextBox.Text;
        }

    }
}
