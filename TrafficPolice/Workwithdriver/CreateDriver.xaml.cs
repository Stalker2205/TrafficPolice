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
    public partial class CreateDriver : Page
    {
        public CreateDriver()
        {
            InitializeComponent();
            BitmapImage bitmapImage = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\Image\\Additionally\\Photo.png", UriKind.Absolute)); ;
            Photo.Source = bitmapImage;
            PhotoButton.Width = bitmapImage.Width;
        }
        bool key = false;
        string photoName;
        private void CreateDriverButton_Click(object sender, RoutedEventArgs e)
        {
            #region Check number and Series
            int PasSer, PasNum, LicSer, LicNum;
            if (PassSeries.Text.Length == 0 || PassSeries.Text.Length != 4) { MessageBox.Show("Серия паспорта состоит из 4-х цифр"); return; }
            else { try { PasSer = Convert.ToInt32(PassSeries.Text); } catch { MessageBox.Show("Серия паспорта состоит из 4-х цифр"); return; } }

            if (DriverLicenseSeries.Text.Length == 0 || DriverLicenseSeries.Text.Length != 4) { MessageBox.Show("Серия прав состоит из 4-х цифр"); return; }
            else { try { LicSer = Convert.ToInt32(DriverLicenseSeries.Text); } catch { MessageBox.Show("Серия прав состоит из 4-х цифр"); return; } }

            if (PassNumber.Text.Length == 0 || PassNumber.Text.Length != 6) { MessageBox.Show("Номер паспорта состоит из 6 цифр"); return; }
            else { try { PasNum = Convert.ToInt32(PassNumber.Text); } catch { MessageBox.Show("Номер паспорта состоит из 6 цифр"); return; } }

            if (DriverLicenceNumber.Text.Length == 0 || DriverLicenceNumber.Text.Length != 6) { MessageBox.Show("Номер прав состоит из 6 цифр"); return; }
            else { try { PasNum = Convert.ToInt32(DriverLicenceNumber.Text); } catch { MessageBox.Show("Номер прав состоит из 6 цифр"); return; } }
            #endregion
            #region Check datetime
            if (StartDate.SelectedDate.Value.Date.Year < 1900) { MessageBox.Show($"Человеку не может быть {DateTime.Now.Date.Year - StartDate.SelectedDate.Value.Date.Year} лет"); return; }
            if (Vidali.SelectedDate.Value.Date.Year < 1900) { MessageBox.Show($"Человеку не может быть {DateTime.Now.Date.Year - StartDate.SelectedDate.Value.Date.Year} лет"); return; }
            if ((FinishDate.SelectedDate.Value.Date.Year - StartDate.SelectedDate.Value.Date.Year) > 150) { MessageBox.Show($"На данный момент, человек не может прожить больше 150 лет"); return; }

            #endregion
            #region Kanegory Mass
            string[] kategory = new string[16];
            kategory[0] = "A"; kategory[1] = "A1";
            kategory[2] = "B"; kategory[3] = "B1";
            kategory[4] = "C"; kategory[5] = "C1";
            kategory[6] = "D"; kategory[7] = "D1";
            kategory[8] = "BE"; kategory[9] = "CE";
            kategory[10] = "C1E"; kategory[11] = "DE";
            kategory[12] = "D1E"; kategory[13] = "M";
            kategory[14] = "Tm"; kategory[15] = "Tb";
            #endregion
            #region add Driver,Passport,DriverLicence
            if (!key) { MessageBox.Show("Необходимо выбрать фото!"); return; }
            int driverId = 0;
            int? passID = null;
            int? LicenceID = null;
            using (MyDBconnection db = new MyDBconnection())
            {

                db.Passports.Load();
                db.DriversLicenses.Load();
                var pas1 = db.Passports.Local.Where(x => x.PassportNumber == Convert.ToInt32(PassNumber.Text) && x.PassportSeries == Convert.ToInt32(PassSeries.Text));
                foreach (Passport passport in pas1) { passID = passport.PassportID; }
                if (passID != null) { MessageBox.Show("Такой паспорт уже есть в системе"); return; }
                var drad = db.DriversLicenses.Local.Where(x => x.DriversLicenseNumber == Convert.ToInt32(DriverLicenceNumber.Text) && x.DriversLicenseSeries == Convert.ToInt32(DriverLicenseSeries.Text));
                foreach (DriversLicense dl in drad) { LicenceID = dl.DriversLicenseID; }
                if (LicenceID != null) { MessageBox.Show("Такие права уже существуют"); return; }
                Driver driver = new Driver();
                driver.FirstName = FirstName.Text;
                driver.LastName = LastName.Text;
                driver.Patronymic = Patronimic.Text;
                driver.Photo = photoName;
                db.Drivers.Add(driver);
                db.SaveChanges();
                db.Drivers.Load();
                var driv = db.Drivers.Local.Where(x => x.Photo == photoName);
                foreach (Driver dr in driv) { driverId = dr.DriverID; }
                Passport pass = new Passport();
                pass.PassportID = driverId;
                pass.PassportNumber = Convert.ToInt32(PassNumber.Text);
                pass.PassportSeries = Convert.ToInt32(PassSeries.Text);
                pass.PassportAdress = Adress.Text;
                pass.DateOfIssue = Vidali.DisplayDate.Date;
                db.Passports.Add(pass);
                DriversLicense driversLicense = new DriversLicense();
                driversLicense.DriverID = driverId;
                driversLicense.DriversLicenseNumber = Convert.ToInt32(DriverLicenceNumber.Text);
                driversLicense.DriversLicenseSeries = Convert.ToInt32(DriverLicenseSeries.Text);
                driversLicense.Category = Kategory.Text;
                driversLicense.DateStart = StartDate.DisplayDate.Date;
                driversLicense.DateEnd = FinishDate.DisplayDate.Date;
                db.DriversLicenses.Add(driversLicense);
                db.SaveChanges();
            }
            #endregion
            MessageBox.Show("Добавлено!"); return;
        }

        private void PhotoButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image (*.png;*.jpg;*.BMP)|*.png;*.jpg;*.BMP";
            if (dialog.ShowDialog() == true)
            {
                Photo.Source = new BitmapImage(new Uri(dialog.FileName));
                File.Copy(dialog.FileName, AppDomain.CurrentDomain.BaseDirectory + $"\\Image\\Photo\\{dialog.SafeFileName}");
                key = true;
                photoName = dialog.SafeFileName;
            }
        }
    }
}
