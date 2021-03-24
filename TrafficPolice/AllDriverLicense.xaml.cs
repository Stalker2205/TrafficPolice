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
using System.Windows.Shapes;

namespace TrafficPolice
{
    /// <summary>
    /// Логика взаимодействия для AllDriverLicense.xaml
    /// </summary>
    public partial class AllDriverLicense : Window
    {
        public AllDriverLicense()
        {
            InitializeComponent();
            using (MyDBconnection db = new MyDBconnection())
            {
                db.DriversLicenses.Load();
                dgDriverLicense.ItemsSource = db.DriversLicenses.Local.Where(x => x.DriverID == DriverClass.DriverID);
            }
            Kategoryes.Clear();
            AddCategories();
        }
        static Dictionary<string, bool> Kategoryes = new Dictionary<string, bool>();
        private void btViewDriverLicence_Click(object sender, RoutedEventArgs e)
        {
            Button but = (Button)sender;
            using (MyDBconnection db = new MyDBconnection())
            {
                db.DriversLicenses.Load();
                gbDriverLicence.DataContext = db.DriversLicenses.Local.Where(x => x.DriversLicenseID == Convert.ToInt32(but.Content));
                db.DriverKategoryLicences.Load();
                var kategory = db.DriverKategoryLicences.Local.Where(x => x.DriversLicenseID == Convert.ToInt32(but.Content));
                foreach (var item in kategory)
                {
                    CheckBox cb = (CheckBox)gbCategory.FindName($"cb{item.Kategory}");
                    cb.IsChecked = true;
                    DatePicker datePicker = (DatePicker)gbCategory.FindName($"dp{item.Kategory}");
                    datePicker.Text = item.DateOfAssignment.ToString();
                }
            }
        }
        private void cbA_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox check = (CheckBox)sender;
            string kat = check.Name;
            Kategoryes[kat.Remove(0, 2)] = false;
        }
        private void cb_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox check = (CheckBox)sender;
            string kat = check.Name;
            Kategoryes[kat.Remove(0, 2)] = true;

        }
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
    }
}
