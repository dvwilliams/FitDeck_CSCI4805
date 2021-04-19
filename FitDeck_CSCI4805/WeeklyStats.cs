using System;
using System.Collections.Generic;

namespace FitDeck_CSCI4805
{
    public class WeeklyStats
    {
        private List<DailyStats> dailyStats;
        public List<DailyStats> _DailyStats { get { return dailyStats; } } 

        public WeeklyStats()
        {
            dailyStats = new List<DailyStats>();
        }

        public void addDailyStat(DailyStats stats)
        {
            this.dailyStats.Add(stats);
        }

        public float averageTime()
        {
            float addedTimes = 0;
            float averageTime = 0;
            int count = 0;

            foreach(DailyStats ds in dailyStats)
            {
                addedTimes += ds.TimeSpent;
                count++;
            }
            averageTime = addedTimes / count;
            return averageTime;
        }

        public int averageCaloriesBurned()
        {
            int addedCalories = 0;
            int averageCaloriesBurned = 0;
            int count = 0;

            foreach (DailyStats ds in dailyStats)
            {
                addedCalories += ds.caloriesburned();
                count++;
            }
            averageCaloriesBurned = addedCalories / count;
            return averageCaloriesBurned;
        }
    }
}
