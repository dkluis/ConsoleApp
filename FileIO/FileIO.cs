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
            public bool WriteText(string[] line, bool appending)
            {
                // File.WriteAllLines("Config.txt", line, append: appending);
                return true;
            }

            public string[] ReadLines()
            {
                String[] text = File.ReadAllLines("Config.txt");
                return text;
            }
        }
    }
}
