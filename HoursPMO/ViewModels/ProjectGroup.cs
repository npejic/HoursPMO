using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HoursPMO.Models;
using HoursPMO.DAL;
using System.Data.Entity;

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

        public List<ProjectGroup> SumForTheSelectedWeeks(List<int> selectedWeekInMonth, int YearSelected, HoursContext db)
        {

            var data = from project in db.WeekPerUserPerProjects.Include(p => p.Project)
                       from w in selectedWeekInMonth
                       where project.Year == YearSelected && project.WeekNo == w
                       group project by project.Project into projectGroup
                       select new ProjectGroup()
                       {
                           Project = projectGroup.Key,
                           FTOCount = projectGroup.Sum(o => o.FTO),
                           LeavesCount = projectGroup.Sum(o => o.Leaves),
                           PossibleCount = projectGroup.Sum(o => o.Possible),
                           ActualCount = projectGroup.Sum(o => o.Actual),
                           BillableCount = projectGroup.Sum(o => o.Billable),
                           WorkingDaysCount = projectGroup.Sum(o => o.WorkingDays)
                       };

            return (data.ToList());
        }

    }
}