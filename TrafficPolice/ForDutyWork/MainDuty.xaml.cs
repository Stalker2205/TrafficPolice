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

namespace TrafficPolice
{
    /// <summary>
    /// Логика взаимодействия для MainDuty.xaml
    /// </summary>
    public partial class MainDuty : Page
    {
        public MainDuty()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            dg_MainGrid.Visibility = Visibility.Hidden;
            WorkFrame.Visibility = Visibility.Visible;
            WorkFrame.Navigate(new RaportPage());
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            dg_MainGrid.Visibility = Visibility.Hidden;
            WorkFrame.Visibility = Visibility.Visible;
            WorkFrame.Navigate(new CreateStaff());
        }
    }
}
