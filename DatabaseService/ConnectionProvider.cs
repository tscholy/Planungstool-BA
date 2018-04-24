using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DatabaseService
{
    public class ConnectionProvider
    {
        string mysqlConString = "Server=localhost;Database=planningtool;Userid=root;password=;Ssl Mode=None;";

        public IDbConnection GetConnection()
        {
            IDbConnection c = new MySqlConnection(mysqlConString);
            c.Open();
            return c;
        }
    }
}
