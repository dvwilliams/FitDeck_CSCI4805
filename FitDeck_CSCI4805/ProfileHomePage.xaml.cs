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

        //need user to navigate between pages until databse is used
       
        UserAccount user;
        public ProfileHomePage(UserAccount user)
        {
            InitializeComponent();

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
    }
}
