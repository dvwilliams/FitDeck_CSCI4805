using System;
namespace FitDeck_CSCI4805
{
    public class DailyStats
    {
        private float timeSpent;
        public float TimeSpent { get { return timeSpent; } }

        private int caloriesBurned;

        public DailyStats()
        {
        }

        private float convertTimeSpent()
        {

            int hour = (int)this.timeSpent;
            hour = hour * 60;
            float minute = this.timeSpent - hour;
            minute = minute * 100;

            return hour + minute;
        }

        public int caloriesburned()
        {
            int calories = 0;

            //MET for strength = 4.5
            //MET for balance = 4
            //MET for Endurance = 7
            //MET for flexibility = 5
            //if () { }

            //convertTimeSpent() * (//MET * 3.5 * //weight*.453592)


            return 1;
        }
    }
}
