using System;
using System.Collections.Generic;

namespace FitDeck_CSCI4805.UserCreated
{
    public class UserCreatedWorkout
    {
        public int WorkoutId { get; set; }

        public int UserId { get; set; }

        public string Title { get; set; }

        public string DayOfWeek { get; set; }

        public List<int> Exercises { get; set; }

        public UserCreatedWorkout(string title, string dayOfWeek, List<int> ex)
        {
            this.WorkoutId = -1;
            this.UserId = -1;
            this.Title = title;
            this.DayOfWeek = dayOfWeek;
            this.Exercises = ex;
        }
    }
}
