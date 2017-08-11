using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HikersConnection.Models;
using Microsoft.AspNet.Identity;

namespace HikersConnection.Controllers
{
    public class HikesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Hikes
        [Authorize]
        public ActionResult Index()
        {
            var hikes = db.Hikes
                .Include(u => u.OrganizerId)
                .Include(h => h.Trail);
            return View(hikes.ToList());
        }

        // GET: Hikes
        [Authorize]
        public ActionResult MyScheduledHikes()
        {
            var userId = User.Identity.GetUserId();
            var hikes = db.Hikes.Where (d => d.OrganizerId = userId)
                .Include(u => u.OrganizerId)
                .Include(h => h.Trail);
            return View(hikes.ToList());
        }

        // GET: Hikes/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hike hike = db.Hikes.Find(id);
            if (hike == null)
            {
                return HttpNotFound();
            }
            return View(hike);
        }

        // GET: Hikes/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.TrailID = new SelectList(db.Trails, "ID", "Name");
            ViewBag.OrganizerID = User.Identity.GetUserName();
            return View();
        }

        // POST: Hikes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Date,Time,TrailID,Notes,OrganizerId")] Hike hike)
        {
            if (ModelState.IsValid)
            {
                var Organizer = User.Identity.GetUserName();
                hike.Organizer = Organizer;
                db.Hikes.Add(hike);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TrailID = new SelectList(db.Trails, "ID", "Name", hike.TrailID);
            ViewBag.OrganizerID = User.Identity.GetUserName();
            return View(hike);
        }

        // GET: Hikes/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hike hike = db.Hikes.Find(id);
            if (hike == null)
            {
                return HttpNotFound();
            }
            ViewBag.TrailID = new SelectList(db.Trails, "ID", "Name", hike.TrailID);
            ViewBag.OrganizerID = User.Identity.GetUserName();
            return View(hike);
        }

        // POST: Hikes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Date,Time,TrailID,Notes,Organizer_Id")] Hike hike)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hike).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TrailID = new SelectList(db.Trails, "ID", "Name", hike.TrailID);
            ViewBag.OrganizerID = User.Identity.GetUserName();
            return View(hike);
        }

        // GET: Hikes/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hike hike = db.Hikes.Find(id);
            if (hike == null)
            {
                return HttpNotFound();
            }
            return View(hike);
        }

        // POST: Hikes/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hike hike = db.Hikes.Find(id);
            db.Hikes.Remove(hike);
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
