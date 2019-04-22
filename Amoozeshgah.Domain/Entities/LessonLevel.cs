using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amoozeshgah.Domain.Entities
{
    public class LessonLevel : BaseEntity
    {
        public string Name { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        public virtual ICollection<Lesson> Lessons { get; set; }
            = new HashSet<Lesson>();
    }
}
