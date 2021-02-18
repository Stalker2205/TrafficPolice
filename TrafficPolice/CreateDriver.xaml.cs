﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace TrafficPolice
{
    /// <summary>
    /// Логика взаимодействия для CreateDriver.xaml
    /// </summary>
    public partial class CreateDriver : Page
    {
        public CreateDriver()
        {
            InitializeComponent();
            Photo.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Image\\Additionally\\Photo.png", UriKind.Absolute));
            PhotoButton.Width = Photo.Width;
            using (MyDBconnection db = new MyDBconnection())
            {
                db.Passports.Load();
                db.DriversLicenses.Load();
                PassportComboBox.ItemsSource = db.Passport.Local;
                DriverLicenseComboBox.ItemsSource = db.DriversLicenses.Local;
                DriverLicenseDataGrid.ItemsSource = db.DriversLicenses.Local;
                
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
