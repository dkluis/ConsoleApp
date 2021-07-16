﻿using System;
using UILib;
using FileHandling;

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
                        TextFile config = new TextFile();
                        bool success = config.FileExistCreate(config.FilePath, true);
                        display.DisplayText(20, 20, $"File Create is: {success}");
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
