using System;
using UILib;
using FileIOLib;
using Media_Library;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string cmdline = "";
            string looper = "";
            Display display = new Display();

            /*
            TVShow show1 = new TVShow();
            Book book1 = new Book();
            Movie movie1 = new Movie();
            Music music1 = new Music();
            Environment.Exit(1);
            */

            if (args.Length < 1)
            {
                cmdline = "No Commandline argument passed in";
            }
            else
            {
                if (args.Length > 1)
                {
                    cmdline = $"Too Many Commandline arguments passed in: {args.Length}, all are ignored";
                }
                else
                {
                    looper = args[0].ToLower().Replace("-", "");
                    cmdline = $"Command {args[0].ToLower()} passed in, menu item {looper} activated";
                }
            }

            
            while (looper.ToLower() != "q")
            {
                display.DisplayProgramMenu(false);
                display.DisplayText(0, 0, cmdline);

                if (looper == "")
                {
                    looper = display.GetInput(display.xleftOther, display.yInput, "Input: ");
                }
                switch (looper.ToLower())
                {
                    case "q":
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                    case "a":
                        OptionA optionA = new OptionA();
                        optionA.Main2();
                        display.DisplayProgramMenu(true);
                        break;
                    case "b":
                        OptionB optionB = new OptionB();
                        optionB.Main3();
                        display.DisplayProgramMenu(true);
                        break;
                    case "c":
                        FileIO config = new FileIO();
                        string[] FilePath = { "Users", "Dick" };
                        string File = "ConsoleAppConfig.txt";
                        
                        (bool success, string FFP) = config.Initialize(FilePath, File);
                        display.DisplayText(20, 20, $"File Create is: {success} at {FFP}\n");

                        string[] result = config.ReadLines();
                        foreach (string line in result)
                        {
                            Console.WriteLine($"...: {line}...");
                        }
                        break;
                    default:
                        display.DisplayText(display.xleftStatusMsg, display.yStatus, "Menu Command Not Implemented    ");
                        break;
                }
                looper = "";
            }
        }
    }
}
