using System;
using System.Collections.Generic;
using System.Text;

namespace FitDeck.Models.Account
{
    public class ApplicationUser
    {
        public int ApplicationUserId { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Fullname { get; set; }

        public float Height { get; set; }

        public int Weight { get; set; }

        //Date of birth
        public DateTime DOB { get; set; }

        public string Token { get; set; }
    }
}
