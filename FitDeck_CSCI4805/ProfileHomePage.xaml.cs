using System;
using System.Collections.Generic;
using System.Diagnostics;
using FitDeck_CSCI4805.Account;
using Xamarin.Forms;

namespace FitDeck_CSCI4805
{
    public partial class ProfileHomePage : ContentPage
    {
        RestDay restDay;
        RestDays restDays;
        Workouts workouts;
        Workout workout;
        RestService restService;
        List<Exercise> exercises;
        Exercis exercise;
        List<string> workoutNames;
        Stopwatch stopwatch;
        DailyStats dailystats;
        WeeklyStats weeklyStats;

        //need user to navigate between pages until database is used
        //doesnt show user info anymore!!
        UserAccount user;
        public ProfileHomePage(UserAccount user)
        {
            InitializeComponent();

            restService = new RestService();
            exercises = new List<Exercise>();
            workout = new Workout();
            stopwatch = new Stopwatch();
            dailystats = new DailyStats();
            weeklyStats = new WeeklyStats();

            DailyStats dailystat = new DailyStats((float)1.20, 45, DayOfWeek.Monday);
            weeklyStats.addDailyStat(dailystat);
            dailyStatsCharts.ItemsSource = weeklyStats._DailyStats;

            this.user = user;
            lblName.Text = user.FullName;
            lblUsername.Text = user.UserName;
            lblEmail.Text = user.Email;
            lblAge.Text = user.Age.ToString();
            lblHeight.Text = user.GetHeightString();
            lblWeight.Text = user.Weight.ToString();

        }

        void logoutButton_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }

        //rest day window is visible
        void addRestDayButton_Clicked(System.Object sender, System.EventArgs e)
        {
            popupDayView.IsVisible = true;
        }

        //goes to either create workout page or preselected workout page
        async void addWorkoutButton_Clicked(System.Object sender, System.EventArgs e)
        {

            string answer = await DisplayActionSheet("Add Workout", "Cancel", "Create Custom Workout", "Add Preselected Workout");
            Debug.WriteLine("Action: " + answer);

            if(answer == "Create Custom Workout")
            {
                await Navigation.PushAsync(new CreateWorkoutPage(user));
            }
            else if(answer == "Add Preselected Workout")
            {
                await Navigation.PushAsync(new PredeterminedWorkoutPage(user));
            }
            
        }

        //goes to edit workout page (which i think should just be the create workout page but with
        //a specifically chosen workout idk)
        void editWorkoutButton_Clicked(System.Object sender, System.EventArgs e)
        {
            if(workouts == null)
            {
                DisplayAlert("Error", "Please add workout(s)", "OK");
;            }
            else
            {
                popupEditWorkoutsView.IsVisible = true;
                //needs to call database to retrieve the list of workout exercises
                listOfWorkoutsPicker.ItemsSource = workouts._Workouts;
            }
            
        }

        //uses popup window to add restday(s)
        //will set the listview for workouts to nothing if the day is currently a restday
        void addRestDaysButton_Clicked(System.Object sender, System.EventArgs e)
        {
            var noBoxChecked = sundayCheckBox.IsChecked == false && mondayCheckBox.IsChecked == false
                && tuesdayCheckBox.IsChecked == false && wednesdayCheckBox.IsChecked == false
                && thursdayCheckBox.IsChecked == false && fridayCheckBox.IsChecked == false
                && saturdayCheckBox.IsChecked == false && anydayCheckBox.IsChecked == false;

            restDays = new RestDays();

            if (noBoxChecked)
            {
                DisplayAlert("Error", "Please Check only one day of the week box.", "OK");
            }
            else
            {
                if (sundayCheckBox.IsChecked == true)
                {
                    restDay = new RestDay(DayOfWeek.Sunday);
                    restDays.addRestDay(restDay);
                }
                if (mondayCheckBox.IsChecked == true)
                {
                    restDay = new RestDay(DayOfWeek.Monday);
                    restDays.addRestDay(restDay);
                }
                if (tuesdayCheckBox.IsChecked == true)
                {
                    restDay = new RestDay(DayOfWeek.Tuesday);
                    restDays.addRestDay(restDay);
                }
                if (wednesdayCheckBox.IsChecked == true)
                {
                    restDay = new RestDay(DayOfWeek.Wednesday);
                    restDays.addRestDay(restDay);
                }
                if (thursdayCheckBox.IsChecked == true)
                {
                    restDay = new RestDay(DayOfWeek.Thursday);
                    restDays.addRestDay(restDay);
                }
                if (fridayCheckBox.IsChecked == true)
                {
                    restDay = new RestDay(DayOfWeek.Friday);
                    restDays.addRestDay(restDay);
                }
                if (saturdayCheckBox.IsChecked == true)
                {
                    restDay = new RestDay(DayOfWeek.Saturday);
                    restDays.addRestDay(restDay);
                }
                if (anydayCheckBox.IsChecked == true)
                {
                    restDay = new RestDay(DayOfWeek.Sunday);
                    RestDay restDay2 = new RestDay(DayOfWeek.Monday);
                    RestDay restDay3 = new RestDay(DayOfWeek.Tuesday);
                    RestDay restDay4 = new RestDay(DayOfWeek.Wednesday);
                    RestDay restDay5 = new RestDay(DayOfWeek.Thursday);
                    RestDay restDay6 = new RestDay(DayOfWeek.Friday);
                    RestDay restDay7 = new RestDay(DayOfWeek.Saturday);

                    restDays.addRestDay(restDay);
                    restDays.addRestDay(restDay2);
                    restDays.addRestDay(restDay3);
                    restDays.addRestDay(restDay4);
                    restDays.addRestDay(restDay5);
                    restDays.addRestDay(restDay6);
                    restDays.addRestDay(restDay7);

                }
                popupDayView.IsVisible = false;

                foreach (RestDay rd in restDays.restdays)
                {
                    if (rd.Day == DateTime.Now.DayOfWeek)
                    {
                        rd.IsCurrentDay = true;
                        workoutsListView.ItemsSource = "";
                    }
                    else
                    {
                        workoutsListView.ItemsSource = workouts._Workouts;
                    }
                }

            }

        }

