using Amoozeshgah.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Amoozeshgah.Core.Mapping
{
    public class LanguageCenterMap : EntityTypeConfiguration<LanguageCenter>
    {
        public LanguageCenterMap()
        {
            //Key
            HasKey(t => t.Id);

            //Properties

            //Table
           // ToTable("LanguageCenters");
        }
    }
}
