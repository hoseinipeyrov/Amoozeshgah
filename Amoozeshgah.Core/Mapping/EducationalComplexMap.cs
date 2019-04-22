using Amoozeshgah.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Amoozeshgah.Core.Mapping
{
    public class EducationalComplexMap : EntityTypeConfiguration<Complex>
    {
        public EducationalComplexMap()
        {
            //Key
            HasKey(t => t.Id);

            //Properties

            //Table
            ToTable("EducationalComplexes");
        }
    }
}
