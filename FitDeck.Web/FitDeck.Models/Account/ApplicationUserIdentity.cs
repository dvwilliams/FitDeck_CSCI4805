using System;
using System.Collections.Generic;
using System.Text;

namespace FitDeck.Models.Account
{
    public class ApplicationUserIdentity
    {
        public int ApplicationUserId { get; set; }

        public string UserName { get; set; }

        public string NormalizedUserName { get; set; }

        public string Email { get; set; }

        public string NormalizedEmail { get; set; }

        public string PasswordHash { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
