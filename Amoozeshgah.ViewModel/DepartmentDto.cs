using Amoozeshgah.Domain.Entities;
using Amoozeshgah.Resource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Amoozeshgah.ViewModel
{
    public class DepartmentDto : Dto
    {
        public DepartmentDto()
        {
            PageTitle = PageTitlesResx.Departments;

        }
        public IEnumerable<Department> Departments { get; set; }
        public IEnumerable<SelectListItem> DepartmentTypes { get; set; }
        //public IEnumerable<SelectListItem> Languages { get; set; }

        #region Fileds
        public int Id { get; set; }
        [Display(Name = "DepartmentType", ResourceType = typeof(DepartmentResx))]
        [Required(ErrorMessageResourceName = "DepartmentTypeNameError", ErrorMessageResourceType = typeof(RequiredResx))]

        public int DepartmentTypeId { get; set; }
        [Display(Name = "DepartmentTypeName", ResourceType = typeof(DepartmentResx))]

        public string DepartmentTypeName { get; set; }



        [Display(Name = "Name", ResourceType = typeof(DepartmentResx))]
        [Required(ErrorMessageResourceName = "DepartmentNameError", ErrorMessageResourceType = typeof(RequiredResx))]

        public string Name { get; set; }


        [Display(Name = "Description", ResourceType = typeof(BaseResx))]
        public string Description { get; set; }

        //[Display(Name = "Language", ResourceType = typeof(DepartmentResx))]
        //public int LanguageId { get; set; }
        public int SiteId { get; set; }
        #endregion

    }
}
