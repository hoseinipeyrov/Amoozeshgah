using Amoozeshgah.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Amoozeshgah.Core.Mapping
{
   public class ClassroomMap : EntityTypeConfiguration<Classroom> 
    {
       public ClassroomMap()
       {
            //Key
            HasKey(cr => cr.Id);

            //Properties
            Property(cr =>cr.Name ).IsRequired().HasMaxLength(50);
            Property(cr => cr.Capacity).IsRequired();
            Property(cr => cr.ClassroomTypeId).IsRequired();
            Property(cr => cr.Code).IsRequired();
            Property(cr => cr.Description).IsOptional();


            //Table
            ToTable("Classrooms");

            //Relation          
      //      HasRequired(p => p.Person).WithRequiredDependent(u => u.User);
        }
    }
}
