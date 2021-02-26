using System;
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
using System.IO;
using Microsoft.Win32;

namespace TrafficPolice
{
    /// <summary>
    /// Логика взаимодействия для CreateDriver.xaml
    /// </summary>
    public partial class ViewDriver : Page
    {
        public ViewDriver()
        {
            InitializeComponent();
            FirstName.IsReadOnly = true;
            LastName.IsReadOnly = true;
            Patronimic.IsReadOnly = true;
            PassNumber.IsReadOnly = true;
            PassSeries.IsReadOnly = true;
            Adress.IsReadOnly = true;
            using (MyDBconnection db = new MyDBconnection())
            {
                db.Drivers.Load();
                db.Passports.Load();
                db.DriversLicenses.Load();
                DriverLicenseGrid.ItemsSource = db.DriversLicenses.Local.Where(x => x.DriverID == DriverClass.DriverID);
                var driver1 = db.Drivers.Local.Where(x => x.DriverID == DriverClass.DriverID);
                var passport = db.Passports.Local.Where(x => x.PassportID == DriverClass.DriverID);
                foreach(Driver driver in driver1)
                {
                    FirstName.Text = driver.FirstName;
                    LastName.Text = driver.LastName;
                    Patronimic.Text = driver.Patronymic;
                    try
                    {
                        Photo.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + $"\\Image\\Photo\\{driver.Photo}"));
                    }
                    catch { Photo.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + $"\\Image\\Additionally\\Photo.png")); }
                }
                foreach(Passport ps in passport)
                {
                    PassSeries.Text = ps.PassportSeries.ToString() ;
                    PassNumber.Text = ps.PassportNumber.ToString();
                    Adress.Text = ps.PassportAdress.ToString();
                    Vidali.SelectedDate = ps.DateOfIssue.Date.Date;
                }
            }

        }
    }
}
