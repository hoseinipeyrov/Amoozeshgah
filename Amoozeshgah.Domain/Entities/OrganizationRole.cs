using System.Collections.Generic;

namespace Amoozeshgah.Domain.Entities
{
    public class OrganizationRole : BaseEntity
    {
        public string NameFa { get; set; }
        public string Name { get; set; }
        public virtual ICollection<OrganizationMenuItem> MenuItems { get; set; }
        = new HashSet<OrganizationMenuItem>();
        public virtual ICollection<OrganizationUserRole> SitesUsersRoles { get; set; }
        = new HashSet<OrganizationUserRole>();
    }
}
