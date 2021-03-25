using System;
namespace FitDeck.Models.Exercises
{
    public class Exercise
    {
        public int ExerciseId { get; set; }

        public string Title { get; set; }

        public string MuscleGroup { get; set; }

        public string WorkoutType { get; set; }

        public int Sets { get; set; }

        public int Reps { get; set; }
    }
}
