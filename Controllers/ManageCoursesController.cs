using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SIPLCollege.Models;

namespace SIPLCollege.Controllers
{
    public class ManageCoursesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ManageCourses
        public ActionResult Index()
        {
            return View(db.ManageCourses.ToList());
        }

        // GET: ManageCourses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ManageCourses manageCourses = db.ManageCourses.Find(id);
            if (manageCourses == null)
            {
                return HttpNotFound();
            }
            return View(manageCourses);
        }

        // GET: ManageCourses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManageCourses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseId,CourseName")] ManageCourses manageCourses)
        {
            if (ModelState.IsValid)
            {
                db.ManageCourses.Add(manageCourses);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(manageCourses);
        }

        // GET: ManageCourses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ManageCourses manageCourses = db.ManageCourses.Find(id);
            if (manageCourses == null)
            {
                return HttpNotFound();
            }
            return View(manageCourses);
        }

        // POST: ManageCourses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseId,CourseName")] ManageCourses manageCourses)
        {
            if (ModelState.IsValid)
            {
                db.Entry(manageCourses).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(manageCourses);
        }

        // GET: ManageCourses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ManageCourses manageCourses = db.ManageCourses.Find(id);
            if (manageCourses == null)
            {
                return HttpNotFound();
            }
            return View(manageCourses);
        }

        // POST: ManageCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ManageCourses manageCourses = db.ManageCourses.Find(id);
            db.ManageCourses.Remove(manageCourses);
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
