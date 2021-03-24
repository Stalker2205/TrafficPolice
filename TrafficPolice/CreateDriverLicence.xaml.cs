using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
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
    /// Логика взаимодействия для CreateDriverLicence.xaml
    /// </summary>
    public partial class CreateDriverLicence : Page
    {
        public CreateDriverLicence()
        {
            InitializeComponent();
            AddCategories();
            Kategoryes.Clear();
            List<int> DriverList = new List<int>();
            using (MyDBconnection db = new MyDBconnection())
            {
                db.Drivers.Load();
                db.Passports.Load();
                db.DriversLicenses.Load();
                db.DriverKategoryLicences.Load();
                var driver = db.Drivers.Local;
                foreach (var item in driver)
                {
                    DriverList.Add(item.DriverID);
                }
                cbDriverID.ItemsSource = DriverList;
            }
        }
        static Dictionary<string, bool> Kategoryes = new Dictionary<string, bool>();
        static void AddCategories()
        {
            Kategoryes.Add("A", false); Kategoryes.Add("A1", false);
            Kategoryes.Add("B", false); Kategoryes.Add("B1", false);
            Kategoryes.Add("C", false); Kategoryes.Add("C1", false);
            Kategoryes.Add("D", false); Kategoryes.Add("D1", false);
            Kategoryes.Add("BE", false); Kategoryes.Add("CE", false);
            Kategoryes.Add("C1E", false); Kategoryes.Add("DE", false);
            Kategoryes.Add("D1E", false); Kategoryes.Add("M", false);
            Kategoryes.Add("Tm", false); Kategoryes.Add("Tb", false);
        }
        private void cb_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox check = (CheckBox)sender;
            string kat = check.Name;
            Kategoryes[kat.Remove(0, 2)] = true;
        }
        private void cbA_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox check = (CheckBox)sender;
            string kat = check.Name;
            Kategoryes[kat.Remove(0, 2)] = false;
        }

        private void cbDriverID_DropDownClosed(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            using (MyDBconnection db = new MyDBconnection())
            {
                db.Drivers.Load();
                db.Passports.Load();
                int driverID = 0;
                try
                {
                    driverID = Convert.ToInt32(cb.Text);
                }
                catch { MessageBox.Show("Необходимо выбрать водителя!"); return; }
                grDriver.DataContext = db.Drivers.Local.Where(x => x.DriverID == Convert.ToInt32(cb.Text));
                grPassport.DataContext = db.Passports.Local.Where(x => x.PassportID == Convert.ToInt32(cb.Text));
                byte[] by = db.Drivers.Local.Where(x => x.DriverID == Convert.ToInt32(cb.Text)).First().Photo;
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.StreamSource = new MemoryStream(by);
                bitmap.EndInit();
                imPhoto.Source = bitmap;
            }
        }

        private void btGeneratSeries_Click(object sender, RoutedEventArgs e)
        {
            int key = 0;
            int ser = 0;
            int num = 0;
            using (MyDBconnection db = new MyDBconnection())
            {
                db.DriversLicenses.Load();
                do
                {
                    string number = string.Empty;
                    string series = string.Empty;
                    Random random = new Random();
                    for (int i = 0; i != 4; i++)
                    {
                        series += random.Next(1, 9).ToString();
                    }
                    ser = Convert.ToInt32(series);
                    for (int j = 0; j < 6; j++)
                    {
                        number += random.Next(1, 9).ToString();
                    }
                    num = Convert.ToInt32(number);
                    key = db.DriversLicenses.Local.Where(x => x.DriversLicenseSeries == ser && x.DriversLicenseNumber == num).Count();
                } while (key != 0);
                tbLicSeries.Text = ser.ToString();
                tbLicNumber.Text = num.ToString();
            }
        }

        private void btCreateDriverLicence_Click(object sender, RoutedEventArgs e)
        {
            int drivID = 0;
            try
            {
                drivID = Convert.ToInt32(cbDriverID.Text);
            }
            catch { MessageBox.Show("Необходимо выбрать водителя");return; }
            if (dpDateofIssue.SelectedDate.Value.Date.Year <DateTime.Now.Date.Year) { MessageBox.Show("ВУ дествует как минимум год!");return; }
        }
    }
}
