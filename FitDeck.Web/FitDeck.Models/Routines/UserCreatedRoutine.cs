﻿using System;
using System.Collections.Generic;
using FitDeck.Models.Workouts;

namespace FitDeck.Models.Routines
{
    public class UserCreatedRoutine
    {
        public int RoutineId { get; set; }

        public string Title { get; set; }

        public string RestDay { get; set; }

        public List<UserCreatedWorkout> UserCreatedWorkouts { get; set; }

    }
}
