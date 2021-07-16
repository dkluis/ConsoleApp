using System;
using System.IO;

namespace FileHandling
{
    class Files
    {
        static void Main()
        {
        }
    }

    public class TextFile
    {
        public string FileName;
        public string FilePath;
        public string WorkingPath;
        public string UserName;

        public TextFile(string File = "ConsoleAppConfig.txt")
        {
            FileName = File;
            WorkingPath = Environment.CurrentDirectory;
            UserName = Environment.UserName;

            EnvInfo ei = new EnvInfo();

            switch (ei.OS)
            {
                case "Windows":
                    FilePath = Path.Join(@"C:\Users\Dick", FileName);
                    break;
                case "Linux":
                    FilePath = Path.Join(@"/Users/Dick", FileName);
                    break;
                default:
                    FilePath = Path.Join(WorkingPath, FileName);
                    break;
            }
        }

        public bool FileExistCreate(string file, bool create)
        {
            bool exist = false;
            if (!File.Exists(file))
            {
                if (create)
                {
                    File.Create(file);
                    exist = true;
                }
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
                    break;
                case PlatformID.Unix:
                case PlatformID.MacOSX:
                    OS = "Linux";
                    break;
                default:
                    OS = "Unknown";
                    break;
            }
            MachineName = Environment.MachineName.ToString();
        }
    }
}


