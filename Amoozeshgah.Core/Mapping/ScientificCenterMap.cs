using Amoozeshgah.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Amoozeshgah.Core.Mapping
{
    public class ScientificCenterMap : EntityTypeConfiguration<ScientificCenter>
    {
        public ScientificCenterMap()
        {
            //Key
            HasKey(t => t.Id);

            //Properties

            //Table
            ToTable("ScientificCenters");
        }
    }
}
