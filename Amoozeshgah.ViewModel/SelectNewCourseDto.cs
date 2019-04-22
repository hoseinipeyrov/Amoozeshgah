using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Amoozeshgah.ViewModel
{
    public class SelectNewCourseDto:Dto
    {
        public SelectNewCourseDto()
        {
            PageTitle = "انتخاب درس";
        }
        public int Id { get; set; }
        public IEnumerable<SelectListItem> Categorys { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<SelectListItem> CategoryItems { get; set; }
        public int CategoryItemId { get; set; }
        public IEnumerable<SelectListItem> Provinces { get; set; }
        public int ProvinceId { get; set; }
        public IEnumerable<SelectListItem> Citys { get; set; }
        public int CityId { get; set; }
        public IEnumerable<SelectListItem> EducationalCenters { get; set; }
        public IEnumerable<SelectListItem> Cources { get; set; }

    }
}
