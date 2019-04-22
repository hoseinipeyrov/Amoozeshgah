using Amoozeshgah.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Amoozeshgah.Core.Mapping
{
    public class ProvinceMap : EntityTypeConfiguration<Province>
    {
        public ProvinceMap()
        {
            //Key
            HasKey(t => t.Id);

            //Properties

            //Table
            ToTable("Provinces");

            HasRequired(a => a.Site).WithRequiredDependent(s => s.Province);
        }
    }
}
