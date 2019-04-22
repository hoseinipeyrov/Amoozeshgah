using System;
using Amoozeshgah.Resource;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Amoozeshgah.ViewModel
{
    public class CourseDto : Dto
    {
        public CourseDto()
        {
            PageTitle = "تشکیل کلاس";
        }
        [Key]
        public int Id { get; set; }

        [Display(Name = "ClassCode", ResourceType = typeof(BaseResx))]
        [Required(ErrorMessageResourceName = "ClassCodeError", ErrorMessageResourceType = typeof(RequiredResx))]
        public string Code { get; set; }

        [Display(Name = "ClassName", ResourceType = typeof(BaseResx))]
        [Required(ErrorMessageResourceName = "ClassNameNameError", ErrorMessageResourceType = typeof(RequiredResx))]
        public string Name { get; set; }

        [Display(Name = "ClassCapacity", ResourceType = typeof(BaseResx))]
        public int Capacity { get; set; }

        [Display(Name = "Description", ResourceType = typeof(BaseResx))]
        public string Description { get; set; }

        [Display(Name = "ClassroomName", ResourceType = typeof(BaseResx))]
        [Required(ErrorMessage = "اتاق")]
        public int ClassroomId { get; set; }

        [Display(Name = "TeacherName", ResourceType = typeof(BaseResx))]
        [Required(ErrorMessage = "کد استاد")]
        public int TeacherId { get; set; }

        [Display(Name = "LessonName", ResourceType = typeof(BaseResx))]
        [Required(ErrorMessage = "نام درس")]
        public int LessonId { get; set; }

        [Display(Name = "تاریخ شروع")]
        [Required(ErrorMessage = "تاریخ شروع")]
        public string StartDateJalali { get; set; }
        [Display(Name = "TermName", ResourceType = typeof(BaseResx))]
        [Required(ErrorMessage = "ترم")]

        public int TermId { get; set; }
        public IEnumerable<SelectListItem> Classrooms { get; set; }
        public IEnumerable<SelectListItem> Teachers { get; set; }
        public IEnumerable<SelectListItem> Lessons { get; set; }
        public IEnumerable<SelectListItem> Terms { get; set; }


        [Display(Name = "تعداد جلسات")]
        [Required(ErrorMessage = "تعداد جلسات را وارد نمایید")]
        [Range(0, 100, ErrorMessage = "تعداد مجاز 0 تا 100 ")]

        public int SessionCount { get; set; }

        [Display(Name = "شهریه کل")]
        [Required(ErrorMessage = "شهریه کل را وارد نمایید")]
        public int? Price { get; set; }

    }
}
