using System;
using System.Collections.Generic;
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

namespace WpfAppDuikstek
{
    public partial class PageBewerkVissen : Page
    {
        private diveLocationsDb diveLocationsDb = new diveLocationsDb();
        private String fishName;

        public PageBewerkVissen()
        {
            InitializeComponent();
            loadFishNames();
        }

        //Nieuwe of bestaande vis kiezen
        private void loadFishNames()
        {
            selectFish.Items.Clear();
            List<string> fishNames = new List<string>(diveLocationsDb.getAllFishNames());

            foreach (String name in fishNames)
            {
                selectFish.Items.Add(name);
            }
        }

        private void newFish_Checked(object sender, RoutedEventArgs e)
        {
            selectFish.IsEnabled = false;
            btnAddFish.Visibility = Visibility.Visible;
            btnUpdateFish.Visibility = Visibility.Collapsed;
            btnRemoveFish.Visibility = Visibility.Collapsed;
            tbName.IsEnabled = true;
            clearInfo();
            enableInteractions();
        }

        private void existingFish_Checked(object sender, RoutedEventArgs e)
        {
            selectFish.IsEnabled = true;
            btnAddFish.Visibility = Visibility.Collapsed;
            btnUpdateFish.Visibility = Visibility.Visible;
            btnRemoveFish.Visibility = Visibility.Visible;
            tbName.IsEnabled = false;
            enableInteractions();
            setinfo();
        }

        private void selectFish_SelectionChanged(object sender, RoutedEventArgs e)
        {
            setinfo();
        }

        private void enableInteractions()
        {
            tbDescription.IsEnabled = true;
            saltwater.IsEnabled = true;
            freshwater.IsEnabled = true;
            other.IsEnabled = true;
            tbColors.IsEnabled = true;
            tbAvgSize.IsEnabled = true;
            lastUpdated.IsEnabled = true;
            btnAddFish.IsEnabled = true;
            btnUpdateFish.IsEnabled = true;
            btnRemoveFish.IsEnabled = true;
        }

        private void setinfo()
        {
            if (selectFish.SelectedItem != null)
            {
                fishName = selectFish.SelectedItem.ToString();
            }
            else
            {
                return;
            }

            tbName.Text = fishName;
            tbDescription.Text = diveLocationsDb.getFishInfo(fishName, "description");

            String waterType = diveLocationsDb.getFishInfo(fishName, "water_type");
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

            tbColors.Text = diveLocationsDb.getFishInfo(fishName, "colors");
            tbAvgSize.Text = diveLocationsDb.getFishInfo(fishName, "avg_size");
            lastUpdated.Text = diveLocationsDb.getFishInfo(fishName, "last_updated");
        }

        private void clearInfo()
        {
            tbName.Text = "";
            tbDescription.Text = "";
            saltwater.IsChecked = false;
            freshwater.IsChecked = false;
            other.IsChecked = false;
            tbColors.Text = "";
            tbAvgSize.Text = "";
            lastUpdated.Text = "";
        }

        //Knoppen om de vis toe te voegen/updaten of te verwijderen
        private void btnAddFish_Click(object sender, RoutedEventArgs e)
        {
            if (checkData())
            {
                if (!(checkIfFishExists(tbName.Text)))
                {
                    diveLocationsDb.addFish(tbName.Text, tbDescription.Text, getWaterType(), tbColors.Text, tbAvgSize.Text, (DateTime)lastUpdated.SelectedDate);
                    loadFishNames();
                    clearInfo();
                }
            }
        }

        private void btnUpdateFish_Click(object sender, RoutedEventArgs e)
        {
            if (checkData())
            {
                diveLocationsDb.updateFish(tbName.Text, tbDescription.Text, getWaterType(), tbColors.Text, tbAvgSize.Text, (DateTime)lastUpdated.SelectedDate);
            }
        }

        private void btnRemoveFish_Click(object sender, RoutedEventArgs e)
        {
            if (fishName != null)
            {
                MessageBoxResult result = MessageBox.Show("Weet je zeker dat je de vis wilt verwijderen?",
                                                      "Bevestiging",
                                                      MessageBoxButton.YesNo,
                                                      MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    diveLocationsDb.deleteFish(fishName);
                }

                loadFishNames();
                clearInfo();
            }
        }

        private bool checkData()
        {
            if (tbName.Text != "" && tbDescription.Text != "" && (saltwater.IsChecked == true || freshwater.IsChecked == true || other.IsChecked == true) && lastUpdated.SelectedDate != null)
            {
                return true;
            }
            MessageBox.Show("Vul alle velden in");
            return false;
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

        private bool checkIfFishExists(String fish)
        {
            List<string> fishNames = new List<string>(diveLocationsDb.getAllFishNames());

            foreach (String name in fishNames)
            {
                if (name.ToLower() == fish.ToLower())
                {
                    MessageBox.Show("Vis bestaat al");
                    return true;
                }
            }
            return false;
        }

    }
}
