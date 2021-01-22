using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TrafficPolice
{
    public class Passport
    {
        [Key]
        [ForeignKey("Driver")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PassportID { get; set; }
        public int PassportNumber { get; set; }
        public int PassportSeries { get; set; }
        public string PassportAdress { get; set; }
        public DateTime DateOfIssue { get; set; }
        public Driver Driver { get; set; }
        
    }
}
