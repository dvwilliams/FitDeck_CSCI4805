using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FitDeck.Models.Account
{
    public class ApplicationUserLogin
    {
        [Required(ErrorMessage ="Username is required")]
        [MinLength(5, ErrorMessage ="Must be 5-??? characters")]
        [MaxLength(/*Insert max num*/, ErrorMessage ="Must be 5-??? characters")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(10, ErrorMessage = "Must be 10-??? characters")]
        [MaxLength(/*Insert max num*/, ErrorMessage = "Must be 10-??? characters")]
        public string Password { get; set; }
    }
}
