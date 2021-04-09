using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using FitDeck.Models.Exercises;
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

        public async Task<FitDeck.Models.Exercises.Exercise> GetExerciseById(int exerciseId)
        {
            IEnumerable<FitDeck.Models.Exercises.Exercise> exercises;

            using (var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await connection.OpenAsync();

                exercises = await connection.QueryAsync<FitDeck.Models.Exercises.Exercise> (
                    "GetExerciseById",
                    new { ExerciseId = exerciseId },
                    commandType: CommandType.StoredProcedure
                    );
            }
            return exercises.ToList();
        }

        public async Task<List<Exercise>> GetExerciseByMuscleGroup(string muscleGroup)
        {
            IEnumerable<Exercise> exercises;

            using (var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await connection.OpenAsync();

                exercises = await connection.QueryAsync<Exercise>(
                    "GetExerciseByMuscleGroup",
                    new { MuscleGroup = muscleGroup },
                    commandType: CommandType.StoredProcedure
                    );
            }

            return exercises.ToList();
        }

        public async Task<List<Exercise>> GetExerciseByTitle(string title)
        {
            IEnumerable<Exercise> exercises;

            using (var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await connection.OpenAsync();

                exercises = await connection.QueryAsync<Exercise>(
                    "GetExerciseByTitle",
                    new { Title = title },
                    commandType: CommandType.StoredProcedure
                    );
            }

            return exercises.ToList();
        }
    }
}
