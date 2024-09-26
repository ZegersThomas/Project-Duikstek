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
        private diveLocationsDb diveLocationsDb = new diveLocationsDb();

        public PageBewerkDuiksteks()
        {
            InitializeComponent();
            loadDiveLocations();
            LoadFishes();
        }

        //Nieuwe of bestaande duikstek kiezen
        private void newDiveLocation_Checked(object sender, RoutedEventArgs e)
        {
            selectDiveLocation.IsEnabled = false;
            btnAddDiveLocation.Visibility = Visibility.Visible;
            btnUpdateDiveLocation.Visibility = Visibility.Collapsed;
            tbName.IsEnabled = true;
            enableInteractions();
        }

        private void existingDiveLocation_Checked(object sender, RoutedEventArgs e)
        {
            selectDiveLocation.IsEnabled = true;
            btnAddDiveLocation.Visibility = Visibility.Collapsed;
            btnUpdateDiveLocation.Visibility = Visibility.Visible;
            tbName.IsEnabled = false;
            enableInteractions();
        }

        private void enableInteractions()
        {
            tbDescription.IsEnabled = true;
            cmbFishes.IsEnabled = true;
            btnAddFish.IsEnabled = true;
            btnRemoveFish.IsEnabled = true;
            btnRemoveAllFish.IsEnabled = true;
            saltwater.IsEnabled = true;
            freshwater.IsEnabled = true;
            other.IsEnabled = true;
            lastUpdated.IsEnabled = true;
            btnAddDiveLocation.IsEnabled = true;
            btnUpdateDiveLocation.IsEnabled = true;
            btnRemoveDiveLocation.IsEnabled = true;
        }

        private void loadDiveLocations()
        {
            List<string> diveLocations = new List<string>(diveLocationsDb.getAllDivingLocations());

            foreach (String name in diveLocations)
            {
                selectDiveLocation.Items.Add(name);
            }
        }

        //Vissen aan een duikstek toevoegen of verwijderen
        private void LoadFishes()
        {
            List<string> fishNames = new List<string>(diveLocationsDb.getAllFishNames());

            foreach (String name in fishNames)
            {
                cmbFishes.Items.Add(name);
            }
        }

        private void btnAddFish_Click(object sender, RoutedEventArgs e)
        {
            if(cmbFishes.SelectedItem != null)
            {
                string fishName = cmbFishes.SelectedItem.ToString();
                fishes.Items.Add(fishName);
            }
            else
            {
                MessageBox.Show("Selecteer een vis");
            }
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

        //Knoppen om de duikstek toe te voegen/updaten of te verwijderen
        private void btnAddDiveLocation_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdateDiveLocation_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRemoveDiveLocation_Click(object sender, RoutedEventArgs e)
        {

        }

        
    }
}
