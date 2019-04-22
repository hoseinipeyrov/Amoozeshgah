using System.Collections.Generic;
using System.ComponentModel;

namespace Amoozeshgah.Domain.Entities
{
    public class Menu : BaseEntity
    {
        public string Name { get; set; }
        [DefaultValue(1)]
        public bool IsEnable { get; set; }
        public string CssClass { get; set; }
        public string IconName { get; set; }

        public virtual ICollection<MenuItem> MenuItems { get; set; }
        = new HashSet<MenuItem>();
        //public virtual ICollection<OrganizationMenuItem> OrganizationMenuItems { get; set; }
        //= new HashSet<OrganizationMenuItem>();
    }
}
