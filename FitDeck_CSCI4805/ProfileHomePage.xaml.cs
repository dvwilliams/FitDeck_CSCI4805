using System;
using System.Collections.Generic;
using System.Diagnostics;
using FitDeck_CSCI4805.Account;
using Xamarin.Forms;

namespace FitDeck_CSCI4805
{
    public partial class ProfileHomePage : ContentPage
    {
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

        }

        void addRestDayButton_Clicked(System.Object sender, System.EventArgs e)
        {
        }

        async void addWorkoutButton_Clicked(System.Object sender, System.EventArgs e)
        {

            string answer = await DisplayActionSheet("Add Workout", "Cancel", "Create Custom Workout", "Add Preselected Workout");
            Debug.WriteLine("Action: " + answer);

            if(answer == "Create Custom Workout")
            {
                await Navigation.PushAsync(new CreateWorkoutPage());
            }
            else if(answer == "Add Preselected Workout")
            {
                await Navigation.PushAsync(new PreselectedWorkoutPage());
            }
            
        }

        void editWorkoutButton_Clicked(System.Object sender, System.EventArgs e)
        {
        }
    }
}
