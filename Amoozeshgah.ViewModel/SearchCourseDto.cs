using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Amoozeshgah.Domain.Entities;

namespace Amoozeshgah.ViewModel
{
   public class SearchCourseDto:Dto
    {
        public SearchCourseDto()
        {
            PageTitle = "جستجوی درس";
        }

        [Display(Name = "استان")]
        [Required(ErrorMessage = "استان را انتخاب کنید")]
        public int? ProvinceId { get; set; }
        public IEnumerable<SelectListItem> Provinces { get; set; }


        [Display(Name = "ناحیه")]
        [Required(ErrorMessage = "ناحیه را انتخاب کنید")]
        public int? AreaId { get; set; }
        public IEnumerable<SelectListItem> Areas { get; set; }


        [Display(Name = "جنسیت")]
        [Required(ErrorMessage = "جنسیت را مشخص کنید")]
        public int SexId { get; set; }
        public IEnumerable<SelectListItem> Sexes { get; set; }

        [Display(Name = "نوع مرکز")]
        [Required(ErrorMessage = "نوع مرکز را انتخاب کنید")]
        public string EducationalCenterCategory { get; set; }
        public IEnumerable<SelectListItem> EducationalCenterCategories { get; set; }

        [Display(Name = "کد مرکز")]
        public int? EducationalCenterCode { get; set; }

        [Display(Name = "نام مرکز")]
        public string EducationalCenterName { get; set; }

        [Display(Name = "نام کلاس")]
        public string CourseName { get; set; }

        [Display(Name = "کد کلاس")]
        public string CourseCode { get; set; }

        public IEnumerable<Course> Courses { get; set; }


    }
}
