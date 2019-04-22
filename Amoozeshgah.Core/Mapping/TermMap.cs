using Amoozeshgah.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Amoozeshgah.Core.Mapping
{
    public class TermMap : EntityTypeConfiguration<Term>
    {
        public TermMap()
        {
            //Key
            HasKey(t => t.Id);

            //Properties
            Property(t => t.StartDate).IsRequired();
            Property(t => t.EndDate).IsRequired();

            //relations
            HasMany(t => t.Courses).
                WithRequired(c => c.Term).
                HasForeignKey(c => c.TermId).
                WillCascadeOnDelete(false);
            //Table
            ToTable("Terms");

            
        }
    }
}
