using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventCalendar.Models
{
    public enum EventType
    {
        Birthday, Wedding, Graduation, Anniversary, Others
    }
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
        public DateTime StartTime { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "End Time")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh:mm:ss tt}")]
        public DateTime EndTime { get; set; }

        [Display(Name = "Event Type")]
        public EventType? EventType { get; set; }

        [Required]
        [Display(Name = "Street Number"), StringLength(50)]
        public string StreetNumber { get; set; }

        [Display(Name = "Street Name"), StringLength(50)]
        public string StreetName { get; set; }

        [Required, StringLength(30)]
        public string City { get; set; }

        [Required, StringLength(30)]
        public string State { get; set; }

        [Required]
        [DataType(DataType.PostalCode)]
        public string ZipCode { get; set; }

        public string URL { get; set; }

        [Display(Name = "All-Day Event?")]
        public bool? IsAllDay { get; set; }

        [Display(Name = "Special Instructions")]
        [DataType(DataType.MultilineText)]
        public string SpecialIntructions { get; set; }

        [Display(Name = "Event Address")]
        public string EventAddress {
            get
            {
                string streetName = string.IsNullOrWhiteSpace(this.StreetName) ? "" : this.StreetName + ", ";
                return string.Format($"{StreetNumber} {streetName} {City} {State} {ZipCode}");
            }
         }
    }
}