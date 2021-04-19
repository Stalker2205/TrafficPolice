﻿using System;
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
    /// Логика взаимодействия для CreateCar.xaml
    /// </summary>
    public partial class CreateCar : Page
    {
        public CreateCar()
        {
            InitializeComponent();
        }
        public static bool Proverka(Grid group)
        {
            if (string.IsNullOrWhiteSpace(((TextBox)group.FindName("tb_Vin")).Text) || ((TextBox)group.FindName("tb_Vin")).Text.Length != 17)
            {
                MessageBox.Show($"Vin состоит из 17 символов, вы ввели {((TextBox)group.FindName("tb_Vin")).Text.Length} "); return false;
            }
            else
            {
                using (MyDBconnection db = new MyDBconnection())
                {
                    db.Cars.Load();
                    if (string.IsNullOrEmpty(db.Cars.Local.Where(x => x.Vin == ((TextBox)group.FindName("tb_Vin")).Text).Count().ToString()))
                    {

                    }
                    else
                    {
                        MessageBox.Show("Такой vin уже существует");
                        return false;
                    }

                }
            }

            if (string.IsNullOrWhiteSpace(((TextBox)group.FindName("tb_CarType")).Text))
            {
                MessageBox.Show("Введите тип машин!"); return false;
            }
            if (string.IsNullOrWhiteSpace(((TextBox)group.FindName("tb_EngineNumber")).Text) || ((TextBox)group.FindName("tb_EngineNumber")).Text.Length != 6)
            {
                MessageBox.Show("Введите номер двигателя"); return false;
            }
            else
            {
                try
                {
                    int.Parse(((TextBox)group.FindName("tb_EngineNumber")).Text);
                }
                catch { MessageBox.Show("Номер двигателя состоит из цифр"); return false; }
            }
            if (string.IsNullOrWhiteSpace(((TextBox)group.FindName("tb_ChossingNumber")).Text) || ((TextBox)group.FindName("tb_ChossingNumber")).Text.Length != 6)
            {
                MessageBox.Show("Регистрационный номер состоит из 6 символов"); return false;
            }
            if (string.IsNullOrWhiteSpace(((TextBox)group.FindName("tb_bodyNomber")).Text) || ((TextBox)group.FindName("tb_bodyNomber")).Text.Length < 9 || ((TextBox)group.FindName("tb_bodyNomber")).Text.Length > 12)
            {

                MessageBox.Show("Номер кузова состоит от 6 до 9 цифр"); return false;
            }
            else
            {
                try
                {
                    int.Parse(((TextBox)group.FindName("tb_bodyNomber")).Text);
                }
                catch { MessageBox.Show("Номер кузова состоит из цифр"); return false; }
            }

            if (string.IsNullOrWhiteSpace(((TextBox)group.FindName("tb_Color")).Text))
            {
                MessageBox.Show("Цвет не может быть Null"); return false;
            }
            if (string.IsNullOrWhiteSpace(((TextBox)group.FindName("tb_MaxWeight")).Text))
            {
                MessageBox.Show("Максимальный веш не может быть Null"); return false;
            }
            if (((ComboBox)group.FindName("cb_Driver")).SelectedItem == null)
            {
                MessageBox.Show("Необходимо выбрать водителя!"); return false;
            }

            using (MyDBconnection db = new MyDBconnection())
            {
                db.Cars.Load();
                db.Drivers.Load();
                var driver = db.Drivers.Local.Where(x => x.DriverID == int.Parse(((ComboBox)group.FindName("cb_Driver")).Text)).First();
                Car car = new Car();
                car.Vin = ((TextBox)group.FindName("tb_Vin")).Text;
                car.VenhicleType = ((TextBox)group.FindName("tb_CarType")).Text;
                car.EngineNumber = int.Parse(((TextBox)group.FindName("tb_EngineNumber")).Text);
                car.BodyNumber = int.Parse(((TextBox)group.FindName("tb_bodyNomber")).Text);
                car.Color = ((TextBox)group.FindName("tb_Color")).Text;
                car.MaxVeigh = int.Parse(((TextBox)group.FindName("tb_MaxWeight")).Text);
                car.Status = "Не зарегестрированно";
                car.DriverID = driver.DriverID;
                db.Cars.Add(car);
                db.SaveChanges();
                var car1 = db.Cars.Local.Where(x => x.Vin == ((TextBox)group.FindName("tb_Vin")).Text).First();
                CarClass.ID = car.CarID;
                DriverClass.DriverID = driver.DriverID;
            }
            return true;
        }
        public static bool ProvDoc(int CarID)
        {
            using (MyDBconnection db = new MyDBconnection())
            {
                db.Cars.Load();
                db.Ctcs.Load();
                db.Ptcs.Load();
                db.Insurances.Load();
                db.Inspections.Load();
                db.Statements.Load();

                try
                {
                    db.Ctcs.Local.Where(x => x.CtcID == CarID).First();
                }
                catch { return false; }
                try
                {
                    db.Ptcs.Local.Where(x => x.PtcID == CarID).First();
                }
                catch { return false; }
                try
                {
                    db.Insurances.Local.Where(x => x.InsuranceID == CarID).First();
                }
                catch { return false; }
                try
                {
                    db.Inspections.Local.Where(x => x.CarID == CarID).First();
                }
                catch { return false; }
                try
                {
                    db.Statements.Local.Where(x => x.CarID == CarID).First();
                }
                catch { return false; }
                db.Cars.Local.Where(x => x.CarID == CarID).First().Status = "Зарегестрированно";
                db.SaveChanges();

            }
            return true;
        }
        private void bt_CreateCar_Click(object sender, RoutedEventArgs e)
        {
            if (Proverka(gr_car))
            {
                gb_Documents.IsEnabled = true;
                MessageBox.Show("Создано, для окончания регистрации внесите все необходимые документы");
            }
        }

        private void bt_createCTC_Click(object sender, RoutedEventArgs e)
        {

            CreateCTC cr = new CreateCTC();
            cr.ShowDialog();
            ProvDoc(CarClass.ID);
        }

        private void bt_insurance_Click(object sender, RoutedEventArgs e)
        {
            CreateInsurances cr = new CreateInsurances();
            cr.ShowDialog();
            ProvDoc(CarClass.ID);
        }
    }

}