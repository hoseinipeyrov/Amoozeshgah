using Amoozeshgah.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Amoozeshgah.Core.Mapping
{
    public class RegularSchoolLicensMap : EntityTypeConfiguration<RegularSchoolLicens>
    {
        public RegularSchoolLicensMap()
        {
            //Key
            HasKey(t => t.Id);


            //Properties

            //Table
            ToTable("RegularSchoolLicenses");
        }
    }
}
