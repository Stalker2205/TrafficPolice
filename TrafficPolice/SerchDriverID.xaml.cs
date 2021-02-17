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
using System.Windows.Shapes;

namespace TrafficPolice
{
    /// <summary>
    /// Логика взаимодействия для SerchDriverID.xaml
    /// </summary>
    public partial class SerchDriverID : Window
    {
        public SerchDriverID()
        {
            InitializeComponent();
            List<string> List = new List<string>();
            List.Add("Паспорт");
            List.Add("Права");
            DocumentComboBox.ItemsSource = List;
            DocumentComboBox.Text = "Паспорт";
        }

        private void SerchDriver_Click(object sender, RoutedEventArgs e)
        {
            if (DocumentComboBox.Text.ToString() == "Паспорт")
            {
                RequestsClass.CheckPassport(SeriesTbox.Text.ToString(), NumberTbox.Text.ToString());
                if(RequestsClass.Driver == null) { MessageBox.Show("Нет такого паспорта");return; }
                Close();
            }
            else
            {
                RequestsClass.CheckDriverLicence(SeriesTbox.Text.ToString(), NumberTbox.Text.ToString());
                if(RequestsClass.Driver == null) { MessageBox.Show("Нет таких прав"); return; }
                Close();
            }
        }
    }
}
