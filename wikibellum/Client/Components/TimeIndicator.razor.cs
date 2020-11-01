using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace wikibellum.Client.Components
{
    public partial class TimeIndicator : ComponentBase
    {
        public int CurrentYear
        {
            get
            {
                return CurrentDate.Year;
            }
            set
            {
                CurrentDate = new DateTime(value, CurrentMonth, CurrentDay);
            }
        }
        public int CurrentMonth
        {
            get
            {
                return CurrentDate.Month;
            }
            set
            {
                CurrentDate = new DateTime(CurrentYear, value, CurrentDay);
            }
        }
        public int CurrentDay
        {
            get
            {
                return CurrentDate.Day;
            }
            set
            {
                CurrentDate = new DateTime(CurrentYear, CurrentMonth, value);
            }
        }
        private DateTime _currentDate = new DateTime(1939, 1, 1);
        public DateTime CurrentDate
        {
            get
            {
                return _currentDate;
            }
            set
            {
                _currentDate = value;
                DateChangeData data = new DateChangeData()
                {
                    Mode = Mode,
                    Date = CurrentDate
                };
                DateChangeEventCallback.InvokeAsync(data);
            }
        }
        public int IndicatorValue
        {
            get
            {
                int value = 0;
                if (Mode == IndicatorMode.Days)
                {
                    value = (int)TimeSpan.FromTicks(CurrentDate.Ticks).TotalDays;
                }
                if (Mode == IndicatorMode.Months)
                {
                    value = DateToMonths();
                }
                return value;
            }
            set
            {
                if (Mode == IndicatorMode.Days)
                {
                    CurrentDate = new DateTime().AddDays(value);
                }
                if (Mode == IndicatorMode.Months)
                {
                    CurrentDate = MonthsToDate(value);
                }
            }
        }
        public int StepValue
        {
            get
            {
                return 1;
            }

        }
        public int MinRange
        {
            get
            {
                if (Mode == IndicatorMode.Months)
                {
                    return 13;
                }
                return (int)TimeSpan.FromTicks(_minDate.Ticks).TotalDays;
            }
        }
        public int MaxRange
        {
            get
            {
                if (Mode == IndicatorMode.Months)
                {
                    return 96;
                }
                return (int)TimeSpan.FromTicks(_maxDate.Ticks).TotalDays;
            }

        }
        private int _yearRangeStart = 1939;
        private int _yearRangeEnd = 1945;
        private static DateTime _minDate = new DateTime(1939, 1, 1);
        private static DateTime _maxDate = new DateTime(1945, 12, 31);
        private System.Timers.Timer _timer;
        private int _playDirection = 1;
        public IndicatorMode Mode { get; set; } = IndicatorMode.Months;
        [Parameter]
        public EventCallback<DateChangeData> DateChangeEventCallback { get; set; }
        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        protected void ChangeMode(IndicatorMode mode)
        {
            Mode = mode;
            if (mode == IndicatorMode.Months)
            {
                CurrentDay = 1;
            }
        }

        private bool IsActive(int speed)
        {
            if (_timer == null)
            {
                return false;
            }
            var direction = speed < 0 ? -1 : 1;
            speed = GetInterval(speed);
            if (_playDirection == direction && speed == _timer.Interval && _timer.Enabled == true)
            {
                return true;
            }

            return false;
        }

        private int GetInterval(int speed)
        {
            var interval = (int)MathF.Abs(speed) * 1000;
            if (Mode == IndicatorMode.Days)
            {
                interval = interval / 2;
            }
            return interval;
        }
        protected void Play(int speed)
        {
            _playDirection = speed < 0 ? -1 : 1;
            if (_timer != null)
            {
                _timer.Interval = GetInterval(speed);
            }
            else
            {
                SetTimer(GetInterval(speed));
            }
        }
        private void Stop()
        {

            if (_timer != null)
            {
                _timer.AutoReset = false;
                _timer.Enabled = false;
                _timer = null;
            }

        }
        private void SetTimer(int interval)
        {
            _timer = new System.Timers.Timer(interval);
            _timer.Elapsed += OnTimedEvent;
            _timer.AutoReset = true;
            _timer.Enabled = true;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            IncrementDate(_playDirection);
        }

        protected void IncrementDate(int amount)
        {
            if (Mode == IndicatorMode.Days)
            {
                var newDate = _currentDate.AddDays(amount);
                if (DateTime.Compare(newDate, _maxDate) <= 0 && DateTime.Compare(newDate, _minDate) >= 0)
                {
                    CurrentDate = _currentDate.AddDays(amount);
                }
            }
            if (Mode == IndicatorMode.Months)
            {
                var newDate = _currentDate.AddMonths(amount);
                if (DateTime.Compare(newDate, _maxDate.Subtract(new TimeSpan(30, 0, 0, 0))) <= 0 && DateTime.Compare(newDate, _minDate) >= 0)
                {
                    CurrentDate = _currentDate.AddMonths(amount);
                }
            }
        }
        protected int DateToMonths()
        {
            var yearValue = (int)MathF.Abs(1938 - CurrentYear);
            var value = yearValue * 12 + CurrentMonth;
            return value;
        }
        
        protected DateTime MonthsToDate(int months)
        {
            int year = 1938 + (int)MathF.Floor(months / 12);
            int month = months % 12;
            if (month == 0)
            {
                month = 12;
                year += -1;
            }
            DateTime date = new DateTime(year, month, 1);
            return date;
        }

    }

    public class DateChangeData
    {
        public IndicatorMode Mode { get; set; }
        public DateTime Date { get; set; }
    }
    public enum IndicatorMode
    {
        Months,
        Days
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
