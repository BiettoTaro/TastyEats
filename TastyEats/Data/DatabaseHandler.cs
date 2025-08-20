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

        public static DataTable ExecuteQuery(string query, Dictionary<string, object>? parameters = null)
        {
            using var conn = new NpgsqlConnection(connString);
            conn.Open();

            using var cmd = new NpgsqlCommand(query, conn);
            if (parameters != null)
            {
                foreach (var pair in parameters)
                    cmd.Parameters.AddWithValue(pair.Key, pair.Value);
            }

            using var reader = cmd.ExecuteReader();
            var dt = new DataTable();
            dt.Load(reader);
            return dt;
        }

        public static int ExecuteNonQuery(string query, Dictionary<string, object>? parameters = null)
        {
            using var conn = new NpgsqlConnection(connString);
            conn.Open();

            using var cmd = new NpgsqlCommand(query, conn);
            if (parameters != null)
            {
                foreach (var pair in parameters)
                    cmd.Parameters.AddWithValue(pair.Key, pair.Value);
            }

            return cmd.ExecuteNonQuery();
        }

    }
}
