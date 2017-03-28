using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HoursPMO.Models;
using HoursPMO.DAL;
using System.Data.Entity;

namespace HoursPMO.ViewModels
{
    /// <summary>
    /// class for representing sum of User atributes
    /// </summary>
    public class ProjectGroup
    {
        /// <summary>
        /// ProjectID is connection to Project Class
        /// </summary>
        public int ProjectID { get; set; }
        /// <summary>
        /// Sum for FTO
        /// </summary>
        public int FTOSum { get; set; }
        /// <summary>
        /// Sum for Leaves
        /// </summary>
        public int LeavesSum { get; set; }
        /// <summary>
        /// Sum for Possible
        /// </summary>
        public int PossibleSum { get; set; }
        /// <summary>
        /// Sum for Actual
        /// </summary>
        public int ActualSum { get; set; }
        /// <summary>
        /// Sum for Billable
        /// </summary>
        public int BillableSum { get; set; }
        /// <summary>
        /// Sum for Working Days
        /// </summary>
        public int WorkingDaysSum { get; set; }
        /// <summary>
        /// TODO: ovo verovatno ne treba
        /// </summary>
        public virtual Project Project { get; set; }

        /// <summary>
        /// Method that returns List of ProjectGroup object with properties that represents sum for each Project 
        /// in selected weeks and year
        /// </summary>
        /// <param name="selectedWeeksInMonth">List of Int that holds weeks numbers for calculating sum</param>
        /// <param name="YearSelected">Selected year for calculating sum</param>
        /// <param name="db">database TODO: prebaci samo tabelu WeeksPerUserPerProject</param>
        /// <returns></returns>
        public static List<ProjectGroup> SumForTheSelectedWeeks(List<int> selectedWeeksInMonth, int YearSelected, HoursContext db)
        {

            var data = from project in db.WeekPerUserPerProjects.Include(p => p.Project)
                       from w in selectedWeeksInMonth
                       where project.Year == YearSelected && project.WeekNo == w
                       group project by project.Project into projectGroup
                       select new ProjectGroup()
                       {
                           Project = projectGroup.Key,
                           FTOSum = projectGroup.Sum(o => o.FTO),
                           LeavesSum = projectGroup.Sum(o => o.Leaves),
                           PossibleSum = projectGroup.Sum(o => o.Possible),
                           ActualSum = projectGroup.Sum(o => o.Actual),
                           BillableSum = projectGroup.Sum(o => o.Billable),
                           WorkingDaysSum = projectGroup.Sum(o => o.WorkingDays)
                       };

            return (data.ToList());
        }
    }
}