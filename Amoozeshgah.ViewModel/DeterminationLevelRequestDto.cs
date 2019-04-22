using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amoozeshgah.ViewModel
{
    public class DeterminationLevelRequestDto : Dto
    {
        [Display(Name = "کد مرکز آموزشی")]
        [Required(ErrorMessage = "کد مرکز آموزشی را وارد نمایید")]
        public int EducationalCenterCode { get; set; }

        [Display(Name = "تاریخ پیشنهادی")]
        [Required(ErrorMessage = "تاریخ پیشنهادی را وارد نمایید")]
        public string PreferDay { get; set; }
        [Display(Name = "ساعت پیشنهادی")]
        [Required(ErrorMessage = "ساعت پیشنهادی را وارد نمایید")]
        public string PreferHour { get; set; }

    }
}
