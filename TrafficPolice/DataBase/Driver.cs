using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficPolice
{
    public class Driver
    {

        [Key]
        [ForeignKey("Car")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DriverID { get; set; }
        public string Photo { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public int? DriversLicenseID { get; set; }
        public List<DriversLicense> driversLicenses { get; set; }
        
        public Passport Passport { get; set;}
        public Car Car { get; set; }
        public Insurance Insurance { get; set; }
    }
}
