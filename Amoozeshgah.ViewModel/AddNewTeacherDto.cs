using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amoozeshgah.ViewModel
{
    public class AddNewTeacherDto:Dto
    {
        [Display(Name = "نام")]
        public string FirstName { get; set; }

        [Display(Name = "نام خانوادگی")]
        public string LastName { get; set; }

        [Display(Name = "کد ملی")]
        public string NationalCode { get; set; }

        public ICollection<AddNewTeacherDto> EducationalCenterTeachers { get; set; }
            = new HashSet<AddNewTeacherDto>();
    }

}
