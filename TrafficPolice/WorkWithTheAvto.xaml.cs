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
            using(MyDBconnection db = new MyDBconnection())
            {
                db.Cars.Load();
                CarGrid.ItemsSource = db.Cars.Local;
            }



        }

        private void Avto_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SerchPTS_Click(object sender, RoutedEventArgs e)
        {
            CarGrid.Visibility = Visibility.Hidden;
            FrameForNavigation.Visibility = Visibility.Visible;
            try
            {
                AvtoClass.AvtoID = Convert.ToInt32(AvtoId.Text);
            }
            catch { MessageBox.Show("Id должно быть числом!");return; }
            FrameForNavigation.Navigate(new SerchWithPTS());
        }
    }
}
