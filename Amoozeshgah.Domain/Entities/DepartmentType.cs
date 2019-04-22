using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amoozeshgah.Domain.Entities
{
    public class DepartmentType : BaseEntity
    {
        public DepartmentType()
        {
            Departments = new HashSet<Department>();
        }
        public string Name { get; set; }
        public string NameFa { get; set; }
        public string Description { get; set; }
        public int EducationalCenterId { get; set; }
        [ForeignKey("EducationalCenterId")]
        public virtual EducationalCenter EducationalCenter { get; set; }

        public virtual ICollection<Department> Departments { get; set; }
    }
}
