using Amoozeshgah.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Amoozeshgah.Core.Mapping
{
    public class PreSchoolLicensMap : EntityTypeConfiguration<PreSchoolLicens>
    {
        public PreSchoolLicensMap()
        {
            //Key
            HasKey(t => t.Id);

            //Properties

            //Table
            ToTable("PreSchoolLicenses");
        }
    }
}
