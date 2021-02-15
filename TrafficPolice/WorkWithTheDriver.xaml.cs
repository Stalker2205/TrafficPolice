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
    public partial class WorkWithTheDriver : Page
    {
        public WorkWithTheDriver()
        {
            InitializeComponent();
            using (MyDBconnection db = new MyDBconnection())
            {
                db.Drivers.Load();
                db.Passports.Load();
                DriverGrid.ItemsSource = db.Drivers.Local;
            }
        }

        private void CreateDriver_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SerchDriver_Click(object sender, RoutedEventArgs e)
        {
            int DriverID;

            if (IdDriverTbox.Text.Length != 0)
            {
                try
                {
                    DriverID = Convert.ToInt32(IdDriverTbox.Text);
                }
                catch { MessageBox.Show("ID должно быть числом!"); return; }
                using (MyDBconnection db = new MyDBconnection())
                {
                    db.Drivers.Load();
                    DriverGrid.ItemsSource = db.Drivers.Local.Where(x => x.DriverID == DriverID);
                }
            }
            else
            {
                SerchDriverID serchDriverID = new SerchDriverID();
                serchDriverID.ShowDialog();
                if (RequestsClass.Driver == null) return;
                using (MyDBconnection db = new MyDBconnection())
                {
                    db.Drivers.Load();
                    DriverGrid.ItemsSource = db.Drivers.Local.Where(x => x.DriverID == RequestsClass.Driver);
                }
            }
        }
    }
}
