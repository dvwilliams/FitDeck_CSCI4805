using System;
namespace FitDeck_CSCI4805.Account
{
    public class UserSignup
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string FullName { get; set; }

        public int Age { get; set; }

        public int HeightInches { get; set; }

        public float Weight { get; set; }

        public UserSignup(string userName, string password, string email, string fullName, int age, int height, float wieght)
        {
            this.UserName = userName;
            this.Password = password;
            this.Email = email;
            this.FullName = fullName;
            this.Age = age;
            this.HeightInches = height;
            this.Weight = wieght;
        }
    }
}
