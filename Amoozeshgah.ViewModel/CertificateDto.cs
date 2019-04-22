using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amoozeshgah.ViewModel
{
  public  class CertificateDto:Dto
    {
        public CertificateDto()
        {
            PageTitle = "مجوز ها";
        }
        [Display(Name = "تاریخ مجوز تاسیس موقت")]
        [Required(ErrorMessage = "تاریخ مجوز تاسیس موقت")]
        public string TemporaryEstablishmentCertificateJalaliDate { get; set; }

        [Display(Name = "شماره مجوز تاسیس موقت")]
        [Required(ErrorMessage = "شماره مجوز تاسیس موقت")]
        public string TemporaryEstablishmentCertificateNumber { get; set; }

        [Display(Name = "تاریخ مجوز راه اندازی")]
        [Required(ErrorMessage = "تاریخ مجوز راه اندازی")]
        public string BootCertificateJalaliDate { get; set; }

        [Display(Name = "شماره مجوز راه اندازی")]
        [Required(ErrorMessage = "شماره مجوز راه اندازی")]
        public string BootCertificateNumber { get; set; }

        [Display(Name = "تاریخ مجوز جا به جایی")]
        [Required(ErrorMessage = "تاریخ مجوز جا به جایی")]
        public string MovementCertificateJalaliDate { get; set; }

        [Display(Name = "تاریخ مجوز زوج و فرد")]
        [Required(ErrorMessage = "تاریخ مجوز زوج و فرد")]
        public string EvenOddCertificateJalaliDate { get; set; }

        [Display(Name = "شماره مجوز زوج و فرد")]
        [Required(ErrorMessage = "شماره مجوز زوج و فرد")]
        public string EvenOddCertificateNumber { get; set; }



    }
}
