using Amoozeshgah.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Amoozeshgah.Core.Mapping
{
    public class SexMap : EntityTypeConfiguration<Sex>
    {
        public SexMap()
        {
            //Key
            HasKey(t => t.Id);

            //Properties

            //Table
            ToTable("Sexes");
        }
    }
}
