using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using Xamarin.Forms;
using System.IO;
using FitDeck_CSCI4805.Account;
using FitDeck_CSCI4805.WebApi;
using System.Net;
using System.Diagnostics;
using Xamarin.Forms.Internals;

namespace FitDeck_CSCI4805
{
    public partial class CreateWorkoutPage : ContentPage
    {
        RestService restService;
        List<Exercise> exercises;
        Exercis exercise;
        Workout workout;
        List<string> workoutNames;
        UserAccount _user;

        //need user to navigate between pages until databse is used
        public CreateWorkoutPage(UserAccount _user)
        {
            InitializeComponent();
            restService = new RestService();
            exercises = new List<Exercise>();
            workout = new Workout();
            this._user = _user;
        }

        //Method to populate specific muscle group picker with the appropriate muscle group
        //works with weight training option for type of exercise
        void muscleGroupPicker_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            if (muscleGroupPicker.SelectedIndex > -1)
            {
                var specificGroup = new List<string>();
                if (muscleGroupPicker.SelectedItem.ToString() == "Upper Arms")
                {
                    specificGroup.Add("Triceps Brachii");
                    specificGroup.Add("Biceps Brachii");
                    specificGroup.Add("Brachialis");
                    concentratedMuscleGroupPicker.ItemsSource = specificGroup;
                }
                else if (muscleGroupPicker.SelectedItem.ToString() == "ForeArms")
                {
                    specificGroup.Add("Brachioradialis");
                    specificGroup.Add("Wrist Flexors");
                    specificGroup.Add("Wrist Extensors");
                    specificGroup.Add("Pronators");
                    specificGroup.Add("Supinators");
                    concentratedMuscleGroupPicker.ItemsSource = specificGroup;
                }

                else if (muscleGroupPicker.SelectedItem.ToString() == "Shoulders")
                {
                    specificGroup.Add("Anterior Deltoid");
                    specificGroup.Add("Lateral Deltoid");
                    specificGroup.Add("Posterior Deltoid");
                    specificGroup.Add("Supraspinatus");
                    concentratedMuscleGroupPicker.ItemsSource = specificGroup;
                }
                else if (muscleGroupPicker.SelectedItem.ToString() == "Hips")
                {
                    specificGroup.Add("Gluteus Maximus");
                    specificGroup.Add("Abductors");
                    specificGroup.Add("Flexors");
                    specificGroup.Add("Deep External Rotators");
                    concentratedMuscleGroupPicker.ItemsSource = specificGroup;

                }
                else if (muscleGroupPicker.SelectedItem.ToString() == "Chest")
                {
                    specificGroup.Add("General Chest");
                    specificGroup.Add("Pectoralis Major, Sternal");
                    specificGroup.Add("Pectoralis Minor");
                    specificGroup.Add("Serratus Anterior");
                    concentratedMuscleGroupPicker.ItemsSource = specificGroup;
                }
                else if (muscleGroupPicker.SelectedItem.ToString() == "Back")
                {
                    specificGroup.Add("General Back");
                    specificGroup.Add("Latissimus Dorsi and Teres Major");
                    specificGroup.Add("Trapezius Upper");
                    specificGroup.Add("Trapezius Middle");
                    specificGroup.Add("Trapezius Lower");
                    specificGroup.Add("Levator Scapulae");
                    specificGroup.Add("Rhomboids");
                    specificGroup.Add("Infraspinatus and Teres Minor");
                    specificGroup.Add("Subscapularis");
                    concentratedMuscleGroupPicker.ItemsSource = specificGroup;
                }
                else if (muscleGroupPicker.SelectedItem.ToString() == "Waist")
                {
                    specificGroup.Add("Rectus Abdominis");
                    specificGroup.Add("Traverse Abdominis");
                    specificGroup.Add("Obliques");
                    specificGroup.Add("Quadratus Lumborum");
                    specificGroup.Add("Erector Spinae");
                    concentratedMuscleGroupPicker.ItemsSource = specificGroup;
                }
                else if (muscleGroupPicker.SelectedItem.ToString() == "Neck")
                {
                    specificGroup.Add("Sternocleidomastoid");
                    specificGroup.Add("Splenius");
                    concentratedMuscleGroupPicker.ItemsSource = specificGroup;
                }
                else if (muscleGroupPicker.SelectedItem.ToString() == "Thighs")
                {
                    specificGroup.Add("Quadriceps");
                    specificGroup.Add("Hamstrings");
                    specificGroup.Add("Hip Adductors");
                    concentratedMuscleGroupPicker.ItemsSource = specificGroup;
                }
                else //calves
                {
                    specificGroup.Add("General Calves");
                    specificGroup.Add("Gastrocnemius");
                    specificGroup.Add("Soleus");
                    specificGroup.Add("Tibialis Anterior");
                    specificGroup.Add("Popliteus");
                    concentratedMuscleGroupPicker.ItemsSource = specificGroup;
                }
            }
            else
            {
                concentratedMuscleGroupPicker.SelectedIndex = -1;
            }

        }

