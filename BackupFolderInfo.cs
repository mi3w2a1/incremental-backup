using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncrementalBackup
{
    public class BackupFolderInfo
    {
        public BackupFolderInfo()
        {
        }

        //public BackupFolderInfo(string sourceFolderPath, string targetFolderPath)
        //{
        //    SourceFolderPath = sourceFolderPath;
        //    TargetFolderPath = targetFolderPath;
        //}

        public BackupFolderInfo(string sourceFolderPath, string targetFolderPath, string[] extensions, string memo)
        {
            SourceFolderPath = sourceFolderPath;
            TargetFolderPath = targetFolderPath;
            Extensions = extensions;
            Memo = memo;
        }

        public string SourceFolderPath = "";
        public string TargetFolderPath = "";
        public string[] Extensions = null;
        public string Memo = "";
    }
}

