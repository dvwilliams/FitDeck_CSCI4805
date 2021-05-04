﻿using System;
using System.Collections.Generic;

namespace FitDeck_CSCI4805
{
    public class Workout
    {
        private string name;
        public string Name { set { name = value; } get { return name; } }

        private string day;
        public string Day { set { day = value; } get { return day; } }

        private string type;

        private List<Exercise> exercises;
        public List<Exercise> Exercises { set { exercises = value; } get { return exercises; } }

        private List <Exercise> superset;

        public Workout()
        {
            this.name = "";
            this.day = "";
            exercises = new List<Exercise>();
            superset = new List<Exercise>();
        }

        public Workout(string name, string day)
        {
            this.name = name;
            this.day = day;
            exercises = new List <Exercise>();
            this.superset = new List<Exercise>();
        }

        public void addExercise(Exercise exercise)
        {
            exercises.Add(exercise);
        }

        public void deleteExercise(Exercise exercise)
        {
            foreach(Exercise ex in exercises)
            {
                if (ex == exercise)
                {
                    exercises.Remove(exercise);
                }
            }
        }

        //change types to basic(strength), cardio(endurance), keep flexibility
        public string getType()
        {
            int countStrength = 0;
            int countEndurance = 0;
            int countBalance = 0;
            int countFlexibility = 0;
            foreach(Exercise ex in exercises)
            {
                if(ex.Type == "strength")
                {
                    countStrength++;
                }
                if (ex.Type == "endurance")
                {
                    countEndurance++;
                }
                if (ex.Type == "balance")
                {
                    countBalance++;
                }
                if (ex.Type == "flexibilty")
                {
                    countFlexibility++;
                }
            }

            if(countStrength > countBalance && countStrength >= countEndurance && countStrength >= countFlexibility)
            {
                return "strength";
            }
            else if(countBalance >= countStrength && countBalance >= countEndurance && countBalance >= countFlexibility)
            {
                return "balance";
            }
            else if(countFlexibility >= countEndurance && countFlexibility > countStrength && countFlexibility > countBalance)
            {
                return "flexibility";
            }
            else
            {
                return "endurance";
            }
        }

        //don't know if i'll keep the supersets
        public void addSuperset(Exercise exercise1, Exercise exercise2)
        {
            
        }

        public void addSuperset(Exercise exercise1, Exercise exercise2, Exercise exercise3)
        {

        }

        public List<Exercise> rearrangeList(List<Exercise> newList)
        {
            this.exercises = newList;
            return this.exercises;
        }

        
    }
}