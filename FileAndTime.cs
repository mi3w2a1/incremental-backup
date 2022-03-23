using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncrementalBackup
{
    public class FileAndTime
    {
        public FileAndTime(string path, long tick)
        {
            FilePath = path;
            Tick = tick;
        }

        public long Tick
        {
            get;
            protected set;
        }
        = 0;

        public string FilePath
        {
            get;
            protected set;
        }
        = "";

        public bool IsChecked
        {
            get;
            set;
        }
        = false;
    }
}
