using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HoursPMO.Models
{
    public class WeekPerUserPerProject : BaseClass
    {
        public int WeekPerUserPerProjectID { get; set; }
        public int FTO { get; set; }
        public int Leaves { get; set; }
        public int Possible { get; set; }
        public int Actual { get; set; }
        public int Billable { get; set; }
        public int WorkingDays { get; set; }
        //[Range(1, 12)]
        public int WeekNo { get; set; }
        //[Range(2010, 2025)]
        public int Year { get; set; }

        public int UserID { get; set; }
        public int ProjectID { get; set; }
 
        public virtual User User { get; set; }
        public virtual Project Project { get; set; }
    }
}