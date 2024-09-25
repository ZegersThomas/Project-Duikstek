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
    public partial class PageBewerkDuiksteks : Page
    {
        public PageBewerkDuiksteks()
        {
            InitializeComponent();
        }

        private void newDuikstek_Checked(object sender, RoutedEventArgs e)
        {
            selectDuikstek.IsEnabled = false;
        }

        private void existingDuikstek_Checked(object sender, RoutedEventArgs e)
        {
            selectDuikstek.IsEnabled = true;
        }

        //private bool ShouldRemoveChild(UIElement child)
        //{
        //    if (child is FrameworkElement frameworkElement)
        //    {
        //        return frameworkElement.Tag == null || frameworkElement.Tag.ToString() != "keep";
        //    }

        //    return true;
        //}

        private void btnAddFish_Click(object sender, RoutedEventArgs e)
        {
            //foreach (var child in addFishPanel.Children.OfType<UIElement>().ToList())
            //{
            //    if (ShouldRemoveChild(child))
            //    {
            //        addFishPanel.Children.Remove(child);
            //    }
            //}

            //ComboBox newFish = new ComboBox()
            //{

            //};
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
    }
}
