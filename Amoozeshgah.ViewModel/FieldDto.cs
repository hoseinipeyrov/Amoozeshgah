using Amoozeshgah.Domain.Entities;
using Amoozeshgah.Resource;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace Amoozeshgah.ViewModel
{
    public class FieldDto : Dto
    {
        public FieldDto()
        {
            PageTitle = "رشته";
        }
        public int Id { get; set; }

        [Display(Name = "Name", ResourceType = typeof(FieldResx))]
        public string Name { get; set; }
        [Display(Name = "Description", ResourceType = typeof(BaseResx))]
        public string Description { get; set; }

        [Display(Name = "Name", ResourceType = typeof(DepartmentResx))]
        public int DepartmentId { get; set; }

        [Display(Name = "Name", ResourceType = typeof(DepartmentResx))]
        public string DepartmentName { get; set; }

        public IEnumerable<SelectListItem> Departments { get; set; }
        [Display(Name = "نوع دپارتمان")]
        public string DepartmentTypeName { get; set; }
    }
}
