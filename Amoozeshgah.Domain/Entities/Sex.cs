using System.Collections.Generic;

namespace Amoozeshgah.Domain.Entities
{
    public class Sex : BaseEntity
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public virtual ICollection<EducationalCenter> EducationalCenters { get; set; }
        = new HashSet<EducationalCenter>();
    }
}
