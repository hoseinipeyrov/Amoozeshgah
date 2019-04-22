using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Amoozeshgah.ViewModel
{
    public class EducationalCenterRuleDto : Dto
    {
        public EducationalCenterRuleDto()
        {
            PageTitle = "قوانین مرکز آموزشی";
        }
        [Display(Name = "قوانین مرکز آموزشی ")]
        [Required(ErrorMessage = "لطفا قوانین مرکز آموزشی را وارد نمایید")]
        [AllowHtml]
        public string Rule { get; set; }

        public string EducationalCenterName { get; set; }
    }
}
