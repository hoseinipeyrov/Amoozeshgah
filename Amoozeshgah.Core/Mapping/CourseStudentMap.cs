using Amoozeshgah.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Amoozeshgah.Core.Mapping
{
   public class CourseStudentMap : EntityTypeConfiguration<CourseStudent> 
    {
       public CourseStudentMap()
       {
            //Key
            HasKey(c => c.Id);

            //Properties
            Property(cs =>cs.CourseId ).IsRequired();
            Property(cs =>cs.StudentId ).IsRequired();



            //Table
            ToTable("CourseStudents");

            //Relation          
      //      HasRequired(p => p.Person).WithRequiredDependent(u => u.User);
        }
    }
}
