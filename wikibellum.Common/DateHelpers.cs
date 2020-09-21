using System;
using System.Collections.Generic;
using System.Text;

namespace wikibellum.Common
{
    public class DateHelpers
    {
        public bool DateIsWithinBounds(DateTime currentDate, DateTime startDate, DateTime endDate)
        {
            if (!(startDate.Year <= currentDate.Year && currentDate.Year <= endDate.Year))
            {
                return false;
            }
            else if ((startDate.Month <= currentDate.Month && currentDate.Month <= endDate.Month))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
