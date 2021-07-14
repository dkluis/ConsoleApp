using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string looper = "";
            while (looper.ToLower() != "q")
            {
                Display display = new Display();
                display.DisplayProgramMenu(false);
                looper = display.GetInput(8, 8, "Input: ");
                switch (looper.ToLower())
                {
                    case "q":
                        Console.Clear();
                        break;
                    case "a":
                        display.DisplayText(18, 10, "A. Do Something                 ");
                        OptionA optionA = new OptionA();
                        optionA.Main2();
                        display.DisplayProgramMenu(true);
                        break;
                    case "b":
                        display.DisplayText(18, 10, "B. Do Something Else            ");
                        OptionB optionB = new OptionB();
                        optionB.Main3();
                        display.DisplayProgramMenu(true);
                        break;
                    default:
                        display.DisplayText(18, 10, "Unknown Menu Command Entered    ");
                        break;
                }
            }
        }
    }

    public class Display
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
