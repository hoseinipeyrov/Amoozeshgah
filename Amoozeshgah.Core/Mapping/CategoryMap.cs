using Amoozeshgah.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Amoozeshgah.Core.Mapping
{
    public class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            //Key
            HasKey(t => t.Id);

            //Properties
            HasMany(c=>c.LessonLevels).
                WithRequired(l=>l.Category).
                HasForeignKey(l=>l.CategoryId).
                WillCascadeOnDelete(false);
            //Table
            ToTable("Categories");
        }
    }
    public class CategoryItemMap : EntityTypeConfiguration<CategoryItem>
    {
        public CategoryItemMap()
        {
            //Key
            HasKey(t => t.Id);

            //Properties

            //Table
            ToTable("CategoryItems");
        }
    }
}
