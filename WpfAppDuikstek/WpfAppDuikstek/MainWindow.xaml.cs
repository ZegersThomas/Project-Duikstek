﻿using System;
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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnBewerkDuiksteks_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new PageBewerkDuiksteks());
        }

        private void btnBewerkVissen_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new PageBewerkVissen());
        }
    }
}
