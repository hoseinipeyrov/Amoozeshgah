using Amoozeshgah.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace Amoozeshgah.Core.Mapping
{
    public class PersonMap : EntityTypeConfiguration<Person>
    {
        public PersonMap()
        {
            //Key
            HasKey(t => t.Id);

            //Properties

            // HasIndex(p => p.NationalCode).IsUnique();
            Property(p => p.NationalCode).IsRequired().HasMaxLength(10).HasColumnAnnotation(IndexAnnotation.AnnotationName,
                                                      new IndexAnnotation(new IndexAttribute("IX_Person_NationalCode_Unique", 0) { IsUnique = true }));
               Property(p => p.FirstName).IsRequired().HasMaxLength(50).HasColumnAnnotation(IndexAnnotation.AnnotationName,
                                                      new IndexAnnotation(new IndexAttribute("IX_Person_FirstNameAndLastName_Unique", 0) { IsUnique = true}));
            Property(p => p.LastName).IsRequired().HasMaxLength(50).HasColumnAnnotation(IndexAnnotation.AnnotationName, 
                                                      new IndexAnnotation(new IndexAttribute("IX_Person_FirstNameAndLastName_Unique", 1) { IsUnique = true}));
            //Table
            ToTable("People");
        }
    }
}
