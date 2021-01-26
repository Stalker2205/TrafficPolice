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

namespace TrafficPolice
{
    /// <summary>
    /// Логика взаимодействия для SerchInCars.xaml
    /// </summary>
    public partial class SerchInCars : Page
    {
        public SerchInCars()
        {
            InitializeComponent();
        }
        int PackageDocuments = 0;
        int Driver = 0;
        private void SerchVin_Click(object sender, RoutedEventArgs e)
        {
            using (MyDBconnection db = new MyDBconnection())
            {
                db.Cars.Load();

                DatagridFirst.ItemsSource = db.Cars.Local.Where(x => x.Vin == VinTbox.Text.ToString());
                var ur = db.Cars.Where(x => x.Vin == VinTbox.Text.ToString());
                foreach (Car car in ur) { PackageDocuments = car.CarID; ; Driver = car.DriverID; }
            }
        }

        private void SerchDriverLicence_Click(object sender, RoutedEventArgs e)
        {
            using(MyDBconnection db = new MyDBconnection())
            {
                db.DriversLicenses.Load();
                DatagridFirst.ItemsSource = db.DriversLicenses.Local.Where(x => x.DriverID == Driver);
            }
        }
    }
}
