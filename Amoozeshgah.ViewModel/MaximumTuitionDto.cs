using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Amoozeshgah.Domain.Entities;

namespace Amoozeshgah.ViewModel
{
    public class MaximumTuitionDto:Dto
    {
        public MaximumTuitionDto()
        {
            PageTitle = "تعیین سقف شهریه";
        }

        [Display(Name = "از تاریخ")]
        [Required(ErrorMessage = "تاریخ شروع")]
        public string FromJalali { get; set; }
        [Display(Name = "تا تاریخ")]
        [Required(ErrorMessage = "تاریخ پایان")]
        public string ToJalali { get; set; }

        [Display(Name = "ناحیه")]
        [Required(ErrorMessage = "ناحیه را انتخاب کنید")]
        public int AreaId { get; set; }
        public IEnumerable<SelectListItem> Areas { get; set; }

        [Display(Name = "علمی ابتدایی")]
        [Required(ErrorMessage = "علمی ابتدایی")]
        public int? ScienceElementry { get; set; }

        [Display(Name = "علمی متوسطه اول")]
        [Required(ErrorMessage = "علمی متوسطه اول")]
        public int? ScienceFirstMiddle { get; set; }

        [Display(Name = "علمی متوسطه دوم")]
        [Required(ErrorMessage = "علمی متوسطه دوم")]
        public int? ScienceSecondMiddle { get; set; }

        [Display(Name = "زبان مقدماتی")]
        [Required(ErrorMessage = "زبان مقدماتی")]
        public int? LanguageElementary { get; set; }

        [Display(Name = "زبان میانی")]
        [Required(ErrorMessage = "زبان میانی")]
        public int? LanguageMiddle { get; set; }

        [Display(Name = "زبان پیشرفته")]
        [Required(ErrorMessage = "زبان پیشرفته")]
        public int? LanguageAdvanced { get; set; }

        [Display(Name = "آزمون")]
        [Required(ErrorMessage = "آزمون")]
        public int? Exam { get; set; }
    }
}
