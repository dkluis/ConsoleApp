using System;
using MySqlConnector;

namespace Database_Lib
{
    public class MariaDB
    {
        private string ConnectionInfo = @"server=ca-server.local; database=Test-TVM-DB; uid=dick; pwd=Sandy3942";
        private MySqlConnection conn;
        private MySqlCommand cmd;
        private MySqlDataReader rdr;

        public void Connect()
        {
            conn = new MySqlConnection(ConnectionInfo);
            Console.WriteLine($"MariaDB is connected with status {conn.State.ToString()}");
        }

        public void Open()
        {
            conn.Open();
            Console.WriteLine($"MariaDB is Open with status {conn.State.ToString()}");
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
