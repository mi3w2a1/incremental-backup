using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using System.Xml.Serialization;
using System.IO;

namespace IncrementalBackup
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            InitListView();
            LoadConfig();
        }

        List<BackupFolderInfo> BackupFolderInfos = new List<BackupFolderInfo>();

        //void InitListView()
        //{
        //    listView1.View = View.Details;
        //    listView1.Columns.Add("バックアップ元");
        //    listView1.Columns.Add("バックアップ先");
        //    listView1.Columns[0].Width = 300;
        //    listView1.Columns[1].Width = 300;
        //    listView1.FullRowSelect = true;
        //    listView1.MultiSelect = false;
        //    listView1.HideSelection = false;
        //}

        //void LoadConfig()
        //{
        //    string path = Application.UserAppDataPath + "\\config.xml";
        //    if (!File.Exists(path))
        //        return;

        //    XmlSerializer xml = new XmlSerializer(typeof(Config));
        //    StreamReader sr = new StreamReader(path);
        //    Config config = (Config)xml.Deserialize(sr);
        //    sr.Close();

        //    BackupFolderInfos = config.BackupFolderInfos;

        //    foreach (BackupFolderInfo info in BackupFolderInfos)
        //    {
        //        string[] item = { info.SourceFolderPath, info.TargetFolderPath };
        //        listView1.Items.Add(new ListViewItem(item));
        //    }
        //}

        void SaveConfig()
        {
            string path = Application.UserAppDataPath + "\\config.xml";

            Config config = new Config();
            config.BackupFolderInfos = BackupFolderInfos;

            XmlSerializer xml = new XmlSerializer(typeof(Config));
            StreamWriter sw = new StreamWriter(path);
            xml.Serialize(sw, config);
            sw.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //private void RegistFolderMenuItem_Click(object sender, EventArgs e)
        //{
        //    FormFolder form = new FormFolder();
        //    if (form.ShowDialog() == DialogResult.OK)
        //    {
        //        if (Directory.Exists(form.SourceFolderPath) && Directory.Exists(form.TargetFolderPath))
        //        {
        //            string[] item = { form.SourceFolderPath, form.TargetFolderPath };
        //            if (form.SourceFolderPath == form.TargetFolderPath)
        //            {
        //                MessageBox.Show("同じフォルダをバックアップ元とバックアップ先に指定することはできません！", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                return;
        //            }
        //            string[] filePaths1 = Directory.GetDirectories(form.SourceFolderPath, "*.*", SearchOption.AllDirectories);
        //            if (filePaths1.Any(x => x == form.TargetFolderPath))
        //            {
        //                MessageBox.Show("親子関係にあるフォルダをバックアップ元とバックアップ先に指定することはできません！", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                return;
        //            }

        //            listView1.Items.Add(new ListViewItem(item));
        //            BackupFolderInfos.Add(new BackupFolderInfo(form.SourceFolderPath, form.TargetFolderPath));
        //            SaveConfig();
        //        }
        //        else
        //            MessageBox.Show("存在するフォルダでないと登録できません！", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //    form.Dispose();
        //}

        //private void ChangeFolderMenuItem_Click(object sender, EventArgs e)
        //{
        //    var selectedItems = listView1.SelectedItems;
        //    if (selectedItems.Count == 0)
        //    {
        //        MessageBox.Show("編集する項目を選択してください！", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }
        //    ListViewItem selectedItem = selectedItems[0];

        //    FormFolder form = new FormFolder();
        //    form.SourceFolderPath = selectedItem.SubItems[0].Text;
        //    form.TargetFolderPath = selectedItem.SubItems[1].Text;
        //    if (form.ShowDialog() == DialogResult.OK)
        //    {
        //        if (Directory.Exists(form.SourceFolderPath) && Directory.Exists(form.TargetFolderPath))
        //        {

        //            string[] filePaths = Directory.GetDirectories(form.SourceFolderPath, "*.*", SearchOption.AllDirectories);
        //            if (form.SourceFolderPath != form.TargetFolderPath && !filePaths.Any(x => x == form.TargetFolderPath))
        //            {
        //                int index = listView1.Items.IndexOf(selectedItem);
        //                listView1.Items[index].SubItems[0].Text = form.SourceFolderPath;
        //                listView1.Items[index].SubItems[1].Text = form.TargetFolderPath;
        //                BackupFolderInfos[index].SourceFolderPath = form.SourceFolderPath;
        //                BackupFolderInfos[index].TargetFolderPath = form.TargetFolderPath;
        //                SaveConfig();
        //            }
        //            else
        //            {
        //                MessageBox.Show("バックアップ元フォルダのなかにバックアップ先のフォルダを指定することはできません！", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //        }
        //        else
        //            MessageBox.Show("存在するフォルダでないと登録できません！", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //    form.Dispose();
        //}

        private void UnregistFolderMenuItem_Click(object sender, EventArgs e)
        {
            var selectedItems = listView1.SelectedItems;
            if (selectedItems.Count == 0)
            {
                MessageBox.Show("削除する項目を選択してください！", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ListViewItem selectedItem = selectedItems[0];
            int index = listView1.Items.IndexOf(selectedItem);

            string source = BackupFolderInfos[index].SourceFolderPath;
            string target = BackupFolderInfos[index].TargetFolderPath;
            string mes = String.Format("以下の登録を削除します。\n\nバックアップ元：\n{0}\n\nバックアップ先\n{1}", source, target);

            if (MessageBox.Show(mes, "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                BackupFolderInfos.RemoveAt(index);
                listView1.Items.RemoveAt(index);
                SaveConfig();
            }
        }

        //void FullBackup(string sourceFolder, string targetFolder)
        //{
        //    string[] filePaths = Directory.GetFiles(sourceFolder, "*.*", SearchOption.AllDirectories);
        //    string[] folderPaths = Directory.GetDirectories(sourceFolder, "*.*", SearchOption.AllDirectories);

        //    // 現在時刻からフォルダを作成する
        //    string targetFolder1 = targetFolder + "\\" + DateTime.Now.ToString("yyyy-MMdd-HHmmss");

        //    // フォルダを作成する
        //    if (!Directory.Exists(targetFolder1))
        //        Directory.CreateDirectory(targetFolder1);

        //    // 先にフォルダをバックアップする（フォルダがないとファイルをコピーできない）
        //    foreach (string path in folderPaths)
        //    {
        //        string destfolderPath = path.Replace(sourceFolder, targetFolder1);
        //        Directory.CreateDirectory(destfolderPath);
        //    }

        //    // そのあとファイルをバックアップする
        //    foreach (string path in filePaths)
        //    {
        //        string destFilePath = path.Replace(sourceFolder, targetFolder1);
        //        File.Copy(path, destFilePath);
        //    }
        //}

        //string GetSourceFolderPath()
        //{
        //    var indexes = listView1.SelectedIndices;
        //    if (indexes.Count == 1)
        //        return listView1.Items[indexes[0]].SubItems[0].Text;
        //    else
        //        return "";
        //}

        //string GetTargetFolderPath()
        //{
        //    var indexes = listView1.SelectedIndices;
        //    if (indexes.Count == 1)
        //        return listView1.Items[indexes[0]].SubItems[1].Text;
        //    else
        //        return "";
        //}

        //private void StartBackupMenuItem_Click(object sender, EventArgs e)
        //{
        //    string sourceFolder = GetSourceFolderPath();
        //    string targetFolder = GetTargetFolderPath();

        //    if (Backup(sourceFolder, targetFolder))
        //        MessageBox.Show("終了");
        //}

        public string GetFolderPathFromTicks(long ticks)
        {
            DateTime dt = new DateTime(ticks);
            return GetTargetFolderPath() + "\\" + dt.ToString("yyyy-MMdd-HHmmss");
        }

        string GetLastLogFilePath(string targetFolder)
        {
            if (!Directory.Exists(GetLogFolderPath(targetFolder)))
                return "";

            string[] filePaths = Directory.GetFiles(GetLogFolderPath(targetFolder), "*.txt", SearchOption.TopDirectoryOnly);
            if (filePaths.Length == 0)
                return "";

            return filePaths.Max();
        }

        string GetLogFolderPath(string targetFolder)
        {
            return targetFolder + "\\log";
        }

        List<FileAndTime> CreateFileAndTimes(string logFilePath)
        {
            List<FileAndTime> fileAndTimes = new List<FileAndTime>();

            StreamReader sr = new StreamReader(logFilePath);
            string str = sr.ReadToEnd();
            sr.Close();

            string[] vs1 = str.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in vs1)
            {
                string[] vs2 = line.Split(new string[] { "::" }, StringSplitOptions.RemoveEmptyEntries);
                if (vs2.Length != 2)
                    continue;

                FileAndTime fileAndTime = new FileAndTime(vs2[0], long.Parse(vs2[1]));
                fileAndTimes.Add(fileAndTime);
            }
            return fileAndTimes;
        }

        //bool DoesNeedBackup(List<FileAndTime> fileAndTimes, string[] folderPaths, string[] filePaths)
        //{
        //    if (fileAndTimes.Count != folderPaths.Length + filePaths.Length)
        //        return true;

        //    bool doesNeed = false;
        //    foreach (string path in filePaths)
        //    {
        //        FileAndTime fileAndTime = fileAndTimes.FirstOrDefault(x => x.FilePath == path);
        //        if (fileAndTime == null)
        //        {
        //            doesNeed = true;
        //            break;
        //        }
        //        else
        //        {
        //            if (File.GetLastWriteTime(path).Ticks > fileAndTime.Tick)
        //            {
        //                doesNeed = true;
        //                break;
        //            }
        //        }
        //    }
        //    foreach (string path in folderPaths)
        //    {
        //        FileAndTime fileAndTime = fileAndTimes.FirstOrDefault(x => x.FilePath == path);
        //        if (fileAndTime == null)
        //        {
        //            doesNeed = true;
        //            break;
        //        }
        //        else
        //        {
        //            if (Directory.GetLastWriteTime(path).Ticks > fileAndTime.Tick)
        //            {
        //                doesNeed = true;
        //                break;
        //            }
        //        }
        //    }
        //    return doesNeed;
        //}

        //bool Backup(string sourceFolder, string targetFolder)
        //{
        //    if (sourceFolder == "" || targetFolder == "")
        //    {
        //        MessageBox.Show("バックアップするフォルダが選択されていません！", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return false;
        //    }
        //    if (!Directory.Exists(sourceFolder) || !Directory.Exists(targetFolder))
        //    {
        //        MessageBox.Show("設定されているフォルダは存在しません！", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return false;
        //    }

        //    string[] filePaths = Directory.GetFiles(sourceFolder, "*.*", SearchOption.AllDirectories);
        //    string[] folderPaths = Directory.GetDirectories(sourceFolder, "*.*", SearchOption.AllDirectories);

        //    List<FileAndTime> fileAndTimes = null;
        //    string lastLogFilePath = GetLastLogFilePath(targetFolder);
        //    if (lastLogFilePath != "")
        //    {
        //        fileAndTimes = CreateFileAndTimes(lastLogFilePath);
        //        if (!DoesNeedBackup(fileAndTimes, folderPaths, filePaths))
        //        {
        //            MessageBox.Show("バックアップをとる必要があるファイルは見つかりませんでした", "報告", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            return false;
        //        }
        //    }
        //    else
        //        fileAndTimes = new List<FileAndTime>();

        //    long nowTicks = DateTime.Now.Ticks;
        //    string targetFolder1 = GetFolderPathFromTicks(nowTicks);

        //    if (!Directory.Exists(targetFolder1))
        //        Directory.CreateDirectory(targetFolder1);

        //    List<string> newFiles = new List<string>();
        //    List<string> newFolders = new List<string>();
        //    List<string> modifiedFiles = new List<string>();
        //    List<string> deletedFiles = new List<string>();

        //    foreach (string path in folderPaths)
        //    {
        //        FileAndTime fileAndTime = fileAndTimes.FirstOrDefault(x => x.FilePath == path);
        //        if (fileAndTime == null || Directory.GetLastWriteTime(path).Ticks != fileAndTime.Tick)
        //        {
        //            // fileAndTime == null なら新しく作成されたフォルダ
        //            // Directory.GetLastWriteTime(path).Ticks != fileAndTime.Tick なら内容が変更されたフォルダ
        //            string destfolderPath = path.Replace(sourceFolder, targetFolder1);
        //            Directory.CreateDirectory(destfolderPath);
        //        }

        //        // fileAndTime != null のときはチェック済みにする
        //        // fileAndTime == null のときはそのパスを新しく作成されたフォルダとしてリストに格納する
        //        if (fileAndTime != null)
        //            fileAndTime.IsChecked = true;
        //        else
        //            newFolders.Add(path);
        //    }

        //    foreach (string path in filePaths)
        //    {
        //        string destFilePath = path.Replace(sourceFolder, targetFolder1);
        //        FileAndTime fileAndTime = fileAndTimes.FirstOrDefault(x => x.FilePath == path);

        //        if (fileAndTime == null)
        //        {
        //            // fileAndTime == null なら新しく作成されたファイル
        //            // 新しく作成されたファイルとして、そのパスをリストに格納する
        //            CopyFile(path, destFilePath);
        //            newFiles.Add(path);
        //        }
        //        else if (File.GetLastWriteTime(path).Ticks != fileAndTime.Tick)
        //        {
        //            // File.GetLastWriteTime(path).Ticks != fileAndTime.Tick なら更新されたファイル
        //            // 更新されたファイルとして、そのパスをリストに格納する
        //            CopyFile(path, destFilePath);
        //            modifiedFiles.Add(path);
        //        }

        //        // fileAndTime != null のときはチェック済みにする
        //        if (fileAndTime != null)
        //            fileAndTime.IsChecked = true;
        //    }

        //    // チェックされていない要素があればそれは削除されたファイルまたはフォルダである
        //    deletedFiles = fileAndTimes.Where(x => !x.IsChecked).Select(x => x.FilePath).ToList();

        //    // ログを保存するためのファイルを保存するフォルダパスを取得する（必要ならそのためのフォルダをつくる）
        //    string logFolderPath = GetLogFolderPath(targetFolder);
        //    if (!Directory.Exists(logFolderPath))
        //        Directory.CreateDirectory(logFolderPath);

        //    // ログを保存する
        //    string logFilePath = GetLogFilePathFromTicks(nowTicks);
        //    SaveLogFile(logFilePath, folderPaths, filePaths, targetFolder);

        //    // 差分を保存するためのファイルを保存するフォルダパスを取得する（必要ならそのためのフォルダをつくる）
        //    string differenceFolderPath = GetDifferenceFolderPath();
        //    if (!Directory.Exists(differenceFolderPath))
        //        Directory.CreateDirectory(differenceFolderPath);

        //    // 差分をファイルとして保存する
        //    string differenceFilePath = GetDifferenceFilePathFromTicks(nowTicks);
        //    SaveDifferenceFile(differenceFilePath, newFiles, newFolders, modifiedFiles, deletedFiles);

        //    return true;
        //}

        void CopyFile(string sourceFilePath, string destFilePath)
        {
            // ファイルをコピーしたいフォルダが存在しない場合はつくる
            FileInfo info = new FileInfo(destFilePath);
            if (!Directory.Exists(info.DirectoryName))
                Directory.CreateDirectory(info.DirectoryName);

            File.Copy(sourceFilePath, destFilePath);
        }

        public string GetLogFilePathFromTicks(long ticks)
        {
            DateTime dt = new DateTime(ticks);
            return GetTargetFolderPath() + "\\log\\" + dt.ToString("yyyy-MMdd-HHmmss") + ".txt";
        }

        public string GetDifferenceFilePathFromTicks(long ticks)
        {
            DateTime dt = new DateTime(ticks);
            return GetTargetFolderPath() + "\\difference\\" + dt.ToString("yyyy-MMdd-HHmmss") + ".txt";
        }

        string GetDifferenceFolderPath()
        {
            return GetTargetFolderPath() + "\\difference";
        }

        void SaveLogFile(string logFilePath, string[] folderPaths, string[] filePaths, string targetFolderPath)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string path in folderPaths)
            {
                DateTime dt = Directory.GetLastWriteTime(path);
                string time = dt.Ticks.ToString();

                // ファイル名やフォルダ名として使えない文字でパスと更新時刻を区切る
                string str = String.Format("{0}::{1}\n", path, time);
                sb.Append(str);
            }
            foreach (string path in filePaths)
            {
                DateTime dt = File.GetLastWriteTime(path);
                string time = dt.Ticks.ToString();
                string str = String.Format("{0}::{1}\n", path, time);
                sb.Append(str);
            }

            using (StreamWriter sw = new StreamWriter(logFilePath))
            {
                sw.Write(sb.ToString());
            }
        }

        void SaveDifferenceFile(string differenceFilePath, List<string> newFiles, List<string> newFolders, List<string> modifiedFiles, List<string> deletedFiles)
        {
            StringBuilder sb = new StringBuilder();

            sb.Clear();
            sb.Append("新しく生成されたフォルダ\n\n");
            foreach (string path in newFolders)
                sb.Append(path + "\n");
            sb.Append("\n新しく生成されたファイル\n\n");
            foreach (string path in newFiles)
                sb.Append(path + "\n");
            sb.Append("\n更新されたファイル\n\n");
            foreach (string path in modifiedFiles)
                sb.Append(path + "\n");
            sb.Append("\n削除されたフォルダとファイル\n\n");
            foreach (string path in deletedFiles)
                sb.Append(path + "\n");

            using (StreamWriter sw = new StreamWriter(differenceFilePath))
            {
                sw.Write(sb.ToString());
            }
        }

        List<long> GetRestoreTicksList(string targetFolder)
        {
            string[] filePaths = Directory.GetFiles(GetLogFolderPath(targetFolder), "*.txt", SearchOption.TopDirectoryOnly);
            List<long> ticksList = new List<long>();
            foreach (string path in filePaths)
            {
                ticksList.Add(GetTicksFromLogFilePath(path));
            }
            return ticksList.OrderByDescending(x => x).ToList();
        }

        long GetTicksFromLogFilePath(string filePath)
        {
            FileInfo info = new FileInfo(filePath);
            string name = info.Name;
            string year = name.Substring(0, 4);
            string month = name.Substring(5, 2);
            string day = name.Substring(7, 2);
            string hour = name.Substring(10, 2);
            string minute = name.Substring(12, 2);
            string second = name.Substring(14, 2);

            DateTime dt = new DateTime(int.Parse(year), int.Parse(month), int.Parse(day), int.Parse(hour), int.Parse(minute), int.Parse(second));
            return dt.Ticks;
        }

        List<string> GetBackupFolderPaths(long time, List<long> ticksList)
        {
            List<long> vs = ticksList.Where(x => x <= time).ToList();
            vs = vs.OrderByDescending(x => x).ToList();

            List<string> backupFolderPaths = new List<string>();
            string logPath = GetLogFilePathFromTicks(time);
            foreach (long ticks in vs)
            {
                backupFolderPaths.Add(GetFolderPathFromTicks(ticks));
            }
            return backupFolderPaths;
        }

        //void RestoreFiles(string folderPath, string logFilePath, List<string> backupFolderPaths, string sourceFolderPath)
        //{
        //    StreamReader sr = new StreamReader(logFilePath);
        //    string str = sr.ReadToEnd();
        //    string[] vs1 = str.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
        //    foreach (string path in vs1)
        //    {
        //        string[] vs2 = path.Split(new string[] { "::" }, StringSplitOptions.RemoveEmptyEntries);
        //        if (vs2.Length != 2)
        //        {
        //            MessageBox.Show("ログファイルが破損しています！", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return;
        //        }

        //        string filePath = vs2[0].Replace(sourceFolderPath, folderPath);

        //        bool isFind = false;
        //        foreach (string backupFolderPath in backupFolderPaths)
        //        {
        //            string backupFilePath1 = vs2[0].Replace(sourceFolderPath, backupFolderPath);
        //            if (File.Exists(backupFilePath1))
        //            {
        //                File.Copy(backupFilePath1, filePath);
        //                isFind = true;
        //                break;
        //            }
        //            if (Directory.Exists(backupFilePath1))
        //            {
        //                string newFolderPath = vs2[0].Replace(sourceFolderPath, folderPath);
        //                Directory.CreateDirectory(newFolderPath);

        //                isFind = true;
        //                break;
        //            }
        //        }
        //        if (!isFind)
        //            MessageBox.Show("エラー　ファイルがみつからない", vs2[0], MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    MessageBox.Show("復元完了");
        //}

        //private void RestoreFilesMenuItem_Click(object sender, EventArgs e)
        //{
        //    string targetFolder = GetTargetFolderPath();
        //    if (targetFolder == "")
        //    {
        //        MessageBox.Show("項目が選択されていません！", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }

        //    if (!Directory.Exists(GetLogFolderPath(targetFolder)))
        //    {
        //        MessageBox.Show("バックアップは存在しません", "報告", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        return;
        //    }

        //    List<long> ticksList = GetRestoreTicksList(targetFolder);

        //    FormRestore form = new FormRestore();
        //    form.TicksList = ticksList;
        //    form.ShowDialog(this);

        //    if (form.RestoreTime > 0)
        //    {
        //        string folderPath = form.SelectedPath;

        //        long time = form.RestoreTime;
        //        List<long> vs = form.TicksList;

        //        List<string> backupFolderPaths = GetBackupFolderPaths(time, vs);
        //        string logPath = GetLogFilePathFromTicks(time);

        //        RestoreFiles(folderPath, logPath, backupFolderPaths, GetSourceFolderPath());
        //    }
        //    form.Dispose();
        //}

        private void StartBackupMenuItem_Click(object sender, EventArgs e)
        {
            StartBackup();
        }

        void StartBackup()
        {
            var task = Task.Run(() =>
            {
                EnableMenu(false);

                string sourceFolder = GetSourceFolderPath();
                string targetFolder = GetTargetFolderPath();
                if (Backup(sourceFolder, targetFolder))
                    MessageBox.Show("終了");

                EnableMenu(true);
            });
        }

        bool CanEnd = true;

        void EnableMenu(bool isEnable)
        {
            Invoke((Action)(() => {
                ConfigMenuItem.Enabled = isEnable;
                StartBackupMenuItem.Enabled = isEnable;
                RestoreFilesMenuItem.Enabled = isEnable;
                listView1.Enabled = isEnable;
                CanEnd = isEnable;
            }));
        }

        //string GetSourceFolderPath()
        //{
        //    string ret = "";
        //    Invoke((Action)(() => {
        //        var indexes = listView1.SelectedIndices;
        //        if (indexes.Count == 1)
        //            ret = listView1.Items[indexes[0]].SubItems[0].Text;
        //    }));
        //    return ret;
        //}


        //string GetTargetFolderPath()
        //{
        //    string ret = "";
        //    Invoke((Action)(() => {
        //        var indexes = listView1.SelectedIndices;
        //        if (indexes.Count == 1)
        //            ret = listView1.Items[indexes[0]].SubItems[1].Text;
        //    }));
        //    return ret;
        //}

        protected override void OnClosing(CancelEventArgs e)
        {
            if (!CanEnd)
            {
                e.Cancel = true;
                MessageBox.Show("処理中なので終了できません！", "報告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            base.OnClosing(e);
        }

        //bool Backup(string sourceFolder, string targetFolder)
        //{
        //    // 引数が適切かチェック
        //    if (!CheckFolderPaths(sourceFolder, targetFolder))
        //    {
        //        return false;
        //    }

        //    // プログレスバーのついたフォームを表示
        //    FormBackupProgress formBackupProgress = new FormBackupProgress();
        //    formBackupProgress.Show();

        //    // バックアップの候補になるファイルとフォルダのパスの取得
        //    formBackupProgress.GetProgressBarGetSourceFiles().Maximum = 2;
        //    string[] filePaths = GetSourceFilePaths(sourceFolder, formBackupProgress);
        //    if (filePaths == null)
        //    {
        //        Invoke((Action)(() => {
        //            formBackupProgress.IsEnd = true;
        //            formBackupProgress.Dispose();
        //        }));
        //        return false;
        //    }
        //    else
        //    {
        //        Invoke((Action)(() => {
        //            ProgressBar progressBar = formBackupProgress.GetProgressBarGetSourceFiles();
        //            Invoke((Action)(() => {
        //                progressBar.Value = 1;
        //            }));
        //        }));
        //    }

        //    string[] folderPaths = GetSourceFolderPaths(sourceFolder, formBackupProgress);
        //    if (folderPaths == null)
        //    {
        //        Invoke((Action)(() => {
        //            formBackupProgress.IsEnd = true;
        //            formBackupProgress.Dispose();
        //        }));
        //        return false;
        //    }
        //    else
        //    {
        //        Invoke((Action)(() => {
        //            ProgressBar progressBar = formBackupProgress.GetProgressBarGetSourceFiles();
        //            Invoke((Action)(() => {
        //                progressBar.Value = 2;
        //            }));
        //        }));
        //    }

        //    // 以前にバックアップの処理はされているか。ログがあるはずなので取得して解析する
        //    // ログがない場合は初めてのバックアップなのですべてバックアップする
        //    List<FileAndTime> fileAndTimes = null;
        //    string lastLogFilePath = GetLastLogFilePath(targetFolder);
        //    if (lastLogFilePath != "")
        //    {
        //        fileAndTimes = CreateFileAndTimes(lastLogFilePath);
        //        if (StopBackupIfCancel(formBackupProgress))
        //        {
        //            Invoke((Action)(() => {
        //                formBackupProgress.IsEnd = true;
        //                formBackupProgress.Dispose();
        //            }));
        //            return false;
        //        }

        //        // DoesNeedBackupメソッドの処理は
        //        // バックアップ元フォルダにたくさんのファイルがあると時間がかかるかもしれない
        //        if (!DoesNeedBackup(fileAndTimes, folderPaths, filePaths, formBackupProgress))
        //        {
        //            Invoke((Action)(() => {
        //                formBackupProgress.IsEnd = true;
        //                formBackupProgress.Dispose();
        //            }));

        //            MessageBox.Show("バックアップをとる必要があるファイルは見つかりませんでした", "報告", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            return false;
        //        }
        //    }
        //    else
        //    {
        //        fileAndTimes = new List<FileAndTime>();
        //    }

        //    Invoke((Action)(() => {
        //        ProgressBar progressBar = formBackupProgress.GetProgressBarGetBackupFiles();
        //        Invoke((Action)(() => {
        //            progressBar.Value = 0;
        //            progressBar.Maximum = 1;
        //            progressBar.Value = 1;
        //        }));
        //    }));

        //    long nowTicks = DateTime.Now.Ticks;
        //    string targetFolder1 = GetFolderPathFromTicks(nowTicks);

        //    if (!Directory.Exists(targetFolder1))
        //        Directory.CreateDirectory(targetFolder1);

        //    List<string> newFiles = new List<string>();
        //    List<string> newFolders = new List<string>();
        //    List<string> modifiedFiles = new List<string>();
        //    List<string> deletedFiles = new List<string>();

        //    // 必要であればフォルダをバックアップする
        //    if (!BackupFolderIfNeed(sourceFolder, targetFolder1, folderPaths, fileAndTimes, newFolders, formBackupProgress))
        //    {
        //        Invoke((Action)(() => {
        //            formBackupProgress.IsEnd = true;
        //            formBackupProgress.Dispose();
        //        }));
        //        return false;
        //    }

        //    // 必要であればファイルをバックアップする
        //    if (!BackupFilesIfNeed(sourceFolder, targetFolder1, filePaths, fileAndTimes, newFiles, modifiedFiles, formBackupProgress))
        //    {
        //        Invoke((Action)(() => {
        //            formBackupProgress.IsEnd = true;
        //            formBackupProgress.Dispose();
        //        }));
        //        return false;
        //    }

        //    // deletedFilesには前回のバックアップでは存在したがいまは存在しない（削除された）ファイルのパスが格納される
        //    deletedFiles = fileAndTimes.Where(x => !x.IsChecked).Select(x => x.FilePath).ToList();

        //    // ログを保存する
        //    if (!SaveLogFile(targetFolder, folderPaths, filePaths, nowTicks, formBackupProgress))
        //    {
        //        Invoke((Action)(() => {
        //            formBackupProgress.IsEnd = true;
        //            formBackupProgress.Dispose();
        //        }));
        //        return false;
        //    }

        //    // 差分をファイルとして保存する
        //    SaveDifferenceFile(targetFolder, newFiles, newFolders, modifiedFiles, deletedFiles, nowTicks, formBackupProgress);

        //    Invoke((Action)(() => {
        //        formBackupProgress.IsEnd = true;
        //        formBackupProgress.Dispose();
        //    }));
        //    return true;
        //}

        bool CheckFolderPaths(string sourceFolder, string targetFolder)
        {
            if (sourceFolder == "" || targetFolder == "")
            {
                MessageBox.Show("バックアップするフォルダが選択されていません！", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!Directory.Exists(sourceFolder) || !Directory.Exists(targetFolder))
            {
                MessageBox.Show("設定されているフォルダは存在しません！", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        //string[] GetSourceFilePaths(string sourceFolder, FormBackupProgress formBackupProgress)
        //{
        //    string[] filePaths = Directory.GetFiles(sourceFolder, "*.*", SearchOption.AllDirectories);
        //    if (StopBackupIfCancel(formBackupProgress))
        //        return null;
        //    else
        //        return filePaths;
        //}

        //string[] GetSourceFolderPaths(string sourceFolder, FormBackupProgress formBackupProgress)
        //{
        //    string[] folderPaths = Directory.GetDirectories(sourceFolder, "*.*", SearchOption.AllDirectories);

        //    if (StopBackupIfCancel(formBackupProgress))
        //        return null;
        //    else
        //        return folderPaths;
        //}

        bool DoesNeedBackup(List<FileAndTime> fileAndTimes, string[] folderPaths, string[] filePaths, FormBackupProgress formBackupProgress)
        {
            if (fileAndTimes.Count != folderPaths.Length + filePaths.Length)
                return true;

            bool doesNeed = false;
            Invoke((Action)(() => {
                ProgressBar progressBar = formBackupProgress.GetProgressBarGetBackupFiles();
                Invoke((Action)(() => {
                    progressBar.Maximum = filePaths.Length + folderPaths.Length;
                }));
            }));

            foreach (string path in filePaths)
            {
                if (StopBackupIfCancel(formBackupProgress))
                    return false;

                FileAndTime fileAndTime = fileAndTimes.FirstOrDefault(x => x.FilePath == path);
                if (fileAndTime == null)
                    return true;
                else
                {
                    if (File.GetLastWriteTime(path).Ticks > fileAndTime.Tick)
                        return true;

                    Invoke((Action)(() => {
                        ProgressBar progressBar = formBackupProgress.GetProgressBarGetBackupFiles();
                        Invoke((Action)(() => {
                            progressBar.Value++;
                        }));
                    }));
                }
            }
            foreach (string path in folderPaths)
            {
                if (StopBackupIfCancel(formBackupProgress))
                    return false;

                FileAndTime fileAndTime = fileAndTimes.FirstOrDefault(x => x.FilePath == path);
                if (fileAndTime == null)
                    return true;
                else
                {
                    if (Directory.GetLastWriteTime(path).Ticks > fileAndTime.Tick)
                        return true;

                    Invoke((Action)(() => {
                        ProgressBar progressBar = formBackupProgress.GetProgressBarGetBackupFiles();
                        Invoke((Action)(() => {
                            progressBar.Value++;
                        }));
                    }));
                }
            }
            return doesNeed;
        }

        bool BackupFolderIfNeed(string sourceFolder, string targetFolder1, string[] folderPaths, List<FileAndTime> fileAndTimes, List<string> newFolders, FormBackupProgress formBackupProgress)
        {
            Invoke((Action)(() => {
                ProgressBar progressBar = formBackupProgress.GetProgressBarBackupFolders();
                Invoke((Action)(() => {
                    progressBar.Maximum = folderPaths.Length;
                }));
            }));

            foreach (string path in folderPaths)
            {
                if (StopBackupIfCancel(formBackupProgress))
                    return false;

                FileAndTime fileAndTime = fileAndTimes.FirstOrDefault(x => x.FilePath == path);
                if (fileAndTime == null || Directory.GetLastWriteTime(path).Ticks != fileAndTime.Tick)
                {
                    string destfolderPath = path.Replace(sourceFolder, targetFolder1);
                    Directory.CreateDirectory(destfolderPath);
                }
                if (fileAndTime != null)
                    fileAndTime.IsChecked = true;
                else
                    newFolders.Add(path);

                Invoke((Action)(() => {
                    ProgressBar progressBar = formBackupProgress.GetProgressBarBackupFolders();
                    Invoke((Action)(() => {
                        progressBar.Value++;
                    }));
                }));
            }
            return true;
        }

        bool BackupFilesIfNeed(string sourceFolder, string targetFolder1, string[] filePaths, List<FileAndTime> fileAndTimes, List<string> newFiles, List<string> modifiedFiles, FormBackupProgress formBackupProgress)
        {
            Invoke((Action)(() => {
                ProgressBar progressBar = formBackupProgress.GetProgressBarBackupFiles();
                Invoke((Action)(() => {
                    progressBar.Maximum = filePaths.Length;
                }));
            }));

            foreach (string path in filePaths)
            {
                if (StopBackupIfCancel(formBackupProgress))
                    return false;

                string destFilePath = path.Replace(sourceFolder, targetFolder1);
                FileAndTime fileAndTime = fileAndTimes.FirstOrDefault(x => x.FilePath == path);

                if (fileAndTime == null)
                {
                    CopyFile(path, destFilePath);
                    newFiles.Add(path);
                }
                else if (File.GetLastWriteTime(path).Ticks != fileAndTime.Tick)
                {
                    CopyFile(path, destFilePath);
                    modifiedFiles.Add(path);
                }
                if (fileAndTime != null)
                    fileAndTime.IsChecked = true;

                Invoke((Action)(() => {
                    ProgressBar progressBar = formBackupProgress.GetProgressBarBackupFiles();
                    Invoke((Action)(() => {
                        progressBar.Value++;
                    }));
                }));
            }
            return true;
        }

        bool SaveLogFile(string targetFolder, string[] folderPaths, string[] filePaths, long nowTicks, FormBackupProgress formBackupProgress)
        {
            string logFolderPath = GetLogFolderPath(targetFolder);
            if (!Directory.Exists(logFolderPath))
                Directory.CreateDirectory(logFolderPath);

            string logFilePath = GetLogFilePathFromTicks(nowTicks);
            SaveLogFile(logFilePath, folderPaths, filePaths, formBackupProgress);
            if (StopBackupIfCancel(formBackupProgress))
                return false;

            return true;
        }

        void SaveLogFile(string logFilePath, string[] folderPaths, string[] filePaths, FormBackupProgress formBackupProgress)
        {
            Invoke((Action)(() => {
                ProgressBar progressBar = formBackupProgress.GetProgressBarLogFile();
                Invoke((Action)(() => {
                    progressBar.Maximum = folderPaths.Length + filePaths.Length;
                }));
            }));

            StringBuilder sb = new StringBuilder();
            foreach (string path in folderPaths)
            {
                if (formBackupProgress.BackupCancel)
                    return;

                DateTime dt = Directory.GetLastWriteTime(path);
                string time = dt.Ticks.ToString();

                // ファイル名やフォルダ名として使えない文字でパスと更新時刻を区切る
                string str = String.Format("{0}::{1}\n", path, time);
                sb.Append(str);

                Invoke((Action)(() => {
                    ProgressBar progressBar = formBackupProgress.GetProgressBarLogFile();
                    Invoke((Action)(() => {
                        progressBar.Value++;
                    }));
                }));

            }
            foreach (string path in filePaths)
            {
                if (formBackupProgress.BackupCancel)
                    return;

                DateTime dt = File.GetLastWriteTime(path);
                string time = dt.Ticks.ToString();
                string str = String.Format("{0}::{1}\n", path, time);
                sb.Append(str);

                Invoke((Action)(() => {
                    ProgressBar progressBar = formBackupProgress.GetProgressBarLogFile();
                    Invoke((Action)(() => {
                        progressBar.Value++;
                    }));
                }));
            }

            using (StreamWriter sw = new StreamWriter(logFilePath))
            {
                sw.Write(sb.ToString());
            }
        }

        bool SaveDifferenceFile(string targetFolder, List<string> newFiles, List<string> newFolders, List<string> modifiedFiles, List<string> deletedFiles, long nowTicks, FormBackupProgress formBackupProgress)
        {
            string differenceFolderPath = GetDifferenceFolderPath();
            if (!Directory.Exists(differenceFolderPath))
                Directory.CreateDirectory(differenceFolderPath);

            string differenceFilePath = GetDifferenceFilePathFromTicks(nowTicks);
            SaveDifferenceFile(differenceFilePath, newFiles, newFolders, modifiedFiles, deletedFiles, formBackupProgress);
            return true;
        }

        void SaveDifferenceFile(string differenceFilePath, List<string> newFiles, List<string> newFolders, List<string> modifiedFiles, List<string> deletedFiles, FormBackupProgress formBackupProgress)
        {
            Invoke((Action)(() => {
                ProgressBar progressBar = formBackupProgress.GetProgressBarDifferenceFile();
                Invoke((Action)(() => {
                    progressBar.Maximum = newFiles.Count + newFolders.Count + modifiedFiles.Count + deletedFiles.Count;
                }));
            }));

            StringBuilder sb = new StringBuilder();
            sb.Append("新しく生成されたフォルダ\n\n");
            foreach (string path in newFolders)
            {
                sb.Append(path + "\n");
                Invoke((Action)(() => {
                    ProgressBar progressBar = formBackupProgress.GetProgressBarDifferenceFile();
                    Invoke((Action)(() => {
                        progressBar.Value++;
                    }));
                }));
            }
            sb.Append("\n新しく生成されたファイル\n\n");
            foreach (string path in newFiles)
            {
                sb.Append(path + "\n");
                Invoke((Action)(() => {
                    ProgressBar progressBar = formBackupProgress.GetProgressBarDifferenceFile();
                    Invoke((Action)(() => {
                        progressBar.Value++;
                    }));
                }));
            }
            sb.Append("\n更新されたファイル\n\n");
            foreach (string path in modifiedFiles)
            {
                sb.Append(path + "\n");
                Invoke((Action)(() => {
                    ProgressBar progressBar = formBackupProgress.GetProgressBarDifferenceFile();
                    Invoke((Action)(() => {
                        progressBar.Value++;
                    }));
                }));
            }
            sb.Append("\n削除されたフォルダとファイル\n\n");
            foreach (string path in deletedFiles)
            {
                sb.Append(path + "\n");
                Invoke((Action)(() => {
                    ProgressBar progressBar = formBackupProgress.GetProgressBarDifferenceFile();
                    Invoke((Action)(() => {
                        progressBar.Value++;
                    }));
                }));
            }

            using (StreamWriter sw = new StreamWriter(differenceFilePath))
            {
                sw.Write(sb.ToString());
            }
        }

        bool StopBackupIfCancel(FormBackupProgress formBackupProgress)
        {
            return formBackupProgress.BackupCancel;
        }

        void RestoreFiles(string folderPath, string logFilePath, List<string> backupFolderPaths, string sourceFolderPath)
        {
            FormRestoreProgress formRestoreProgress = new FormRestoreProgress();
            formRestoreProgress.Show();

            StreamReader sr = new StreamReader(logFilePath);
            string str = sr.ReadToEnd();
            string[] vs1 = str.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            Invoke((Action)(() => {
                Invoke((Action)(() => {
                    formRestoreProgress.GetProgressBar().Value = 0;
                    formRestoreProgress.GetProgressBar().Maximum = vs1.Length;
                }));
            }));

            foreach (string path in vs1)
            {
                if (formRestoreProgress.RestoreCancel)
                {
                    System.Threading.Thread.Sleep(1000);
                    Invoke((Action)(() => {
                        formRestoreProgress.RestoreCancel = true;
                        formRestoreProgress.Dispose();
                    }));
                    MessageBox.Show("復元処理は中断されました", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Invoke((Action)(() => {
                    Invoke((Action)(() => {
                        formRestoreProgress.GetProgressBar().Value++;
                    }));
                }));

                string[] vs2 = path.Split(new string[] { "::" }, StringSplitOptions.RemoveEmptyEntries);
                if (vs2.Length != 2)
                {
                    MessageBox.Show("ログファイルが破損しています！", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Invoke((Action)(() => {
                        formRestoreProgress.RestoreCancel = true;
                        formRestoreProgress.Dispose();
                    }));
                    return;
                }

                string filePath = vs2[0].Replace(sourceFolderPath, folderPath);

                bool isFind = false;
                foreach (string backupFolderPath in backupFolderPaths)
                {
                    string backupFilePath1 = vs2[0].Replace(sourceFolderPath, backupFolderPath);
                    if (File.Exists(backupFilePath1))
                    {
                        File.Copy(backupFilePath1, filePath);
                        isFind = true;
                        break;
                    }
                    if (Directory.Exists(backupFilePath1))
                    {
                        string newFolderPath = vs2[0].Replace(sourceFolderPath, folderPath);
                        Directory.CreateDirectory(newFolderPath);

                        isFind = true;
                        break;
                    }
                }
                if (!isFind)
                    MessageBox.Show("エラー　ファイルがみつからない", vs2[0], MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            System.Threading.Thread.Sleep(1000);
            Invoke((Action)(() => {
                formRestoreProgress.RestoreCancel = true;
                formRestoreProgress.Dispose();
            }));

            MessageBox.Show("復元完了", "報告", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void InitListView()
        {
            listView1.View = View.Details;
            listView1.Columns.Add("バックアップ元");
            listView1.Columns.Add("バックアップ先");
            listView1.Columns.Add("除外する拡張子");
            listView1.Columns.Add("メモ");
            listView1.Columns[0].Width = 200;
            listView1.Columns[1].Width = 200;
            listView1.Columns[2].Width = 100;
            listView1.FullRowSelect = true;
            listView1.MultiSelect = false;
            listView1.HideSelection = false;
        }

        void LoadConfig()
        {
            string path = Application.UserAppDataPath + "\\config.xml";
            if (!File.Exists(path))
                return;

            XmlSerializer xml = new XmlSerializer(typeof(Config));
            StreamReader sr = new StreamReader(path);
            Config config = (Config)xml.Deserialize(sr);
            sr.Close();

            BackupFolderInfos = config.BackupFolderInfos;

            foreach (BackupFolderInfo info in BackupFolderInfos)
            {
                string extensions;
                if (info.Extensions != null)
                    extensions = String.Join(", ", info.Extensions);
                else
                    extensions = "";
                string[] item = { info.SourceFolderPath, info.TargetFolderPath, extensions, info.Memo };
                listView1.Items.Add(new ListViewItem(item));
            }
        }

        private void RegistFolderMenuItem_Click(object sender, EventArgs e)
        {
            FormFolder form = new FormFolder();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (Directory.Exists(form.SourceFolderPath) && Directory.Exists(form.TargetFolderPath))
                {
                    string[] filePaths = Directory.GetDirectories(form.SourceFolderPath, "*.*", SearchOption.AllDirectories);

                    if (form.SourceFolderPath != form.TargetFolderPath && !filePaths.Any(x => x == form.TargetFolderPath))
                    {
                        string str = String.Join(", ", form.Extensions);
                        string[] item = { form.SourceFolderPath, form.TargetFolderPath, str, form.Memo };
                        listView1.Items.Add(new ListViewItem(item));
                        BackupFolderInfos.Add(new BackupFolderInfo(form.SourceFolderPath, form.TargetFolderPath, form.Extensions, form.Memo));

                        SaveConfig();
                    }
                    else
                    {
                        MessageBox.Show("バックアップ元フォルダのなかにバックアップ先のフォルダを指定することはできません！", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("存在するフォルダでないと登録できません！", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            form.Dispose();
        }

        private void ChangeFolderMenuItem_Click(object sender, EventArgs e)
        {
            var selectedItems = listView1.SelectedItems;
            if (selectedItems.Count == 0)
            {
                MessageBox.Show("編集する項目を選択してください！", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ListViewItem selectedItem = selectedItems[0];

            FormFolder form = new FormFolder();

            int index = listView1.Items.IndexOf(selectedItem);
            form.SourceFolderPath = BackupFolderInfos[index].SourceFolderPath;
            form.TargetFolderPath = BackupFolderInfos[index].TargetFolderPath;
            form.Extensions = BackupFolderInfos[index].Extensions;
            form.Memo = BackupFolderInfos[index].Memo;

            if (form.ShowDialog() == DialogResult.OK)
            {
                if (Directory.Exists(form.SourceFolderPath) && Directory.Exists(form.TargetFolderPath))
                {
                    string[] filePaths = Directory.GetDirectories(form.SourceFolderPath, "*.*", SearchOption.AllDirectories);
                    if (form.SourceFolderPath != form.TargetFolderPath && !filePaths.Any(x => x == form.TargetFolderPath))
                    {
                        string[] itemText = { form.SourceFolderPath, form.TargetFolderPath, String.Join(",", form.Extensions), form.Memo };
                        ListViewItem item = new ListViewItem(itemText);

                        listView1.Items.RemoveAt(index);
                        listView1.Items.Insert(index, item);
                        BackupFolderInfos[index].SourceFolderPath = form.SourceFolderPath;
                        BackupFolderInfos[index].TargetFolderPath = form.TargetFolderPath;
                        BackupFolderInfos[index].Extensions = form.Extensions;
                        BackupFolderInfos[index].Memo = form.Memo;

                        SaveConfig();
                    }
                    else
                    {
                        MessageBox.Show("バックアップ元フォルダのなかにバックアップ先のフォルダを指定することはできません！", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("存在するフォルダでないと登録できません！", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            form.Dispose();
        }

        int GetSelectedItemIndex()
        {
            int ret = -1;
            Invoke((Action)(() => {
                var indexes = listView1.SelectedIndices;
                if (indexes.Count == 1)
                    ret = indexes[0];
            }));
            return ret;
        }

        string GetSourceFolderPath()
        {
            int index = GetSelectedItemIndex();
            if (index != -1)
                return BackupFolderInfos[index].SourceFolderPath;
            else
                return "";
        }

        string GetTargetFolderPath()
        {
            int index = GetSelectedItemIndex();
            if (index != -1)
                return BackupFolderInfos[index].TargetFolderPath;
            else
                return "";
        }

        string[] GetExtensions()
        {
            int index = GetSelectedItemIndex();
            if (index != -1)
                return BackupFolderInfos[index].Extensions;
            else
                return new string[] { "" };
        }

        public void GetSourceFilePaths(string folder, string searchPattern, List<string> filePaths, List<string> AccessDeniedFolder, string[] extensions, FormBackupProgress formBackupProgress)
        {
            if (StopBackupIfCancel(formBackupProgress))
                return;

            string[] fs = Directory.GetFiles(folder, searchPattern, SearchOption.TopDirectoryOnly);
            fs = fs.Where(x => {
                FileInfo info = new FileInfo(x);
                return extensions == null || !extensions.Any(x1 => "." + x1 == info.Extension && ("." + x1).Length == info.Extension.Length);
            }).ToArray();

            filePaths.AddRange(fs);

            string[] subFolders = Directory.GetDirectories(folder);
            foreach (string path in subFolders)
            {
                try
                {
                    GetSourceFilePaths(path, searchPattern, filePaths, AccessDeniedFolder, extensions, formBackupProgress);
                }
                catch (Exception ex)
                {
                    // アクセスを拒否された場合
                    AccessDeniedFolder.Add(path);
                }
            }
        }

        public void GetSourceFolderPaths(string folder, string searchPattern, List<string> filePaths, List<string> AccessDeniedFolder, FormBackupProgress formBackupProgress)
        {
            if (StopBackupIfCancel(formBackupProgress))
                return;

            string[] fs = Directory.GetDirectories(folder, searchPattern, SearchOption.TopDirectoryOnly);
            filePaths.AddRange(fs);

            foreach (string path in fs)
            {
                try
                {
                    GetSourceFolderPaths(path, searchPattern, filePaths, AccessDeniedFolder, formBackupProgress);
                }
                catch (Exception ex)
                {
                    // アクセスを拒否された場合
                    AccessDeniedFolder.Add(path);
                }
            }
        }

        bool Backup(string sourceFolder, string targetFolder)
        {
            if (!CheckFolderPaths(sourceFolder, targetFolder))
                return false;

            FormBackupProgress formBackupProgress = new FormBackupProgress();
            formBackupProgress.Show();

            List<string> sourceFilePaths = new List<string>();
            List<string> AccessDeniedFolder = new List<string>();

            formBackupProgress.GetProgressBarGetSourceFiles().Maximum = 2;
            GetSourceFilePaths(sourceFolder, "*", sourceFilePaths, AccessDeniedFolder, GetExtensions(), formBackupProgress);
            if (StopBackupIfCancel(formBackupProgress))
            {
                Invoke((Action)(() => {
                    formBackupProgress.IsEnd = true;
                    formBackupProgress.Dispose();
                }));
                return false;
            }

            if (sourceFilePaths.Count == 0)
            {
                Invoke((Action)(() => {
                    formBackupProgress.IsEnd = true;
                    formBackupProgress.Dispose();
                }));
                return false;
            }
            else
            {
                Invoke((Action)(() => {
                    formBackupProgress.GetProgressBarGetSourceFiles().Value = 1;
                }));
            }

            List<string> sourceFolderPaths = new List<string>();
            GetSourceFolderPaths(sourceFolder, "*", sourceFolderPaths, AccessDeniedFolder, formBackupProgress);
            if (StopBackupIfCancel(formBackupProgress))
            {
                Invoke((Action)(() => {
                    formBackupProgress.IsEnd = true;
                    formBackupProgress.Dispose();
                }));
                return false;
            }
            else
            {
                Invoke((Action)(() => {
                    formBackupProgress.GetProgressBarGetSourceFiles().Value = 2;
                }));
            }

            string[] folderPaths = sourceFolderPaths.ToArray();
            string[] filePaths = sourceFilePaths.ToArray();

            // ここから下は前回と同じ

            // 以前にバックアップの処理はされているか。ログがあるはずなので取得して解析する
            // ログがない場合は初めてのバックアップなのですべてバックアップする
            List<FileAndTime> fileAndTimes = null;
            string lastLogFilePath = GetLastLogFilePath(targetFolder);
            if (lastLogFilePath != "")
            {
                fileAndTimes = CreateFileAndTimes(lastLogFilePath);
                if (StopBackupIfCancel(formBackupProgress))
                {
                    Invoke((Action)(() => {
                        formBackupProgress.IsEnd = true;
                        formBackupProgress.Dispose();
                    }));
                    return false;
                }

                // DoesNeedBackupメソッドの処理は
                // バックアップ元フォルダにたくさんのファイルがあると時間がかかるかもしれない
                if (!DoesNeedBackup(fileAndTimes, folderPaths, filePaths, formBackupProgress))
                {
                    Invoke((Action)(() => {
                        formBackupProgress.IsEnd = true;
                        formBackupProgress.Dispose();
                    }));

                    MessageBox.Show("バックアップをとる必要があるファイルは見つかりませんでした", "報告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            else
            {
                fileAndTimes = new List<FileAndTime>();
            }

            Invoke((Action)(() => {
                ProgressBar progressBar = formBackupProgress.GetProgressBarGetBackupFiles();
                Invoke((Action)(() => {
                    progressBar.Value = 0;
                    progressBar.Maximum = 1;
                    progressBar.Value = 1;
                }));
            }));

            long nowTicks = DateTime.Now.Ticks;
            string targetFolder1 = GetFolderPathFromTicks(nowTicks);

            if (!Directory.Exists(targetFolder1))
                Directory.CreateDirectory(targetFolder1);

            List<string> newFiles = new List<string>();
            List<string> newFolders = new List<string>();
            List<string> modifiedFiles = new List<string>();
            List<string> deletedFiles = new List<string>();

            // 必要であればフォルダをバックアップする
            if (!BackupFolderIfNeed(sourceFolder, targetFolder1, folderPaths, fileAndTimes, newFolders, formBackupProgress))
            {
                Invoke((Action)(() => {
                    formBackupProgress.IsEnd = true;
                    formBackupProgress.Dispose();
                }));
                return false;
            }

            // 必要であればファイルをバックアップする
            if (!BackupFilesIfNeed(sourceFolder, targetFolder1, filePaths, fileAndTimes, newFiles, modifiedFiles, formBackupProgress))
            {
                Invoke((Action)(() => {
                    formBackupProgress.IsEnd = true;
                    formBackupProgress.Dispose();
                }));
                return false;
            }

            // deletedFilesには前回のバックアップでは存在したがいまは存在しない（削除された）ファイルのパスが格納される
            deletedFiles = fileAndTimes.Where(x => !x.IsChecked).Select(x => x.FilePath).ToList();

            // ログを保存する
            if (!SaveLogFile(targetFolder, folderPaths, filePaths, nowTicks, formBackupProgress))
            {
                Invoke((Action)(() => {
                    formBackupProgress.IsEnd = true;
                    formBackupProgress.Dispose();
                }));
                return false;
            }

            // 差分をファイルとして保存する
            SaveDifferenceFile(targetFolder, newFiles, newFolders, modifiedFiles, deletedFiles, nowTicks, formBackupProgress);

            Invoke((Action)(() => {
                formBackupProgress.IsEnd = true;
                formBackupProgress.Dispose();
            }));
            return true;
        }

        private void RestoreFilesMenuItem_Click(object sender, EventArgs e)
        {
            string targetFolder = GetTargetFolderPath();
            if (targetFolder == "")
            {
                MessageBox.Show("項目が選択されていません！", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Directory.Exists(GetLogFolderPath(targetFolder)))
            {
                MessageBox.Show("バックアップは存在しません", "報告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<long> ticksList = GetRestoreTicksList(targetFolder);

            FormRestore form = new FormRestore();
            form.TicksList = ticksList;
            form.ShowDialog(this);

            if (form.RestoreTime > 0)
            {
                string folderPath = form.SelectedPath;

                long time = form.RestoreTime;
                List<long> vs = form.TicksList;

                List<string> backupFolderPaths = GetBackupFolderPaths(time, vs);
                string logPath = GetLogFilePathFromTicks(time);

                if (form.SelectedSourcePartPath == "")
                {
                    Task.Run(() =>
                    {
                        EnableMenu(false);
                        RestoreFiles(folderPath, logPath, backupFolderPaths, GetSourceFolderPath());
                        EnableMenu(true);
                    });
                }
                else
                {
                    Task.Run(() =>
                    {
                        EnableMenu(false);
                        RestorePartFiles(folderPath, logPath, backupFolderPaths, GetSourceFolderPath(), form.SelectedSourcePartPath);
                        EnableMenu(true);
                    });
                }
            }
            form.Dispose();
        }

        /// <summary>
        /// ファイル・フォルダを一部だけ復元する
        /// </summary>
        /// <param name="folderPath">どこへ復元するか</param>
        /// <param name="logFilePath">復元処理のために必要なログファイルの場所</param>
        /// <param name="backupFolderPaths">バックアップに必要なデータが存在するフォルダのパス（複数）</param>
        /// <param name="sourceFolderPath">バックアップ元のフォルダのパス</param>
        /// <param name="sourcePartFolderPath">本当に復元したいバックアップ元のフォルダのパス</param>
        void RestorePartFiles(string folderPath, string logFilePath, List<string> backupFolderPaths, string sourceFolderPath, string sourcePartFolderPath)
        {
            FormRestoreProgress formRestoreProgress = new FormRestoreProgress();
            formRestoreProgress.Show();

            StreamReader sr = new StreamReader(logFilePath);
            string str = sr.ReadToEnd();
            string[] vs1 = str.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            vs1 = vs1.Where(x => x.IndexOf(sourcePartFolderPath) != -1).ToArray();

            Invoke((Action)(() => {
                Invoke((Action)(() => {
                    formRestoreProgress.GetProgressBar().Value = 0;
                    formRestoreProgress.GetProgressBar().Maximum = vs1.Length;
                }));
            }));

            foreach (string path in vs1)
            {
                if (formRestoreProgress.RestoreCancel)
                {
                    System.Threading.Thread.Sleep(1000);
                    Invoke((Action)(() => {
                        formRestoreProgress.RestoreCancel = true;
                        formRestoreProgress.Dispose();
                    }));

                    MessageBox.Show("復元処理は中断されました", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Invoke((Action)(() => {
                    Invoke((Action)(() => {
                        formRestoreProgress.GetProgressBar().Value++;
                    }));
                }));

                string[] vs2 = path.Split(new string[] { "::" }, StringSplitOptions.RemoveEmptyEntries);
                if (vs2.Length != 2)
                {
                    MessageBox.Show("ログファイルが破損しています！", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    System.Threading.Thread.Sleep(1000);
                    Invoke((Action)(() => {
                        formRestoreProgress.RestoreCancel = true;
                        formRestoreProgress.Dispose();
                    }));
                    return;
                }

                string filePath = vs2[0].Replace(sourceFolderPath, folderPath);

                bool isFind = false;
                foreach (string backupFolderPath in backupFolderPaths)
                {
                    string backupFilePath1 = vs2[0].Replace(sourceFolderPath, backupFolderPath);
                    if (File.Exists(backupFilePath1))
                    {
                        File.Copy(backupFilePath1, filePath);
                        isFind = true;
                        break;
                    }
                    if (Directory.Exists(backupFilePath1))
                    {
                        string newFolderPath = vs2[0].Replace(sourceFolderPath, folderPath);
                        Directory.CreateDirectory(newFolderPath);

                        isFind = true;
                        break;
                    }
                }
                if (!isFind)
                    MessageBox.Show("エラー ファイルがみつからない", vs2[0], MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            System.Threading.Thread.Sleep(1000);
            Invoke((Action)(() => {
                formRestoreProgress.RestoreCancel = true;
                formRestoreProgress.Dispose();
            }));
            MessageBox.Show("復元完了", "報告", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
