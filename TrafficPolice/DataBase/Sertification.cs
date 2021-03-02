using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficPolice
{
    public class Sertification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SertificationID { get; set; }
        public int SertificationNumber { get; set; }
        public int SertificationSeries { get; set; }
        public string SertificationPosition { get; set; }
        public DateTime ValidUnit { get; set; }
        public Staff Staff { get; set; }

    }
}
