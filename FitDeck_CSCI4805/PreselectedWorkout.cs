using System;
using System.Collections.Generic;

namespace FitDeck_CSCI4805
{
    public class PreselectedWorkout : Workout
    {
        public List<Exercise> cardioAndConditioningWorkout;
        public List<Exercise> plyometricWorkout;
        public List<Exercise> stretchWorkout;
        public List<Exercise> abdominalWorkout;
        public List<Exercise> armsWorkout;
        public List<Exercise> backWorkout;
        public List<Exercise> chestWorkout;
        public List<Exercise> legsWorkout;

        public PreselectedWorkout()
        {
            cardioAndConditioningWorkout = new List<Exercise>();
            plyometricWorkout = new List<Exercise>();
            stretchWorkout = new List<Exercise>();
            abdominalWorkout = new List<Exercise>();
            armsWorkout = new List<Exercise>();
            backWorkout = new List<Exercise>();
            chestWorkout = new List<Exercise>();
            legsWorkout = new List<Exercise>();
        }

        public void CardioAndConditioningWorkout()
        {
            Exercise ex1 = new Exercise("Jumping Jack", 7, "Cardio", "");
            Exercise ex2 = new Exercise("Burpee", 1, "Cardio", "");

            cardioAndConditioningWorkout.Add(ex1);
            cardioAndConditioningWorkout.Add(ex2);
            
        }
        public void PlyometricWorkout()
        {
            Exercise ex1 = new Exercise("Speed Hop", 1717, "Plyometric", "");
            Exercise ex2 = new Exercise("Cone Jumps", 1718, "Plyometric", "");
            Exercise ex3 = new Exercise("Long Depth Jump", 214, "Plyometric", "");
            Exercise ex4 = new Exercise("Single Leg Lateral Hop (over barrier)", 1737, "Plyometric", "");
           

            plyometricWorkout.Add(ex1);
            plyometricWorkout.Add(ex2);
            plyometricWorkout.Add(ex3);
            plyometricWorkout.Add(ex4);            
        }
        public void StretchWorkout()
        {
            Exercise ex1 = new Exercise("Neck Extensor Stretch", 61, "Flexibility", "Splenius");
            Exercise ex2 = new Exercise("Neck Rotation Stretch", 1382, "Flexibility", "Sternocleidomastoid");
            Exercise ex3 = new Exercise("Lying Crossover Stretch", 1276, "Flexibility", "Hip Abductors");
            Exercise ex4 = new Exercise("Lying Glute Stretch", 1263, "Flexibility", "Gluteus Maximus");
            Exercise ex5 = new Exercise("Side Pretzel Stretch", 1283, "Flexibility", "Hip Adductors");
            Exercise ex6 = new Exercise("Standing Quadriceps Stretch", 1305, "Flexibility", "Quadriceps");
            Exercise ex7 = new Exercise("Lunging Straight Leg Calf Stretch", 1343, "Flexibility", "General Calf / Gastrocnemius");
            Exercise ex8 = new Exercise("Kneeling Shin Stretch", 1358, "Flexibility", "Tibialis Anterior");
            Exercise ex9 = new Exercise("Seated Plantar Fascia Stretch", 1363, "Flexibility", "Plantar Fascia");


            stretchWorkout.Add(ex1);
            stretchWorkout.Add(ex2);
            stretchWorkout.Add(ex3);
            stretchWorkout.Add(ex4);
            stretchWorkout.Add(ex5);
            stretchWorkout.Add(ex6);
            stretchWorkout.Add(ex7);
            stretchWorkout.Add(ex8);
            stretchWorkout.Add(ex9);
            
        }
        public void AbdominalWorkout()
        {
            Exercise ex1 = new Exercise("Twisting Sit-up (arms crossed)", 749, "Basic", "Obliques");
            Exercise ex2 = new Exercise("Side Bend", 713, "Basic", "Obliques");
            Exercise ex3 = new Exercise("Push Crunch", 629, "Basic", "Rectus Abdominis");
            
            

            abdominalWorkout.Add(ex1);
            abdominalWorkout.Add(ex2);
            abdominalWorkout.Add(ex3);
            

        }
        public void ArmsWorkout()
        {
           
            Exercise ex1 = new Exercise("Triceps Dip", 1793, "Basic", "Triceps Brachii");
            Exercise ex2 = new Exercise("Triceps Dip (kneeling)", 253, "Basic", "Triceps Brachii");
            Exercise ex3 = new Exercise("Curl", 327, "Basic", "Biceps Brachii");
            Exercise ex4 = new Exercise("Incline Curl", 328, "Basic", "Biceps Brachii");
            Exercise ex5 = new Exercise("Concentration Curl", 340, "Basic", "Brachialis");
            Exercise ex6 = new Exercise("Preacher Curl", 341, "Basic", "Brachialis");
            Exercise ex7 = new Exercise("Upright Row", 102, "Basic", "Lateral Deltoid");
            Exercise ex8 = new Exercise("Wrist Curl", 36, "Basic", "Wrist Flexors");
            Exercise ex9 = new Exercise("Reverse Wrist Curl", 370, "Basic", "Wrist Extensors");

            armsWorkout.Add(ex1);
            armsWorkout.Add(ex2);
            armsWorkout.Add(ex3);
            armsWorkout.Add(ex4);
            armsWorkout.Add(ex5);
            armsWorkout.Add(ex6);
            armsWorkout.Add(ex7);
            armsWorkout.Add(ex8);
            armsWorkout.Add(ex9);
           

        }
        public void BackWorkout()
        {
            Exercise ex1 = new Exercise("Lying Row", 415, "Basic", "General Back");
            Exercise ex2 = new Exercise("Bent-over Row", 414, "Basic", "General Back");
            Exercise ex3 = new Exercise("Shrug", 517, "Basic", "Trapezius Upper Fibers and Levator Scapulae");
            Exercise ex4 = new Exercise("Inverted Row", 448, "Basic", "General Back");
            Exercise ex5 = new Exercise("Inverted Shrug", 527, "Basic", "Trapezius Upper Fibers and Levator Scapulae");
            Exercise ex6 = new Exercise("Pull-up", 497, "Basic", "Latissimus Dorsi and Teres Major");
            Exercise ex7 = new Exercise("Chin-up", 455, "Basic", "Latissimus Dorsi and Teres Major");
            Exercise ex8 = new Exercise("Parallel Close Grip Pull-up", 456, "Basic", "Latissimus Dorsi and Teres Major");

            backWorkout.Add(ex1);
            backWorkout.Add(ex2);
            backWorkout.Add(ex3);
            backWorkout.Add(ex4);
            backWorkout.Add(ex5);
            backWorkout.Add(ex6);
            backWorkout.Add(ex7);
            backWorkout.Add(ex8);


        }
        public void ChestWorkout()
        {
            Exercise ex1 = new Exercise("Chest Dip", 561, "Basic", "General Chest");
            Exercise ex2 = new Exercise("Push-up Plus", 1805, "Basic", "Serratus Anterior");
            Exercise ex3 = new Exercise("Chest Dip (kneeling)", 562, "Basic", "Pectoralis Major");
            Exercise ex4 = new Exercise("Incline Shoulder Raise", 625, "Basic", "Serratus Anterior");

            chestWorkout.Add(ex1);
            chestWorkout.Add(ex2);
            chestWorkout.Add(ex3);
            chestWorkout.Add(ex4);

        }
        public void LegsWorkout()
        {
            Exercise ex1 = new Exercise("Split Squat", 924, "Basic", "Gluteus Maximus");
            Exercise ex2 = new Exercise("Squat", 925, "Basic", "Gluteus Maximus");
            Exercise ex3 = new Exercise("Lying Hip Abduction", 933, "Basic", "Abductors");
            Exercise ex4 = new Exercise("Lying Straight Leg Raise", 970, "Basic", "Hip Flexors");
            Exercise ex5 = new Exercise("Lying Scissor Kick", 967, "Basic", "Hip Flexors");
            Exercise ex6 = new Exercise("Standing Calf Raise", 1176, "Basic", "General Calf / Gastrocnemius");
            Exercise ex7 = new Exercise("Single Leg Calf Raise", 1174, "Basic", "General Calf / Gastrocnemius");
            Exercise ex8 = new Exercise("Reverse Calf Raise", 1448, "Basic", "Tibialis Anterior");



            legsWorkout.Add(ex1);
            legsWorkout.Add(ex2);
            legsWorkout.Add(ex3);
            legsWorkout.Add(ex4);
            legsWorkout.Add(ex5);
            legsWorkout.Add(ex6);
            legsWorkout.Add(ex7);
            legsWorkout.Add(ex8);

        }

    }
}
