using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HikersConnection.Models;

namespace HikersConnection.Controllers
{
    public class HikersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Hikers
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Hikers.ToList());
        }

        // GET: Hikers/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hiker hiker = db.Hikers.Find(id);
            if (hiker == null)
            {
                return HttpNotFound();
            }
            return View(hiker);
        }

        // GET: Hikers/Create
        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new Hiker
            {
                AgeGroups = db.AgeGroups.ToList()
            };

            return View(viewModel);
        }

        // POST: Hikers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,LastName,FirstName,AgeGroupID")] Hiker hiker)
        {
            var viewModel = new Hiker
            {
                AgeGroups = db.AgeGroups.ToList()
            };

            if (ModelState.IsValid)
            {
                db.Hikers.Add(hiker);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View (viewModel);
        }

        // GET: Hikers/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hiker hiker = db.Hikers.Find(id);
            hiker.AgeGroups = db.AgeGroups.ToList();
            if (hiker == null)
            {
                return HttpNotFound();
            }
            return View(hiker);
        }

        // POST: Hikers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,LastName,FirstName,AgeGroupID")] Hiker hiker)
        {
            var viewModel = new Hiker
            {
                AgeGroups = db.AgeGroups.ToList()
            };

            if (ModelState.IsValid)
            {
                db.Entry(hiker).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        // GET: Hikers/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hiker hiker = db.Hikers.Find(id);
            if (hiker == null)
            {
                return HttpNotFound();
            }
            return View(hiker);
        }

        // POST: Hikers/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hiker hiker = db.Hikers.Find(id);
            db.Hikers.Remove(hiker);
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
