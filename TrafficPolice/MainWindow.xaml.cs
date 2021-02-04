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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoginF loginF = new LoginF();
            loginF.ShowDialog();
            #region Login
            if (!LoginClass.key) { Close(); }

            #endregion
            #region DBSelect
            using (MyDBconnection bconnection = new MyDBconnection())
            {
                bconnection.Staffs.Load();
                bconnection.Ranks.Load();
                int RID = 0;
                var stf = bconnection.Staffs.Where(x => x.Login == LoginClass.LoginName && x.Password == LoginClass.LoginPassword);
                foreach (Staff staff in stf) RID = staff.RankID;
                var rnk = bconnection.Ranks.Where(X => X.RankID == RID);
                foreach (Rank rank in rnk) { RankName.Text = rank.RankName; Rank.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + $"\\Image\\Pagon\\{rank.RankPhoto}",UriKind.Absolute)); }
               
            }
            #endregion 
            LogoImg.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + $"\\Image\\Logo\\TrafficPoliceLogo.svg"));
        }

        private void Serchavto_Click(object sender, RoutedEventArgs e)
        {
            FormPage.Navigate(new SerchAvto());
        }
    }
}
