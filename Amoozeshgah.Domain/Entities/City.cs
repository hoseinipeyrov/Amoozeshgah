using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amoozeshgah.Domain.Entities
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public int Code { get; set; }
        public int ProvinceId { get; set; }
        public virtual Province Province { get; set; }
        public virtual ICollection<Student> CityOfBirths { get; set; }
            = new HashSet<Student>();
        public virtual ICollection<Student> CityOfHomes { get; set; }
           = new HashSet<Student>();
    }
}
