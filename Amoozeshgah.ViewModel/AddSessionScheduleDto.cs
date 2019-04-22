using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Amoozeshgah.ViewModel
{
    public class AddSessionScheduleDto : Dto
    {
        [Display(Name = "تاریخ شروع")]
        public string StartDayJalali { get; set; }

        [Display(Name = "ساعت شروع")]
        public string StartHour { get; set; }

        [Display(Name = "روز")]
        public string StartDayName { get; set; }

        [Display(Name = "ساعت شروع")]
        public string StartTimeJalali { get; set; }
        [Display(Name = "تاریخ و ساعت شروع")]
        public string StartDayTimeJalali { get; set; }




        public string EndDateJalali { get; set; }
        public string EndTimeJalali { get; set; }

        public string EndDateTimeJalali { get; set; }

        [Display(Name = "درس")]
        public int CourseId { get; set; }

        [Display(Name = "اتاق درس")]
        public int ClassroomId { get; set; }
        public IEnumerable<SelectListItem> Classrooms { get; set; }
    }
}
