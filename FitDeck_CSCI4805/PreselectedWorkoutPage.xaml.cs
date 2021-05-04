/**using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace FitDeck_CSCI4805
{
    public partial class PreselectedWorkoutPage : ContentPage
    {
        PreselectedWorkout workout;
        RestService restService;
        User user;
        PreselectedWorkout pw;
        //need user to navigate between pages until databse is used
        public PreselectedWorkoutPage(User user)
        {
            InitializeComponent();
            workout = new PreselectedWorkout();
            restService = new RestService();
            this.user = user;
            pw = new PreselectedWorkout();
        }

        //adds the workout to the user's workouts and returns to the profile screen
        //checks that the checkbox has one item selected and sets the day
        void addPreselectedWorkoutButton_Clicked(System.Object sender, System.EventArgs e)
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

            foreach (CheckBox cb in cbs)
            {
                if (cb.IsChecked == true)
                {
                    count++;
                }
            }

            if (noBoxChecked || count > 1)
            {
                DisplayAlert("Error", "Please Check only one day of the week box.", "OK");
            }
            else
            {
                if (sundayCheckBox.IsChecked == true)
                {
                    workout.Day = sunday.ToString();
                    workout.Name = selectWorkoutPicker.SelectedItem.ToString();
                }
                else if (mondayCheckBox.IsChecked == true)
                {
                    workout.Day = monday.ToString();
                    workout.Name = selectWorkoutPicker.SelectedItem.ToString();
                }
                else if (tuesdayCheckBox.IsChecked == true)
                {
                    workout.Day = tuesday.ToString();
                    workout.Name = selectWorkoutPicker.SelectedItem.ToString();
                }
                else if (wednesdayCheckBox.IsChecked == true)
                {
                    workout.Day = wednesday.ToString();
                    workout.Name = selectWorkoutPicker.SelectedItem.ToString();
                }
                else if (thursdayCheckBox.IsChecked == true)
                {
                    workout.Day = thursday.ToString();
                    workout.Name = selectWorkoutPicker.SelectedItem.ToString();
                }
                else if (fridayCheckBox.IsChecked == true)
                {
                    workout.Day = friday.ToString();
                    workout.Name = selectWorkoutPicker.SelectedItem.ToString();
                }
                else if (saturdayCheckBox.IsChecked == true)
                {
                    workout.Day = saturday.ToString();
                    workout.Name = selectWorkoutPicker.SelectedItem.ToString();
                }
                else
                {
                    workout.Day = anyday.ToString();
                    workout.Name = selectWorkoutPicker.SelectedItem.ToString();
                }
                popupDayView.IsVisible = false;
                Navigation.PushAsync(new ProfileHomePage(user));
            }


        }

        //doesn't work right but is supposed to call the api to populate a list view
        //based on the exercise ids
        async void chooseWorkoutButton_Clicked(System.Object sender, System.EventArgs e)
        {
            List<int> ids = new List<int>();
            int count = 0;

            if(selectWorkoutPicker.SelectedIndex == -1)
            {
                await DisplayAlert("Error", "Please select a workout", "OK");
            }
            else
            {
                List<Exercise> exers = getExercises(selectWorkoutPicker.SelectedItem.ToString());

                foreach (Exercise ex in exers)
                {
                    count++;
                    if (exers.Count == count)
                    {
                        var token = await restService.AuthenticateUserAsync();

                        //heres the issue. I've called it with a list of strings, a list of ints, an array
                        //of strings, an array of ints, and single strings and ints. it only works with id:1
                        //rigt now it just has a string in it so it doesnt throw an error when i test other code 
                        var content = await RestService.getExerciseById(ex.Name, token.token);

                        if (content != null)
                        {
                            preselectedWorkoutsView.ItemsSource = content.exercises;
                        }
                        else
                        {
                            await DisplayAlert("Error", "Something went wrong", "OK");
                        }

                    }
                    
                }

            }
        }

        //retrieves the right list of exercises for the selected item in the picker
        List<Exercise> getExercises(string selectedWorkout)
        {
            if (selectedWorkout == "Cardio and Conditioning")
            {
                pw.CardioAndConditioningWorkout();
                return pw.cardioAndConditioningWorkout;
            }
            else if (selectedWorkout == "Plyometric Workout")
            {
                pw.PlyometricWorkout();
                return pw.plyometricWorkout;
            }
            else if (selectedWorkout == "Stretch Workout")
            {
                pw.StretchWorkout();
                return pw.stretchWorkout;
            }
            else if (selectedWorkout == "Abdominal Workout")
            {
                pw.AbdominalWorkout();
                return pw.abdominalWorkout;
            }
            else if (selectedWorkout == "Arms Workout")
            {
                pw.ArmsWorkout();
                return pw.armsWorkout;
            }
            else if (selectedWorkout == "Back Workout")
            {
                pw.BackWorkout();
                return pw.backWorkout;
            }
            else if (selectedWorkout == "Chest Workout")
            {
                pw.ChestWorkout();
                return pw.chestWorkout;
            }
            else
            {
                pw.LegsWorkout();
                return pw.legsWorkout;
            }
                                                         
        }

        void addWorkoutButton_Clicked(System.Object sender, System.EventArgs e)
        {
            popupDayView.IsVisible = true;

        }
    }
}
**/