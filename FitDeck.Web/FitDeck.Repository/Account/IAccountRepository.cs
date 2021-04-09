using System;
using System.Threading;
using System.Threading.Tasks;
using FitDeck.Models.Account;
using Microsoft.AspNetCore.Identity;

namespace FitDeck.Repository.Account
{
    public interface IAccountRepository
    {
        public Task<IdentityResult> CreateAsync(ApplicationUserIdentity user, CancellationToken cancellationToken);

        public Task<ApplicationUserIdentity> GetByUserIdAsync(int userId, CancellationToken cancellationToken);

        public Task<ApplicationUserIdentity> GetByUserNameAsync(string normalizedUserName, CancellationToken cancellationToken);
    }
}
