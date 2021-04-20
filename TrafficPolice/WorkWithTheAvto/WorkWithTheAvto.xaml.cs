using System;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TrafficPolice
{
    /// <summary>
    /// Логика взаимодействия для WorkWithTheDriver.xaml
    /// </summary>
    public partial class WorkWithTheAvto : Page
    {
        private string _id;
        public WorkWithTheAvto()
        {
            InitializeComponent();
            using (MyDBconnection db = new MyDBconnection())
            {
                db.Cars.Load();
                dgCar.ItemsSource = db.Cars.Local;
            }
        }

        private void MenuItem_SubmenuOpened_1(object sender, RoutedEventArgs e)
        {
            _id = ((MenuItem)sender).Header.ToString();
            CarClass.ID = Convert.ToInt32(_id);
        }

        private void bt_registredCar_Click(object sender, RoutedEventArgs e)
        {
            FrameFromNavigation.Visibility = Visibility.Visible;
            FrameFromNavigation.Navigate(new CreateCar());
            dgCar.Visibility = Visibility.Hidden;
        }
    }
}

