using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amoozeshgah.Common.DateConverter
{
    public static class JalaliDate
    {
        public static string ToJalalDateTime(this DateTime dateTime, DateFormat dateFormat)
        {
            var jalaliDateTime = new PersianDateTime(dateTime);
            return  jalaliDateTime.ToString(DateFormatter.FormatDate(dateFormat));
        }
    }
}
