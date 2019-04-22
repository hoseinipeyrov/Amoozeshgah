using Amoozeshgah.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Amoozeshgah.Core.Mapping
{
    public class EducationalScientificCenterMap : EntityTypeConfiguration<ScientificCenter>
    {
        public EducationalScientificCenterMap()
        {
            //Key
            HasKey(t => t.Id);

            //Properties

            //Table
            ToTable("EducationalScientificCenters");
        }
    }
}
