using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HoursPMO.Models;

namespace HoursPMO.ViewModels
{
    public class ProjectGroup
    {
        public int ProjectID { get; set; }
        public int FTOCount { get; set; }
        public int LeavesCount { get; set; }
        public int PossibleCount { get; set; }
        public int ActualCount { get; set; }
        public int BillableCount { get; set; }
        public int WorkingDaysCount { get; set; }

        public virtual Project Project { get; set; }
    }
}