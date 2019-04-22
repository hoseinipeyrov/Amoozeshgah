using Amoozeshgah.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Amoozeshgah.Core.Mapping
{
    public class LanguageMap : EntityTypeConfiguration<Language>
    {
        public LanguageMap()
        {
            //Key
            HasKey(l => l.Id);

            //Properties
            Property(l => l.Name).IsRequired().HasMaxLength(50).HasColumnType("nvarchar");
            Property(l => l.NameFa).IsOptional().HasMaxLength(50).HasColumnType("nvarchar");
            
            //Table
            ToTable("Languages");
        }
    }
}
