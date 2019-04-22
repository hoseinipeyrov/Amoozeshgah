using Amoozeshgah.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Amoozeshgah.Core.Mapping
{
    public class SchoolsLicenceMap : EntityTypeConfiguration<SchoolsLicence>
    {
        public SchoolsLicenceMap()
        {
            //Key
            HasKey(t => t.Id);

            //Properties

            //Table
            ToTable("SchoolsLicences");
        }
    }
}
