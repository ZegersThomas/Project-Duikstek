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
        private String diveLocationName;

        public PageBewerkDuiksteks()
        {
            InitializeComponent();
            loadDiveLocations();
            LoadFishes();
        }

        //Nieuwe of bestaande duikstek kiezen
        private void loadDiveLocations()
        {
            selectDiveLocation.Items.Clear();
            List<string> diveLocations = new List<string>(diveLocationsDb.getAllDivingLocations());

            foreach (String name in diveLocations)
            {
                selectDiveLocation.Items.Add(name);
            }
        }

        private void newDiveLocation_Checked(object sender, RoutedEventArgs e)
        {
            selectDiveLocation.IsEnabled = false;
            btnAddDiveLocation.Visibility = Visibility.Visible;
            btnUpdateDiveLocation.Visibility = Visibility.Collapsed;
            btnRemoveDiveLocation.Visibility = Visibility.Collapsed;
            tbName.IsEnabled = true;
            clearInfo();
            enableInteractions();
        }

        private void existingDiveLocation_Checked(object sender, RoutedEventArgs e)
        {
            selectDiveLocation.IsEnabled = true;
            btnAddDiveLocation.Visibility = Visibility.Collapsed;
            btnUpdateDiveLocation.Visibility = Visibility.Visible;
            btnRemoveDiveLocation.Visibility = Visibility.Visible;
            tbName.IsEnabled = false;
            enableInteractions();
            setinfo();
        }
        private void selectDiveLocation_SelectionChanged(object sender, RoutedEventArgs e)
        {
            setinfo();
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

        private void setinfo()
        {
            if (selectDiveLocation.SelectedItem != null)
            {
                diveLocationName = selectDiveLocation.SelectedItem.ToString();
            }
            else 
            { 
                return;
            }

            tbName.Text = diveLocationName;
            tbDescription.Text = diveLocationsDb.getDiveLocationInfo(diveLocationName, "description");

            lbFishes.Items.Clear();
            List<string> fishes = new List<string>(diveLocationsDb.getFishesForDiveLocation(diveLocationName));
            foreach (String fish in fishes)
            {
                lbFishes.Items.Add(fish);
            }

            String waterType = diveLocationsDb.getDiveLocationInfo(diveLocationName, "water_type");
            switch (waterType)
            {
                case "Zout":
                    saltwater.IsChecked = true;
                    break;
                case "Zoet":
                    freshwater.IsChecked = true;
                    break;
                case "anders":
                    other.IsChecked = true;
                    break;
                default:
                    break;
            }

            lastUpdated.Text = diveLocationsDb.getDiveLocationInfo(diveLocationName, "last_updated");
        }

        private void clearInfo()
        {
            tbName.Text = "";
            tbDescription.Text = "";
            lbFishes.Items.Clear();
            saltwater.IsChecked = false;
            freshwater.IsChecked = false;
            other.IsChecked = false;
            lastUpdated.Text = "";
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
                lbFishes.Items.Add(fishName);
            }
            else
            {
                MessageBox.Show("Selecteer een vis");
            }
        }

        private void btnRemoveFish_Click(object sender, RoutedEventArgs e)
        {
            if (lbFishes.SelectedItem != null)
            {
                lbFishes.Items.Remove(lbFishes.SelectedItem);
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
                lbFishes.Items.Clear();
            }
        }

        //Knoppen om de duikstek toe te voegen/updaten of te verwijderen
        private void btnAddDiveLocation_Click(object sender, RoutedEventArgs e)
        {
            diveLocationsDb.addDiveLocation(tbName.Text, tbDescription.Text, (DateTime)lastUpdated.SelectedDate, getWaterType());
            clearInfo();
            loadDiveLocations();
            clearInfo();
        }

        private void btnUpdateDiveLocation_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRemoveDiveLocation_Click(object sender, RoutedEventArgs e)
        {
            if (diveLocationName != null)
            {
                MessageBoxResult result = MessageBox.Show("Weet je zeker dat je de duikstek wilt verwijderen?",
                                                      "Bevestiging",
                                                      MessageBoxButton.YesNo,
                                                      MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    diveLocationsDb.deleteDiveLocation(diveLocationName);
                }

                loadDiveLocations();
                clearInfo();
            }
        }

        private String getWaterType()
        {
            if (saltwater.IsChecked == true)
            {
                return "Zout";
            }
            else if (freshwater.IsChecked == true)
            {
                return "Zoet";
            }
            else
            {
                return "anders";
            }
        }


    }
}
