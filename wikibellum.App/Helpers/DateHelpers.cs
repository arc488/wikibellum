using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace wikibellum.App.Helpers
{
    public class DateHelpers
    {
        public bool DateIsWithinBounds(int totalMonths, DateTime startDate, DateTime endDate)
        {
            int startMonths = ConvertDateToMonths(startDate);
            int endMonths = ConvertDateToMonths(endDate);

            if (startMonths <= totalMonths && totalMonths <= endMonths)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        public int ConvertDateToMonths(DateTime dateTime)
        {
            var year = -(1938 - dateTime.Year);
            var month = dateTime.Month;
            return year * 12 + month;
        }
    }
}
