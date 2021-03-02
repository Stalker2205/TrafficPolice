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
    public partial class UpdateDriver : Page
    {
        public UpdateDriver()
        {
            InitializeComponent();
            using (MyDBconnection db = new MyDBconnection())
            {
                db.Drivers.Load();
                db.Passports.Load();
                var driv = db.Drivers.Local.Where(x => x.DriverID == DriverClass.DriverID);
                var pass = db.Passports.Local.Where(x => x.PassportID == DriverClass.DriverID);
                foreach (Driver driver in driv)
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
                foreach (Passport passport in pass)
                {
                    PassNumber.Text = passport.PassportNumber.ToString();
                    PassSeries.Text = passport.PassportSeries.ToString();
                    Adress.Text = passport.PassportAdress.ToString();
                }
            }



        }
        bool key = false;
        string photoName;
        private void CreateDriverButton_Click(object sender, RoutedEventArgs e)
        {
            #region Check number and Series
            int PasSer, PasNum;
            if (PassSeries.Text.Length == 0 || PassSeries.Text.Length != 4) { MessageBox.Show("Серия паспорта состоит из 4-х цифр"); return; }
            else { try { PasSer = Convert.ToInt32(PassSeries.Text); } catch { MessageBox.Show("Серия паспорта состоит из 4-х цифр"); return; } }

            if (PassNumber.Text.Length == 0 || PassNumber.Text.Length != 6) { MessageBox.Show("Номер паспорта состоит из 6 цифр"); return; }
            else { try { PasNum = Convert.ToInt32(PassNumber.Text); } catch { MessageBox.Show("Номер паспорта состоит из 6 цифр"); return; } }
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
            #region Update
            if (!key) { MessageBox.Show("Необходимо выбрать фото!"); return; }
            using(MyDBconnection db = new MyDBconnection())
            {
               Driver driv = db.Drivers.Where(x => x.DriverID == DriverClass.DriverID).FirstOrDefault();
                driv.FirstName = FirstName.Text;
                driv.LastName = LastName.Text;
                driv.Patronymic = Patronimic.Text;
               // driv.Photo = photoName;
                db.SaveChanges();
                Passport pass = db.Passports.Where(x => x.PassportID == DriverClass.DriverID).FirstOrDefault();
                pass.PassportSeries =PasSer;
                pass.PassportNumber = PasNum;
                pass.PassportAdress = Adress.Text;
                db.SaveChanges();
            }
            #endregion
            MessageBox.Show("Добавлено!"); key = false;
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
