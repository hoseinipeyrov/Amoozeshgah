using Amoozeshgah.Resource;
using System.ComponentModel.DataAnnotations;

namespace Amoozeshgah.ViewModel
{
    public class DepartmentTypeDto : Dto
    {
        public DepartmentTypeDto()
        {
            PageTitle = PageTitlesResx.DepartmentTypes;
        }
        public int Id { get; set; }

        [Display(Name = "Name", ResourceType = typeof(BaseResx))]
        [Required(ErrorMessageResourceName = "DepartmentTypeNameError", ErrorMessageResourceType = typeof(RequiredResx))]
        public string Name { get; set; }
        [Display(Name = "NameFa", ResourceType = typeof(BaseResx))]
        public string NameFa { get; set; }
        [Display(Name = "Description", ResourceType = typeof(BaseResx))]
//        [RegularExpression(
//    "^[a-zA-Z0-9_]*$",
//    ErrorMessageResourceType = typeof(Resources.RegistrationModel),
//    ErrorMessageResourceName = "UsernameError"
//)]
        public string Description { get; set; }
    }
}
