using FitDeck.Models.Account;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitDeck.Models.UserStats
{
    class DailyStats
    {
        public int ApplicationUserId { get; set; }

        public DateTime Day { get; set; }

        public decimal WorkoutTime { get; set; }

        public decimal CaloriesBurned { get; set; }
    }
}
