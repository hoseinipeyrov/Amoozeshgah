using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Amoozeshgah.ViewModel
{
    public class RefundRequestDto : Dto
    {
        public RefundRequestDto()
        {
            PageTitle = "درخواست استرداد";
        }
        [Display(Name = "کلاس")]
        [Required(ErrorMessage = "کلاس را انتخاب کنید")]
        public int CourseId { get; set; }
        public IEnumerable<SelectListItem> Courses { get; set; }

        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "توضیحات")]
        [AllowHtml]
        public string Description { get; set; }
        [Display(Name = "آپلود مدارک")]
        public HttpPostedFileBase Document { get; set; }
    }
}
