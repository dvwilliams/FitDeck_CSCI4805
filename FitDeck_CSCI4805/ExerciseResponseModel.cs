using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace FitDeck_CSCI4805
{
    //properties given by the json file of the Api
    public class ExerciseResponseModel
    {
        [JsonProperty("exercises")]
        public List<Exercis> exercises { get; set; }

    }

    //specific exercises given by the Api when called
    public class Exercis
    {
        public int Exercise_Id { get; set; }
        public string Exercise_Name { get; set; }
        public string URL { get; set; }
        public string Apparatus_Name { get; set; }
        public string Apparatus_Abbreviation { get; set; }
        public int IV { get; set; }
        public int Intensity_Weight { get; set; }
        public int Intensity_RM1 { get; set; }
        public int Intensity_Measurement { get; set; }
        public int Intensity_Cardio { get; set; }
        public int Duration_Reps { get; set; }
        public int Duration_Distance { get; set; }
        public int Duration_Time { get; set; }
        public int Duration_Interval { get; set; }
        public int Cardio_HR { get; set; }
        public int Cardio_Level { get; set; }
        public int Cardio_METs { get; set; }
        public int Cardio_HRMax { get; set; }
        public int Cardio_HRReserve { get; set; }
        public int Cardio_METMax { get; set; }
        public int Cardio_VO2Max { get; set; }
        public int Cardio_VO2Reserve { get; set; }
        public int Cardio_RPE1_10 { get; set; }
        public int Cardio_RPE6_20 { get; set; }
        public int Cardio_Speed { get; set; }
        public int Cardio_Watts { get; set; }
        public string Apparatus_Groups_Name { get; set; }
        public int is_concatenate { get; set; }
        public string Utility_Name { get; set; }
        public object Secondary_Muscle_Group { get; set; }
        public string Movement_Name { get; set; }
        public int Bilateral_Loading { get; set; }
        public int Body_Weight_Percent { get; set; }
        public string Instructions_Preparation { get; set; }
        public string Instructions_Execution { get; set; }
        public string Small_Img_1 { get; set; }
        public string Small_Img_2 { get; set; }
        public string Larg_Img_1 { get; set; }
        public string Larg_Img_2 { get; set; }
        public string GIF_Img { get; set; }
        public int Recommend_Image { get; set; }
        public string video_src { get; set; }
        public string video_play_thumbnail { get; set; }
        public string video_xs_thumbnail { get; set; }
        public string Exercise_Name_Complete { get; set; }
        public string Exercise_Name_Complete_Abbreviation { get; set; }
        public string Utility_Icon { get; set; }
        public string Target_Muscle_Group { get; set;}
    }

   

}
