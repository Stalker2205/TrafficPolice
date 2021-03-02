using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficPolice
{
    public class DriversLicense
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DriversLicenseID { get; set; }
        public int DriversLicenseNumber { get; set; }
        public int DriversLicenseSeries { get; set; }
        public string Category { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public int DriverID { get; set; }
        public Driver Driver { get; set; }
    }

}
