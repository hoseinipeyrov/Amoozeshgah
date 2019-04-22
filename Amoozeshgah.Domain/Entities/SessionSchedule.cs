using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amoozeshgah.Domain.Entities
{
    public class SessionSchedule : BaseEntity
    {

        public DateTime StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }

        public string StartDayJalali { get; set; }
        public string StartDayName { get; set; }

        public string StartTimeJalali { get; set; }

        public string StartDayTimeJalali { get; set; }




        public string EndDateJalali { get; set; }
        public string EndTimeJalali { get; set; }

        public string EndDateTimeJalali { get; set; }


        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }

        public int ClassroomId { get; set; }
        [ForeignKey(nameof(ClassroomId))]
        public virtual Classroom Classroom { get; set; }
    }
}
