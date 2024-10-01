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

        public String getFishInfo(String fishName, String column)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM fishes WHERE name = @name", conn);
                    cmd.Parameters.AddWithValue("@name", fishName);
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
                    String quarry = "INSERT INTO `divelocations`(`name`, `description`, `last_updated`, `water_type`) VALUES ('" + diveLocationName + "','" + diveLocationDescription + "','" + diveLocationUpdated.ToString("yyyy-MM-dd") + "','" + diveLocationWaterType + "')";
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

        public void updateDiveLocation(String diveLocationName, String diveLocationDescription, DateTime diveLocationUpdated, String diveLocationWaterType)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    String quarry = "UPDATE divelocations SET description='" + diveLocationDescription + "',last_updated='" + diveLocationUpdated.ToString("yyyy-MM-dd") + "',water_type='" + diveLocationWaterType + "' WHERE name='" + diveLocationName + "'";
                    MySqlCommand cmd = new MySqlCommand(quarry, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Duikstek succesvol bijgewerkt");
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

        public void deleteDiveLocation(String diveLocationName)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    String quarry = "DELETE FROM divelocations WHERE name='" + diveLocationName + "'";
                    MySqlCommand cmd = new MySqlCommand(quarry, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Duikstek succesvol verwijderd");
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

        public void addFishToDiveLocation(String diveLocation, String fish)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    String quarry = "INSERT INTO `divelocations_has_fishes`(`DiveLocations_name`, `Fishes_name`) VALUES ('" + diveLocation + "','" + fish + "')";
                    MySqlCommand cmd = new MySqlCommand(quarry, conn);
                    cmd.ExecuteNonQuery();
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

        public void removeFishFromDiveLocation(String diveLocation, String fish)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    String quarry = "DELETE FROM divelocations_has_fishes WHERE `DiveLocations_name`='" + diveLocation + "' AND `Fishes_name`='" + fish + "'";
                    MySqlCommand cmd = new MySqlCommand(quarry, conn);
                    cmd.ExecuteNonQuery();
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

        public void removeAllFishFromDiveLocation(String diveLocation)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    String quarry = "DELETE FROM divelocations_has_fishes WHERE `DiveLocations_name`='" + diveLocation + "'";
                    MySqlCommand cmd = new MySqlCommand(quarry, conn);
                    cmd.ExecuteNonQuery();
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

        public void addFish(String name, String description, String waterType, String colors, String avgSize, DateTime lastUpdated)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    String quarry = "INSERT INTO `fishes`(`name`, `description`, `last_updated`, `water_type`, `colors`, `avg_size`) VALUES ('" + name + "','" + description + "','" + lastUpdated.ToString("yyyy-MM-dd") + "','" + waterType + "','" + colors + "','" + avgSize + "')";
                    MySqlCommand cmd = new MySqlCommand(quarry, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Vis succesvol aangemaakt");
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

        public void updateFish(String name, String description, String waterType, String colors, String avgSize, DateTime lastUpdated)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    String quarry = "UPDATE fishes SET description='" + description + "',last_updated='" + lastUpdated.ToString("yyyy-MM-dd") + "',water_type='" + waterType + "',colors='" + colors + "',avg_size='" + avgSize + "' WHERE name='" + name + "'";
                    MySqlCommand cmd = new MySqlCommand(quarry, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Vis succesvol bijgewerkt");
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

        public void deleteFish(String name)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    String quarry = "DELETE FROM divelocations_has_fishes WHERE `Fishes_name`='" + name + "'";
                    MySqlCommand cmd = new MySqlCommand(quarry, conn);
                    cmd.ExecuteNonQuery();

                    quarry = "DELETE FROM fishes WHERE name='" + name + "'";
                    cmd = new MySqlCommand(quarry, conn);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Vis succesvol verwijderd");
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
