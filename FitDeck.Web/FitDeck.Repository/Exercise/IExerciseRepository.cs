using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitDeck.Models.Exercises;

namespace FitDeck.Repository.Exercise
{
    public interface IExerciseRepository
    {
        public Task<List<Exercise>> Get
    }
}
