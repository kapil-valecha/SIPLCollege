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
    public class ManageSubjectsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ManageSubjects
        public ActionResult Index()
        {
            return View(db.ManageSubjects.ToList());
        }

        // GET: ManageSubjects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ManageSubjects manageSubjects = db.ManageSubjects.Find(id);
            if (manageSubjects == null)
            {
                return HttpNotFound();
            }
            return View(manageSubjects);
        }

        // GET: ManageSubjects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManageSubjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SubjectId,SubjectName")] ManageSubjects manageSubjects)
        {
            if (ModelState.IsValid)
            {
                db.ManageSubjects.Add(manageSubjects);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(manageSubjects);
        }

        // GET: ManageSubjects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ManageSubjects manageSubjects = db.ManageSubjects.Find(id);
            if (manageSubjects == null)
            {
                return HttpNotFound();
            }
            return View(manageSubjects);
        }

        // POST: ManageSubjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SubjectId,SubjectName")] ManageSubjects manageSubjects)
        {
            if (ModelState.IsValid)
            {
                db.Entry(manageSubjects).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(manageSubjects);
        }

        // GET: ManageSubjects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ManageSubjects manageSubjects = db.ManageSubjects.Find(id);
            if (manageSubjects == null)
            {
                return HttpNotFound();
            }
            return View(manageSubjects);
        }

        // POST: ManageSubjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ManageSubjects manageSubjects = db.ManageSubjects.Find(id);
            db.ManageSubjects.Remove(manageSubjects);
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
