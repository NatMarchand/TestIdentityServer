using System;
using System.Threading.Tasks;
using NatMarchand.Identity4.DataAccess;
using NatMarchand.Identity4.DataAccess.Entities;

namespace NatMarchand.Identity4.BusinessLogic.Identity
{
    public class ExternalIdentityStore : IExternalIdentityStore
    {
        private readonly IUsersDal _usersDal;

        public ExternalIdentityStore(IUsersDal usersDal)
        {
            _usersDal = usersDal;
        }

        public Task<User> GetUserAsync(string provider, string userId)
        {
            return _usersDal.GetUserByExternalIdentityAsync(provider, userId);
        }
    }
}