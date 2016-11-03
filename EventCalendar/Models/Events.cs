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
        public string Title { get; set; }

    //    [Required]
    //    [DataType(DataType.Date)]
        public DateTime Date { get; set; }

   //     [Required]
   //     [DataType(DataType.Time)]
        [Display(Name = "Start Time")]
        public string StartTime { get; set; }

  //      [Required]
  //      [DataType(DataType.Time)]
        [Display(Name = "End Time")]
        public string EndTime { get; set; }


        [Display(Name = "URL")]
        public string Url { get; set; }


        public bool? allDay { get; set; }
    }
}