using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace wikibellum.Client.Components
{
    public partial class TimeIndicator : ComponentBase
    {
        private int _totalMonths;
        public int TotalMonths { 
            get
            {
                _totalMonths = _currentYear * 12 + _currentMonth;
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

        private int _currentYear;
        public int CurrentYear 
        {
            get 
            {
                return _currentYear;
            }
            set 
            {

                _currentYear = value == 0 ? 12 : value;
                DateChangeEventCallback.InvokeAsync(TotalMonths);
            }
        }
        private int _currentMonth;
        public int CurrentMonth 
        {
            get
            {
                return _currentMonth;
            }
            set
            {
                _currentMonth = value;
                DateChangeEventCallback.InvokeAsync(TotalMonths);
            }
        }
        private readonly int _yearRangeStart = 1939;
        private readonly int _yearRangeEnd = 1945;

        [Parameter]
        public EventCallback<int> DateChangeEventCallback { get; set; }
        protected override void OnInitialized()
        {
            _currentMonth = 1;
            _currentYear = 1;
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
