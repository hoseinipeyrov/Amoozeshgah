using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amoozeshgah.Domain.Entities
{
    public class Course : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int Capacity { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public string StartDateJalali { get; set; }
        public int SessionCount { get; set; }
        public int SessionHour { get; set; }
        public int SessionMinute { get; set; }

        public int TeacherId { get; set; }

        [ForeignKey(nameof(TeacherId))]
        public virtual Teacher Teacher { get; set; }

        public int LessonId { get; set; }
        [ForeignKey(nameof(LessonId))]

        public virtual Lesson Lesson { get; set; }

        public int TermId { get; set; }
        [ForeignKey(nameof(TermId))]
        public virtual Term Term { get; set; }

        public int ClassroomId { get; set; }
        public int Price { get; set; }


        public virtual ICollection<SessionSchedule> Sessions { get; set; }
        =new HashSet<SessionSchedule>();


        public virtual ICollection<CourseJoinStudent> CoursesJoinStudents { get; set; }
            = new HashSet<CourseJoinStudent>();

        public virtual ICollection<DiscountRequest> DiscountRequests { get; set; }
            = new HashSet<DiscountRequest>();
        public virtual ICollection<RefundRequest> RefundRequests { get; set; }
            = new HashSet<RefundRequest>();

    }
}
