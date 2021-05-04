using System;
using System.Collections.Generic;

namespace FitDeck_CSCI4805.PreDetermined
{
    public class PreDeterminedWorkout
    {
        public int WorkoutId { get; set; }

        public string Title { get; set; }

        public string Day { get; set; }

        public List<int> Exercises { get; set; }
    }
}
