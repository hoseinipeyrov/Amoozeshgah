using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amoozeshgah.Domain.Entities
{
    public class AuditEntry
    {
        public AuditEntry()
        {
            AuditProperties = new HashSet<AuditEntryProperty>();
        }
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string EntitySetName { get; set; }

        [StringLength(255)]
        public string EntityTypeName { get; set; }

        public int State { get; set; }

        [StringLength(255)]
        public string StateName { get; set; }

        [StringLength(255)]
        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual ICollection<AuditEntryProperty> AuditProperties { get; set; }

    }
}
