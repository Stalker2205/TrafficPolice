using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficPolice
{
    public class Position
    {
        [Key]
        [ForeignKey("WorkSchedule")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PositionID { get; set; }
        public string PositionName { get; set; }
        public WorkSchedule WorkSchedule { get; set; }
    }
}
