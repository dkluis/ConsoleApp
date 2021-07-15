using UILib;
using StringManipulations;
using System;

namespace ConsoleApp
{
    class OptionB
    {
        public void Main3()
        {
            Display disp = new Display();
            string Looper = "";

            while (Looper != "q")
            {
                string InspectionString = "";
                disp.DisplayOptionScreen("Break out the Media name", true);
                InspectionString = disp.GetInput(disp.xLeftCol1, disp.yTop, "Enter a media string: ");

                if (InspectionString == "q")
                {
                    Looper = "q";
                    break;
                }

                StrMani SM = new StrMani();
                
                string[] result = new string[] { };
                foreach (string pattern in SM.MediaPatterns)
                {
                    result = SM.ValidateRegex(pattern, InspectionString.ToLower(), false);
                    //}
                    //string[] result = SM.ValidateRegex(Pattern, InspectionString, false);
                    if (result[0] == InspectionString.ToLower())
                    {
                        disp.DisplayText(disp.xleftStatusMsg, disp.yStatus, "Media not found in the string");
                    }
                    else
                    {
                        disp.DisplayText(disp.xleftStatusMsg, disp.yStatus, $"Media found is: \"{result[0]}\" and lenght {result.Length}");
                        break;
                    }
                }

                Looper = disp.GetInput(0, 1, "Hit q: ");
            }
        }
    }
}