using System;
using System.Collections.Generic;
using FitDeck_CSCI4805.Account;
using FitDeck_CSCI4805.WebApi;
using Xamarin.Forms;

namespace FitDeck_CSCI4805
{
    public partial class LoginPage : ContentPage
    {
        private UserLogin login;
        private ConnectApi connect;
        private UserAccount _user;
        public LoginPage()
        {
            InitializeComponent();
            this.login = new UserLogin();
            this.connect = new ConnectApi();
            this._user = new UserAccount();
        }

        async void SigninBtn_Clicked(System.Object sender, System.EventArgs e)
        {
            if(usernameEntry == null || passwordEntry == null)
            {
                DisplayAlert("Error:", "You must fill out all fields.", "OK");
            }
            login.UserName = usernameEntry.Text;
            login.Password = passwordEntry.Text;
            _user = await connect.LoginAsync(login);
            Navigation.PushAsync(new ProfileHomePage(_user));
        }
    }
}
