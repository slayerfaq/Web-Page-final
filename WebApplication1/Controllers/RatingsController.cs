using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class RatingsController : Controller
    {
        private zurnalEntities db = new zurnalEntities();

        // GET: Ratings
        public ActionResult Index()
        {
            var ratings = db.Ratings.Include(r => r.Disciplina).Include(r => r.Student);
            return View(ratings.ToList());
        }

        // GET: Ratings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ratings ratings = db.Ratings.Find(id);
            if (ratings == null)
            {
                return HttpNotFound();
            }
            return View(ratings);
        }

        // GET: Ratings/Create
        public ActionResult Create()
        {
            ViewBag.Rating = new SelectList(db.Disciplina, "Id", "Title");
            ViewBag.Id_student = new SelectList(db.Student, "Id", "Name");
            return View();
        }

        // POST: Ratings/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_student,Data_lessons,Rating")] Ratings ratings)
        {
            if (ModelState.IsValid)
            {
                db.Ratings.Add(ratings);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Rating = new SelectList(db.Disciplina, "Id", "Title", ratings.Rating);
            ViewBag.Id_student = new SelectList(db.Student, "Id", "Name", ratings.Id_student);
            return View(ratings);
        }

        // GET: Ratings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ratings ratings = db.Ratings.Find(id);
            if (ratings == null)
            {
                return HttpNotFound();
            }
            ViewBag.Rating = new SelectList(db.Disciplina, "Id", "Title", ratings.Rating);
            ViewBag.Id_student = new SelectList(db.Student, "Id", "Name", ratings.Id_student);
            return View(ratings);
        }

        // POST: Ratings/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_student,Data_lessons,Rating")] Ratings ratings)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ratings).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Rating = new SelectList(db.Disciplina, "Id", "Title", ratings.Rating);
            ViewBag.Id_student = new SelectList(db.Student, "Id", "Name", ratings.Id_student);
            return View(ratings);
        }

        // GET: Ratings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ratings ratings = db.Ratings.Find(id);
            if (ratings == null)
            {
                return HttpNotFound();
            }
            return View(ratings);
        }

        // POST: Ratings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ratings ratings = db.Ratings.Find(id);
            db.Ratings.Remove(ratings);
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
