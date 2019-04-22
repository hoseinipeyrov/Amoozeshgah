using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Amoozeshgah.ViewModel
{
    public class AccountInformationDto : Dto
    {
        public AccountInformationDto()
        {
            PageTitle = "اطلاعات حساب";
        }

        [Display(Name = "نام صاحب حساب")]
        [Required(ErrorMessage = "نام صاحب حساب")]
        public string AccountOwnerFirstName { get; set; }

        [Display(Name = "نام خانوادگی صاحب حساب")]
        [Required(ErrorMessage = "نام خانوادگی صاحب حساب")]
        public string AccountOwnerLastName { get; set; }

        [Display(Name = "نام بانک")]
        [Required(ErrorMessage = "نام بانک")]
        public int BankId { get; set; }

        public IEnumerable<SelectListItem> Banks { get; set; }

        [Display(Name = "نام شعبه")]
        [Required(ErrorMessage = "نام شعبه")]
        public string BrancheName { get; set; }

        [Display(Name = "کد شعبه")]
        [Required(ErrorMessage = "کد شعبه")]
        public int? BrancheCode { get; set; }

        [Display(Name = "شماره حساب")]
        [Required(ErrorMessage = "شماره حساب")]
        public string AccountNumber { get; set; }

        [Display(Name = "شماره شبا")]
        [Required(ErrorMessage = "شماره شبا")]
        public string IdPay { get; set; }
    }
}
