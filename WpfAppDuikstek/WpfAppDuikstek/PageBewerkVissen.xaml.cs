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
        public PageBewerkVissen()
        {
            InitializeComponent();
        }

        private void newFish_Checked(object sender, RoutedEventArgs e)
        {
            selectFish.IsEnabled = false;
        }

        private void existingFish_Checked(object sender, RoutedEventArgs e)
        {
            selectFish.IsEnabled = true;
        }
    }
}
