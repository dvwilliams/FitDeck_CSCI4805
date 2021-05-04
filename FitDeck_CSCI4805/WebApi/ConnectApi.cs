using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FitDeck_CSCI4805.Account;
using Newtonsoft.Json;

namespace FitDeck_CSCI4805.WebApi
{
    public class ConnectApi
    {
        static HttpClient client = new HttpClient();
        static string path = "";

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

        //public async Task<>
    }
}