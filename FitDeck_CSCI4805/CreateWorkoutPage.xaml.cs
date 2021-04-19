using System;
using System.Collections.Generic;
using System.Net.Http;
using Xamarin.Forms;

namespace FitDeck_CSCI4805
{
    public partial class CreateWorkoutPage : ContentPage
    {
        static HttpClient client = new HttpClient();

        public CreateWorkoutPage()
        {
            InitializeComponent();
        }

        void armsButton_Clicked(System.Object sender, System.EventArgs e)
        {

        }
    }
}
