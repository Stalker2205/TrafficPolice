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
    public partial class SerchWithPTS : Page
    {
        public SerchWithPTS()
        {
            InitializeComponent();
            using (MyDBconnection db = new MyDBconnection())
            {
                db.Ptcs.Load();
                MainGrid.DataContext = db.Ptcs.Local.Where(x=>x.PtcID == AvtoClass.AvtoID);
            }

        }
        private void CreateDriverButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PhotoButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
