using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficPolice
{
    public class Inspection
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InspectionID { get; set; }
        public string RegistrationNumber { get; set; }
        public DateTime EndDate { get; set; }
        public string PlaceOfInspaction { get; set; }
        public string Vin { get; set; }
        public int ChossisNumber { get; set; }
        public int BodyNumber { get; set; }
        public string Model { get; set; }
        public string Malfunctions { get; set; }
        public bool UsingCar { get; set; }
        public  Document Document { get; set; }
    }
}
