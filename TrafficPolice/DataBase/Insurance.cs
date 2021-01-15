using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficPolice
{
    public class Insurance
    {
        [Key]
        [ForeignKey("Driver")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InsuranceID { get; set; }
        public int InsuranceNumber { get; set; }
        public int InsuranceSeries { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Insurant { get; set; }
        public List<Document> Document { get; set; }
        public Driver Driver { get; set; }
    }
}
