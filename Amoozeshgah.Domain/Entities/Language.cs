using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amoozeshgah.Domain.Entities
{
    public partial class Language : BaseEntity
    {
        public Language()
        {
            Departments = new HashSet<Department>();
        }
        public string Name { get; set; }
        public string NameFa { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
        public int? PlaceId { get; set; }
        [ForeignKey("PlaceId")]
        public virtual Place Place { get; set; }

    }
}
