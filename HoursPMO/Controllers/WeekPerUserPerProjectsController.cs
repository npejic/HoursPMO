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
    public class WeekPerUserPerProjectsController : Controller
    {
        private HoursContext db = new HoursContext();

        public ActionResult Index(string searchString1, string searchString2)
        {
            var weekPerUserPerProjects = from s in db.WeekPerUserPerProjects
                                         select s;
            if (!String.IsNullOrEmpty(searchString1) && !String.IsNullOrEmpty(searchString2))
            {
                var stringToInt1 = Convert.ToInt32(searchString1);
                var stringToInt2 = Convert.ToInt32(searchString2);


                weekPerUserPerProjects = weekPerUserPerProjects.Where(s => s.WeekNo == stringToInt1 && s.Year == stringToInt2);
            }
            return View(weekPerUserPerProjects.ToList());
        }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="MonthNoSelectedString"></param>
       /// <param name="YearSelectedString"></param>
       /// <returns></returns>
        public ActionResult MonthReportSelect(string MonthNoSelectedString, string YearSelectedString)
        {
            int MonthNoSelected = Convert.ToInt32(MonthNoSelectedString);
            int YearSelected = Convert.ToInt32(YearSelectedString);

            WeeksInMonthAndYear.WeeksNumbers weekNumbers = new WeeksInMonthAndYear.WeeksNumbers();
            List<int> selectedWeekInMonth = new List<int>();
            if (MonthNoSelectedString != null && YearSelectedString != null)
            {
                selectedWeekInMonth = weekNumbers.WeeksNumberInYearPerMonth(MonthNoSelected, YearSelected);
            }
            //ProjectGroup pg = new ProjectGroup();
            var data = ProjectGroup.SumForTheSelectedWeeks(selectedWeekInMonth, YearSelected, db);
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
