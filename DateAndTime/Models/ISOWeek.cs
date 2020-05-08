using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace DateAndTime.Models
{
    public class ISOWeek
    {
       static Calendar calender = CultureInfo.InvariantCulture.Calendar;
        public static int GetIso8601WeekOfYear(DateTime time)
        {
            DayOfWeek day = calender.GetDayOfWeek(time);
            if(day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }

            return calender.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }
    }
}