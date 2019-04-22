using Amoozeshgah.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Amoozeshgah.Core.Mapping
{
    public class RegularSchoolMap : EntityTypeConfiguration<RegularSchool>
    {
        public RegularSchoolMap()
        {
            //Key
            HasKey(t => t.Id);

            //Properties

            //Table
            ToTable("RegularSchools");
        }
    }
}
