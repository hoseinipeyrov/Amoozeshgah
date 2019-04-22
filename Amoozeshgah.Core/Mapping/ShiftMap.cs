using Amoozeshgah.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Amoozeshgah.Core.Mapping
{
    public class ShiftMap : EntityTypeConfiguration<Shift>
    {
        public ShiftMap()
        {
            //Key
            HasKey(t => t.Id);
            
            //Properties

            //Table
            ToTable("Shifts");
        }
    }
}
