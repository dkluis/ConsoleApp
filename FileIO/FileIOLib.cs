using System;
using System.IO;

namespace FileIOLib
{
    class Program
    {
        static void Main()
        {
        }
    }

    public class FileIO
    {
        protected string FileName;
        protected string FilePath;
        public string Drive;
        protected string FullFileName;

        protected string WorkingPath;
        protected string UserName;

        protected bool Initialized;
        protected bool FileExists;

        public FileIO()
        {
            Initialized = false;
            FileExists = false;

            EnvInfo ei = new EnvInfo();
            WorkingPath = ei.WorkingPath;
            UserName = ei.UserName;
            Drive = ei.Drive;
        }

        public (bool, string) Initialize(string[] FilePathIn, string File)
        {
            bool success = false;
            FullFileName = Path.Combine(FilePathIn);
            FullFileName = Path.Join(Drive, FullFileName); 
            FullFileName = Path.Join(FullFileName, File);
            if (Exists())
            {
                FileExists = true;
                success = true;
                Initialized = true;
            }
            return (success, FullFileName);
        }

        private bool Exists()
        {
            bool exist = false;
            if (!File.Exists(FullFileName))
            {
                File.Create(FullFileName);
                exist = true;
            }
            else
            {
                exist = true;
            }
            return exist;
        }

        public void WriteLines(string[] line, bool appending)
        {
            // File.WriteAllLines("Config.txt", line, append: appending);
        }

        public string[] ReadLines()
        {
            String[] text = File.ReadAllLines("Config.txt");
            return text;
        }
    }

    public class EnvInfo
    {
        public readonly string OS;
        public readonly string MachineName;
        public readonly string UserName;
        public readonly string WorkingPath;
        public string Drive;

        public EnvInfo()
        {
            OperatingSystem os = Environment.OSVersion;
            PlatformID pid = os.Platform;
            switch (pid)
            {
                case PlatformID.Win32NT:
                case PlatformID.Win32S:
                case PlatformID.Win32Windows:
                case PlatformID.WinCE:
                    OS = "Windows";
                    Drive = @"C:";
                    break;
                case PlatformID.Unix:
                case PlatformID.MacOSX:
                    OS = "Linux";
                    Drive = @"/";
                    break;
                default:
                    OS = "Unknown";
                    Drive = "Unknown";
                    break;
            }
            MachineName = Environment.MachineName.ToString();
            WorkingPath = Environment.CurrentDirectory;
            UserName = Environment.UserName;
        }
    }
}