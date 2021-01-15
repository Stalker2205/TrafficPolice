using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficPolice
{
    public class Ptc
    {
        [Key]
        [ForeignKey("Document")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CtcID { get; set; }
        public int CtcNumber { get; set; }
        public int CtcSeries { get; set; }
        public int YearOfManufacture { get; set; }
        public int EngineVolume { get; set; }
        public string EngineType { get; set; }
        public string EcoClass { get; set; }
        public string Manufacture { get; set; }
        public string CustomsRestrictions { get; set; }
        public string DateOut { get; set; }
        public Document Document { get; set; }
    }
}
