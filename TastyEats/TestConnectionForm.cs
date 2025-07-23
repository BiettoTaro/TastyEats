using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TastyEats
{
    public partial class TestConnectionForm : Form
    {
        public TestConnectionForm()
        {
            InitializeComponent();
        }

        private void btnCheckConnection_Click(object sender, EventArgs e)
        {
            try
            {
                using (var connection = TastyEats.Models.DatabaseHandler.GetConnection())
                {
                    connection.Open();
                    // Check how may tables are in the database
                    string query = @"
                        SELECT table_name
                        FROM information_schema.tables
                        WHERE table_schema = 'public';";
                    using (var cmd = new Npgsql.NpgsqlCommand(query, connection))
                    using (var reader = cmd.ExecuteReader())
                    {
                        List<string> tables = new List<string>();

                        while (reader.Read())
                        {
                            tables.Add(reader.GetString(0));
                        }

                        MessageBox.Show($"Connection successful! Found {tables.Count} tables:\n{string.Join(", ", tables)}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Connection failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
