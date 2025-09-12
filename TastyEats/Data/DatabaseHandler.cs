using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms; 
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
            try
            {
                return new NpgsqlConnection(connString);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating DB connection: {ex.Message}",
                                "Database Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                throw; // still throw so higher layers know connection failed
            }
        }

        public static DataTable ExecuteQuery(string query, Dictionary<string, object>? parameters = null)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show($"Query failed: {ex.Message}",
                                "Database Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                throw; // rethrow so controllers can decide what to do
            }
        }

        public static int ExecuteNonQuery(string query, Dictionary<string, object>? parameters = null)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show($"Command failed: {ex.Message}",
                                "Database Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return -1; // indicate failure gracefully
            }
        }
    }
}
