using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FitDeck.Models.Account
{
    public class ApplicationUserLogin
    {
        [Required(ErrorMessage ="Username is required")]
        [MinLength(5, ErrorMessage ="Must be 5-50 characters")]
        [MaxLength(50, ErrorMessage ="Must be 5-50 characters")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(5, ErrorMessage = "Must be 5-60 characters")]
        [MaxLength(60, ErrorMessage = "Must be 5-60 characters")]
        public string Password { get; set; }
    }
}
