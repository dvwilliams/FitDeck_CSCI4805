using System;
namespace FitDeck_CSCI4805
{
    public class User
    {
        private string username;
        public string Username { get { return username; } }

        private string emailAddress;
        public string EmailAddress { get { return emailAddress; } }

        private string password;
        public string Password { set { password = value; } get { return password; } }

        private string name;
        public string Name { get { return name; } }

        private DateTime dOB;
        public DateTime DOB { get { return dOB; } }

        private int weight;
        public int Weight { get { return weight; } }

        private float height;
        public float Height { get { return height; } }

        public User(string username, string emailAddress)
        {
            this.username = username;
            this.emailAddress = emailAddress;
        }
        public User(string username, string emailAddress, string name, DateTime dOB, int weight, float height)
        {
            this.username = username;
            this.emailAddress = emailAddress;
            this.name = name;
            this.dOB = dOB;
            this.weight = weight;
            this.height = height;

        }

        public int getAge()
        {
            int age = 0;
            var today = DateTime.Today;
            int thisYear = today.Year;
            int dOBYear = this.dOB.Year;

            age = thisYear - dOBYear;
            return age;
        }

        public string heightString()
        {
            string h = "";

            int feet = (int)this.height;
            float inches = (this.height - feet);
            inches = inches * 100;
            inches = (int)inches;
            h = feet + "' " + inches + "''";
            return h;
        }

        
    }
}
