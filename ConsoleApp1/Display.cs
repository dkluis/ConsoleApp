using System;

namespace ConsoleApp
{
    class Display
    {
        public int yTitle = 3;
        public int yTop = 5;
        public int yInput = 11;
        public int yStatus = 13;
        public int xLeftCol1 = 5;
        public int xleftCol2 = 40;
        public int xleftOther = 15;
        public int xleftStatus = 18;
        public int xleftStatusMsg = 25;
        public int xleftInput = 18;

        public void DisplayProgramMenu(bool refresh)
        {
            if (refresh)
            {
                Console.Clear();
            }
            DisplayText(xLeftCol1, yTitle, "Simple Main Menu");
            DisplayText(xLeftCol1, yTop, "a. Do Something");
            DisplayText(xLeftCol1, yTop + 1, "b. Do Something Else");
            DisplayText(xleftCol2, yTop, "c. Do Another Thing");
            DisplayText(xleftCol2, yTop + 1, "d. Yet Another Thingy");
            DisplayText(xleftOther, yInput + 1, "(q - Quit)");
            DisplayText(xleftOther, yStatus, "Status:");
        }

        public void DisplayText(int xpos, int ypos, string text)
        {
            Console.SetCursorPosition(xpos, ypos);
            Console.Write(text);
        }

        public string GetInput(int xpos, int ypos, string text)
        {
            DisplayText(xpos, ypos, text);
            string Answer = Console.ReadLine();

            return Answer;
        }
    }
}
