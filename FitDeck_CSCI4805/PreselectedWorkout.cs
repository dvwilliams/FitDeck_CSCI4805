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
            Exercise ex1 = new Exercise("Basic Hop", 7, "Cardio", "");
            Exercise ex2 = new Exercise("Rider", 1398, "Cardio", "");
            Exercise ex3 = new Exercise("Mountain Climber", 4, "Cardio", "");
            Exercise ex4 = new Exercise("Burpee", 1, "Cardio", "");
            Exercise ex5 = new Exercise("Back Pedal", 1590, "Cardio", "");
            Exercise ex6 = new Exercise("High Knee Run", 1593, "Cardio", "");

            cardioAndConditioningWorkout.Add(ex1);
            cardioAndConditioningWorkout.Add(ex2);
            cardioAndConditioningWorkout.Add(ex3);
            cardioAndConditioningWorkout.Add(ex4);
            cardioAndConditioningWorkout.Add(ex5);
            cardioAndConditioningWorkout.Add(ex6);

            
        }
        public void PlyometricWorkout()
        {
            Exercise ex1 = new Exercise("180 Jump Turns", 1700, "Plyometric", "");
            Exercise ex2 = new Exercise("Squat Jump", 1701, "Plyometric", "");
            Exercise ex3 = new Exercise("Split Jump", 226, "Plyometric", "");
            Exercise ex4 = new Exercise("Lateral Line Hop", 1728, "Plyometric", "");
            Exercise ex5 = new Exercise("Single Leg Lateral Hop (over line)", 1736, "Plyometric", "");
            Exercise ex6 = new Exercise("Broad Jumps", 220, "Plyometric", "");
            Exercise ex7 = new Exercise("Single Leg Speed Hops", 1725, "Plyometric", "");

            plyometricWorkout.Add(ex1);
            plyometricWorkout.Add(ex2);
            plyometricWorkout.Add(ex3);
            plyometricWorkout.Add(ex4);
            plyometricWorkout.Add(ex5);
            plyometricWorkout.Add(ex6);
            plyometricWorkout.Add(ex7);

        }
        public void StretchWorkout()
        {
            Exercise ex1 = new Exercise("Neck Extensor Stretch", 61, "Flexibility", "Splenius");
            Exercise ex2 = new Exercise("Neck Rotation Stretch", 1382, "Flexibility", "Sternocleidomastoid");
            Exercise ex3 = new Exercise("Single Arm Wrist Extensor Stretch", 1223, "Flexibility", "Wrist Extensors");
            Exercise ex4 = new Exercise("Single Arm Wrist Flexor Stretch", 1378, "Flexibility", "Wrist Flexors");
            Exercise ex5 = new Exercise("Standing Brachioradialis Stretch", 1533, "Flexibility", "Brachioradialis");
            Exercise ex6 = new Exercise("Overhead Triceps Stretch", 1773, "Flexibility", "Triceps Brachii");
            Exercise ex7 = new Exercise("Standing Biceps Stretch", 1219, "Flexibility", "Biceps Brachii");
            Exercise ex8 = new Exercise("Bent-over Lat Stretch", 1226, "Flexibility", "Latissimus Dorsi and Teres Major");
            Exercise ex9 = new Exercise("Seated Bent-over Infraspinatus Stretch", 1237, "Flexibility", "Infraspinatus and Teres Minor");
            Exercise ex10 = new Exercise("Hugging Stretch", 1372, "Flexibility", "Rhomboids");
            Exercise ex11 = new Exercise("Chair Trapezius Stretch", 1983, "Flexibility", "Trapezius Upper Fibers and Levator Scapulae");
            Exercise ex12 = new Exercise("Doorway Chest Stretch", 1223, "Flexibility", "General Chest / Pectoralis Major, Sternal");
            Exercise ex13 = new Exercise("Doorway Modified Chest Stretch", 1367, "Flexibility", "Pectoralis Minor");
            Exercise ex14 = new Exercise("Lying Crossover Stretch", 1276, "Flexibility", "Hip Abductors");
            Exercise ex15 = new Exercise("Lying Glute Stretch", 1263, "Flexibility", "Gluteus Maximus");
            Exercise ex16 = new Exercise("Kneeling Adductor Magnus Stretch", 1323, "Flexibility", "Hip Adductors");
            Exercise ex17 = new Exercise("Standing Quadriceps Stretch", 1305, "Flexibility", "Quadriceps");
            Exercise ex18 = new Exercise("Lunging Straight Leg Calf Stretch", 1343, "Flexibility", "General Calf / Gastrocnemius");
            Exercise ex19 = new Exercise("Kneeling Shin Stretch", 1358, "Flexibility", "Tibialis Anterior");
            Exercise ex20 = new Exercise("Seated Plantar Fascia Stretch", 1363, "Flexibility", "Plantar Fascia");


            stretchWorkout.Add(ex1);
            stretchWorkout.Add(ex2);
            stretchWorkout.Add(ex3);
            stretchWorkout.Add(ex4);
            stretchWorkout.Add(ex5);
            stretchWorkout.Add(ex6);
            stretchWorkout.Add(ex7);
            stretchWorkout.Add(ex8);
            stretchWorkout.Add(ex9);
            stretchWorkout.Add(ex10);
            stretchWorkout.Add(ex11);
            stretchWorkout.Add(ex12);
            stretchWorkout.Add(ex13);
            stretchWorkout.Add(ex14);
            stretchWorkout.Add(ex15);
            stretchWorkout.Add(ex16);
            stretchWorkout.Add(ex17);
            stretchWorkout.Add(ex18);
            stretchWorkout.Add(ex19);
            stretchWorkout.Add(ex20);


        }
        public void AbdominalWorkout()
        {
            Exercise ex1 = new Exercise("Twisting Sit-up (arms crossed)", 749, "Basic", "Obliques");
            Exercise ex2 = new Exercise("Side Crunch", 1603, "Basic", "Obliques");
            Exercise ex3 = new Exercise("V-up", 674, "Basic", "Rectus Abdominis");
            Exercise ex4 = new Exercise("Lying Leg-Hip Raise", 692, "Basic", "Rectus Abdominis");
            Exercise ex5 = new Exercise("Superman", 796, "Basic", "Erector Spinae");
            Exercise ex6 = new Exercise("Alternating Bird Dog", 784, "Basic", "Erector Spinae");
            Exercise ex7 = new Exercise("Contralateral Superman", 792, "Basic", "Erector Spinae");
            Exercise ex8 = new Exercise("Bent-knee Lying Twist", 789, "Basic", "Obliques");
            

            abdominalWorkout.Add(ex1);
            abdominalWorkout.Add(ex2);
            abdominalWorkout.Add(ex3);
            abdominalWorkout.Add(ex4);
            abdominalWorkout.Add(ex5);
            abdominalWorkout.Add(ex6);
            abdominalWorkout.Add(ex7);
            abdominalWorkout.Add(ex8);

        }
        public void ArmsWorkout()
        {
           
            Exercise ex1 = new Exercise("Lying Triceps Extension", 284, "Basic", "Triceps Brachii");
            Exercise ex2 = new Exercise("Kickback", 283, "Basic", "Triceps Brachii");
            Exercise ex3 = new Exercise("One Arm Triceps Extension", 285, "Basic", "Triceps Brachii");
            Exercise ex4 = new Exercise("Curl", 227, "Basic", "Biceps Brachii");
            Exercise ex5 = new Exercise("Seated Curl", 2017, "Basic", "Biceps Brachii");
            Exercise ex6 = new Exercise("Concentration Curl", 340, "Basic", "Brachialis");
            Exercise ex7 = new Exercise("Standing Preacher Curl (on incline bench)", 2028, "Basic", "Brachialis");
            Exercise ex8 = new Exercise("Arnold Press", 70, "Basic", "Anterior Deltoid");
            Exercise ex9 = new Exercise("Front Raise", 71, "Basic", "Anterior Deltoid");
            Exercise ex10 = new Exercise("Lateral Raise", 111, "Basic", "Lateral Deltoid");
            Exercise ex11 = new Exercise("Rear Delt Row", 144, "Basic", "Posterior Deltoid");
            Exercise ex12 = new Exercise("Wrist Curl", 362, "Basic", "Wrist Flexors");
            Exercise ex13 = new Exercise("Reverse Wrist Curl", 375, "Basic", "Wrist Extensors");

            armsWorkout.Add(ex1);
            armsWorkout.Add(ex2);
            armsWorkout.Add(ex3);
            armsWorkout.Add(ex4);
            armsWorkout.Add(ex5);
            armsWorkout.Add(ex6);
            armsWorkout.Add(ex7);
            armsWorkout.Add(ex8);
            armsWorkout.Add(ex9);
            armsWorkout.Add(ex10);
            armsWorkout.Add(ex11);
            armsWorkout.Add(ex12);
            armsWorkout.Add(ex13);

        }
        public void BackWorkout()
        {
            Exercise ex1 = new Exercise("Lying Row", 415, "Basic", "General Back");
            Exercise ex2 = new Exercise("Bent Arm Pullover", 461, "Basic", "Latissimus Dorsi and Teres Major");
            Exercise ex3 = new Exercise("Cambered Barbell Seated Shrug", 511, "Basic", "Trapezius Upper Fibers and Levator Scapulae");
            Exercise ex4 = new Exercise("Inverted Row", 448, "Basic", "General Back");
            Exercise ex5 = new Exercise("Shoulder Internal Rotation (on floor)", 540, "Basic", "Subscapularis");
            Exercise ex6 = new Exercise("Seated Shoulder External Rotation", 416, "Basic", "Infraspinatus and Teres Minor");
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
            Exercise ex1 = new Exercise("Chest Dip (between benches)", 613, "Basic", "General Chest");
            Exercise ex2 = new Exercise("Push-up", 616, "Basic", "General Chest");
            Exercise ex3 = new Exercise("Incline Push-up", 614, "Basic", "General Chest");
            Exercise ex4 = new Exercise("Push-up Plus", 1805, "Basic", "Serratus Anterior");
            Exercise ex5 = new Exercise("Incline Shoulder Raise", 625, "Basic", "Serratus Anterior");
            Exercise ex6 = new Exercise("Decline Push-up", 560, "Basic", "Pectoralis Major, Clavical");
            Exercise ex7 = new Exercise("Pike Push-up",1436, "Basic", "Pectoralis Major, Clavical");

            chestWorkout.Add(ex1);
            chestWorkout.Add(ex2);
            chestWorkout.Add(ex3);
            chestWorkout.Add(ex4);
            chestWorkout.Add(ex5);
            chestWorkout.Add(ex6);
            chestWorkout.Add(ex7);

        }
        public void LegsWorkout()
        {
            Exercise ex1 = new Exercise("Split Squat", 924, "Basic", "Gluteus Maximus");
            Exercise ex2 = new Exercise("Squat", 925, "Basic", "Gluteus Maximus");
            Exercise ex3 = new Exercise("Side Bridge Hip Abduction", 938, "Basic", "Abductors");
            Exercise ex4 = new Exercise("Lying Straight Leg Raise", 970, "Basic", "Hip Flexors");
            Exercise ex5 = new Exercise("Lateral Step-up", 1081, "Basic", "Quadriceps");
            Exercise ex6 = new Exercise("Hanging Hamstring Bridge", 1814, "Basic", "Hamstrings");
            Exercise ex7 = new Exercise("Standing Calf Raise", 1176, "Basic", "General Calf / Gastrocnemius");
            Exercise ex8 = new Exercise("Single Leg Calf Raise", 1174, "Basic", "General Calf / Gastrocnemius");
            Exercise ex9 = new Exercise("Reverse Calf Raise", 1448, "Basic", "Tibialis Anterior");



            legsWorkout.Add(ex1);
            legsWorkout.Add(ex2);
            legsWorkout.Add(ex3);
            legsWorkout.Add(ex4);
            legsWorkout.Add(ex5);
            legsWorkout.Add(ex6);
            legsWorkout.Add(ex7);
            legsWorkout.Add(ex8);
            legsWorkout.Add(ex9);

        }

    }
}
