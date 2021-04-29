using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using Xamarin.Forms;
using System.IO;
using System.Drawing;
using Image = System.Drawing.Image;
using System.Net;

namespace FitDeck_CSCI4805
{
    public partial class CreateWorkoutPage : ContentPage
    {
        RestService restService;
        public CreateWorkoutPage()
        {
            InitializeComponent();
            restService = new RestService();
            
        }

        //Method to populate specific muscle group picker with the appropriate muscle group
        void muscleGroupPicker_SelectedIndexChanged(System.Object sender, System.EventArgs e)
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

        //still need to put in if statments to better handle exceptions
        //figure out images
        private async void findExercisesButton_Clicked(System.Object sender, System.EventArgs e)
        {
            var token = await restService.AuthenticateUserAsync();
            var content = await RestService.Exercises((string)apparatusPicker.SelectedItem, (string)concentratedMuscleGroupPicker.SelectedItem, token.token);

            int count = 0;
            if (content != null)
            {
                foreach (Exercis ex in content.exercises)
                {
                    count++;

                }
                if (content.exercises.Count == count)
                    {
                        layout.ItemsSource = content.exercises;
                    }
            }
            else
            {
                await DisplayAlert("alert", "Something went wrong", "ok");
            }
        }
    }
}
