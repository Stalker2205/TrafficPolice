using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TrafficPolice
{
    public class RequestsClass
    {
        public static int PackageDocuments;
        public static int Driver;
        public static bool keySerch = false;
        public static void CheckVIn(string Vin)
        {
            keySerch = false;
            if (Vin.Length != 17) { MessageBox.Show("Длина vin - 17 символов"); return; }
            using (MyDBconnection db = new MyDBconnection())
            {
                db.Cars.Load();
                db.Cars.Local.Where(x => x.Vin == Vin);
                var ur = db.Cars.Where(x => x.Vin == Vin);
                foreach (Car car in ur) { PackageDocuments = car.CarID; ; Driver = car.DriverID; }
            }
            keySerch = true;
        }

        public static void CheckDriverLicence (string series,string number)
        {
            keySerch = false;
            int num;
            int ser;
            try
            {
                num = Convert.ToInt32(number);
                ser = Convert.ToInt32(series);
            }
            catch { MessageBox.Show("Серия и номер должны быть числами");return; }

            if(series.Length == 0||series.Length !=4 || number.Length == 0 || number.Length != 6)
            {
                MessageBox.Show("Серия должна состоять из 4 цифр \n Номер должен состоять из 6 цифр");return;
            }

            using ( MyDBconnection db = new MyDBconnection())
            {
                db.DriversLicenses.Load();
                db.Drivers.Load();
                db.Cars.Load();
                var driveLicence = db.DriversLicenses.Local.Where(x => x.DriversLicenseSeries == ser && x.DriversLicenseNumber == num);
                foreach (DriversLicense DLIcence in driveLicence) { Driver = DLIcence.DriverID; }
                var car1 = db.Cars.Local.Where(x => x.DriverID == Driver);
                foreach (Car car in car1) { PackageDocuments = car.CarID; }
            }
            keySerch = true;
        }






    }
}
