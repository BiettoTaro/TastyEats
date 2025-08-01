using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Npgsql;

namespace TastyEats.Data
{
    public static class DatabaseHandler
    {
        private static readonly string host = "192.168.1.131";
        private static readonly string port = "5432";
        private static readonly string username = "postgres";
        private static readonly string password = "postgres123";
        private static readonly string database = "tastyeats";

        private static readonly string connString = $"Host={host};Port={port};Username={username};Password={password};Database={database}";

        public static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(connString);
        }

        public static DataTable ExecuteQuery(string query)
        {
            DataTable dt = new DataTable();
            using (var connection = GetConnection())
            {
                try
                {
                    using (var conn = GetConnection())
                    {
                        conn.Open();
                        using (var cmd = new NpgsqlCommand(query, conn))
                        using (var adapter = new NpgsqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                       
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error executing query: {ex.Message}");
                }
                return dt;
            }
        }
        public static int ExecuteNonQuery(string query)
        {
            try 
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error executing non-query: {ex.Message}");
                throw;
            }
        }
    }
}
