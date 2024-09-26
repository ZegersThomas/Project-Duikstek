using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace WpfAppDuikstek
{
    internal class diveLocationsDb
    {
        private string connectionString = "Server=localhost;Database=divelocations;Uid=root;Pwd=;";

        public List<string> getAllDivingLocations()
        {
            List<string> diveLocations = new List<string>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT name FROM divelocations", conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    foreach (DataRow row in dataTable.Rows)
                    {
                        diveLocations.Add(row["name"].ToString());
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                }

                return diveLocations;
            }
        }

        public List<string> getAllFishNames()
        {
            List<string> fishes = new List<string>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT name FROM fishes", conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    foreach (DataRow row in dataTable.Rows)
                    {
                        fishes.Add(row["name"].ToString());
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                }

                return fishes;
            }
        }

        public String getDiveLocationInfo(String diveLocationName, String column)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM divelocations WHERE name = @name", conn);
                    cmd.Parameters.AddWithValue("@name", diveLocationName);
                    cmd.ExecuteNonQuery();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    DataRow info = dataTable.Rows[0];

                    return info[column].ToString();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                }

                return "";
            }
        }

        public List<string> getFishesForDiveLocation(String diveLocationName)
        {
            List<string> fishes = new List<string>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT fishes_name FROM divelocations_has_fishes WHERE divelocations_name = @name", conn);
                    cmd.Parameters.AddWithValue("@name", diveLocationName);
                    cmd.ExecuteNonQuery();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    foreach (DataRow row in dataTable.Rows)
                    {
                        fishes.Add(row["fishes_name"].ToString());
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                }

                return fishes;
            }
        }

        public void addDiveLocation(String diveLocationName, String diveLocationDescription, DateTime diveLocationUpdated, String diveLocationWaterType)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    String quarry = "INSERT INTO `divelocations`(`name`, `description`, `last_updated`, `water_type`) VALUES ('" + diveLocationName + "','" + diveLocationDescription + "','" + diveLocationUpdated + "','" + diveLocationWaterType + "')";
                    MySqlCommand cmd = new MySqlCommand(quarry, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Duikstek succesvol aangemaakt");
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
