using Amoozeshgah.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Amoozeshgah.Core.Mapping
{
   public class ClassroomTypeMap : EntityTypeConfiguration<ClassroomType> 
    {
       public ClassroomTypeMap()
       {
            //Key
            HasKey(ct => ct.Id);

            //Properties
            Property(ct =>ct.Type).IsRequired().HasMaxLength(50);
            Property(ct => ct.Description).IsOptional();

            //Table
            ToTable("ClassroomTypes");

            //Relation          
        }
    }
}
