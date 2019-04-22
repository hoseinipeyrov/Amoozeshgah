using System.Collections.Generic;

namespace Amoozeshgah.Domain.Entities
{
   public class EducationDegree:BaseEntity
    {
        public string Name { get; set; }
        public int Code { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
            = new HashSet<Teacher>();
    }
}
