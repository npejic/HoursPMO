using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HoursPMO.DAL;
using HoursPMO.Models;
using HoursPMO.ViewModels;

namespace HoursPMO.Controllers
{
    /// <summary>
    /// Controler for WeekPerUserPerProjects class
    /// </summary>
    public class WeekPerUserPerProjectsController : Controller
    {
        private HoursContext db = new HoursContext();

        /// <summary>
        /// Index action of WeekPerUserPerProjectsController
        /// </summary>
        /// <param name="weekSelectedString">week number for search display</param>
        /// <param name="yearSelectedString">year number for search display</param>
        /// <returns></returns>
        public ActionResult Index(string weekSelectedString, string yearSelectedString)
        {
            var weekPerUserPerProjects = from s in db.WeekPerUserPerProjects
                                         select s;
            if (!String.IsNullOrEmpty(weekSelectedString) && !String.IsNullOrEmpty(yearSelectedString))
            {
                var weekSelectedInt = Convert.ToInt32(weekSelectedString);
                var yearSelectedInt = Convert.ToInt32(yearSelectedString);

                weekPerUserPerProjects = weekPerUserPerProjects
                    .Where(s => s.WeekNo == weekSelectedInt && s.Year == yearSelectedInt);
            }
            return View(weekPerUserPerProjects.ToList());
        }

       /// <summary>
       /// Action that will calculate sum for User atributes, for month and year that is inputed in view
       /// </summary>
       /// <param name="MonthNoSelectedString">Month int number inputed in view</param>
       /// <param name="YearSelectedString">Year int number inputed in view</param>
       /// <returns></returns>
        public ActionResult MonthReportSelect(string MonthNoSelectedString, string YearSelectedString)
        {
            int MonthNoSelected = Convert.ToInt32(MonthNoSelectedString);
            int YearSelected = Convert.ToInt32(YearSelectedString);

            //selectedWeeksInMonth gets ordinals of weeks
            //TODO: make WeeksNumberInYearPerMonth method static
            WeeksInMonthAndYear.WeeksNumbers weekNumbers = new WeeksInMonthAndYear.WeeksNumbers();
            List<int> selectedWeeksInMonth = new List<int>();
            if (MonthNoSelectedString != null && YearSelectedString != null)
            {
                selectedWeeksInMonth = weekNumbers.WeeksNumberInYearPerMonth(MonthNoSelected, YearSelected);
            }
         
            var data = ProjectGroup.SumForTheSelectedWeeks(selectedWeeksInMonth, YearSelected, db);
            return View(data);    
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeekPerUserPerProject weekPerUserPerProject = db.WeekPerUserPerProjects.Find(id);
            if (weekPerUserPerProject == null)
            {
                return HttpNotFound();
            }
            return View(weekPerUserPerProject);
        }

        // GET: WeekPerUserPerProjects/Create
        public ActionResult Create()
        {
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName");
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName");
            return View();
        }

        // POST: WeekPerUserPerProjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WeekPerUserPerProjectID,FTO,Leaves,Possible,Actual,Billable,WorkingDays,WeekNo,Year,UserID,ProjectID,Created")] WeekPerUserPerProject weekPerUserPerProject)
        {
            if (ModelState.IsValid)
            {
                db.WeekPerUserPerProjects.Add(weekPerUserPerProject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName", weekPerUserPerProject.ProjectID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", weekPerUserPerProject.UserID);
            return View(weekPerUserPerProject);
        }

        // GET: WeekPerUserPerProjects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeekPerUserPerProject weekPerUserPerProject = db.WeekPerUserPerProjects.Find(id);
            if (weekPerUserPerProject == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName", weekPerUserPerProject.ProjectID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", weekPerUserPerProject.UserID);
            return View(weekPerUserPerProject);
        }

        // POST: WeekPerUserPerProjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WeekPerUserPerProjectID,FTO,Leaves,Possible,Actual,Billable,WorkingDays,WeekNo,Year,UserID,ProjectID,Created")] WeekPerUserPerProject weekPerUserPerProject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(weekPerUserPerProject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName", weekPerUserPerProject.ProjectID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", weekPerUserPerProject.UserID);
            return View(weekPerUserPerProject);
        }

        // GET: WeekPerUserPerProjects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeekPerUserPerProject weekPerUserPerProject = db.WeekPerUserPerProjects.Find(id);
            if (weekPerUserPerProject == null)
            {
                return HttpNotFound();
            }
            return View(weekPerUserPerProject);
        }

        // POST: WeekPerUserPerProjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WeekPerUserPerProject weekPerUserPerProject = db.WeekPerUserPerProjects.Find(id);
            db.WeekPerUserPerProjects.Remove(weekPerUserPerProject);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
