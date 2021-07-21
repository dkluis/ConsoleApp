using System;
using System.Collections.Generic;
using MySqlConnector;

namespace Database_Lib
{
    public class MariaDB
    {
        private string ConnectionInfo = @"server=ca-server.local; database=Test-TVM-DB; uid=dick; pwd=Sandy3942";
        private MySqlConnection conn;
        private MySqlCommand cmd;
        private MySqlDataReader rdr;
        public string exception;

        public bool Connect()
        {
            bool success = true;
            try
            {
                conn = new MySqlConnection(ConnectionInfo);
                Console.WriteLine($"MariaDB is connected with status {conn.State.ToString()}");
            }
            catch (Exception e)
            {
                exception = e.Message.ToString();
                success = false;
            }
            return success;
        }

        public bool Open()
        {
            bool success = true;
            try
            {
                conn.Open();
            Console.WriteLine($"MariaDB is Open with status {conn.State.ToString()}");
            }
            catch (Exception e)
            {
                exception = e.Message.ToString();
                success = false;
            }
            return success;
        }

        public void Close()
        {
            conn.Close();
            Console.WriteLine($"MariaDB is Close with status {conn.State.ToString()}");
        }

        public MySqlCommand Command(string sql)
        {
            cmd = new MySqlCommand(sql, conn);
            Console.WriteLine($"MariaDB Command status {conn.State.ToString()}");
            Console.WriteLine($"MariaDB is Cmd status {cmd.ToString()}");
            return cmd;
        }

        public MySqlDataReader ExecQuery()
        {
            rdr = cmd.ExecuteReader();
            // Console.WriteLine($"Query result has {rdr.Count()} records");  // This sets the rdr to be used completely.
            // Console.WriteLine($"Query result has {rdr.GetName(0)} records");
            // Haven't found a good way yet to know how many records are in the set.
            return rdr;
        }

        public void ExecNonQuery()
        {
            cmd.ExecuteNonQuery();
        }

        public struct Key_Value_Rec
        {
            public string key;
            public string info;
            public string comment;

            public void Fill(string f1, string f2, string f3)
            {
                key = f1;
                info = f2;
                comment = f3;
            }
        } 

        public struct Download_Options_Rec
        {
            public string providername;
            public string link_prefix;
            public string suffixlink;
            public string searchchar;

            public void Fill(string f1, string f2, string f3, string f4)
            {
                providername = f1;
                link_prefix = f2;
                suffixlink = f3;
                searchchar = f4;
            }
        }
    }

    public static class Extensions
    {
        public static int Count(this MySqlDataReader dr)
        {
            int count = 0;
            while (dr.Read())
                count++;

            return count;
        }

        public static List<MariaDB.Key_Value_Rec> List_KeyValue_Records(this MySqlDataReader dr)
        {
            List<MariaDB.Key_Value_Rec> ListofRecords = new List<MariaDB.Key_Value_Rec>();
            MariaDB.Key_Value_Rec rec = new MariaDB.Key_Value_Rec();

            while (dr.Read())
            {
                rec.Fill(dr[0].ToString(), dr[1].ToString(), dr[2].ToString());
                ListofRecords.Add(rec);
            }
            Console.WriteLine($"ListofRecords: {ListofRecords.Count}");
            return ListofRecords;
        }
    }
}
