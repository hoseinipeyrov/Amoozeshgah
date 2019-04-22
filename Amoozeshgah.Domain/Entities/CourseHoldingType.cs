using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amoozeshgah.Domain.Entities
{
    /// <summary>
    /// نوع برگزاری دوره
    /// </summary>
    public class CourseHoldingType : BaseEntity
    {
        public string Name { get; set; }
        public int Code { get; set; }
        public ICollection<EducationalCenter> EducationalCenters { get; set; }
    }
}
