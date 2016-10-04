using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HoursPMO.Models
{
    /// <summary>
    /// Class that contains informations about project job that is done in current week per users
    /// </summary>
    public class WeekPerUserPerProject : BaseClass
    {
        /// <summary>
        /// ID for WeekPerUserPerProject row
        /// </summary>
        public int WeekPerUserPerProjectID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int FTO { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Leaves { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Possible { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Actual { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Billable { get; set; }
        /// <summary>
        /// Number of working days in current week
        /// </summary>
        public int WorkingDays { get; set; }
        /// <summary>
        /// Number of the Week that numbers are inputed for, can be intiger from 1 to 52
        /// </summary>
        [Required(ErrorMessage = "Please enter number of the week.")]
        [Range(1, 52, ErrorMessage="Week can be from 1 to 52")]
        public int WeekNo { get; set; }
        /// <summary>
        /// Year in question
        /// </summary>
        [Range(2010, 2025)]
        public int Year { get; set; }
        /// <summary>
        /// String that combines Year and Week Number, format type yyyy-ww
        /// </summary>
        [NotMapped]
        public string YearAndWeekNo { get { return Year + "-" + WeekNo; } } 
        
        /// <summary>
        /// 
        /// </summary>
        public int UserID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ProjectID { get; set; }
 
        /// <summary>
        /// 
        /// </summary>
        public virtual User User { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Project Project { get; set; }
    }
}