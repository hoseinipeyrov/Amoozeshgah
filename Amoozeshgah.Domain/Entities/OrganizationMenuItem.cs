using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amoozeshgah.Domain.Entities
{
    public class OrganizationMenuItem : BaseEntity
    {
        public string Name { get; set; }
        public bool IsEnable { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string CssClass { get; set; }

        public int MenuId { get; set; }
        [ForeignKey("MenuId")]
        public virtual Menu Menu { get; set; }

        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public virtual OrganizationRole Role { get; set; }
    }
}
