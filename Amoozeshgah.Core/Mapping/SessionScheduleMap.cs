using Amoozeshgah.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Amoozeshgah.Core.Mapping
{
    public class SessionScheduleMap : EntityTypeConfiguration<SessionSchedule>
    {
        public SessionScheduleMap()
        {
            //Key
            HasKey(t => t.Id);

            //Properties
            //Property(t => t.UserName).IsRequired().HasMaxLength(50);
            //Property(t => t.Password).IsRequired();

            //Table
            ToTable("SessionSchedules");

            //Relation  
        }
    }
}
