using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IncrementalBackup
{
    public partial class FormBackupProgress : Form
    {
        public FormBackupProgress()
        {
            InitializeComponent();
        }

        private void FormBackupProgress_Load(object sender, EventArgs e)
        {

        }

        new public void Show()
        {
            Task.Run(() =>
            {
                ShowDialog();
            });
        }

        public bool BackupCancel = false;
        public bool IsEnd = false;

        private void button1_Click(object sender, EventArgs e)
        {
            BackupCancel = true;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (!IsEnd)
            {
                if (MessageBox.Show("バックアップ処理を中止しますか？", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    BackupCancel = true;
                else
                    e.Cancel = true;
                //return;
            }

            base.OnClosing(e);
        }

        public ProgressBar GetProgressBarGetSourceFiles()
        {
            return progressBarGetSourceFiles;
        }

        public ProgressBar GetProgressBarGetBackupFiles()
        {
            return progressBarGetBackupFiles;
        }

        public ProgressBar GetProgressBarBackupFolders()
        {
            return progressBarBackupFolders;
        }

        public ProgressBar GetProgressBarBackupFiles()
        {
            return progressBarBackupFiles;
        }

        public ProgressBar GetProgressBarLogFile()
        {
            return progressBarLogFile;
        }

        public ProgressBar GetProgressBarDifferenceFile()
        {
            return progressBarDifferenceFile;
        }
    }
}
