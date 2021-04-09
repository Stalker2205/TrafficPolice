using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace TrafficPolice
{
    /// <summary>
    /// Логика взаимодействия для PrintBY.xaml
    /// </summary>
    public partial class PrintBY : Window
    {
        public PrintBY()
        {
            InitializeComponent();
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.StreamSource = new MemoryStream(DriverLicenceClass._photo);
            bitmap.EndInit();
            Photo.Source = bitmap;
            tb_LastName.Text = DriverLicenceClass._lastname;
            tb_Name.Text = DriverLicenceClass._name;
            tb_Patronimyc.Text = DriverLicenceClass._patronimyc;
            tb_DateOfIssue.Text = DriverLicenceClass._dateofIssue;
            tb_DateStart.Text = DriverLicenceClass._datestart;
            tb_DateEnd.Text = DriverLicenceClass._dateEnd;
            tb_numberSeries.Text = $"{DriverLicenceClass._number}  {DriverLicenceClass._series}";
            foreach (var item in DriverLicenceClass._kategory)
            {
                if (item.Value == true)
                {
                    if (item.Key.Length == 1)
                    {
                        if (item.Key == "M")
                        {
                            tb_dateOgrA.Text += item.Key;
                            tb_dateStartA.Text = DriverLicenceClass._datestart; 
                        }
                        foreach (var item1 in DriverLicenceClass._Date)
                        {
                            if (item1.Key == item.Key && item1.Key != "M")
                            {
                                ((TextBlock)PrintGrid.FindName($"tb_dateStart{item.Key}")).Text = DriverLicenceClass._datestart;
                                ((TextBlock)PrintGrid.FindName($"tb_dateEnd{item.Key}")).Text = item1.Value.Date.ToString();
                            }
                        }
                    }
                    else if (item.Key.Length == 2)
                    {
                        if (item.Key == "Tm")
                        {
                            tb_dateStartTm.Text = DriverLicenceClass._datestart;
                            foreach (var item3 in DriverLicenceClass._Date)
                            {
                                if (item3.Key == "Tm")
                                {
                                    tb_dateEndTm.Text = item3.Value.Date.ToString();

                                }
                            }

                        }
                        if (item.Key == "Tb")
                        {
                            tb_dateStartTd.Text = DriverLicenceClass._datestart;
                            foreach (var item3 in DriverLicenceClass._Date)
                            {
                                if (item3.Key == "Tb")
                                {
                                    tb_dateEndTd.Text = item3.Value.Date.ToString();

                                }
                            }

                        }
                        if (item.Key[1] == 'E')
                        {
                            foreach (var item2 in DriverLicenceClass._Date)
                            {

                                if (item.Key == item2.Key)
                                {
                                    ((TextBlock)PrintGrid.FindName($"tb_dateStart{item.Key}")).Text = DriverLicenceClass._datestart;
                                    ((TextBlock)PrintGrid.FindName($"tb_dateEnd{item.Key}")).Text = item2.Value.Date.ToString();
                                }
                            }
                        }
                        else if (item.Key[1] == '1')
                        {
                            ((TextBlock)PrintGrid.FindName($"tb_dateOgr{item.Key[0].ToString()}")).Text += item.Key;
                        }
                    }
                    else if (item.Key.Length == 3)
                    {
                        ((TextBlock)PrintGrid.FindName($"tb_dateOgr{item.Key[0]}")).Text += item.Key;
                    }
                }

            }

        }
        private void bt_Print_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog print = new PrintDialog();
            if (print.ShowDialog() == true)
            {
                print.PrintVisual(PrintGrid, "печатаем грид");
            }
        }

    }


}

