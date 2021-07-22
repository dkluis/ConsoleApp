using FileIOLib;
using System;
using UILib;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string cmdline = "";
            string looper = "";
            Display display = new Display();

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
                        EnvInfo ei = new EnvInfo();
                        string[] FilePath = { "Users", "Dick" };
                        string File = "ConsoleAppConfig.txt";

                        (bool success, string FFP) = config.Initialize(FilePath, File);
                        display.DisplayText(20, 20, $"File Create is: {success} at {FFP} and Drive is {ei.WorkingDrive}\n");

                        string[] result = config.ReadLines();
                        foreach (string line in result)
                        {
                            Console.WriteLine($"...: {line}...");
                        }
                        break;
                    case "d":
                        OptionD optionD = new OptionD();
                        optionD.Main();
                        break;
                    case "1":
                        Console.Clear();
                        Option1 option1 = new Option1();
                        option1.Main();
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
