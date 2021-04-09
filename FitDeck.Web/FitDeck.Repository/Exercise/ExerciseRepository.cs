using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using FitDeck.Models.Exercise;
using FitDeck.Repository.Exercise;
using Microsoft.Extensions.Configuration;

namespace FitDeck.Repository.Exercises
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly IConfiguration _config;

        public ExerciseRepository(IConfiguration config)
        {
            _config = config;
        }

        public async Task<ExerciseObject> GetExerciseById(int exerciseId)
        {
            ExerciseObject exercise;

            using (var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await connection.OpenAsync();

                exercise = await connection.QueryFirstOrDefaultAsync<ExerciseObject> (
                    "GetExerciseById",
                    new { ExerciseId = exerciseId },
                    commandType: CommandType.StoredProcedure
                    );
            }

            return exercise;
        }

        public async Task<List<ExerciseObject>> GetExerciseByMuscleGroup(string muscleGroup)
        {
            IEnumerable<ExerciseObject> exercises;

            using (var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await connection.OpenAsync();

                exercises = await connection.QueryAsync<ExerciseObject>(
                    "GetExerciseByMuscleGroup",
                    new { MuscleGroup = muscleGroup },
                    commandType: CommandType.StoredProcedure
                    );
            }

            return exercises.ToList();
        }

        public async Task<List<ExerciseObject>> GetExerciseByTitle(string title)
        {
            IEnumerable<ExerciseObject> exercises;

            using (var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await connection.OpenAsync();

                exercises = await connection.QueryAsync<ExerciseObject>(
                    "GetExerciseByTitle",
                    new { Title = title },
                    commandType: CommandType.StoredProcedure
                    );
            }

            return exercises.ToList();
        }
    }
}
