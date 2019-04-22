using Amoozeshgah.Resource;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Amoozeshgah.ViewModel
{
    public class ClassroomDto:Dto
    {
        public ClassroomDto()
        {
            PageTitle = "اتاق درس";
        }
        public int Id { get; set; }
        [Display(Name = "ClassCode", ResourceType = typeof(ClassroomResx))]
        [Required(ErrorMessageResourceName = "ClassroomCodeError", ErrorMessageResourceType = typeof(RequiredResx))]
        public string Code { get; set; }

        [Display(Name = "ClassName", ResourceType = typeof(ClassroomResx))]
        [Required(ErrorMessageResourceName = "ClassroomNameError", ErrorMessageResourceType = typeof(RequiredResx))]
        public string Name { get; set; }

        [Display(Name = "Description", ResourceType = typeof(BaseResx))]
        public string Description { get; set; }

        [Display(Name = "Capacity", ResourceType = typeof(ClassroomResx))]
        public int Capacity { get; set; }

        [Display(Name = "ClassroomTypeId", ResourceType = typeof(ClassroomResx))]
        public int ClassroomTypeId { get; set; }

        public IEnumerable<SelectListItem> ClassroomTypes { get; set; }
        public int EducationalCenterId { get; set; }
    }
}
