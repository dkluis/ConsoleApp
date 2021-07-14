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
                looper = display.GetInput(15, 8, "Input: ");
                switch (looper.ToLower())
                {
                    case "q":
                        Console.Clear();
                        break;
                    case "a":
                        display.DisplayText(25, 10, "A. Do Something                 ");
                        OptionA optionA = new OptionA();
                        optionA.Main2();
                        display.DisplayProgramMenu(true);
                        break;
                    case "b":
                        display.DisplayText(25, 10, "B. Do Something Else            ");
                        OptionB optionB = new OptionB();
                        optionB.Main3();
                        display.DisplayProgramMenu(true);
                        break;
                    default:
                        display.DisplayText(25, 10, "Unknown Menu Command Entered    ");
                        break;
                }
            }
        }
    }
}
