using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amoozeshgah.ViewModel
{
   public class DeterminationLevelResponseDto:Dto
    {
        public DeterminationLevelResponseDto()
        {
            PageTitle = "تعیین وقت تعیین سطح";
        }

        public int Id { get; set; }

        [Display(Name = "تاریخ")]
        [Required(ErrorMessage = "تاریخ را وارد نمایید")]
        public string Day { get; set; }
        [Display(Name = "ساعت")]
        [Required(ErrorMessage = "ساعت را وارد نمایید")]
        public string Hour { get; set; }

        public string StudentFullName { get; set; }
        public string StudentPereferDate { get; set; }
        public string PhoneNo { get; set; }
    }
}
