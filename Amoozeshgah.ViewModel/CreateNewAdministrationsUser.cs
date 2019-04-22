using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Amoozeshgah.ViewModel
{
    public class CreateNewAdministrationsUserDto : Dto
    {
        public CreateNewAdministrationsUserDto()
        {
            PageTitle = "ایجاد کاربر استانی جدید";
        }
        public int Id { get; set; }
        [Display(Name = "نام")]
        [Required(ErrorMessage = "نام الزامیست")]
        public string FirstName { get; set; }

        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "نام خانوادگی الزامیست")]
        public string LasttName { get; set; }

        [Display(Name = "کد ملی")]
        [Required(ErrorMessage = "کد ملی الزامیست")]
        public string NationalCode { get; set; }

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "نام کاربری الزامیست")]
        public string UserName { get; set; }

        [Display(Name = "شماره تلفن همراه")]
        [Required(ErrorMessage = "شماره تلفن همراه")]
        [RegularExpression(@"((\+98|0)?9\d{9})|(^$)", ErrorMessage = "شماره تلفن همراه صحیح نیست")]
        public string MobileNo { get; set; }

        [Display(Name = "نام اداره")]
        [Required(ErrorMessage = "نام اداره الزامیست")]
        public int AdministrationId { get; set; }
        public IEnumerable<SelectListItem> Administrations { get; set; }
    }
}
