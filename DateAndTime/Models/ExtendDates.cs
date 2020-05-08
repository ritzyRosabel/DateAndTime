
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DateAndTime.Models
{
    public class ExtendDates
    {
        public static DateTimeOffset ExtendMonths (DateTimeOffset current, int months)
        {
            var newDate = current.AddMonths(months).AddTicks(-1);
            return new DateTimeOffset(newDate.Year, newDate.Month, DateTime.DaysInMonth(newDate.Year, newDate.Month), 23, 59, 59, current.Offset);
        }
    }
}