using System;
using System.Text.RegularExpressions;


namespace StringManipulations
{
    class StrLib
    {
        private static void Main()
        {
        }
    }

    public class StrMani
    {
        public string[] MediaPatterns = new string[] { "[sS][0-9]+[eE][0-9]+", "[sS][0-9]+", "season[ .][0-9]+" };
        public string[] MediaFormats = new string[] { ".mkv", ".mp4" };
        public string[] MediaEliminators = new string[] { "www", "rarbg" };

        public string[] ValidateRegex(string regexin, string stringin)
        {
            regexin = $"({regexin})";
            try
            {
                string[] splitcollection = Regex.Split(stringin, regexin);

                return splitcollection;
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine($"Invalid Regex Exception");
                Console.WriteLine($"{e}");
                return Array.Empty<string>();
            }
        }

        public MediaInfo EliminatePrefixes(MediaInfo mi)
        {
            string name = mi.TVShowName;
            foreach (string prefix in MediaEliminators)
            {
                name = name.Replace(prefix, "");
            }
            mi.TVShowName = name;
            return mi;
        }

        public static MediaInfo CleanupName(MediaInfo mi)
        {
            string name = mi.TVShowName;
            name = name.Replace(".", " ").Replace("   ", " ").Replace("  ", " ");
            name = name.TrimEnd();
            name = name.TrimStart();
            mi.TVShowName = name;
            return mi;
        }
    }

    public struct MediaInfo
    {
        public bool isTVShow;
        public bool isMovie;
        public bool isMedia;
        public string TVShowName;
        public string MediaString;
        public string[] ValidateRegexResult;
    }
}
