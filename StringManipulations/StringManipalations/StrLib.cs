using System.Text.RegularExpressions;
using System;
//using DisplayLib;


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
        public string[] ValidateRegex(string regexin, string stringin, bool debug)
        {
            //Display disp = new Display();

            regexin = $"(.{regexin}.)";
            try
            {
                string[] splitcollection = Regex.Split(stringin, regexin);

                if (debug)
                {
                    Console.SetCursorPosition(20, 20);
                    if (splitcollection.Length == 1)
                    {
                        Console.WriteLine("No match found");
                    }
                    else
                    {
                        if (splitcollection.Length != 3)
                        {
                            Console.WriteLine($"Found an unexpected number of matches {splitcollection.Length}");
                        }
                    }

                    foreach (string str in splitcollection)
                    {
                        Console.WriteLine(str);
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
