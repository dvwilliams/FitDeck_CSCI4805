using System;
namespace FitDeck_CSCI4805
{
    public class RestDay
    {
        private DayOfWeek day;
        public DayOfWeek Day { set { day = value; } get { return day; } }

        private bool isCurrentDay;
        public bool IsCurrentDay { set{ isCurrentDay = true; } get { return isCurrentDay; } }

        public RestDay(DayOfWeek day)
        {
            this.day = day;
            this.isCurrentDay = false;
        }
    }
}
