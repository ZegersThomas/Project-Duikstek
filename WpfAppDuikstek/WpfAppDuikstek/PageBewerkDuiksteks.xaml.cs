using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace WpfAppDuikstek
{
    public partial class PageBewerkDuiksteks : Page
    {

        public PageBewerkDuiksteks()
        {
            InitializeComponent();
            LoadData();
        }

        private void newDuikstek_Checked(object sender, RoutedEventArgs e)
        {
            selectDuikstek.IsEnabled = false;
        }

        private void existingDuikstek_Checked(object sender, RoutedEventArgs e)
        {
            selectDuikstek.IsEnabled = true;
        }

        private void btnAddFish_Click(object sender, RoutedEventArgs e)
        {
            fishes.Items.Add("Test Vis");
        }

        private void btnRemoveFish_Click(object sender, RoutedEventArgs e)
        {
            if (fishes.SelectedItem != null)
            {
                fishes.Items.Remove(fishes.SelectedItem);
            }
            else
            {
                MessageBox.Show("Selecteer een item om te verwijderen.");
            }
        }

        private void btnRemoveAllFish_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Weet je zeker dat je alle vissen wilt verwijderen?",
                                                      "Bevestiging",
                                                      MessageBoxButton.YesNo,
                                                      MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                fishes.Items.Clear();
            }
        }

        private void btnUpdateDuikstek_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRemoveDuikstek_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LoadData()
        {
            string connectionString = "Server=localhost;Database=duikstekdb;Uid=root;Pwd=;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT naam FROM vissen", conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    foreach (DataRow row in dataTable.Rows)
                    {
                        fishes.Items.Add(row["naam"].ToString());
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
            }
        }
    }
}
