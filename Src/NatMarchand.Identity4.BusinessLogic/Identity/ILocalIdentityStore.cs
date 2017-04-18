using System;
using System.Threading.Tasks;
using NatMarchand.Identity4.DataAccess.Entities;

namespace NatMarchand.Identity4.BusinessLogic.Identity
{
    public interface ILocalIdentityStore
    {
        Task<User> GetUserAsync(string userName, string password);
        Task IncrementFailedAttemptCounterAsync(string userName);
        Task ResetFailedAttemptCounterAsync(string userName);
    }
}