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
    /// Логика взаимодействия для SerchInCars.xaml
    /// </summary>
    public partial class SerchDriverLicencePage : Page
    {
        public SerchDriverLicencePage()
        {
            InitializeComponent();
        }


        private void SerchDriverLicence_Click(object sender, RoutedEventArgs e)
        {
            if (!RequestsClass.keySerch)
            {
              RequestsClass.CheckDriverLicence(DriverLicenceSeriesTbox.Text.ToString(),DriverLicenceNumberTbox.Text.ToString()) ;  return;
            }
            using (MyDBconnection db = new MyDBconnection())
            {
                db.DriversLicenses.Load();
                DatagridFirst.ItemsSource = db.DriversLicenses.Local.Where(x => x.DriverID == RequestsClass.Driver);
            }
        }

        private void PtcSerch_Click(object sender, RoutedEventArgs e)
        {

            if (!RequestsClass.keySerch)
            {
                RequestsClass.CheckDriverLicence(DriverLicenceSeriesTbox.Text.ToString(), DriverLicenceNumberTbox.Text.ToString()); return;
            }
            using (MyDBconnection db = new MyDBconnection())
            {
                db.Ptcs.Load();
                DatagridFirst.ItemsSource = db.Ptcs.Local.Where(x => x.PtcID == RequestsClass.PackageDocuments);
            }
        }

        private void SetchInsurance_Click(object sender, RoutedEventArgs e)
        {

            if (!RequestsClass.keySerch)
            {
                RequestsClass.CheckDriverLicence(DriverLicenceSeriesTbox.Text.ToString(), DriverLicenceNumberTbox.Text.ToString()); return;
            }
            using (MyDBconnection db = new MyDBconnection())
            {
                db.Insurances.Load();
                DatagridFirst.ItemsSource = db.Insurances.Local.Where(x => x.InsuranceID == RequestsClass.PackageDocuments);
            }
        }

        private void SerchDriver_Click(object sender, RoutedEventArgs e)
        {

            if (!RequestsClass.keySerch)
            {
                RequestsClass.CheckDriverLicence(DriverLicenceSeriesTbox.Text.ToString(), DriverLicenceNumberTbox.Text.ToString()); return;
            }
            using (MyDBconnection db = new MyDBconnection())
            {
                db.Drivers.Load();
                DatagridFirst.ItemsSource = db.Drivers.Local.Where(x => x.DriverID == RequestsClass.Driver);
            }
        }

        private void SerchAvto_Click(object sender, RoutedEventArgs e)
        {

            if (!RequestsClass.keySerch)
            {
                RequestsClass.CheckDriverLicence(DriverLicenceSeriesTbox.Text.ToString(), DriverLicenceNumberTbox.Text.ToString()); return;
            }
            using (MyDBconnection db = new MyDBconnection())
            {
                db.Cars.Load();
                DatagridFirst.ItemsSource = db.Cars.Local.Where(x => x.DriverID == RequestsClass.Driver) ;
            }
        }

        private void DriverLicenceSeriesTbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            RequestsClass.keySerch = false;
        }
    }
}
