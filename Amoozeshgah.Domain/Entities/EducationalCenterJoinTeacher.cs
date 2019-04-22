using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amoozeshgah.Domain.Entities
{
    public class EducationalCenterJoinTeacher 
    {
        public int EducationalCenterId { get; set; }
        [ForeignKey(nameof(EducationalCenterId))]
        public virtual EducationalCenter EducationalCenter { get; set; }

        public int TeacherId { get; set; }
        [ForeignKey(nameof(TeacherId))]
        public virtual Teacher Teacher { get; set; }

        public bool IsDisable { get; set; }
    }
}
