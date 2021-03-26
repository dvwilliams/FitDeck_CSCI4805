using System;
using System.Collections.Generic;
using System.Text;

namespace FitDeck.Models.UserStats
{
    class WeeklyStats
    {
        public int ApplicationUserId { get; set; }

        public int WeekNum { get; set; }

        public int WorkoutTime { get; set; }

        public int CaloriesBurned { get; set; }
    }
}
