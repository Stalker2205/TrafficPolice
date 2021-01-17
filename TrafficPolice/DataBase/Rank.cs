using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficPolice
{
    public class Rank
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RankID { get; set; }
        public string RankName { get; set; }
        public string RankPhoto { get; set; }
    }
}
