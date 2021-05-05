using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FitDeck_CSCI4805.Account;
using FitDeck_CSCI4805.PreDetermined;
using FitDeck_CSCI4805.UserCreated;
using Newtonsoft.Json;

namespace FitDeck_CSCI4805.WebApi
{
    public class ConnectApi
    {
        HttpClient client = new HttpClient();
        string path = "";

        public ConnectApi()
        {
            client.BaseAddress = new Uri("https://fitdeckweb.azurewebsites.net/api");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<UserAccount> SignupAsync(UserSignup signup)
        {
            string _userRegister = JsonConvert.SerializeObject(signup);
            path = client.BaseAddress + "/Account/register";
            UserAccount user = new UserAccount();
            Console.WriteLine("Signup");
            HttpResponseMessage response = await client.PostAsJsonAsync(path, signup);
            if (response.IsSuccessStatusCode)
            {
                //Console.WriteLine("Success");
                user = await response.Content.ReadAsAsync<UserAccount>();
                Console.WriteLine(user.FullName);
            }
            else
            {
                //Console.WriteLine(_userRegister);
                //Console.WriteLine(path);
                Console.WriteLine(response.ReasonPhrase);
            }
            return user;
        }

        public async Task<UserAccount> LoginAsync(UserLogin login)
        {
            path = client.BaseAddress + "/Account/login";

            UserAccount user = new UserAccount();

            HttpResponseMessage response = await client.PostAsJsonAsync(path, login);
            if (response.IsSuccessStatusCode)
            {
                user = await response.Content.ReadAsAsync<UserAccount>();
            }
            else
            {
                Console.WriteLine(response.StatusCode);
            }
            return user;
        }

        public async Task AddWorkoutAsync(UserCreatedWorkout workout, string token)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            path = client.BaseAddress + "/UserCreated/addWorkout";

            HttpResponseMessage response = await client.PostAsJsonAsync(path, workout);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Succes");
            }
            else
            {
                Console.WriteLine("Error in response");
            }
        }

        public async Task<List<UserCreatedWorkout>> GetWorkoutByUserId(string token)
        {
            List<UserCreatedWorkout> workouts = new List<UserCreatedWorkout>();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            path = client.BaseAddress + "/UserCreate/getAllWorkoutsByUserId";

            HttpResponseMessage response = await client.GetAsync(path);

            if (response.IsSuccessStatusCode)
            {
                workouts = await response.Content.ReadAsAsync<List<UserCreatedWorkout>>();
            }
            else
            {
                Console.WriteLine("Error: GetWorkoutByUserId response unsuccesful");
            }
            return workouts;
        }

        public async Task<List<PreDeterminedWorkout>> GetPreDeterminedWorkoutsAsync()
        {
            List<PreDeterminedWorkout> workouts = new List<PreDeterminedWorkout>();
            path = client.BaseAddress + "/PreDetermined/getWorkouts";

            HttpResponseMessage response = await client.GetAsync(path);

            if(response.IsSuccessStatusCode)
            {
                workouts = await response.Content.ReadAsAsync<List<PreDeterminedWorkout>>();
            }
            else
            {
                Console.WriteLine("Error: GetPreDeterminedWorkout response is unsuccesful");
            }

            return workouts;
        }
    }
}