using System;
using UILib;
using FileIOLib;
using Database_Lib;

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
                    case "d":
                        OptionD optionD = new OptionD();
                        optionD.Main();
                        break;
                    case "1":
                        Console.Clear();
                        MariaDB MDb = new MariaDB();
                        success = MDb.Connect();
                        if (!success)
                        {
                            Console.WriteLine($"Did not Connect to mariaDB with exception {MDb.exception}");
                            Environment.Exit(99);
                        }
                        success = MDb.Open();
                        if (!success)
                        {
                            Console.WriteLine($"Did not Open the mariaDB with exception {MDb.exception}");
                            Environment.Exit(99);
                        }

                        // string sql = "SELECT `key`, info, comments FROM key_values WHERE(`key` = 'email')";
                        string sql = "SELECT * FROM Key_Values WHERE (`key` = 'email')";
                        // string sql = "SELECT * FROM Key_Values";
                        Console.WriteLine($"SQL = {sql}");
                        MDb.Command(sql);
                        var Info = MDb.ExecQuery();
                        Console.WriteLine($"Info FieldCount: {Info.FieldCount}, Has Rows: {Info.HasRows}");

                        while (Info.Read())
                        {
                            MariaDB.Key_Value_Rec rec = new MariaDB.Key_Value_Rec();
                            rec.Fill(Info[0].ToString(), Info[1].ToString(), Info[2].ToString());
                            Console.WriteLine($"Reading via index: Key: {Info[0]}, Info: {Info[1]}, Comment: {Info[2]}");
                            Console.WriteLine($"Reading via field name: Key: {rec.key}, Info: {rec.info}, Comment: {rec.comment}");
                        }

                        MDb.Close();
                        MDb.Open();

                        sql = "select * from download_options order by providername asc";
                        MDb.Command(sql);
                        var dlo = MDb.ExecQuery();
                        while (dlo.Read())
                        {
                            MariaDB.Download_Options_Rec rec = new MariaDB.Download_Options_Rec();
                            rec.Fill(dlo[0].ToString(), dlo[1].ToString(), dlo[2].ToString(), dlo[3].ToString());
                            Console.WriteLine($"{rec.providername.PadRight(20)} " +
                                $"### {rec.link_prefix.PadRight(70)} " +
                                $"### {rec.suffixlink.PadRight(40)} " +
                                $"### {rec.searchchar}");
                        }

                        MDb.Close();
                        display.GetInput(50, 0, "");
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
