using Amoozeshgah.Resource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Amoozeshgah.ViewModel
{
    public class LessonDto : Dto
    {
        public LessonDto()
        {
            PageTitle = "درس";
        }
        public int Id { get; set; }
        [Display(Name = "Name", ResourceType = typeof(FieldResx))]
        public int FieldId { get; set; }

        [Display(Name = "LessonName", ResourceType = typeof(LessonResx))]
        public string Name { get; set; }

        [Display(Name = "Code", ResourceType = typeof(LessonResx))]
        public long? Code { get; set; }

        [Display(Name = "TotalHours", ResourceType = typeof(LessonResx))]
        [Required]
        public int? TotalHours { get; set; }

        [Display(Name = "BookName", ResourceType = typeof(LessonResx))]
        public string BookName { get; set; }


        public IEnumerable<SelectListItem> Fields { get; set; }


        [Display(Name = "LessonLevel", ResourceType = typeof(LessonResx))]
        public int LessonLevelId { get; set; }
        public IEnumerable<SelectListItem> LessonLevels { get; set; }
        [Display(Name = "Prerequirement", ResourceType = typeof(LessonResx))]
        public int? PrerequirementId { get; set; }
        public IEnumerable<SelectListItem> Prerequirements { get; set; }
        


    }
}