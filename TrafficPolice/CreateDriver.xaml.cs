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
    /// Логика взаимодействия для CreateDriver.xaml
    /// </summary>
    public partial class CreateDriver : Page
    {
        public CreateDriver()
        {
            InitializeComponent();
            BitmapImage bitmapImage = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Image\\Additionally\\Photo.png", UriKind.Absolute)); ;
            Photo.Source = bitmapImage;
            PhotoButton.Width = bitmapImage.Width;
        }

        private void CreateDriverButton_Click(object sender, RoutedEventArgs e)
        {
            #region Check number and Series
            int PasSer, PasNum, LicSer, LicNum;
            if (PassSeries.Text.Length == 0 || PassSeries.Text.Length != 4) { MessageBox.Show("Серия паспорта состоит из 4-х цифр"); return; }
            else { try { PasSer = Convert.ToInt32(PassSeries.Text); } catch { MessageBox.Show("Серия паспорта состоит из 4-х цифр"); return; } }
            
            if (DriverLicenseSeries.Text.Length == 0 || DriverLicenseSeries.Text.Length != 4) { MessageBox.Show("Серия прав состоит из 4-х цифр"); return; }
            else { try { LicSer = Convert.ToInt32(DriverLicenseSeries.Text); } catch { MessageBox.Show("Серия прав состоит из 4-х цифр"); return; } }
           
            if(PassNumber.Text.Length == 0 || PassNumber.Text.Length != 6) { MessageBox.Show("Номер паспорта состоит из 6 цифр");return; }
            else { try { PasNum = Convert.ToInt32(PassNumber.Text); } catch { MessageBox.Show("Номер паспорта состоит из 6 цифр"); return; } }
           
            if (DriverLicenceNumber.Text.Length == 0 || DriverLicenceNumber.Text.Length != 6) { MessageBox.Show("Номер прав состоит из 6 цифр"); return; }
            else { try { PasNum = Convert.ToInt32(DriverLicenceNumber.Text); } catch { MessageBox.Show("Номер прав состоит из 6 цифр"); return; } }
            #endregion


        }
    }
}
