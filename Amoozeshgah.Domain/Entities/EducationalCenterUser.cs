using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amoozeshgah.Domain.Entities
{
   public class EducationalCenterUser : BaseEntity
    {
        public virtual User User { get; set; }
        public DateTime? HireDate { get; set; }
    }
}
