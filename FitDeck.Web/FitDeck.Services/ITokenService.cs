using System;
using FitDeck.Models.Account;

namespace FitDeck.Services
{
    public interface ITokenService
    {
        public string CreatToken(ApplicationUserIdentity user);
    }
}
