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
    /// Логика взаимодействия для WorkWithTheDriver.xaml
    /// </summary>
    public partial class WorkWithTheAvto : Page
    {
        public WorkWithTheAvto()
        {
            InitializeComponent();
            //using (MyDBconnection db = new MyDBconnection())
            //{
            //    db.Drivers.Load();
            //    db.Passports.Load();
            //    DriverGrid.ItemsSource = db.Drivers.Local;
            //    
            //}
            
        }

        private void CreateDriver_Click(object sender, RoutedEventArgs e)
        {
            DriverGrid.Visibility = Visibility.Hidden;
            FrameFromNavigation.Visibility = Visibility.Visible;
            FrameFromNavigation.Navigate(new CreateDriver());
        }

        private void SerchDriver_Click(object sender, RoutedEventArgs e)
        {
            DriverGrid.Visibility = Visibility.Visible;
            FrameFromNavigation.Visibility = Visibility.Hidden;
            int DriverID;

           
        }

        private void OpenPeopleInfo_Click(object sender, RoutedEventArgs e)
        {
          
        }

        private void UpdateDriverInfo_Click(object sender, RoutedEventArgs e)
        {
          
        }
    }
}
 