using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amoozeshgah.Domain.Entities
{
    public class Religion : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
            = new HashSet<Teacher>();
    }
}
