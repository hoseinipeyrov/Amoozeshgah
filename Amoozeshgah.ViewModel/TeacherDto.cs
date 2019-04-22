using Amoozeshgah.Resource;
using System.ComponentModel.DataAnnotations;

namespace Amoozeshgah.ViewModel
{
    public class TeacherDto : Dto
    {
        public TeacherDto()
        {
            PageTitle = "مدرس";
        }
        public int Id { get; set; }

        [Display(Name = "TeacherCode", ResourceType = typeof(TeacherResx))]
        [Required(ErrorMessageResourceName = "TeacherCodeError", ErrorMessageResourceType = typeof(RequiredResx))]

        public string TeacherCode { get; set; }

        [Display(Name = "FatherName", ResourceType = typeof(TeacherResx))]
        public string FatherName { get; set; }

        [Display(Name = "IsInEvalutionTime", ResourceType = typeof(TeacherResx))]
        public bool IsInEvalutionTime { get; set; }
    }
}
