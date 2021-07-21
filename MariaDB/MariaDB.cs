using System;
using MySqlConnector;

namespace Database_Lib
{
    public class MariaDB
    {
        private string ConnectionInfo = @"server=ca-server.local; database=Test-TVM-DB; uid=dick; pwd=Sandy3942";

        public void Connect()
        {
            MySqlConnection conn = new MySqlConnection(ConnectionInfo);
            conn.Open();
            Console.WriteLine($"MariaDB is connected with status {conn.State.ToString()}");
        }

    }

}
