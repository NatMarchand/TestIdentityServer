using System;
using System.Threading.Tasks;
using NatMarchand.Identity4.DataAccess.Entities;

namespace NatMarchand.Identity4.BusinessLogic.Identity
{
    public interface IExternalIdentityStore
    {
        Task<User> GetUserAsync(string provider, string userId);
    }
}