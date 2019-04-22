using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
/// <summary>
/// 
/// </summary>
namespace Amoozeshgah.Domain.Entities
{
    public class CategoryItem : BaseEntity
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        public virtual ICollection<EducationalCenter> EducationalCenters { get; set; }
        = new HashSet<EducationalCenter>();

    }
}
