using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amoozeshgah.Domain.Entities
{
    public class Term : BaseEntity
    {
        public string Name { get; set; }
        public int Code { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int EducationalCenterId { get; set; }
        [ForeignKey("EducationalCenterId")]
        public virtual EducationalCenter EducationalCenter { get; set; }
        public virtual ICollection<Course> Courses { get; set; }

    }
}
