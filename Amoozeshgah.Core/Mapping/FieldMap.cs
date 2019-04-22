using Amoozeshgah.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace Amoozeshgah.Core.Mapping
{
    public class FieldMap : EntityTypeConfiguration<Field>
    {
        public FieldMap()
        {
            //Key
            HasKey(t => t.Id);

            //Properties
            Property(f => f.Name).HasColumnName("Name").IsRequired()
                                 .HasMaxLength(50)
                                 .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                                                      new IndexAnnotation(new IndexAttribute()));
            //Table
            ToTable("Fields");
        }
    }
}
