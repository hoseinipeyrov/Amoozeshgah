using Amoozeshgah.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Amoozeshgah.Core.Mapping
{
   public class TeacherMap : EntityTypeConfiguration<Teacher> 
    {
       public TeacherMap()
       {
           //Key
           HasKey(t => t.Id);

           //Properties

           //Table
           ToTable("Teachers");

            //Relation          
            HasRequired(t => t.User).WithRequiredDependent(u => u.Teacher);
        }
    }
}
