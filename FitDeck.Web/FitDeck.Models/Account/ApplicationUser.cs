﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FitDeck.Models.Account
{
    public class ApplicationUser
    {
        public int ApplicationUserId { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Height { get; set; }

        public int Weight { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Token { get; set; }
    }
}
