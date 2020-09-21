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
                DateChangeEventCallback.InvokeAsync(_totalMonths);
                return _totalMonths;
            }
            set 
            {
                _currentYear = (int)Math.Floor(Convert.ToDouble((value - 1) / 12));
                var _calculatedMonth = value % 12;
                _currentMonth = _calculatedMonth == 0 ? 12 : _calculatedMonth;
                DateChangeEventCallback.InvokeAsync(value);
            }
        }
        private readonly int _yearRangeStart = 1939;
        private readonly int _yearRangeEnd = 1945;
        private int _currentYear = 1;
        private int _currentMonth = 1;
        [Parameter]
        public EventCallback<int> DateChangeEventCallback { get; set; }
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
