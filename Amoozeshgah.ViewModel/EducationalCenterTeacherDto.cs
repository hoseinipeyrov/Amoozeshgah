using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amoozeshgah.ViewModel
{
    public class EducationalCenterTeacherDto:Dto
    {
        public EducationalCenterTeacherDto()
        {
            PageTitle = "مدرسان";
        }
        [Display(Name = "نام")]
        public string FirstName { get; set; }

        [Display(Name = "نام خانوادگی")]
        public string LastName { get; set; }

        [Display(Name = "کد ملی")]
        public string NationalCode { get; set; }

        [Display(Name = "وضعیت")]
        public object Status { get; set; }
    }
}
