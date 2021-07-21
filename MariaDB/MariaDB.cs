using System;
using MySqlConnector;

namespace Database_Lib
{
    public class MariaDB
    {
        private string ConnectionInfo = @"server=ca-server.local; database=Test-TVM-DB; uid=dick; pwd=Sandy3942";
        private MySqlConnection conn;

        public void Connect()
        {
            conn = new MySqlConnection(ConnectionInfo);
            Console.WriteLine($"MariaDB is connected with status {conn.State.ToString()}");
        }

        public void Open()
        {
            conn.Open();
            Console.WriteLine($"MariaDB is connected with status {conn.State.ToString()}");
        }

        public void Close()
        {
            conn.Close();
            Console.WriteLine($"MariaDB is connected with status {conn.State.ToString()}");
        }
    }
}
