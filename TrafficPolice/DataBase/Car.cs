using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficPolice
{
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CarID { get; set; }
        public string VenhicleType { get; set; }
        public int EngineNumber { get; set; }
        public int ChossisNumber { get; set; }
        public int BodyNumber { get; set; }
        public string Color { get; set; }
        public int MaxVeigh { get; set; }
        public string Vin { get; set; }
        public Driver Driver { get; set; }
        public int DriverID { get; set; }
        public Ptc Ptc { get; set; }
        public Insurance Insurance { get; set; }
        public Ctc Ctc { get; set; }
        public List<Inspection> Inspections { get; set; }
        public List<Statement> Statements { get; set; }

    }
}
