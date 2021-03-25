using System;
using System.Collections.Generic;
using FitDeck.Models.Exercises;

namespace FitDeck.Models.Workouts
{
    public class UserCreatedWorkout
    {
        public int WorkoutId { get; set; }

        public string Title { get; set; }

        public string DayOfWeek { get; set; }

        public List<Exercise> Exercises { get; set; }
    }
}
