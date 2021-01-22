using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TrafficPolice
{
    public class Document
    {
        public Document()
        {
            Statement = new List<Statement>();
            Insurances = new List<Insurance>();
            inspections = new List<Inspection>();
        }

        [Key]
        [ForeignKey("Car")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DocumentID { get; set; }
        public int? StatementsID { get; set; }
        public List<Statement> Statement { get; set; }
        public Ctc Ctc { get; set; }
        public int CtcID { get; set; }
        public Ptc Ptc { get; set; }
        public int PtcID { get; set; }
        public List<Insurance> Insurances { get; set; }
        public int? InsuranceID { get; set; }  
        public List<Inspection> inspections { get; set; }
        public int? InspectionID { get; set; }
        public Car Car { get; set; }
    }
}
