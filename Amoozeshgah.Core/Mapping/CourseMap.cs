using Amoozeshgah.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Amoozeshgah.Core.Mapping
{
   public class CourseMap : EntityTypeConfiguration<Course> 
    {
       public CourseMap()
       {
            //Key
            HasKey(c => c.Id);

            //Properties
            Property(cr =>cr.Name ).IsRequired().HasMaxLength(50);
            Property(cr => cr.Capacity).IsRequired();
            Property(cr => cr.Code).IsRequired();
            Property(cr => cr.Description).IsOptional();
            Property(cr => cr.TeacherId).IsRequired();
            Property(cr => cr.LessonId).IsRequired();


            //Table
            ToTable("Courses");

            //Relation 
        }
    }
}
