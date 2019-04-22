using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amoozeshgah.Domain.Entities
{
    public class Student : BaseEntity
    {
        public virtual User User { get; set; }

        public string ParentFirstName { get; set; }
        public string ParentLastName { get; set; }

        public int CityOfBirthId { get; set; }
        public virtual City CityOfBirth { get; set; }

        public string CellPhoneNumber { get; set; }
        public string PhoneNumber { get; set; }

        public int CityOfHomeId { get; set; }
        public virtual City CityOfHome { get; set; }


        public virtual ICollection<CourseJoinStudent> CoursesJoinStudents { get; set; }
            = new HashSet<CourseJoinStudent>();
        public virtual ICollection<LanguageDeterminationLevelRequest> LanguageDeterminationLevelRequests { get; set; }
            = new HashSet<LanguageDeterminationLevelRequest>();
        public virtual ICollection<DiscountRequest> DiscountRequests { get; set; }
            = new HashSet<DiscountRequest>();
        public virtual ICollection<RefundRequest> RefundRequests { get; set; }
            = new HashSet<RefundRequest>();

    }
}
