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
    public partial class FormRestore : Form
    {
        public FormRestore()
        {
            InitializeComponent();
        }

        public List<long> TicksList = null;
        public string SelectedPath = "";
        public long RestoreTime = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                SelectedPath = dialog.SelectedPath;
            }

            dialog.Dispose();
        }

        //private void FormRestore_Load(object sender, EventArgs e)
        //{
        //    if (TicksList == null)
        //        return;

        //    foreach (long ticks in TicksList)
        //    {
        //        DateTime dt = new DateTime(ticks);
        //        string str = dt.ToString("yyyy年 MM月 dd日 HH時 mm分 ss秒");
        //        listBox1.Items.Add(str);
        //    }
        //}

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("復元時刻が指定されていません！", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (SelectedPath == "")
            {
                MessageBox.Show("復元先フォルダのパスが指定されていません！", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!Directory.Exists(SelectedPath))
            {
                MessageBox.Show("指定された復元先フォルダは存在しません！", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string[] vs1 = Directory.GetFiles(SelectedPath, "*.*", SearchOption.TopDirectoryOnly);
            string[] vs2 = Directory.GetDirectories(SelectedPath, "*.*", SearchOption.TopDirectoryOnly);
            if (vs1.Length != 0 || vs2.Length != 0)
            {
                MessageBox.Show("復元先フォルダは空のフォルダを指定してください！", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            long ticks = TicksList[listBox1.SelectedIndex];
            DateTime dt = new DateTime(ticks);
            string str = dt.ToString("yyyy年 MM月 dd日 HH時 mm分 ss秒");
            string mes = String.Format("フォルダ {0} に\n{1} のファイルとフォルダを復元します", SelectedPath, str);
            if (MessageBox.Show(mes, "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                RestoreTime = ticks;
                this.Close();
            }
        }

        private void FormRestore_Load(object sender, EventArgs e)
        {
            if (TicksList == null)
                return;

            foreach (long ticks in TicksList)
            {
                DateTime dt = new DateTime(ticks);
                string str = dt.ToString("yyyy年 MM月 dd日 HH時 mm分 ss秒");
                listBox1.Items.Add(str);
            }

            ChangeButtonSelectFileFolderEnabled();
        }

        private void ButtonRemoveRestorePoint_Click(object sender, EventArgs e)
        {
            int i = listBox1.SelectedIndex;
            if (i != -1)
            {
                Form1 form1 = (Form1)Owner;
                if (i - 1 >= 0)
                {
                    // 項目に対応するフォルダはどれか？
                    string removeFolder = form1.GetFolderPathFromTicks(TicksList[i]);
                    string moveToFolder = form1.GetFolderPathFromTicks(TicksList[i - 1]);

                    // 移動させるフォルダのパスをすべて求める
                    string[] folderPaths = Directory.GetDirectories(removeFolder, "*", SearchOption.AllDirectories);
                    foreach (string path in folderPaths)
                    {
                        string newPath = path.Replace(removeFolder, moveToFolder);
                        if (!Directory.Exists(newPath))
                            Directory.CreateDirectory(newPath);
                    }

                    // 移動させるファイルのパスをすべて求める
                    string[] moveFromPaths = Directory.GetFiles(removeFolder, "*", SearchOption.AllDirectories);

                    foreach (string path in moveFromPaths)
                    {
                        string newPath = path.Replace(removeFolder, moveToFolder);

                        // 移動先に同じファイルが存在するのであれば移動しない。
                        if (!File.Exists(newPath))
                        {
                            // 移動元にファイルが存在することを確認する。
                            if (File.Exists(path))
                            {
                                FileInfo info = new FileInfo(newPath);
                                if (!Directory.Exists(info.DirectoryName))
                                    Directory.CreateDirectory(info.DirectoryName);

                                // ひとつ次の世代のフォルダに移動。
                                // これがアンチウイルスソフトには怪しく見えるらしい。
                                File.Move(path, newPath);
                            }
                        }
                    }

                    // ログファイルと差分記録ファイルを削除する。
                    // これもアンチウイルスソフトには怪しく見えるらしい。
                    string delFilePath = form1.GetLogFilePathFromTicks(TicksList[i]);
                    File.Delete(delFilePath);
                    delFilePath = form1.GetDifferenceFilePathFromTicks(TicksList[i]);
                    File.Delete(delFilePath);

                    // バックアップ情報を保存しているフォルダを削除する。
                    // これもアンチウイルスソフトには怪しく見えるらしい。
                    Directory.Delete(removeFolder, true);
                    TicksList.RemoveAt(i);

                    listBox1.Items.RemoveAt(i);
                    if (i - 1 >= 0)
                        listBox1.SelectedIndex = i - 1;
                }
                else
                    MessageBox.Show("これは削除できません！");
            }
        }

        void ChangeButtonSelectFileFolderEnabled()
        {
            if (CheckBoxIsPartFiles.Checked)
                ButtonSelectFileFolder.Enabled = true;
            else
                ButtonSelectFileFolder.Enabled = false;
        }

        private void CheckBoxIsPartFiles_CheckedChanged(object sender, EventArgs e)
        {
            ChangeButtonSelectFileFolderEnabled();
        }

        public string SelectedSourcePartPath = "";
        private void ButtonSelectFileFolder_Click(object sender, EventArgs e)
        {
            if (SelectedPath == "" || !Directory.Exists(SelectedPath))
            {
                MessageBox.Show("先に復元先フォルダを指定してください！", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int i = listBox1.SelectedIndex;
            if (i != -1)
            {
                Form1 form1 = (Form1)Owner;
                string selectLogFilePath = form1.GetLogFilePathFromTicks(TicksList[i]);

                StreamReader sr = new StreamReader(selectLogFilePath);
                string str = sr.ReadToEnd();
                sr.Close();

                RestoreTime = TicksList[listBox1.SelectedIndex];

                FormPartRestore form = new FormPartRestore();
                form.fileList = str;
                form.ShowDialog(this);

                SelectedSourcePartPath = form.SelectedSourcePath;

                if (SelectedSourcePartPath != "")
                {
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("復元する時刻を選択してください！", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }
    }
}
