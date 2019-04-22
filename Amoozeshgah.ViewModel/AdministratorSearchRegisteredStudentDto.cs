using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Amoozeshgah.ViewModel
{
   public class AdministratorSearchRegisteredStudentDto: Dto
    {
        public AdministratorSearchRegisteredStudentDto()
        {
            PageTitle = "فراگیران ثبت نام شده";
        }
        [Display(Name = "استان")]
        [Required(ErrorMessage = "استان را انتخاب کنید")]
        public int? ProvinceId { get; set; }

        public List<SelectListItem> Provinces { get; set; }
            = new List<SelectListItem>();

        [Display(Name = "ناحیه")]
        [Required(ErrorMessage = "ناحیه را انتخاب کنید")]
        public int? AreaId { get; set; }
        public List<SelectListItem> Areas { get; set; }
            = new List<SelectListItem>();

        [Display(Name = "جنسیت")]
        [Required(ErrorMessage = "جنسیت را مشخص کنید")]
        public int SexId { get; set; }
        public List<SelectListItem> Sexes { get; set; }
            = new List<SelectListItem>();

        [Display(Name = "نوع مرکز")]
        [Required(ErrorMessage = "نوع مرکز را انتخاب کنید")]
        public string EducationalCenterCategory { get; set; }
        public IEnumerable<SelectListItem> EducationalCenterCategories { get; set; }

        [Display(Name = "کد مرکز")]
        public int? EducationalCenterCode { get; set; }

        [Display(Name = "نام مرکز")]
        public string EducationalCenterName { get; set; }
    }
}
