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
        }
        bool key = false;
        string photoName;
        private void CreateDriverButton_Click(object sender, RoutedEventArgs e)
        {
            #region Check number and Series
            int PasSer, PasNum, LicSer, LicNum;
            if (TextBox_PassportSeries.Text.Length == 0 || TextBox_PassportSeries.Text.Length != 4) { MessageBox.Show("Серия паспорта состоит из 4-х цифр"); return; }
            else { try { PasSer = Convert.ToInt32(TextBox_PassportSeries.Text); } catch { MessageBox.Show("Серия паспорта состоит из 4-х цифр"); return; } }

            if (TextBox_DriverLicenseSeries.Text.Length == 0 || TextBox_DriverLicenseSeries.Text.Length != 4) { MessageBox.Show("Серия прав состоит из 4-х цифр"); return; }
            else { try { LicSer = Convert.ToInt32(TextBox_DriverLicenseSeries.Text); } catch { MessageBox.Show("Серия прав состоит из 4-х цифр"); return; } }

            if (TextBox_PassportNumber.Text.Length == 0 || TextBox_PassportNumber.Text.Length != 6) { MessageBox.Show("Номер паспорта состоит из 6 цифр"); return; }
            else { try { PasNum = Convert.ToInt32(TextBox_PassportNumber.Text); } catch { MessageBox.Show("Номер паспорта состоит из 6 цифр"); return; } }

            if (TextBox_DriverLicenseNumber.Text.Length == 0 || TextBox_DriverLicenseNumber.Text.Length != 6) { MessageBox.Show("Номер прав состоит из 6 цифр"); return; }
            else { try { PasNum = Convert.ToInt32(TextBox_DriverLicenseNumber.Text); } catch { MessageBox.Show("Номер прав состоит из 6 цифр"); return; } }
            #endregion
            #region Check datetime
            if (DatePicker_DateOfIssue.SelectedDate.Value.Date.Year < 1900) { MessageBox.Show($"Человеку не может быть {DateTime.Now.Date.Year - DatePicker_DateOfIssue.SelectedDate.Value.Date.Year} лет"); return; }
            if ((DatePicker_FinishDate.SelectedDate.Value.Date.Year - DatePicker_StartDate.SelectedDate.Value.Date.Year) < 0) { MessageBox.Show("Дата окончания должна быть больше даты выдачи"); return; }
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
                var pas1 = db.Passports.Local.Where(x => x.PassportNumber == Convert.ToInt32(TextBox_PassportNumber.Text) && x.PassportSeries == Convert.ToInt32(TextBox_PassportSeries.Text));
                foreach (Passport passport in pas1) { passID = passport.PassportID; }
                if (passID != null) { MessageBox.Show("Такой паспорт уже есть в системе"); return; }
                var drad = db.DriversLicenses.Local.Where(x => x.DriversLicenseNumber == Convert.ToInt32(TextBox_DriverLicenseNumber.Text) && x.DriversLicenseSeries == Convert.ToInt32(TextBox_DriverLicenseSeries.Text));
                foreach (DriversLicense dl in drad) { LicenceID = dl.DriversLicenseID; }
                if (LicenceID != null) { MessageBox.Show("Такие права уже существуют"); return; }
                Driver driver = new Driver();
                driver.FirstName = TextBox_FirstName.Text;
                driver.LastName = TextBox_LastName.Text;
                driver.Patronymic = TextBox_Patronimic.Text;
             //   driver.Photo = photoName;
                db.Drivers.Add(driver);
                db.SaveChanges();
                db.Drivers.Load();
                //var driv = db.Drivers.Local.Where(x => x.Photo == photoName);
               // foreach (Driver dr in driv) { driverId = dr.DriverID; }
                Passport pass = new Passport();
                pass.PassportID = driverId;
                pass.PassportNumber = Convert.ToInt32(TextBox_PassportNumber.Text);
                pass.PassportSeries = Convert.ToInt32(TextBox_PassportSeries.Text);
                pass.PassportAdress = TextBox_Adress.Text;
                pass.DateOfIssue = DatePicker_DateOfIssue.DisplayDate.Date;
                db.Passports.Add(pass);
                DriversLicense driversLicense = new DriversLicense();
                driversLicense.DriverID = driverId;
                driversLicense.DriversLicenseNumber = Convert.ToInt32(TextBox_DriverLicenseNumber.Text);
                driversLicense.DriversLicenseSeries = Convert.ToInt32(TextBox_DriverLicenseSeries.Text);
                // driversLicense.Category = Kategory.Text;
                driversLicense.DateStart = DatePicker_StartDate.DisplayDate.Date;
                driversLicense.DateEnd = DatePicker_FinishDate.DisplayDate.Date;
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

