using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amoozeshgah.Domain.Entities
{
    public class LanguageDeterminationLevelRequest : BaseEntity
    {
        //student side
        public int StudentId { get; set; }
        [ForeignKey(nameof(StudentId))]
        public virtual Student Student { get; set; }

        public int EducationalCenterId { get; set; }
        [ForeignKey(nameof(EducationalCenterId))]
        public virtual EducationalCenter EducationalCenter { get; set; }

        public string PreferJalaliDay { get; set; }
        public string PreferJalaliHour { get; set; }
        public string PreferJalaliDayName { get; set; }

        public DateTime PreferDate { get; set; }


        //educational center side

        public string SetJalaliDay { get; set; }
        public string SetJalaliHour { get; set; }
        public string SetJalaliDayName { get; set; }

        public DateTime SetDate { get; set; }
        public string Setter { get; set; }


    }
}
