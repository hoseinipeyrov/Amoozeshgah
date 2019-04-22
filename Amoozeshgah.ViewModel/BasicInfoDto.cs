using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Amoozeshgah.Common;
using Amoozeshgah.Domain.Entities;

namespace Amoozeshgah.ViewModel
{
    public class BasicInfoDto : Dto
    {
        public BasicInfoDto()
        {
            PageTitle = "مشخصات";
        }
        [Display(Name = "کد مرکز")]
        public int Id { get; set; }
        [Display(Name = "نام مرکز")]
        public string Name { get; set; }

        [Display(Name = "تلفن ثابت")]
        [Required(ErrorMessage = "تلفن ثابت را وارد کنید")]
        public string PhoneNo1 { get; set; }

        [Display(Name = "جنسیت")]
        public string Sex { get; set; }

        [Display(Name = "کد مجوز موافقت اصولی")]
        [Required(ErrorMessage = "کد مجوز موافقت اصولی را وارد کنید")]
        public string CertificateCode { get; set; }

        [Display(Name = "نوع واحد آموزشی")]
        public string Category { get; set; }

        [Display(Name = "زیر نوع")]
        public string[] CategoryItems { get; set; }

        [Display(Name = "شیفت")]
        public string Shift { get; set; }

        [Display(Name = "کد پستی")]
        [Required(ErrorMessage = "کد پستی را وارد نمایید")]
        public string PostalCode { get; set; }

        [Display(Name = "نشانی")]
        [Required(ErrorMessage = "نشانی را وارد نمایید")]
        public string Address { get; set; }

        [Display(Name = "نوع مجوز")]
        [Required(ErrorMessage = "نوع مجوز را انتخاب کنید")]
        public int? CertificateTypeId { get; set; }
        public IEnumerable<SelectListItem> CertificateTypes { get; set; }

        [Display(Name = "سال تاسیس")]
        [Required(ErrorMessage = "سال تاسیس را انتخاب کنید")]
        public int? EstablishmentDate { get; set; }
        public IEnumerable<SelectListItem> CourseHoldingTypes { get; set; }

        [Display(Name = "واقع در ساختمان")]
        [Required(ErrorMessage = "مکان را وارد نمایید")]
        public string SitePlace { get; set; }

        [Display(Name = "نوع برگزاری دوره")]
        [Required(ErrorMessage = "نوع برگزاری دوره را مشخص کنید")]
        public int[] CourseHoldingTypesIds { get; set; }

    }
}
