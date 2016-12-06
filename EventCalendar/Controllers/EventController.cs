using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EventCalendar.Models;
using EventCalendar.Data;


namespace EventCalendar.Controllers
{
    public class EventController : Controller
    {
        private EventCalendarContext db = new EventCalendarContext();

        // GET: Event
        public ActionResult Index()
        {
            return View(db.Events.ToList());
        }

        public JsonResult GetEvents()
        {
            var events = db.Events.ToList();
            var eventList = from e in events
                            select new
                            {
                                id = e.Id,
                                title = e.EventTitle,
                                start = e.StartDateTime.ToString("s"),
                                end = e.EndDateTime.ToString("s"),
                                allDay = false
                            };
            var rows = eventList.ToArray();
            return Json(rows, JsonRequestBehavior.AllowGet);
        }

        // GET: Event/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
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
            ViewBag.States = GetStates();
            return View();
        }

        // POST: Event/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EventTitle,EventDate,StartTime,EndTime,EventType,StreetNumber,StreetName,City,State,ZipCode,URL,IsAllDay,SpecialIntructions")] Event events)
        {
            ViewBag.States = GetStates();
            if (ModelState.IsValid)
            {
                db.Events.Add(events);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            DropDownRebind();
            return View(events);
        }

        // GET: Event/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event events = db.Events.Find(id);
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
            Event events = db.Events.Find(id);
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
            Event events = db.Events.Find(id);
            db.Events.Remove(events);
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

        // Added 2016-11-20
        private void DropDownRebind()
        {
            List<SelectListItem> SelectYesNo = new List<SelectListItem>();

            SelectYesNo.Add(new SelectListItem
            {
                Text = "Yes",
                Value = true.ToString()
            });
            SelectYesNo.Add(new SelectListItem
            {
                Text = "No",
                Value = false.ToString()
            });

            ViewData["selectYesNo"] = SelectYesNo;
        }

        private static DateTime ConvertFromUnixTimeStamp(double timestamp)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(timestamp);
        }

        private Dictionary<string, string> GetStates()
        {
            return new Dictionary<string, string>
            {
                {"AK", "Alaska" },
                {"Al", "Alabama" },
                {"AZ", "Arizona" },
                {"AR", "Arkansas" },
                {"CA", "California" },
                {"CO", "Colorado" },
                {"CT", "Connecticut" },
                {"DE", "Delaware" },
                {"FL", "Florida" },
                {"GA", "Georgia" },
                {"HI", "Hawaii" },
                {"ID", "Idaho" },
                {"IL", "Illinois" },
                {"IN", "Indiana" },
                {"IO", "Iowa" },
                {"KS", "Kansas" },
                {"KY", "Kentucky" },
                {"LA", "Louisiana" },
                {"ME", "Maine" },
                {"MD", "Maryland" },
                {"MA", "Massachusetts" },
                {"MI", "Michigan" },
                {"MN", "Minnesota" },
                {"MS", "Mississippi" },
                {"MO", "Missouri" },
                {"MT", "Montana" },
                {"NE", "Nebraska" },
                {"NV", "Nevada" },
                {"NH", "New Hampshire" },
                {"NJ", "New Jersey" },
                {"NM", "New Mexico" },
                {"NY", "New York" },
                {"NC", "North Carolina" },
                {"ND", "North Dakota" },
                {"TN", "Tennessee" },
                {"TX", "Texas" },
                {"UT", "Utah" },
                {"VT", "Vermont" },
                {"VI", "Virginia" },
                {"WA", "Washington" },
                {"WV", "West Virginia" },
                {"WI", "Wisconsin" },
                {"WY", "Wyoming" },
            };
        }
    }
}
