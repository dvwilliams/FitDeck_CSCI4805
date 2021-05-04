using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace FitDeck_CSCI4805
{
    public partial class FinishSignupPage : ContentPage
    {
        string username, emailaddress;

        public FinishSignupPage(string username, string emailAddress)
        {
            InitializeComponent();

            this.username = username;
            this.emailaddress = emailAddress;

        }
        void finishAccountBtn_Clicked(System.Object sender, System.EventArgs e)
        {
            if (nameEntry == null || monthDOBPicker.SelectedIndex == -1 || dayDOBPicker.SelectedIndex == -1 ||
                yearEntry == null || weightEntry == null || feetHeightPicker.SelectedIndex == -1 || inchesHeightPicker.SelectedIndex == -1)
            {
                DisplayAlert("Error:", "All boxes must have valid entries.", "OK");

            }
            else
            {
                int parseYear = int.Parse(yearEntry.Text);
                if (parseYear >= 2022 || parseYear <= 1849)
                {
                    DisplayAlert("Error:", "Please Enter a valid year.", "OK");
                }
                else
                {
                    int month = (int)monthDOBPicker.SelectedItem;
                    int day = (int)dayDOBPicker.SelectedItem;
                    int year = Int32.Parse(yearEntry.Text);
                    DateTime dOB = new DateTime(year, month, day);


                    int feet = (int)feetHeightPicker.SelectedItem;
                    int inches = (int)inchesHeightPicker.SelectedItem;
                    float ins = (float)inches / 100;
                    float height = feet + ins;
                    Math.Round(height, 2);
                    User user = new User(username, emailaddress, nameEntry.Text, dOB, Int32.Parse(weightEntry.Text), height);

                    //Created to test whether the data was being stored or not
                    //ObservableCollection<string> data = new ObservableCollection<string>();
                    //data.Add(user.ToString());
                    //userView.ItemsSource = data;

                    //navigates to the next page in the app
                    //paramater of user needed to test without the database
                    Navigation.PushAsync(new ProfileHomePage(user));
                }
            }
        }

        //when the user selects a month, it will populate the day picker with the specific days that are
        //in that month
        //I think i might go back and edit february to also only have 29 days if the year is a leap year
        void monthDOBPicker_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            var days = new List<int>();
            if (monthDOBPicker.SelectedIndex == 0 || monthDOBPicker.SelectedIndex == 2 || monthDOBPicker.SelectedIndex == 4 ||
            monthDOBPicker.SelectedIndex == 6 || monthDOBPicker.SelectedIndex == 7 || monthDOBPicker.SelectedIndex == 9 ||
                monthDOBPicker.SelectedIndex == 11)
            {
                days.Add(01);
                days.Add(02);
                days.Add(03);
                days.Add(04);
                days.Add(05);
                days.Add(06);
                days.Add(07);
                days.Add(08);
                days.Add(09);
                days.Add(10);
                days.Add(11);
                days.Add(12);
                days.Add(13);
                days.Add(14);
                days.Add(15);
                days.Add(16);
                days.Add(17);
                days.Add(18);
                days.Add(19);
                days.Add(20);
                days.Add(21);
                days.Add(22);
                days.Add(23);
                days.Add(24);
                days.Add(25);
                days.Add(26);
                days.Add(27);
                days.Add(28);
                days.Add(29);
                days.Add(30);
                days.Add(31);

                dayDOBPicker.ItemsSource = days;
            }
            else if (monthDOBPicker.SelectedIndex == 3 || monthDOBPicker.SelectedIndex == 5 ||
                monthDOBPicker.SelectedIndex == 8 || monthDOBPicker.SelectedIndex == 10)
            {
                days.Add(01);
                days.Add(02);
                days.Add(03);
                days.Add(04);
                days.Add(05);
                days.Add(06);
                days.Add(07);
                days.Add(08);
                days.Add(09);
                days.Add(10);
                days.Add(11);
                days.Add(12);
                days.Add(13);
                days.Add(14);
                days.Add(15);
                days.Add(16);
                days.Add(17);
                days.Add(18);
                days.Add(19);
                days.Add(20);
                days.Add(21);
                days.Add(22);
                days.Add(23);
                days.Add(24);
                days.Add(25);
                days.Add(26);
                days.Add(27);
                days.Add(28);
                days.Add(29);
                days.Add(30);

                dayDOBPicker.ItemsSource = days;
            }
            else
            {
                days.Add(01);
                days.Add(02);
                days.Add(03);
                days.Add(04);
                days.Add(05);
                days.Add(06);
                days.Add(07);
                days.Add(08);
                days.Add(09);
                days.Add(10);
                days.Add(11);
                days.Add(12);
                days.Add(13);
                days.Add(14);
                days.Add(15);
                days.Add(16);
                days.Add(17);
                days.Add(18);
                days.Add(19);
                days.Add(20);
                days.Add(21);
                days.Add(22);
                days.Add(23);
                days.Add(24);
                days.Add(25);
                days.Add(26);
                days.Add(27);
                days.Add(28);
                days.Add(29);

                dayDOBPicker.ItemsSource = days;
            }
        }
        
    }

}

