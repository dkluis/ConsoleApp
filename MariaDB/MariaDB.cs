using MySqlConnector;
using System;
using System.Collections.Generic;

namespace Database_Lib
{
    public class MariaDB
    {
        private string ConnectionInfo = @"server=ca-server.local; database=Test-TVM-DB; uid=dick; pwd=Sandy3942"; //Test DB Info, not sensitive info
        private MySqlConnection conn;
        private MySqlCommand cmd;
        private MySqlDataReader rdr;
        //private MySqlDataAdapter da;
        public string exception;

        public bool Connect()
        {
            bool success = true;
            try
            {
                conn = new MySqlConnection(ConnectionInfo);
                Console.WriteLine($"MariaDB is connected with status {conn.State}");
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
                Console.WriteLine($"MariaDB is Open with status {conn.State}");
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
            Console.WriteLine($"MariaDB is Close with status {conn.State}");
        }

        public MySqlCommand Command(string sql)
        {
            cmd = new MySqlCommand(sql, conn);
            Console.WriteLine($"MariaDB Command status {conn.State}");
            Console.WriteLine($"MariaDB is Cmd status {cmd}");
            return cmd;
        }

        public MySqlDataReader ExecQuery()
        {
            rdr = cmd.ExecuteReader();
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

        public struct Shows_Rec
        {
            public UInt64 showid;
            public string showname;
            public string url;
            public string type;
            public string showstatus;
            public string premiered;
            public string language;
            public int runtime;
            public string network;
            public string country;
            public string tvrage;
            public string thetvdb;
            public string imdb;
            public Int64 tvmaze_updated;
            public MySqlDateTime tvmaze_upd_date;
            public string status;
            public string download;
            public MySqlDateTime record_updated;
            public string alt_showname;
            public string alt_sn_override;
            public int eps_count;
            public MySqlDateTime eps_updated;

            public void Fill(UInt64 f1, string f2, string f3, string f4, string f5, string f6)
            {
                showid = f1;
                showname = f2;
                url = f3;
                type = f4;
                showstatus = f5;
                premiered = f6;
            }

            public void Fill(UInt64 f1, string f2, string f3, string f4, string f5, string f6,
                string f7, int f8, string f9, string f10, string f11, string f12, string f13,
                Int64 f14, MySqlDateTime f15, string f16, string f17,
                MySqlDateTime f18, string f19, string f20, int f21, MySqlDateTime f22)

            {
                showid = f1;
                showname = f2;
                url = f3;
                type = f4;
                showstatus = f5;
                premiered = f6;
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
            List<MariaDB.Key_Value_Rec> ListofRecords = new();
            MariaDB.Key_Value_Rec rec = new();

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
