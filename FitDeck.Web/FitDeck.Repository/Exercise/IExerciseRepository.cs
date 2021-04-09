using FitDeck.Models.Exercise;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitDeck.Repository.Exercise
{
    public interface IExerciseRepository
    {
        public Task<ExerciseObject> GetExerciseById(int exerciseId);
        public Task<List<ExerciseObject>> GetExerciseByMuscleGroup(string muscleGroup);

        public Task<List<ExerciseObject>> GetExerciseByTitle(string title);
    }
}