        //Method to populate specific type picker with the appropriate entires
        //works with every other option for type of exercise
        void exerciseTypePicker_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            var type = new List<string>();
            var intensity = new List<string>();

            if (exerciseTypePicker.SelectedItem.ToString() == "Weight Training")
            {
                DisplayAlert("Weight Training", "If you would like to select weight training exercises, choose muscle groups and an apparatus", "OK");

                intensityPicker.IsVisible = false;
            }
            else if (exerciseTypePicker.SelectedItem.ToString() == "Plyometrics")
            {
                specificTypePicker.Title = "Movement";
                intensityPicker.IsVisible = true;

                type.Add("Vertical");
                type.Add("Horizontal");
                type.Add("Lateral");
                type.Add("Truck Extension");
                type.Add("Trunk Flexion");
                type.Add("Trunk Rotation");
                type.Add("Pulldown");
                type.Add("Forward Push");
                type.Add("Upward Push");
                specificTypePicker.ItemsSource = type;

                intensity.Add("Low");
                intensity.Add("Low Medium");
                intensity.Add("Medium");
                intensity.Add("Medium High");
                intensity.Add("High");
                intensityPicker.ItemsSource = intensity;
            }
            else if (exerciseTypePicker.SelectedItem.ToString() == "Stretch")
            {
                intensityPicker.IsVisible = false;
                specificTypePicker.Title = "Bodypart";

                type.Add("Neck");
                type.Add("Shoulders");
                type.Add("Upper Arms");
                type.Add("Forearms");
                type.Add("Back");
                type.Add("Chest");
                type.Add("Waist");
                type.Add("Hips");
                type.Add("Thighs");
                type.Add("Calves");

                specificTypePicker.ItemsSource = type;
            }
            else
            {
                intensityPicker.IsVisible = true;
                specificTypePicker.Title = "Cardio Category";

                type.Add("Calisthenic");
                type.Add("Machine");
                type.Add("Jump Rope");
                type.Add("Circuit Drill");

                specificTypePicker.ItemsSource = type;
            }
        }

        //still need to put in if statments to better handle exceptions
        //figure out images
        private async void findExercisesButton_Clicked(System.Object sender, System.EventArgs e)
        {
            bool notExerciseType = muscleGroupPicker.SelectedIndex != -1 && concentratedMuscleGroupPicker.SelectedIndex != -1
                && apparatusPicker.SelectedIndex != -1 && exerciseTypePicker.SelectedIndex == -1;
            bool notMuscleGroup = muscleGroupPicker.SelectedIndex == -1 && apparatusPicker.SelectedIndex == -1
                && exerciseTypePicker.SelectedIndex != -1 && specificTypePicker.SelectedIndex != -1;


            var token = await restService.AuthenticateUserAsync();
            if (notExerciseType)
            {
                var content = await RestService.weightExercises(apparatusPicker.SelectedItem.ToString(), concentratedMuscleGroupPicker.SelectedItem.ToString(), token.token);
                workoutNames = new List<string>();

                int count = 0;
                if (content != null)
                {
                    foreach (Exercis ex in content.exercises)
                    {
                        count++;
                        workoutNames.Add(ex.Exercise_Name);

                    }
                    if (content.exercises.Count == count)
                    {
                        exerciseListView.ItemsSource = content.exercises;
                    }
                }
                else
                {
                    await DisplayAlert("Error", "No exercises of this muscle group and apparatus. Please make a new selection", "OK");
                }
                
                
            }
            else if (notMuscleGroup)
            {

                if (exerciseTypePicker.SelectedItem.ToString() == "Plyometrics")
                {
                    var content = await RestService.plyoExercises((string)specificTypePicker.SelectedItem, (string)intensityPicker.SelectedItem, token.token);
                    workoutNames = new List<string>();

                    int count = 0;
                    if (content != null)
                    {
                        foreach (Exercis ex in content.exercises)
                        {
                            count++;
                            workoutNames.Add(ex.Exercise_Name);

                        }
                        if (content.exercises.Count == count)
                        {
                            exerciseListView.ItemsSource = content.exercises;

                        }
                    }
                    else
                    {
                        await DisplayAlert("Error", "No exercises of this movement and intensity. Make a new selection.", "OK");

                    }
                }
                else if (exerciseTypePicker.SelectedItem.ToString() == "Stretch")
                {
                    var content = await RestService.stretchExercises((string)specificTypePicker.SelectedItem, token.token);
                    workoutNames = new List<string>();

                    int count = 0;
                    if (content != null)
                    {
                        foreach (Exercis ex in content.exercises)
                        {
                            count++;
                            workoutNames.Add(ex.Exercise_Name);
                            
                        }
                        if (content.exercises.Count == count)
                        {
                            exerciseListView.ItemsSource = content.exercises;

                        }
                    }
                    else
                    {
                        await DisplayAlert("Error", "Please make a new selection", "OK");

                    }
                }
                else if (exerciseTypePicker.SelectedItem.ToString() == "Cardio and Conditioning")
                {
                    var content = await RestService.cardioExercises((string)exerciseTypePicker.SelectedItem, token.token);
                    workoutNames = new List<string>();

                    int count = 0;
                    if (content != null)
                    {
                        foreach (Exercis ex in content.exercises)
                        {
                            count++;
                            workoutNames.Add(ex.Exercise_Name);

                        }
                        if (content.exercises.Count == count)
                        {
                            exerciseListView.ItemsSource = content.exercises;
                            
                        }

                    }
                    else
                    {
                        await DisplayAlert("Error", "Please make a new selection", "OK");

                    }
                }
            }

            else
            {
                await DisplayAlert("Error", "Make sure only one column of entries are selected " +
                    "(i.e. all selections for muscle groups are entered or all selections for " +
                    "exercise type are entered", "OK");
            }
            if (workout != null)
            {
                viewWorkout.ItemsSource = workout.ToString();
            }
        }

        async void exerciseListView_ItemSelected(System.Object sender, SelectedItemChangedEventArgs e)
        {
            var exercis = (Exercis)e.SelectedItem;

            string answer = await DisplayActionSheet("Add Exercise", "Cancel", "Add Exercise to Routine");
            Debug.WriteLine("Action: " + answer);

            if (answer == "Add Exercise to Routine")
            {
                Exercise exer = new Exercise(exercis.Exercise_Name, exercis.Exercise_Id, exercis.Utility_Name, exercis.Target_Muscle_Group);

                exercises.Add(exer);
                
                workout.addExercise(exer);
                viewWorkout.ItemsSource = workout.ToString();

                
            }
            
        }
        void finishCreatingWorkoutButton_Clicked(System.Object sender, System.EventArgs e)
        {
            popupDayView.IsVisible = true;
        }

        void createWorkoutButton_Clicked(System.Object sender, System.EventArgs e)
        {
            var noBoxChecked = sundayCheckBox.IsChecked == false && mondayCheckBox.IsChecked == false
                && tuesdayCheckBox.IsChecked == false && wednesdayCheckBox.IsChecked == false
                && thursdayCheckBox.IsChecked == false && fridayCheckBox.IsChecked == false
                && saturdayCheckBox.IsChecked == false && anydayCheckBox.IsChecked == false;

            List<CheckBox> cbs = new List<CheckBox>();
            cbs.Add(sundayCheckBox);
            cbs.Add(mondayCheckBox);
            cbs.Add(tuesdayCheckBox);
            cbs.Add(wednesdayCheckBox);
            cbs.Add(thursdayCheckBox);
            cbs.Add(fridayCheckBox);
            cbs.Add(saturdayCheckBox);
            cbs.Add(anydayCheckBox);

            int count = 0;

            foreach(CheckBox cb in cbs)
            {
                if(cb.IsChecked == true)
                {
                    count++;
                }
            }

            if (noBoxChecked || workoutNameEntry == null || count > 1)
            {
                DisplayAlert("Error","Please Check only one day of the week box and enter a name for the workout.", "OK");
            }
            else
            {
                if(sundayCheckBox.IsChecked == true)
                {
                    workout.Day = sunday.ToString();
                }
                else if (mondayCheckBox.IsChecked == true)
                {
                    workout.Day = monday.ToString();
                }
                else if (tuesdayCheckBox.IsChecked == true)
                {
                    workout.Day = tuesday.ToString();
                }
                else if (wednesdayCheckBox.IsChecked == true)
                {
                    workout.Day = wednesday.ToString();
                }
                else if (thursdayCheckBox.IsChecked == true)
                {
                    workout.Day = thursday.ToString();
                }
                else if (fridayCheckBox.IsChecked == true)
                {
                    workout.Day = friday.ToString();
                }
                else if (saturdayCheckBox.IsChecked == true)
                {
                    workout.Day = saturday.ToString();
                }
                else
                {
                    workout.Day = anyday.ToString();
                }
                workout.Name = workoutNameEntry.Text;
                Navigation.PushAsync(new ProfileHomePage(_user));
            }
        }

    }
}
