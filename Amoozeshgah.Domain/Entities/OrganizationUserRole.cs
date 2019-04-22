using System.ComponentModel.DataAnnotations.Schema;

namespace Amoozeshgah.Domain.Entities
{
    public partial class OrganizationUserRole : BaseEntity
    {
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public int OrganizationId { get; set; }
        [ForeignKey("OrganizationId")]
        public virtual Organization Organization { get; set; }

        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public virtual OrganizationRole Role { get; set; }

    }
}
