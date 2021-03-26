using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FitDeck.Models.Account;
using System.Threading;

namespace FitDeck.Repository.Account
{
    interface IAccountRepository
    {
        public Task<IdentityResult> CreateAsync(ApplicationUserIdentity user, CancellationToken cancellationToken);

        public Task<ApplicationUserIdentity> GetUserByUserName(string normalizedUserName, CancellationToken cancellationToken);

        public Task<ApplicationUserIdentity> GetUserByUserId(int UserId, CancellationToken cancellationToken);
    }
}


// public Task<ApplicationUserIdentity> GetUserByUsernameAsync(string nomalizedUsername, CancellationToken cancellationToken);