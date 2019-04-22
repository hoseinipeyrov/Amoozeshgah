using Amoozeshgah.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Amoozeshgah.Core.Mapping
{
    public class PreSchoolMap : EntityTypeConfiguration<PreSchool>
    {
        public PreSchoolMap()
        {
            //Key
            HasKey(t => t.Id);

            //Properties

            //Table
            ToTable("PreSchools");
        }
    }
}
