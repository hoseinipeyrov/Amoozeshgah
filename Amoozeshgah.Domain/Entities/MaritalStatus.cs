using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amoozeshgah.Domain.Entities
{
    public class MaritalStatus : BaseEntity
    {
        public string Name { get; set; }
        public int Code { get; set; }

        public ICollection<Teacher> Teachers { get; set; }
        =new HashSet<Teacher>();
    }
}
