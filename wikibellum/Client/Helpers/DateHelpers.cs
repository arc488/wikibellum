using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace wikibellum.Client.Helpers
{
    public class DateHelpers
    {
        public bool DateIsWithinBounds(int totalMonths, DateTime startDate, DateTime endDate)
        {
            int startMonths = ConvertDateToMonths(startDate);
            int endMonths = ConvertDateToMonths(endDate);
            int startDatys = ConvertDateToDays(startDate);
            int endDays = ConvertDateToDays(endDate);

            if (startMonths <= totalMonths && totalMonths <= endMonths)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int ConvertDateToDays(DateTime date)
        {
            var span = date - new DateTime(1939, 1, 1);
            var days = span.TotalDays;
            var daysAsInt = (int)MathF.Round((float)days);
            return daysAsInt;            
        }
        public int ConvertDateToMonths(DateTime dateTime)
        {
            var year = -(1938 - dateTime.Year);
            var month = dateTime.Month;
            var totalMonths = year * 12 + month;
            return totalMonths;
        }
    }
}
