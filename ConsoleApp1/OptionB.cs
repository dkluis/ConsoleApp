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

                MediaInfo mi = new MediaInfo();
                mi.MediaString = InspectionString;
                mi.isMedia = false;
                mi.isMovie = false;
                mi.isTVShow = false;
                mi.TVShowName = "";
                mi.ValidateRegexResult = new string[] { };

                StrMani SM = new StrMani();
                
                string[] result = new string[] { };
                foreach (string pattern in SM.MediaPatterns)
                {
                    result = SM.ValidateRegex(pattern, mi.MediaString);
                    if (result[0] == mi.MediaString)
                    {
                        disp.DisplayText(disp.xleftStatusMsg, disp.yStatus, "Media not found in the string");
                    }
                    else
                    {
                        disp.DisplayText(disp.xleftStatusMsg, disp.yStatus, $"Media found is: \"{result[0]}\", \"{result[1]}\", \"{result[2]}\", and lenght {result.Length}");
                        mi.isTVShow = true;
                        mi.TVShowName = result[0];
                        break;
                    }
                }

                mi = SM.EliminatePrefixes(mi);
                disp.DisplayText(disp.xleftStatusMsg, disp.yStatus + 1, $"TVShow Name is: {mi.TVShowName}");
                mi = StrMani.CleanupName(mi);
                disp.DisplayText(disp.xleftStatusMsg, disp.yStatus + 1, $"Cleaned TVShow Name is: \"{mi.TVShowName}\"");

                Looper = disp.GetInput(0, 1, "Hit q: ");
            }
        }
    }
}