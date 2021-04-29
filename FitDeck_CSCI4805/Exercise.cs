using System;
namespace FitDeck_CSCI4805
{
    public class Exercise
    {
        private string name;
        public string Name { get { return name; } }

        private string type;
        public string Type { get { return type; } }
            
        private string muscleGroup;
        public string MuscleGroup { get { return muscleGroup; } }

        private string notes;
        public string Notes { set { notes = value; } get { return notes; } }

        public Exercise()
        {

        }
        public Exercise(string name, string type, string muscleGroup, string notes)
        {
            this.name = name;
            this.type = type;
            this.muscleGroup = muscleGroup;
            this.notes = notes;
        }
    }
}
