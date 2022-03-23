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
    public partial class FormPartRestore : Form
    {
        public FormPartRestore()
        {
            InitializeComponent();
            TextBoxFolderPath.ReadOnly = true;
        }

        public string fileList = "";
        public string SelectedSourcePath = "";

        List<string> filePaths = new List<string>();
        string curFolder = "";
        string topFolder = "";

        private void FormPartRestore_Load(object sender, EventArgs e)
        {
            string[] vs = fileList.Split(new string[] { "\r\n", "\n", }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string str in vs)
            {
                string[] vs1 = str.Split(new string[] { "::", }, StringSplitOptions.RemoveEmptyEntries);
                if (vs1.Length == 2)
                    filePaths.Add(vs1[0]);
            }

            int last = filePaths[0].LastIndexOf("\\");
            curFolder = filePaths[0].Substring(0, last);
            topFolder = curFolder;
            TextBoxFolderPath.Text = curFolder;

            // 直下のファイルとフォルダを列挙
            foreach (string str in filePaths)
            {
                string str1 = str.Substring(last + 1);
                int index2 = str1.IndexOf("\\");
                if (index2 == -1)
                {
                    listBox1.Items.Add(str1);

                    // フォルダと思われるパスを列挙
                    index2 = str1.IndexOf(".");
                    if (index2 == -1)
                        listBox2.Items.Add(str1);
                }
            }
        }

        private void ButtonOpenFolder_Click(object sender, EventArgs e)
        {
            int index = listBox2.SelectedIndex;
            if (index == -1)
            {
                MessageBox.Show("オープンするフォルダが選択されていません！", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            curFolder = curFolder + "\\" + (string)listBox2.Items[index];
            TextBoxFolderPath.Text = curFolder;

            var list = filePaths.Where(x => x.IndexOf(curFolder) != -1).ToList();
            listBox1.Items.Clear();
            listBox2.Items.Clear();

            foreach (string str in list)
            {
                if (str.Length < curFolder.Length + 1)
                    continue;

                if (str.IndexOf(curFolder + "\\") == -1)
                    continue;

                string str2 = str.Substring(curFolder.Length + 1);
                int index2 = str2.IndexOf("\\");
                if (index2 == -1)
                {
                    listBox1.Items.Add(str2);

                    // フォルダと思われるパスを列挙
                    index = str2.IndexOf(".");
                    if (index == -1)
                    {
                        listBox2.Items.Add(str2);
                    }
                }
            }
        }

        private void ButtonSelect_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            if (index == -1)
            {
                MessageBox.Show("復元するファイルまたはフォルダが選択されていません", "エラー", MessageBoxButtons.OK);
                return;
            }

            string selectedPath = curFolder + "\\" + (string)listBox1.Items[index];

            FormRestore form = (FormRestore)Owner;

            DateTime dt = new DateTime(form.RestoreTime);
            string str = dt.ToString("yyyy年 MM月 dd日 HH時 mm分 ss秒");
            string mes = String.Format("フォルダ {0} に\n{1} の{2}のデータを復元します。\nよろしいですか？", form.SelectedPath, str, selectedPath);

            if (MessageBox.Show(mes, "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                SelectedSourcePath = selectedPath;
                Close();
            }
        }

        private void ButtonFolderUp_Click(object sender, EventArgs e)
        {
            if (curFolder == topFolder)
            {
                MessageBox.Show("このフォルダより上へは移動できません！", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            System.IO.FileInfo info = new System.IO.FileInfo(curFolder);
            curFolder = info.DirectoryName;
            TextBoxFolderPath.Text = curFolder;

            var list = filePaths.Where(x => x.IndexOf(curFolder) != -1).ToList();
            listBox1.Items.Clear();
            listBox2.Items.Clear();

            // 直下のファイルとフォルダのみ列挙
            foreach (string str in list)
            {
                if (str.Length < curFolder.Length + 1)
                    continue;

                if (str.IndexOf(curFolder + "\\") == -1)
                    continue;

                string str2 = str.Substring(curFolder.Length + 1);
                int index = str2.IndexOf("\\");

                if (index == -1)
                {
                    listBox1.Items.Add(str2);

                    // フォルダと思われるパスを列挙
                    int index2 = str2.IndexOf(".");
                    if (index2 == -1)
                    {
                        listBox2.Items.Add(str2);
                    }
                }
            }

        }
    }
}
