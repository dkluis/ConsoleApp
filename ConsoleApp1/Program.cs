using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string looper = "";
            while (looper.ToLower() != "q")
            {
                DisplayMainMenu();
                looper = GetInput(8, 8, "Input: ");
                switch(looper.ToLower())
                {
                    case "q":
                        Console.Clear();
                        break;
                    case "a":
                        DisplayText(18, 10, "A. Do Something                 ");
                        break;
                    case "b":
                        DisplayText(18, 10, "B. Do Something Else            ");
                        break;
                    default:
                        DisplayText(18, 10, "Unknown Menu Command Entered    ");
                        break;
                }
            }
        }

        static void DisplayMainMenu()
        {
            DisplayText(5, 3, "Simple Main Menu");
            DisplayText(5, 5, "a. Do Something");
            DisplayText(5, 6, "b. Do Something Else");
            DisplayText(8, 9, "(q - Quit)");
            DisplayText(8, 10, "Status:");
        }

        static void DisplayText(int xpos, int ypos, string text)
        {
            Console.SetCursorPosition(xpos, ypos);
            Console.Write(text);
        }

        static string GetInput(int xpos, int ypos, string text)
        {
            DisplayText(xpos, ypos, text);
            string Answer = Console.ReadLine();

            return Answer;
        }
    }
}
