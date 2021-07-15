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
        public string[] MediaPatterns = new string[] { "s[0][0-9]e[0-9[0-9]", "s[0-9]e[0-9]", "season[ .][0-9]", "season[ .][0-9][0-9]" };
        public string[] ValidateRegex(string regexin, string stringin, bool debug)
        {
            Display disp = new Display();

            regexin = $"({regexin})";
            try
            {
                string[] splitcollection = Regex.Split(stringin, regexin);

                if (debug)
                {
                    if (splitcollection.Length == 1)
                    {
                        disp.DisplayText(20,20, "No match found");
                    }
                    else
                    {
                        if (splitcollection.Length != 3)
                        {
                            disp.DisplayText(20, 20, $"Found an unexpected number of matches {splitcollection.Length}");
                        }
                    }
                    foreach (string str in splitcollection)
                    {
                        disp.DisplayText(20,20, splitcollection.ToString());
                    }
                }

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
}
