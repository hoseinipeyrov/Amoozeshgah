using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amoozeshgah.Domain.Entities
{
    public partial class Organization : BaseEntity
    {
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
        public long Code { get; set; }
        public int? ParentCode { get; set; }

        public int AdministratorId { get; set; }
        [ForeignKey("AdministratorId")]
        public Person Administrator { get; set; }
        public virtual ICollection<OrganizationUserRole> OrganizationsUsers { get; set; }
            = new HashSet<OrganizationUserRole>(); 
    }
}
