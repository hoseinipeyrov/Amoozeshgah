using Amoozeshgah.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Amoozeshgah.Core.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            //Key
            HasKey(t => t.Id);

            //Properties
            Property(t => t.UserName).IsRequired().HasMaxLength(50);
            Property(t => t.Password).IsRequired();

            //Table
            ToTable("Users");

            //Relation          
            HasRequired(u => u.Person).WithRequiredDependent(p => p.User);
        }
    }
}
