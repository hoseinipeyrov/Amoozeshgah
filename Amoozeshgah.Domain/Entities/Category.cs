using System.Collections.Generic;

namespace Amoozeshgah.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public int Code { get; set; }

        public virtual ICollection<LessonLevel> LessonLevels { get; set; }
        = new HashSet<LessonLevel>();
        public virtual ICollection<CategoryItem> CategoryItems { get; set; }
        = new HashSet<CategoryItem>();
        //public virtual ICollection<EducationalCenter> EducationalCenters { get; set; }
        //= new HashSet<EducationalCenter>();
    }
}
