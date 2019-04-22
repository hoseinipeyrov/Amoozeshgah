using Amoozeshgah.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Amoozeshgah.Core.Mapping
{
    public class RoleMap : EntityTypeConfiguration<Role>
    {
        public RoleMap()
        {
            //Key
            HasKey(t => t.Id);

            //Properties

            //Table
            ToTable("Roles");
        }
    }
}
