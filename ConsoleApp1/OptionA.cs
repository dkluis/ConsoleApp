using StringManipulations;
using System;
using UILib;

namespace ConsoleApp
{
    class OptionA
    {
        public void Main2()
        {
            Display disp = new Display();
            string Looper = "";

            while (Looper != "q")
            {
                string Pattern = "";
                string InspectionString = "Find a pattern in a string";
                disp.DisplayOptionScreen("", true);
                disp.DisplayText(disp.xLeftCol1, disp.yTop, "Enter a pattern (regex): ");
                disp.DisplayText(disp.xLeftCol1, disp.yTop + 1, "Enter a string.........: ");
                Pattern = disp.GetInput(disp.xLeftCol1, disp.yTop, "Enter a pattern (regex): ");
                if (Pattern == "q")
                {
                    Looper = "q";
                    break;
                }
                InspectionString = disp.GetInput(disp.xLeftCol1, disp.yTop + 1, "Enter a string.........: ");
                if (InspectionString == "q")
                {
                    Looper = "q";
                    break;
                }

                StrMani SM = new StrMani();
                
                string[] result = SM.ValidateRegex(Pattern, InspectionString);
                if (result[0] == InspectionString)
                {
                    disp.DisplayText(disp.xleftStatusMsg, disp.yStatus, "Pattern not found in the string");
                }
                else
                {
                    foreach (string item in result)
                    {
                        Console.WriteLine(item);
                    }
                }

                Looper = disp.GetInput(0, 1, "Hit q: ");
            }
        }
    }
}
