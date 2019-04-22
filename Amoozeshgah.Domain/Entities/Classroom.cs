using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amoozeshgah.Domain.Entities
{
    public class Classroom : BaseEntity
    {

        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }

        public int EducationalCenterId { get; set; }
        [ForeignKey(nameof(EducationalCenterId))]
        public virtual EducationalCenter EducationalCenter { get; set; }

        public int ClassroomTypeId { get; set; }
        [ForeignKey("ClassroomTypeId")]
        public virtual ClassroomType ClassroomType { get; set; }
    }
}
