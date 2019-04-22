using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amoozeshgah.Domain.Entities
{
    public class Site : BaseEntity
    {
        public string Name { get; set; }
        public virtual Province  Province { get; set; }
        public virtual Area Area { get; set; }
        public virtual EducationalCenter EducationalCenter { get; set; }
        public string PhoneNo1 { get; set; }
        public string PhoneNo2 { get; set; }
        public string Address { get; set; }
    }
}
