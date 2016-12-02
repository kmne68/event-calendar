using EventCalendar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventCalendar.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult  GetEvents(double start, double end)
        {
            var fromDate = ConvertFromUnixTimestamp(start);
            var toDate = ConvertFromUnixTimestamp(end);

            //Get the events
            //You may get from the repository also
            var eventList = GetEvents();

            var rows = eventList.ToArray();
            return Json(rows, JsonRequestBehavior.AllowGet);
        }

        private List<Event> GetEvents()
        {
            List<Event> eventList = new List<Event>();

      /*      Event newEvent = new Event {
                Id = 1,
                EventTitle = "Event 771",
                //StartTime = DateTime.Now.AddDays(1).ToString("s"),
                StartTime = DateTime.Now.AddDays(1),
                //EndTime = DateTime.Now.AddDays(1).ToString("s"),
                EndTime = DateTime.Now.AddDays(1),
                IsAllDay = IsAllDay.No,
                SpecialIntructions = "Reserve me a date"
            };

    
            eventList.Add(newEvent);

            newEvent = new Event
            {
                Id = 1,
                EventTitle = "Event 3",
                StartTime = DateTime.Now.AddDays(2),
                EndTime = DateTime.Now.AddDays(3),
                IsAllDay = IsAllDay.No,
                SpecialIntructions = "Make the event awesome!"
            };

            eventList.Add(newEvent);
            */
            return eventList;
        }

        private static DateTime ConvertFromUnixTimestamp(double timestamp)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(timestamp);
        }


        // Added 12/1

        public JsonResult GetDiarySummary(double start, double end)
        {
            var ApptListForDate = Schedule.LoadAppointmentSummaryInDateRange(start, end);
            var eventList = from e in ApptListForDate
                            select new
                            {
                                id = e.Id,
                                title = e.EventTitle,
                                date = e.EventDate,
                                start = e.StartTime,
                                end = e.EndTime,
                                color = e.EventType,
                                allDay = false
                            };
            var rows = eventList.ToArray();
            return Json(rows, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDiaryEvents(double start, double end)
        {
            var ApptListForDate = Schedule.LoadAllAppointmentsInDateRange(start, end);
            var eventList = from e in ApptListForDate
                            select new
                            {
                                id = e.Id,
                                title = e.EventTitle,
                                date = e.EventDate,
                                start = e.StartTime,
                                end = e.EndTime,
                                color = e.EventType
                            };
            var rows = eventList.ToArray();
            return Json(rows, JsonRequestBehavior.AllowGet);
        }
    }
}