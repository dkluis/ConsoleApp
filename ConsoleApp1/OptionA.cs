using StringManipulations;

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
                string InspectionString = "";
                disp.DisplayOptionAScreen(true);
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
                SM.ValidateRegex("[0-9]");


                Looper = disp.GetInput(0, 1, "Hit q: ");
            }
        }
    }
}
