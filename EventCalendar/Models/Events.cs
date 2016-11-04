using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventCalendar.Models
{
    public class Events
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Event Name")]
        public string EventTitle { get; set; }

        [Required]
        [Display(Name = "Event Date"), DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime EventDate { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "Start Time")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh:mm:ss tt}")]
        public DateTime? StartTime { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "End Time")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh:mm:ss tt}")]
        public DateTime? EndTime { get; set; }

        public string URL { get; set; }

        [Display(Name = "All-Day Event?")]
        public bool? IsAllDay { get; set; }

        [Display(Name = "Special Instructions")]
        [DataType(DataType.MultilineText)]
        public string SpecialIntructions { get; set; }
    }
}