using System;
namespace FitDeck_CSCI4805.Account
{
    public class UserAccount
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string FullName { get; set; }

        public int Age { get; set; }

        public int HeightInches { get; set; }

        public float Weight { get; set; }

        public string Token { get; set; }

        //returns hieght in X'X" format
        public string GetHeightString()
        {

            return ((this.HeightInches / 12).ToString() + "\'" + (this.HeightInches % 12).ToString() + "\"");
        }
    }
}
