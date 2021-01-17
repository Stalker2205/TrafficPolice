using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficPolice
{
    public class WorkSchedule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WorkScheduleID { get; set; }
        public Staff Staff { get; set; }
        public int StaffID { get; set; }
        public Position Position { get; set; }
        public int PositionID { get; set; }
    }
}
