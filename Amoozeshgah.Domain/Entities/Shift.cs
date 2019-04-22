using System.Collections;
using System.Collections.Generic;

namespace Amoozeshgah.Domain.Entities
{
    public class Shift: BaseEntity
    {
        public string Name { get; set; }
        public ICollection<EducationalCenter> EducationalCenters { get; set; }
    }
}
