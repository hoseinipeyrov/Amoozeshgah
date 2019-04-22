using Amoozeshgah.Resource;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amoozeshgah.ViewModel
{
    public class LanguageDto:Dto
    {
        public LanguageDto()
        {
            PageTitle = "تعریف زبان";
        }
        public int Id { get; set; }
        [Display(Name = "Name", ResourceType = typeof(BaseResx))]
        [Required(ErrorMessageResourceName = "LanguageNameError", ErrorMessageResourceType = typeof(RequiredResx))]
        public string Name { get; set; }
        [Display(Name = "NameFa", ResourceType = typeof(BaseResx))]
        public string NameFa { get; set; }
        public int? PlaceId { get; set; }
    }
}
