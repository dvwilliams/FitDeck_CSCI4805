using System;
using System.Collections.Generic;

namespace FitDeck_CSCI4805
{
    public class Workouts
    {
        private List<Workout> workouts;
        public List<Workout> _Workouts { get { return workouts; } }

        public Workouts()
        {
            workouts = new List<Workout>();
        }

        public void addWorkout(Workout workout)
        {
            this.workouts.Add(workout);
        }

        public void deleteWorkout(Workout workout)
        {
            foreach(Workout wo in workouts)
            {
                if(wo.Name == workout.Name)
                {
                    this.workouts.Remove(workout);
                }
            }
        }

        public List<Workout> getCurrentDayWorkouts(string day)
        {
            List<Workout> todayWorkouts = new List<Workout>();
            foreach (Workout wo in workouts)
            {
                if(wo.Day == day)
                {
                    todayWorkouts.Add(wo);
                }
            }
            return todayWorkouts;
        }
    }
}
