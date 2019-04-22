using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amoozeshgah.Domain.Entities
{
    public class AuditEntryProperty
    {
        public int Id { get; set; }

        public int AuditEntryID { get; set; }

        [StringLength(255)]
        public string RelationName { get; set; }

        [StringLength(255)]
        public string PropertyName { get; set; }

        public string OldValue { get; set; }

        public string NewValue { get; set; }

        public virtual AuditEntry AuditEntry { get; set; }
    }
}