        void editSpecificWorkoutButton_Clicked(System.Object sender, System.EventArgs e)
        {
            if(listOfWorkoutsPicker == null)
            {
                DisplayAlert("Error", "Select a workout to edit or delete", "OK");
            }
            else
            {
                popupEditSpecificWorkoutView.IsVisible = true;
            }
        }

        void deleteWorkoutButton_Clicked(System.Object sender, System.EventArgs e)
        {
            if (listOfWorkoutsPicker == null)
            {
                DisplayAlert("Error", "Select a workout to edit or delete", "OK");
            }
            else
            {
                foreach(Workout wo in workouts._Workouts)
                {
                    if(wo.Name == listOfWorkoutsPicker.SelectedItem.ToString())
                    {
                        workouts.deleteWorkout(wo);
                    }
                }
                
            }
        }

        void finishEditingWorkoutButton_Clicked(System.Object sender, System.EventArgs e)
        {
            popupEditWorkoutsView.IsVisible = false;
        }

        void finishEditingExercisesButton_Clicked(System.Object sender, System.EventArgs e)
        {
            Workout wo = new Workout(workout.Name, workout.Day);
            foreach (Exercise ex in workout.Exercises)
            {
                wo.addExercise(ex);
            }

            //replace old workout in db with this new workout
            popupEditSpecificWorkoutView.IsVisible = false;
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
                viewWorkout.ItemsSource = workout.Exercises;


            }

        }

        void startWorkoutButton_Clicked(System.Object sender, System.EventArgs e)
        {
            //need to grab itemssource from db
            workoutToStartPicker.ItemsSource = workouts._Workouts;
            
            
                popupStartWorkoutView.IsVisible = true;
            
        }

        void startButton_Clicked(System.Object sender, System.EventArgs e)
        {
            if (workoutToStartPicker.SelectedItem == null)
            {
                DisplayAlert("Error", "Please add a workout or select a workout to start", "OK");
            }
            else
            {

                if (!stopwatch.IsRunning)
                {
                    stopwatch.Start();
                    Device.StartTimer(TimeSpan.FromSeconds(100), () =>
                    {
                        Device.BeginInvokeOnMainThread(() =>
                        stopwatchLabel.Text = stopwatch.Elapsed.ToString());
                        if (!stopwatch.IsRunning)
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    });
                }
            }
        }

        void stopButton_Clicked(System.Object sender, System.EventArgs e)
        {
            stopwatch.Stop();
            float time = float.Parse(stopwatchLabel.Text);

            //DailyStats dailystat = new DailyStats(time, dailystats.caloriesburned(), DateTime.Now.DayOfWeek);

            //tester for chart. doesnt work for now
            DailyStats dailystat = new DailyStats((float)1.20, 45, DayOfWeek.Monday);
            weeklyStats.addDailyStat(dailystat);
            dailyStatsCharts.ItemsSource = weeklyStats._DailyStats;

            stopwatchLabel.Text = "You spent " + dailystat.convertTimeSpent() + " minutes working out and burned " + dailystat.CaloriesBurned + " calories.";
        }

        void pauseButton_Clicked(System.Object sender, System.EventArgs e)
        {
            startButton.Text = "Resume";
            stopwatch.Stop();
        }
    }
}
