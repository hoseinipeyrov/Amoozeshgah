using Amoozeshgah.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Amoozeshgah.Core.Mapping
{
    public class LicenseMap : EntityTypeConfiguration<License>
    {
        public LicenseMap()
        {
            //Key
            HasKey(t => t.Id);

            //Properties

            //Table
            ToTable("Licenses");
        }
    }
}
