using System.Collections.Generic;

namespace Amoozeshgah.Domain.Entities
{
    public class CertificateType:BaseEntity
    {
        public string Title { get; set; }
        public virtual ICollection<EducationalCenter> EducationalCenters { get; set; }
            = new HashSet<EducationalCenter>();
    }
}
