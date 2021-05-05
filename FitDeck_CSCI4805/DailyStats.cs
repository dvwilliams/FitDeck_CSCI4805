using System;
namespace FitDeck_CSCI4805
{
    public class DailyStats
    {
        private float timeSpent;
        public float TimeSpent { set { timeSpent = value; } get { return timeSpent; } }

        private int caloriesBurned;
        public int CaloriesBurned { get { return caloriesBurned; } }

        private DayOfWeek day;
        public DayOfWeek Day { set { day = value; } get { return day; } }

        public DailyStats()
        {
        }
        public DailyStats(float timeSpent, int caloriesBurned, DayOfWeek day)
        {
            this.timeSpent = timeSpent;
            this.caloriesBurned = caloriesBurned;
            this.day = day;
        }

        //converts time spent into minutes
        public float convertTimeSpent()
        {

            int hour = (int)this.timeSpent;
            hour = hour * 60;
            float minute = this.timeSpent - hour;
            minute = minute * 100;

            return hour + minute;
        }

        //calculates calories burned in a given workout
        public int caloriesburned()
        {
            //get user and workout from database
            //probably should at least pass in workout and/or user maybe 
            Workout workout = new Workout();
            User user = new User();

            
            if(workout.getType() == "Basic")
            {
                return (int)(convertTimeSpent() * (4.5 * (3.5 * (user.Weight * .453592))/200));
            }
            else if (workout.getType() == "Cardio")
            {
                return (int)(convertTimeSpent() * (7.5 * (3.5 * (user.Weight * .453592)) / 200));
            }
            else if (workout.getType() == "Flexibility")
            {
                return (int)(convertTimeSpent() * (3.5 * (3.5 * (user.Weight * .453592)) / 200));
            }
            else
            {
                return (int)(convertTimeSpent() * (9 * (3.5 * (user.Weight * .453592)) / 200));
            }
            
        }
    }
}
