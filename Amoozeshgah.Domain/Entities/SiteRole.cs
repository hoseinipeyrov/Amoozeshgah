using System.Collections.Generic;

namespace Amoozeshgah.Domain.Entities
{
    public partial class SiteRole : BaseEntity
    {
        public string NameFa { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public virtual ICollection<SiteMenuItem> MenuItems { get; set; }
        = new HashSet<SiteMenuItem>();
        public virtual ICollection<SiteUserRole> SitesUsersRoles { get; set; }
        = new HashSet<SiteUserRole>();
    }
}
