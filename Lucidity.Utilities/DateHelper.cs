using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lucidity.Utilities
{
    public static class DateHelper
    {
        public static DateTime GetFirstDayOfFirstPartWeekOfMonth(int year, int month)
        {
            var firstDayOfMonth = new DateTime(year, month, 1);
            var firstDayOfFirstPartWeekOfMonth = firstDayOfMonth.AddDays(DayOfWeek.Monday - firstDayOfMonth.DayOfWeek);
            return firstDayOfFirstPartWeekOfMonth;
        }

        public static DateTime GetFirstDayOfFirstFullWeekOfMonth(int year, int month)
        {
            var firstDayOfFirstPartWeekOfMonth = GetFirstDayOfFirstPartWeekOfMonth(year, month);

            if(firstDayOfFirstPartWeekOfMonth.Day == 1)
            {
                return firstDayOfFirstPartWeekOfMonth;
            }

            return firstDayOfFirstPartWeekOfMonth.AddDays(7);
        }
    }
}
