using System;
using System.IO;

namespace OTUS_Homework_17_Delegates
{
    public class FileIterator
    {
        public event EventHandler OnFileFound;
        public bool CancelSearch { get; set; } = false;

        public void IterateFiles(string path)
        {
            if (!Directory.Exists(path))
                return;

            foreach (var file in Directory.GetFiles(path))
                if (!CancelSearch)
                    OnFileFound?.Invoke(this, new FileArgs(file));
                else
                    break;
        }
    }

    public class FileArgs : EventArgs
    {
        public string FileName { get; set; }

        public FileArgs(string fileName)
        {
            FileName = fileName;
        }
    }
}
