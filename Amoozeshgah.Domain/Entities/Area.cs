using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amoozeshgah.Domain.Entities
{
    public class Area:BaseEntity
    {
        public int ProvinceId { get; set; }
        [ForeignKey(nameof(ProvinceId))]
        public virtual Province Province { get; set; }

        public virtual Site Site { get; set; }

        public virtual ICollection<EducationalCenter> EducationalCenters { get; set; }
        = new HashSet<EducationalCenter>();
        public virtual ICollection<MaximumTuition> MaximumTuitions { get; set; }
            = new HashSet<MaximumTuition>();
        
    }
}
