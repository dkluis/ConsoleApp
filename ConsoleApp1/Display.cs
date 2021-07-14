﻿using System;

namespace ConsoleApp
{
    class Display
    {
        public void DisplayProgramMenu(bool refresh)
        {
            if (refresh)
            {
                Console.Clear();
            }
            DisplayText(5, 3, "Simple Main Menu");
            DisplayText(5, 5, "a. Do Something");
            DisplayText(5, 6, "b. Do Something Else");
            DisplayText(8, 9, "(q - Quit)");
            DisplayText(8, 10, "Status:");
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