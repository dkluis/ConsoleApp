using System;
using System.IO;

namespace FileIO
{
    class FileIO
    {
        static void Main4()
        {
        }

        public class TextFile
        {
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

            public void WriteText(string[] line, bool appending)
            {
                // File.WriteAllLines("Config.txt", line, append: appending);
            }

            public string[] ReadLines()
            {
                String[] text = File.ReadAllLines("Config.txt");
                return text;
            }
        }
    }
}
