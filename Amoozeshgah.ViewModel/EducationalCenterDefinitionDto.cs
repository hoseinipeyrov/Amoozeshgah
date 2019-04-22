using Amoozeshgah.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Amoozeshgah.ViewModel
{
    public class EducationalCenterDefinitionDto : Dto
    {
        public EducationalCenterDefinitionDto()
        {
            PageTitle = "موسسه آموزشی";
        }
        public int Id { get; set; }
        [Display(Name = "نام موسسه")]
        [Required(ErrorMessage = "نام موسسه را وارد کنید")]
        public string EducationalCenterName { get; set; }

        [Display(Name = "جنسیت")]
        [Required(ErrorMessage = "جنسیت را انتخاب کنید")]
        public int SexId { get; set; }
        public IEnumerable<SelectListItem> Sexes { get; set; }

        [Display(Name = "شیفت")]
        [Required(ErrorMessage = "شیفت را انتخاب کنید")]
        public int ShiftId { get; set; }
        public IEnumerable<SelectListItem> Shifts { get; set; }


        [Display(Name = "شماره مجوز موافقت اصولی")]
        public string CertificateCode { get; set; }

        [Display(Name = "شماره تلفن ثابت اول")]
        public string PhoneNo1 { get; set; }

        [Display(Name = "شماره تلفن ثابت دوم")]
        public string PhoneNo2 { get; set; }
        [Display(Name = "نشانی")]
        public string Address { get; set; }

        [Display(Name = "نام موسس")]
        [Required(ErrorMessage = "نام موسس را وارد کنید")]
        public string MoassesFirstName { get; set; }

        [Display(Name = "نام خانوادگی موسس")]
        [Required(ErrorMessage = "نام خانوادگی موسس را وارد نمایید")]
        public string MoassesLastName { get; set; }

        [Display(Name = "کد ملی موسس")]
        [Required(ErrorMessage = "کد ملی موسس را وارد نمایید")]
        public string MoassesNationalCode { get; set; }

        [Display(Name = "شماره تلفن همراه")]
        [Required(ErrorMessage = "شماره تلفن همراه را وارد نمایید")]
        public string MoassesMobileNo { get; set; }

        public string Category { get; set; }

        [Display(Name = "نوع مرکز آموزشی")]
        [Required(ErrorMessage = "نوع مرکز آموزشی را انتخاب کنید")]
        //[RegularExpression(@"((\+98|0)?9\d{9})|(^$)", ErrorMessage = "شماره تلفن همراه صحیح نیست")]
        public int[] CategoryItemsIds { get; set; }

    }
}
