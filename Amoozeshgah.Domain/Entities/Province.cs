using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amoozeshgah.Domain.Entities
{
    public class Province : BaseEntity
    {
        public virtual Site Site { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Area> Areas { get; set; }
            = new HashSet<Area>();

        public virtual ICollection<City> Cities { get; set; }
            = new HashSet<City>();

        //public virtual ICollection<Province> Administrations { get; set; }
        //    = new HashSet<Province>();
    }
}
