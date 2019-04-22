using System.ComponentModel.DataAnnotations.Schema;

namespace Amoozeshgah.Domain.Entities
{
    public class Lesson : BaseEntity
    {
        public string Name { get; set; }
        public long Code { get; set; }
        public int TotalHours { get; set; }
        public string BookName { get; set; }
        public int FieldId { get; set; }
        [ForeignKey("FieldId")]
        public virtual Field Field { get; set; }

        public int LessonLevelId { get; set; }
        [ForeignKey("LessonLevelId")]
        public virtual LessonLevel LessonLevel { get; set; }

        public int? PrerequirementId { get; set; }
        [ForeignKey("PrerequirementId")]
        public virtual Lesson Prerequirement { get; set; }
    }
}
