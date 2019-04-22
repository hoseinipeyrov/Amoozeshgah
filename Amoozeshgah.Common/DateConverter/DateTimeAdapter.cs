using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amoozeshgah.Common.DateConverter
{
    public class DateTimeAdapter : IDateTime
    {
        public DateTime UtcNow
        {
            get { return DateTime.UtcNow; }
        }
        public DateTime Now
        {
            get { return DateTime.Now; }
        }
        public string JalaliNow
        {
            get { return PersianDateTime.Now.ToString(); }
        }

    }
}
