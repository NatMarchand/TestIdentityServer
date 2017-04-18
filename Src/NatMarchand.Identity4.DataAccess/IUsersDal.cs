using System;
using System.Threading.Tasks;
using NatMarchand.Identity4.DataAccess.Entities;

namespace NatMarchand.Identity4.DataAccess
{
    public interface IUsersDal
    {
        Task<User> GetUserByInternalIdentityAsync(string username, string password);
        Task<User> GetUserByExternalIdentityAsync(string provider, string userId);
        Task<bool> GetIsUserActiveAsync(Guid subjectId);
    }
}