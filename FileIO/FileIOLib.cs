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
        protected string WorkingDrive;
        protected string UserName;

        protected bool Initialized;
        protected bool FileExists;

        public FileIO()
        {
            Initialized = false;
            FileExists = false;

            EnvInfo ei = new();
            WorkingPath = ei.WorkingPath;
            WorkingDrive = ei.WorkingDrive;
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
            bool exist;
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

        /// <summary>
        /// Add a list of lines to a file if append is true
        /// Rewrites the file with a list of lines if append if false
        /// </summary>
        /// <param name="lines">List of lines</param>
        /// <param name="append">bool</param>
        public void WriteLines(string[] lines, bool append)
        {
            using StreamWriter file = new(FullFileName, append);  // using make this disposable.
            foreach (string line in lines)
            {
                file.WriteLine(line);
            }
        }

        public string[] ReadLines()
        {
            String[] text = File.ReadAllLines(FullFileName);
            return text;
        }
    }

    public class EnvInfo
    {
        public readonly string OS;
        public readonly string MachineName;
        public readonly string UserName;
        public readonly string WorkingPath;
        public readonly string WorkingDrive;
        public readonly string Drive;

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
                    Drive = @"C:\";
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
            WorkingDrive = Path.GetPathRoot(WorkingPath);
            UserName = Environment.UserName;
        }
    }
}