using Amoozeshgah.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Amoozeshgah.Core.Mapping
{
    public class OrganizationsUsersRoleMap : EntityTypeConfiguration<OrganizationUserRole>
    {
        public OrganizationsUsersRoleMap()
        {
            //Key
            HasKey(t => t.Id);

            //Properties
            
            //Table
            ToTable("OrganizationsUsersRoles");
        }
    }
}
