using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amoozeshgah.Domain.Entities
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public int Code { get; set; }

        public virtual ICollection<SiteUserRole> UserRoles { get; set; } = new List<SiteUserRole>();
        public virtual ICollection<ActionMethod> ActionMethods { get; set; } = new List<ActionMethod>();
    }
}
