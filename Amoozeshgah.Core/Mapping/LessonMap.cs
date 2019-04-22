using Amoozeshgah.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace Amoozeshgah.Core.Mapping
{
    public class LessonMap : EntityTypeConfiguration<Lesson>
    {
        public LessonMap()
        {
            //Key
            HasKey(l => l.Id);

            //Properties
            Property(l => l.Name).HasColumnName("Name").IsRequired()
                                 .HasMaxLength(50)
                                 .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                                                      new IndexAnnotation(new IndexAttribute("IX_Lesson_Name_Unique", 2) { IsUnique = true }));
            Property(l => l.Code).IsRequired()
                                 .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                                                      new IndexAnnotation(new IndexAttribute("IX_Lesson_Code_Unique", 1) { IsUnique = true }));

            //Table
            ToTable("Lessons");
        }
    }

    public class LessonLevelMap : EntityTypeConfiguration<LessonLevel>
    {
        public LessonLevelMap()
        {
            //Key
            HasKey(t => t.Id);

            //Properties

            //Table
            ToTable("LessonLevels");
        }
    }

}
