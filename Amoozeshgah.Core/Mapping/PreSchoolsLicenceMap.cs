using Amoozeshgah.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Amoozeshgah.Core.Mapping
{
    public class PreSchoolsLicenceMap : EntityTypeConfiguration<PreSchoolsLicence>
    {
        public PreSchoolsLicenceMap()
        {
            //Key
            HasKey(t => t.Id);

            //Properties

            //Table
            ToTable("PreSchoolsLicences");
        }
    }
}
