using Amoozeshgah.Common.DateConverter;
using Amoozeshgah.Resource;
using Amoozeshgah.ViewModel.Attribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Amoozeshgah.ViewModel
{
    public class TermDto : Dto
    {
        public TermDto()
        {
            PageTitle = PageTitlesResx.Terms;
        }
        public int Id { get; set; }

        [Display(Name = "TermName", ResourceType = typeof(BaseResx))]
        [Required(ErrorMessageResourceName = "TermNameError", ErrorMessageResourceType = typeof(RequiredResx))]
        public string Name { get; set; }

        [Display(Name = "TermCode", ResourceType = typeof(BaseResx))]
        [Required(ErrorMessageResourceName = "TermCodeError", ErrorMessageResourceType = typeof(RequiredResx))]
        public int? Code { get; set; }

        [Display(Name = "TermStartDate", ResourceType = typeof(BaseResx))]
        [Required(ErrorMessageResourceName = "TermStartDateError", ErrorMessageResourceType = typeof(RequiredResx))]
        [RegularExpression(@"^[1-4]\d{3}\/((0?[1-6]\/((3[0-1])|([1-2][0-9])|(0?[1-9])))|((1[0-2]|(0?[7-9]))\/(30|([1-2][0-9])|(0?[1-9]))))$",
            ErrorMessage = "تاریخ به درستی وارد نشده")]
        [DateLessThan("EndDateShamsi", ErrorMessage = "تاریخ شروع باید زودتر از تاریخ پایان ترم باشد")]
        public string StartDateShamsi { get; set; }

        [Display(Name = "TermEndDate", ResourceType = typeof(BaseResx))]
        [Required(ErrorMessageResourceName = "TermEndDateError", ErrorMessageResourceType = typeof(RequiredResx))]
        [RegularExpression(@"^[1-4]\d{3}\/((0?[1-6]\/((3[0-1])|([1-2][0-9])|(0?[1-9])))|((1[0-2]|(0?[7-9]))\/(30|([1-2][0-9])|(0?[1-9]))))$",
            ErrorMessage="تاریخ به درستی وارد نشده")]
        public string EndDateShamsi { get; set; }


        //georgian

    }
}
