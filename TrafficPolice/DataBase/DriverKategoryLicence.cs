using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficPolice
{
    public class DriverKategoryLicence
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        
        public string Kategory { get; set; }
        public DateTime DateOfAssignment { get; set; }
        public DateTime DateExpiration { get; set; }
        public DriversLicense DriversLicense { get; set; }
        public int DriversLicenseID { get; set; }

    }
}
