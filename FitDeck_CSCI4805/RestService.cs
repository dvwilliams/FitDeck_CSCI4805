using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FitDeck_CSCI4805
{
    //class that handles the http connection
    public class RestService
    {
        private static HttpClient client;
        private JsonSerializer jsonSerializer = new JsonSerializer();
        private static RestService _restService;
        public static RestService restService
        {
            get
            {
                if (_restService == null)
                {
                    _restService = new RestService();

                }
                return _restService;
            }
        }
        //generates the client for the use throughout the application
        public RestService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://204.235.60.194");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        //method for taking the given user name and password and will return the bearer token needed for accessing the Api db
       public async Task<ExRxDatabseResponseModel> AuthenticateUserAsync()
        {
            try
            {
                ExRxDatabase erDB = new ExRxDatabase()
                {
                    username = "daphnewexrx", password = "sRA5sHU6"
                };

                var content = new StringContent(JsonConvert.SerializeObject(erDB), Encoding.UTF8, "application/json");
                var response = await client.PostAsync("/consumer/login?", content);

                response.EnsureSuccessStatusCode();
                using (var stream = await response.Content.ReadAsStreamAsync())
                using (var reader = new StreamReader(stream))
                using (var json = new JsonTextReader(reader))
                {
                    var jsoncontent = jsonSerializer.Deserialize<ExRxDatabseResponseModel>(json);
                    Preferences.Set("authtoken", jsoncontent.token);
                    return jsoncontent;
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        //Method responsible for obtaining the list of weight training exercises given from the Api that match the credentials given
        public static async Task<ExerciseResponseModel> weightExercises(string apparatus, string muscleGroup, string token)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            string url = $"/exrxapi/v1/allinclusive/exercises?musclegroup={muscleGroup}&apparatus={apparatus}";

            string response = await client.GetStringAsync(url);

            try
            {
                var app = JsonConvert.DeserializeObject<ExerciseResponseModel>(response);
                return app;
            }
            catch (Exception ex)
            {
                return null;
            } 

        }

        //Method responsible for obtaining the list of plyometric exercises given from the Api that match the credentials given
        public static async Task<ExerciseResponseModel> plyoExercises(string movement, string intensity, string token)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            string url = $"/exrxapi/v1/allinclusive/exercises?movement={movement}&intensity={intensity}";

            string response = await client.GetStringAsync(url);

            try
            {
                var app = JsonConvert.DeserializeObject<ExerciseResponseModel>(response);
                return app;
            }
            catch (Exception ex)
            {
                return null;
            }


        }
        //Method responsible for obtaining the list of stretch exercises given from the Api that match the credentials given
        public static async Task<ExerciseResponseModel> stretchExercises(string bodypart, string token)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            string url = $"/exrxapi/v1/allinclusive/exercises?stretch&bodypart={bodypart}";

            string response = await client.GetStringAsync(url);

            try
            {
                var app = JsonConvert.DeserializeObject<ExerciseResponseModel>(response);
                return app;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        //Method responsible for obtaining the list of cardio/conditioning exercises given from the Api that match the credentials given
        public static async Task<ExerciseResponseModel> cardioExercises(string subcategory, string token)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            string url = $"/exrxapi/v1/allinclusive/exercises?subcategory={subcategory}";

            string response = await client.GetStringAsync(url);

            try
            {
                var app = JsonConvert.DeserializeObject<ExerciseResponseModel>(response);
                return app;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        //only works for burpee (exercise id 1)
        public static async Task<ExerciseResponseModel> getExerciseById(string ID, string token)
        {
            
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            string url = $"/exrxapi/v1/allinclusive/exercises?exerciseids=[{ID}]";

            string response = await client.GetStringAsync(url);

            try
            {
                var app = JsonConvert.DeserializeObject<ExerciseResponseModel>(response);
                return app;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
