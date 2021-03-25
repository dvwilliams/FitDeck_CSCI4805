using System;
using System.Collections.Generic;
using System.Text;

namespace FitDeck.Models.Account
{
    public class ApplicationUserCreate : ApplicationUserLogin
    {
        [MinLength()]
        public string Fullname { get; set; }
    }
}
