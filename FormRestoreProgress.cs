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
    public partial class FormRestoreProgress : Form
    {
        public FormRestoreProgress()
        {
            InitializeComponent();
        }

        new public void Show()
        {
            Task.Run(() =>
            {
                ShowDialog();
            });
        }

        public bool RestoreCancel = false;

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("処理を中止しますか？", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                RestoreCancel = true;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (RestoreCancel)
            {
                base.OnClosing(e);
                return;
            }

            if (MessageBox.Show("処理を中止しますか？", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                RestoreCancel = true;
            else
                e.Cancel = true;
        }

        public ProgressBar GetProgressBar()
        {
            return progressBar1;
        }
    }
}
