using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EventCalendar.Models;

namespace EventCalendar.Controllers
{
    public class EventController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Event
        public ActionResult Index()
        {
            return View(db.Event.ToList());
        }

        // GET: Event/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Event.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // GET: Event/Create
        public ActionResult Create()
        {
            ViewBag.CurrentDate = DateTime.Now.Date.ToShortDateString();
            return View();
        }

        // POST: Event/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EventTitle,EventDate,StartTime,EndTime,EventType,StreetNumber,StreetName,City,State,ZipCode,URL,IsAllDay,SpecialIntructions")] Event events)
        {
            if (ModelState.IsValid)
            {
                db.Event.Add(events);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(events);
        }

        // GET: Event/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event events = db.Event.Find(id);
            if (events == null)
            {
                return HttpNotFound();
            }
            return View(events);
        }

        // POST: Event/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EventTitle,EventDate,StartTime,EndTime,EventType,StreetNumber,StreetName,City,State,ZipCode,URL,IsAllDay,SpecialIntructions")] Event events)
        {
            if (ModelState.IsValid)
            {
                db.Entry(events).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(events);
        }

        // GET: Event/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event events = db.Event.Find(id);
            if (events == null)
            {
                return HttpNotFound();
            }
            return View(events);
        }

        // POST: Event/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event events = db.Event.Find(id);
            db.Event.Remove(events);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Calendar()
        {
            return View();
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
