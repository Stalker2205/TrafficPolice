using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficPolice
{
    public class Staff
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StaffID { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string Photo { get; set; }
        public string Education { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public List<Sertification> Sertifications { get; set; }
        public int? SertificationID { get; set; }
        public List<Rank> Ranks { get; set; }
        public int RankID { get; set; }
    }
}
