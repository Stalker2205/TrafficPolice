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
    /// Логика взаимодействия для SerchAvto.xaml
    /// </summary>
    public partial class SerchAvto : Page
    {
        public SerchAvto()
        {
            InitializeComponent();
        }

        private void SertcVinButton_Click(object sender, RoutedEventArgs e)
        {
            FrameForNavigation.Navigate(new SerchInCars());
        }

        private void SerchDriverLicenseButton_Click(object sender, RoutedEventArgs e)
        {
            FrameForNavigation.Navigate(new SerchDriverLicencePage());
        }

        private void SerchPassportButton_Click(object sender, RoutedEventArgs e)
        {
            FrameForNavigation.Navigate(new SerchPassport());
        }

        private void SertchInsuranceButton_Click(object sender, RoutedEventArgs e)
        {
            FrameForNavigation.Navigate(new SerchIncurance());
        }

        private void SerchCtcButton_Click(object sender, RoutedEventArgs e)
        {
            FrameForNavigation.Navigate(new SerchSTS());
        }

        private void SerchPtcButton_Click(object sender, RoutedEventArgs e)
        {
            FrameForNavigation.Navigate(new SerchPTC());
        }
    }
}
