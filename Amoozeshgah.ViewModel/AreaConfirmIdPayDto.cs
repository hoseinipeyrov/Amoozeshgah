using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amoozeshgah.ViewModel
{
  public  class AreaConfirmIdPayDto:Dto
    {
        public AreaConfirmIdPayDto()
        {
            PageTitle = "تایید شبا";
        }
        [Display(Name = "سال")]
        public string EducationalCenterEstablishmentDateJalali { get; set; }

        [Display(Name = "کد مرکز آموزشی")]
        public int EducationalCenterCode { get; set; }

        [Display(Name = "نام مرکز آموزشی")]
        public string EducationalCenterName { get; set; }

        [Display(Name = "نوع مرکز")]
        public string EducationalCenterCategory { get; set; }

        [Display(Name = "وضعیت")]
        public string IdPayStatus { get; set; }

        [Display(Name = "شبا")]
        public string IdPay { get; set; }

        public string IdPayButtons { get; set; }
    }
}
