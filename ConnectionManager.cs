using System;
using System.Data.SqlClient;

namespace AracKiralamaUygulaması
{
    internal class ConnectionManager
    {
        private static readonly string connectionString = @"Server=MONSTER\SQLEXPRESS;Database=AracKiralama;Trusted_Connection=True;";

        public static SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
    }
}
