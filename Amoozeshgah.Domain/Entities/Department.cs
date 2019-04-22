using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amoozeshgah.Domain.Entities
{
    public class Department : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        //public int EducationalCenterId { get; set; }
        //[ForeignKey("EducationalCenterId")]
        //public EducationalCenter EducationalCenter { get; set; }
        public int DepartmentTypeId { get; set; }
        [ForeignKey("DepartmentTypeId")]
        public virtual DepartmentType DepartmentType { get; set; }
        public virtual ICollection<Field> Fields { get; set; } 
            = new HashSet<Field>();
    }
}
