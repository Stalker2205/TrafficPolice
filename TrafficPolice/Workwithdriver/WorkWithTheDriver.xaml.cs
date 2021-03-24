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
            //using (MyDBconnection db = new MyDBconnection())
            //{
            //    db.Drivers.Load();
            //    db.Passports.Load();
            //    DriverGrid.ItemsSource = db.Drivers.Local;
            //
            Image_Create.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\actions32\\filenew.ico"));
            Image_View.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\actions32\\fileopen.ico"));
            Image_Update.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\actions32\\fileUpdate.ico"));
            Image_Serch.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\actions32\\find.ico"));

        }

        private void CreateDriver_Click(object sender, RoutedEventArgs e)
        {
            DriverGrid.Visibility = Visibility.Hidden;
            FrameFromNavigation.Visibility = Visibility.Visible;
            FrameFromNavigation.Navigate(new CreateDriver());
        }

        private void SerchDriver_Click(object sender, RoutedEventArgs e)
        {
            DriverGrid.Visibility = Visibility.Visible;
            FrameFromNavigation.Visibility = Visibility.Hidden;
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
                IdDriverTbox.Text = RequestsClass.Driver.ToString();
            }
        }

        private void OpenPeopleInfo_Click(object sender, RoutedEventArgs e)
        {
            DriverClass.DriverID = null;
            if (IdDriverTbox.Text.Length == 0)
            {
                DriverGrid.Visibility = Visibility.Visible;
                FrameFromNavigation.Visibility = Visibility.Hidden;
                using (MyDBconnection db = new MyDBconnection())
                {
                    db.Drivers.Load();
                    DriverGrid.ItemsSource = db.Drivers.Local;
                }
            }
            else
            {

                using (MyDBconnection db = new MyDBconnection())
                {
                    db.Drivers.Load();
                    var driv = db.Drivers.Local.Where(x => x.DriverID == Convert.ToInt32(IdDriverTbox.Text));
                    foreach (Driver drive in driv) { DriverClass.DriverID = drive.DriverID; }
                }
                if (DriverClass.DriverID == null) { MessageBox.Show("Нет водителя с таким ID"); return; }
                DriverGrid.Visibility = Visibility.Hidden;
                FrameFromNavigation.Visibility = Visibility.Visible;
                FrameFromNavigation.Navigate(new OpenDriverInfo());
            }
        }

        private void UpdateDriverInfo_Click(object sender, RoutedEventArgs e)
        {
            DriverClass.DriverID = null;
            if (IdDriverTbox.Text.Length == 0)
            {
                MessageBox.Show("Введите ID"); return;
            }
            else
            {
                using (MyDBconnection db = new MyDBconnection())
                {
                    db.Drivers.Load();
                    var driv = db.Drivers.Local.Where(x => x.DriverID == Convert.ToInt32(IdDriverTbox.Text));
                    foreach (Driver drive in driv) { DriverClass.DriverID = drive.DriverID; }
                }
                if (DriverClass.DriverID == null) { MessageBox.Show("Нет водителя с таким ID"); return; }
                DriverGrid.Visibility = Visibility.Hidden;
                FrameFromNavigation.Visibility = Visibility.Visible;
                FrameFromNavigation.Navigate(new UpdateDriverfirst());
            }
        }

        private void mcCreateDriverLIcence(object sender, RoutedEventArgs e)
        {
            DriverGrid.Visibility = Visibility.Hidden;
            FrameFromNavigation.Visibility = Visibility.Visible;
            FrameFromNavigation.Navigate(new CreateDriverLicence());
        }
    }
}

