using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FitDeck.Models.Account
{
    public class ApplicationUserCreate : ApplicationUserLogin
    {
        [Required(ErrorMessage = "Username is required")]
        [MaxLength(50, ErrorMessage = "Must be 5-50 characters")]
        [EmailAddress(ErrorMessage ="Invalid Email format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "FirstName is required")]
        [MinLength(5, ErrorMessage = "Must be 5-50 characters")]
        [MaxLength(50, ErrorMessage = "Must be 5-50 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        [MinLength(3, ErrorMessage = "Must be 3-50 characters")]
        [MaxLength(50, ErrorMessage = "Must be 3-50 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Height is required")]
        public float Height { get; set; }

        [Required(ErrorMessage = "Weight is required")]
        public int Weight { get; set; }

        [Required(ErrorMessage ="Date of Birth is required")]
        public DateTime DOB { get; set; }
    }
}
