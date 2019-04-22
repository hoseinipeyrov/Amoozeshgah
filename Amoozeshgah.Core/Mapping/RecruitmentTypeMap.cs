using Amoozeshgah.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Amoozeshgah.Core.Mapping
{
    public class RecruitmentTypeMap : EntityTypeConfiguration<RecruitmentType>
    {
        public RecruitmentTypeMap()
        {
            //Key
            HasKey(t => t.Id);
            Property(t => t.Name).IsRequired().HasMaxLength(50);

            //Properties

            //Table
            ToTable("RecruitmentTypes");
        }

    }
}
