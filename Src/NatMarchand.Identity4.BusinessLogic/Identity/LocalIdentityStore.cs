using System;
using System.Threading.Tasks;
using NatMarchand.Identity4.DataAccess;
using NatMarchand.Identity4.DataAccess.Entities;

namespace NatMarchand.Identity4.BusinessLogic.Identity
{
    public class LocalIdentityStore : ILocalIdentityStore
    {
        private readonly IUsersDal _usersDal;

        public LocalIdentityStore(IUsersDal usersDal)
        {
            _usersDal = usersDal;
        }

        public Task<User> GetUserAsync(string userName, string password)
        {
            return _usersDal.GetUserByInternalIdentityAsync(userName, password);
        }

        public Task IncrementFailedAttemptCounterAsync(string userName)
        {
            return Task.FromResult(0);
        }

        public Task ResetFailedAttemptCounterAsync(string userName)
        {
            return Task.FromResult(0);
        }
    }
}