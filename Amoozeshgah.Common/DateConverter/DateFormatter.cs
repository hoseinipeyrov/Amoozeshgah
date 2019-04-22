using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amoozeshgah.Common.DateConverter
{
    public static class DateFormatter
    {
        public static string FormatDate(DateFormat dateFormat)
        {
            switch (dateFormat)
            {
                case DateFormat.OnlyYear:
                    return "yyyy";
                case DateFormat.YearMonthDay:
                    return "yyyy/MM/dd";
                case DateFormat.FullDateTime:
                    return "yyyy/MM/dd hh:mm:ss";

                default:
                    return "yyyy/MM/dd hh:mm:ss";
            }
        }
    }
    public enum DateFormat
    {
        OnlyYear = 1,
        YearMonthDay = 4,
        FullDateTime = 5
    };
}
