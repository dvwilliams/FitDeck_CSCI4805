using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FitDeck_CSCI4805
{
    public partial class SignupPage : ContentPage
    {
        public SignupPage()
        {
            InitializeComponent();
        }

        void createAccountBtn_Clicked(System.Object sender, System.EventArgs e)
        {
            if (usernameEntry.Text == null || emailEntry.Text == null || passwordEntry.Text == null || confirmPasswordEntry.Text == null)
            {
                DisplayAlert("Error:", "All boxes must have valid entries.", "OK");
            }
            else if(passwordEntry.Text != confirmPasswordEntry.Text)
            {
                DisplayAlert("Error:", "Passwords do not match.", "OK");
            }
            else
            {
                //Still need to: validate password
               
                User user = new User(usernameEntry.Text, emailEntry.Text);
                //user.Password = passwordEntry.Text;
                Navigation.PushAsync(new FinishSignupPage(usernameEntry.Text, emailEntry.Text));
            }
        }
    }
}
