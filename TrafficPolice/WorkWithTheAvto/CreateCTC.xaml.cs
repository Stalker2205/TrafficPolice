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
    /// Логика взаимодействия для CreateCTC.xaml
    /// </summary>
    public partial class CreateCTC : Window
    {
        public CreateCTC()
        {
            InitializeComponent();
            using(MyDBconnection db = new MyDBconnection())
            {
                db.Drivers.Load();
                cb_Owner.ItemsSource = db.Drivers.Local;
                cb_Owner.Text = CarClass.ID.ToString();
            }
        }

        public static bool Proverk(Grid grid)
        {
            if (string.IsNullOrWhiteSpace(((TextBox)grid.FindName("tb_Series")).Text))
            {
                MessageBox.Show("Серия не должна быть Null"); return false;
            }
            else
            {
                try
                {
                    int.Parse(((TextBox)grid.FindName("tb_Series")).Text);
                }
                catch { MessageBox.Show("Серия должна быть числом"); return false; }
            }
            if (string.IsNullOrWhiteSpace(((TextBox)grid.FindName("tb_Series")).Text))
            {
                MessageBox.Show("Номер не должен быть Null"); return false;
            }
            else
            {
                try
                {
                    int.Parse(((TextBox)grid.FindName("tb_Number")).Text);
                }
                catch { MessageBox.Show("Номер должен быть числом"); return false; }
            }
            if (String.IsNullOrEmpty(((ComboBox)grid.FindName("cb_Owner")).Text))
            {
                MessageBox.Show("Выберите владельца"); return false;
            }
            if (((DatePicker)grid.FindName("dp_DateOfIssue")).SelectedDate.HasValue || ((DatePicker)grid.FindName("dp_DateOfIssue")).DisplayDate > DateTime.Now)
            {
                MessageBox.Show("Выберите корректную дату"); return false;
            }
            using(MyDBconnection db = new MyDBconnection())
            {
                db.Ctcs.Load();
                Ctc ctc = new Ctc();
                ctc.CtcID = CarClass.ID;
                ctc.CtcNumber = int.Parse(((TextBox)grid.FindName("tb_Number")).Text);
                ctc.CtcSeries = ((TextBox)grid.FindName("tb_Series")).Text;
                ctc.DateOfIssue = ((DatePicker)grid.FindName("dp_DateOfIssue")).SelectedDate.Value;
                ctc.Owner =int.Parse( ((ComboBox)grid.FindName("cb_Owner")).Text);
                db.Ctcs.Add(ctc);
                db.SaveChanges();
            }
            return true;
        }
        private void bt_CreateCtc_Click(object sender, RoutedEventArgs e)
        {
            if (Proverk(gr_Ctc))
            {
                MessageBox.Show("Успешно!");
                Close();
            }
        }
    }
}
