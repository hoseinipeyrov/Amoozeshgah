using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amoozeshgah.Domain.Entities
{
    public class Field : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        public virtual ICollection<Lesson> Lessons { get; set; }
        = new HashSet<Lesson>();
    }
}
