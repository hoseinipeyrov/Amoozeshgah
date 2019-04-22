using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amoozeshgah.Common.DateConverter
{
    public static class GeorgianDate
    {
        public static object FormatDate { get; private set; }

        public static DateTime ToGeorgianDateTime(this string dateTime)
        {
            var date = (dateTime.Split('/')).Select(s => int.Parse(s)).ToArray();
            try
            {
                PersianDateTime persianDate = new PersianDateTime(date[0],date[1],date[2]);
                var x= persianDate.ToDateTime();
                return x;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public static DateTime ToGeorgianDateTimeFromJalali(this string dateTime, double hour,double min)
        {
            var persianDate = PersianDateTime.Parse(dateTime);
            var dt = persianDate.ToDateTime();

            var addMinutes = dt.AddDays(hour).AddMinutes(min);
            return addMinutes;

        }

        public static string ToJalaliDateName(this string dateTime)
        {
            var persianDate = PersianDateTime.Parse(dateTime);
            return persianDate.DayName;
        }


        
    }
}
