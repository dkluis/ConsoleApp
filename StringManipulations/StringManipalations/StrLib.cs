using System.Text.RegularExpressions;
using System;
using UILib;


namespace StringManipulations
{
    class StrLib
    {
        static void Main()
        {   
        }
    }

    public class StrMani
    {
        public string[] MediaPatterns = new string[] { "[sS][0-9][0-9][eE][0-9[0-9]", "[sS][0-9][eE][0-9]", "[sS][0-9][0-9]", "[sS][0-9]", "season[ .][0-9]", "season[ .][0-9][0-9]"};
        public string[] MediaFormats = new string[] {".mkv", ".mp4"};
        public string[] ValidateRegex(string regexin, string stringin)
        {
            Display disp = new Display();

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
                string[] empty = new string[] { };
                return empty;
            }
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
