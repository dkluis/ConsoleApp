using System;
using Database_Lib;
using UILib;


namespace ConsoleApp
{
    class Option1
    {
        public void Main()
        {
            bool success;
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

            // sql = "select * from download_options order by providername asc";
            MDb.Command(sql);
            var dlo = MDb.ExecQuery();
            /*
            while (dlo.Read())
            {
                MariaDB.Download_Options_Rec rec = new MariaDB.Download_Options_Rec();
                rec.Fill(dlo[0].ToString(), dlo[1].ToString(), dlo[2].ToString(), dlo[3].ToString());
                Console.WriteLine($"{rec.providername.PadRight(20)} " +
                    $"### {rec.link_prefix.PadRight(70)} " +
                    $"### {rec.suffixlink.PadRight(40)} " +
                    $"### {rec.searchchar}");
            }
            */
            var lor = dlo.List_KeyValue_Records();
            foreach (MariaDB.Key_Value_Rec rec in lor)
            {
                Console.WriteLine($"Record has key: {rec.key} with info: {rec.info} and comment: {rec.comment}");
            }

            MDb.Close();

            MDb.Open();
            sql = "select `showid`, showname, url, type, showstatus, premiered from shows where `showid` = 1";
            MDb.Command(sql);
            var show1 = MDb.ExecQuery();
            show1.Read();
            Console.WriteLine($"Read showid: {show1[0]} with showname: {show1[1]} premiered on {show1[5]}");
            MariaDB.Shows_Rec show_rec = new();
            show_rec.Fill((UInt64)show1[0], (string)show1[1], (string)show1[2], (string)show1[3], (string)show1[4], (string)show1[5]);
            Console.WriteLine($"Read showid: {show_rec.showid} " +
                $"with showname: {show_rec.showname} " +
                $"premiered on {show_rec.premiered} " +
                $"and status now is {show_rec.showstatus}");

            Display disp = new Display();
            disp.GetInput(50, 0, "");
            Console.Clear();
        }
    }
}
