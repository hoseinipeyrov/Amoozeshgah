using Amoozeshgah.Resource;
using System.ComponentModel.DataAnnotations;

namespace Amoozeshgah.ViewModel
{
    public class CustomLanguageTypeDto
    {
        //public int Id { get; set; }
        [Display(Name = "LanguageName", ResourceType = typeof(LanguageTypeResx))]
        public string Name { get; set; }
        [Display(Name = "LanguageNameFarsi", ResourceType = typeof(LanguageTypeResx))]
        public string NameFa { get; set; }
    }
}
