using System;
namespace FitDeck_CSCI4805
{
    public class User
    {
        private string username;
        private string emailAddress;
        private string password;
        public string Password { set { password = value; } get { return password; } }

        private string name;
        private DateTime dOB;
        private int weight;
        private float height;

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

        //created to test app
        public override string ToString()
        {
            return "Name: " + this.name +
                " Birthday: " + this.dOB + "\nWeight: " + this.weight + " Height: " + this.height;
        }
    }
}
