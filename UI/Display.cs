using System;

namespace UILib
{
    class UILib
    {
        static void Main()
        {
        }
    }

    /// <summary>
    /// Class to handle all Console writing and reading
    /// Used to learn putting a class into it's own file and use from elsewhere in the solution
    /// </summary>
    public class Display
    {
        /// <summary>
        /// 
        /// </summary>
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

        /// <summary>
        /// Display the main program menu
        /// Used to learn how to position text while writing to the console
        /// </summary>
        /// <param name="refresh">Used to refresh the console and delete all current displayed text</param>
        public void DisplayProgramMenu(bool refresh)
        {
            if (refresh)
            {
                Console.Clear();
            }
            DisplayText(xLeftCol1, yTitle, "Simple Main Menu");
            DisplayText(xLeftCol1, yTop, "a. Find a pattern in a string");
            DisplayText(xLeftCol1, yTop + 1, "b. Break out the Media name");
            DisplayText(xLeftCol1, yTop + 2, "1. Do MariaDB access actions");
            DisplayText(xleftCol2, yTop, "c. Create File (if not exist) and read it's lines");
            DisplayText(xleftCol2, yTop + 1, "d. Testing Inheritance, Poly, Interfaces, etc.");
            DisplayText(xleftOther, yInput + 1, "(q - Quit)");
            DisplayText(xleftOther, yStatus, "Status:");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="refresh"></param>
        public void DisplayOptionScreen(string title, bool refresh)
        {
            if (refresh)
            {
                Console.Clear();
            }
            DisplayText(xLeftCol1, yTitle, title);

            DisplayText(xleftOther, yInput + 1, "(q - Quit)");
            DisplayText(xleftOther, yStatus, "Status:");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xpos"></param>
        /// <param name="ypos"></param>
        /// <param name="text"></param>
        public void DisplayText(int xpos, int ypos, string text)
        {
            Console.SetCursorPosition(xpos, ypos);
            Console.Write(text);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xpos"></param>
        /// <param name="ypos"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public string GetInput(int xpos, int ypos, string text)
        {
            DisplayText(xpos, ypos, text);
            string Answer = Console.ReadLine();

            return Answer;
        }
    }
}
