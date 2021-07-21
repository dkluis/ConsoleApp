using System;
using Database_Lib;
using UILib;


namespace ConsoleApp
{
    class Option1
    {
        public void Main()
        {
            bool success = false;
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
            Display disp = new Display();
            disp.GetInput(50, 0, "");
            Console.Clear();
        }
    }
}
