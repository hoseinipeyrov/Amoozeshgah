using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amoozeshgah.Domain.Entities
{
    public class ClassroomType : BaseEntity
    {
        public string Type { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Classroom> Classrooms { get; set; }
    }
}
