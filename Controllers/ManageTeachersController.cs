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
    public class ManageTeachersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ManageTeachers
        public ActionResult Index()
        {
            return View(db.ManageTeachers.ToList());
        }

        // GET: ManageTeachers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ManageTeachers manageTeachers = db.ManageTeachers.Find(id);
            if (manageTeachers == null)
            {
                return HttpNotFound();
            }
            return View(manageTeachers);
        }

        // GET: ManageTeachers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManageTeachers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TeacherId,TeacherName,ChooseCourse")] ManageTeachers manageTeachers)
        {
            if (ModelState.IsValid)
            {
                db.ManageTeachers.Add(manageTeachers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(manageTeachers);
        }

        // GET: ManageTeachers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ManageTeachers manageTeachers = db.ManageTeachers.Find(id);
            if (manageTeachers == null)
            {
                return HttpNotFound();
            }
            return View(manageTeachers);
        }

        // POST: ManageTeachers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TeacherId,TeacherName,ChooseCourse")] ManageTeachers manageTeachers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(manageTeachers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(manageTeachers);
        }

        // GET: ManageTeachers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ManageTeachers manageTeachers = db.ManageTeachers.Find(id);
            if (manageTeachers == null)
            {
                return HttpNotFound();
            }
            return View(manageTeachers);
        }

        // POST: ManageTeachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ManageTeachers manageTeachers = db.ManageTeachers.Find(id);
            db.ManageTeachers.Remove(manageTeachers);
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
