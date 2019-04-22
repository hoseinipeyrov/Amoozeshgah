using Amoozeshgah.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Amoozeshgah.Core.Mapping
{
    public class SiteUserRoleMap : EntityTypeConfiguration<SiteUserRole>
    {
        public SiteUserRoleMap()
        {
            //Key
            HasKey(t => t.Id);

            //Properties
            
            //Table
            ToTable("SiteUserRoles");
        }
    }
}
