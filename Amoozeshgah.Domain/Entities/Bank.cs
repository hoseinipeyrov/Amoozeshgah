using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amoozeshgah.Domain.Entities
{
    public class Bank : BaseEntity
    {
        public string Name { get; set; }
        public int? Code { get; set; }
        public string Description { get; set; }
        public ICollection<AccountInformation> AccountInformations { get; set; }
            = new HashSet<AccountInformation>();
    }
}
