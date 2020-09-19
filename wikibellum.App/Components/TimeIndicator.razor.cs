using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace wikibellum.App.Components
{
    public partial class TimeIndicator : ComponentBase
    {
        private int _totalMonths;
        public int TotalMonths { 
            get
            {
                _totalMonths = _currentYear * 12 + _currentMonth;
                TotalMonthsChangeEventCallBack.InvokeAsync(_totalMonths);
                return _totalMonths;
            }
            set 
            {
                TotalMonthsChangeEventCallBack.InvokeAsync(value);
                _currentYear = (int)Math.Floor(Convert.ToDouble(value / 12));
                _currentMonth = value % 12;
            }
        }
        private readonly int _yearRangeStart = 1939;
        private readonly int _yearRangeEnd = 1945;
        private int _currentYear = 1;
        private int _currentMonth = 1;
        public EventCallback<int> TotalMonthsChangeEventCallBack { get; set; }
        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

    }

    public enum Month
    {
        January,
        February,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December
    }

}
