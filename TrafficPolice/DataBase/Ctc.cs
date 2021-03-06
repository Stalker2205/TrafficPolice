﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficPolice
{
    public class Ctc
    {
        [Key] 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("Document")]
        public int CtcID { get; set; }
        public int CtcNumber { get; set; }
        public int CtcSeries { get; set; }
        public int Owner { get; set; }
        public DateTime DateOfIssue { get; set; }
        public Document Document { get; set; }
    }
}
