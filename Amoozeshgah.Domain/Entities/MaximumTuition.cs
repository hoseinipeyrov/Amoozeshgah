using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amoozeshgah.Domain.Entities
{
   public class MaximumTuition:BaseEntity
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public string FromJalali { get; set; }
        public string ToJalali { get; set; }
        public int AreaId { get; set; }
        [ForeignKey(nameof(AreaId))]
        public virtual Area Area { get; set; }
        public int ScienceElementry { get; set; }
        public int ScienceFirstMiddle { get; set; }
        public int ScienceSecondMiddle { get; set; }
        public int LanguageElementary { get; set; }
        public int LanguageMiddle { get; set; }
        public int LanguageAdvanced { get; set; }
        public int Exam { get; set; }
    }
}
