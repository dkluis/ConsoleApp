using System;
using MySqlConnector;

namespace Database_Lib
{
    public class MariaDB
    {
        private string ConnectionInfo = @"server=ca-server.local; database=Test-TVM-DB; uid=dick; pwd=Sandy3942mmm";
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
            return rdr;
        }

        public void ExecNonQuery()
        {
            cmd.ExecuteNonQuery();
        }
    }
}
