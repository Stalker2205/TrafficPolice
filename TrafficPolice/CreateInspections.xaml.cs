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
    /// Логика взаимодействия для CreateInspections.xaml
    /// </summary>
    public partial class CreateInspections : Window
    {
        public CreateInspections()
        {
            InitializeComponent();
            if (StatementsClass.Code == 0)
            {
                tb_Vin.Text = CarClass.Vin;
                tb_Vin.IsEnabled = false;
                tb_BodyNumber.Text = CarClass.BodyNumber.ToString();
                tb_BodyNumber.IsEnabled = false;
                tb_ChossisNumber.Text = CarClass.ChossisNumber.ToString();
                tb_ChossisNumber.IsEnabled = false;
            }
        }
        public static void Proveroki(Grid grid)
        {
            if (string.IsNullOrWhiteSpace(((TextBox)grid.FindName("tb_RegistrationNumber")).Text)|| ((TextBox)grid.FindName("tb_RegistrationNumber")).Text.Length != 15)
            {
                MessageBox.Show("Регистрационный номер состоит из 15 знаков");return;
            }
            if (((DatePicker)grid.FindName("tb_EndDate")).SelectedDate.HasValue)
            {
                MessageBox.Show("Дата окончания не может быть пустой");return;
            }
            if (string.IsNullOrWhiteSpace(((TextBox)grid.FindName("tb_Vin")).Text) || ((TextBox)grid.FindName("tb_Vin")).Text.Length != 17)
            {
                MessageBox.Show("Vin состоит из 17 знаков");return;
            }
            if (string.IsNullOrWhiteSpace(((TextBox)grid.FindName("tb_ChossingNumber")).Text) || ((TextBox)grid.FindName("tb_ChossingNumber")).Text.Length != 6)
            {
                MessageBox.Show("Регистрационный номер состоит из 6 символов"); return ;
            }
            else
            {
                try
                {
                    int.Parse(((TextBox)grid.FindName("tb_ChossingNumber")).Text);
                }
                catch { MessageBox.Show("Регистрационный номер состоит из цифр"); return; }
            }
            if (string.IsNullOrWhiteSpace(((TextBox)grid.FindName("tb_bodyNomber")).Text) || ((TextBox)grid.FindName("tb_bodyNomber")).Text.Length < 9 || ((TextBox)grid.FindName("tb_bodyNomber")).Text.Length > 12)
            {

                MessageBox.Show("Номер кузова состоит от 6 до 9 цифр"); return;
            }
            else
            {
                try
                {
                    int.Parse(((TextBox)grid.FindName("tb_bodyNomber")).Text);
                }
                catch { MessageBox.Show("Номер кузова состоит из цифр"); return; }
            }
            if (string.IsNullOrWhiteSpace(((TextBox)grid.FindName("tb_Model")).Text))
            {
                MessageBox.Show("Модель не может быть пустой");return;
            }
            if (string.IsNullOrWhiteSpace(((TextBox)grid.FindName("tb_PlaceOfInspaction")).Text))
            {
                MessageBox.Show("Место осмотра не может быть пустым"); return;
            }
        }
        public static void CreateInsp(Grid grid)
        {
            using (MyDBconnection db = new MyDBconnection())
            {
                db.Inspections.Load();
                Inspection ins = new Inspection();
                ins.RegistrationNumber = ((TextBox)grid.FindName("tb_RegistrationNumber")).Text;
                ins.EndDate = ((DatePicker)grid.FindName("tb_EndDate")).SelectedDate.Value;
                ins.PlaceOfInspaction = ((TextBox)grid.FindName("tb_PlaceOfInspaction")).Text;
                ins.Vin = ((TextBox)grid.FindName("tb_Vin")).Text;
                ins.ChossisNumber = int.Parse(((TextBox)grid.FindName("tb_ChossingNumber")).Text);
                ins.BodyNumber = int.Parse(((TextBox)grid.FindName("tb_bodyNomber")).Text);
                ins.Model = ((TextBox)grid.FindName("tb_Model")).Text;
                ins.Malfunctions = ((TextBox)grid.FindName("tb_Malfunctions")).Text;
                ins.UsingCar = ((CheckBox)grid.FindName("cb_Expl")).IsEnabled;
                ins.CarID = CarClass.ID;
                db.Inspections.Add(ins);
                db.SaveChanges();

            }
        }

        private void bt_CreateINspection_Click(object sender, RoutedEventArgs e)
        {
            Proveroki(grid_main);
            CreateInsp(grid_main);
            MessageBox.Show("Успешно!");
            Close();
        }
    }
}
