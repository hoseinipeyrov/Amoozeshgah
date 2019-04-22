using Amoozeshgah.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Amoozeshgah.Core.Mapping
{
    public class EducationalBranchMap : EntityTypeConfiguration<Branch>
    {
        public EducationalBranchMap()
        {
            //Key
            HasKey(t => t.Id);

            //Properties

            //Table
            ToTable("EducationalBranches");
        }
    }
}
