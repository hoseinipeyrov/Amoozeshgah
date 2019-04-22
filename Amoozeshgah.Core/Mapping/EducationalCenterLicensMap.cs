using Amoozeshgah.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Amoozeshgah.Core.Mapping
{
    public class EducationalCenterLicensMap : EntityTypeConfiguration<CenterLicense>
    {
        public EducationalCenterLicensMap()
        {
            //Key
            HasKey(t => t.Id);

            //Properties

            //Table
            ToTable("EducationalCenterLicenses");
        }
    }
}
