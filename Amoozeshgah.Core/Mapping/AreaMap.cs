using Amoozeshgah.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Amoozeshgah.Core.Mapping
{
    public class AreaMap : EntityTypeConfiguration<Area>
    {
        public AreaMap()
        {
            //Key
            HasKey(t => t.Id);
            //Properties

            //Table
            ToTable("Areas");

            //Relation
            HasRequired(s => s.Site).WithRequiredDependent(s => s.Area);
        }
    }
}
