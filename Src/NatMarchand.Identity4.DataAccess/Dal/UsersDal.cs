using System;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using Dapper;
using NatMarchand.Identity4.DataAccess.Entities;

namespace NatMarchand.Identity4.DataAccess.Dal
{
    public class UsersDal : IUsersDal
    {
        private readonly DbConnection _connection;

        public UsersDal(DbConnection connection)
        {
            _connection = connection;
        }

        public Task<User> GetUserByInternalIdentityAsync(string username, string password)
        {
            return _connection.QuerySingleOrDefaultAsync<User>("GetUserByInternalIdentity", new { UserName = username, Password = password }, commandType: CommandType.StoredProcedure);
        }

        public Task<User> GetUserByExternalIdentityAsync(string provider, string userId)
        {
            return _connection.QuerySingleOrDefaultAsync<User>("GetUserByExternalIdentity", new { Provider = provider, UserId = userId }, commandType: CommandType.StoredProcedure);
        }

        public Task<bool> GetIsUserActiveAsync(Guid subjectId)
        {
            return _connection.ExecuteScalarAsync<bool>("GetIsUserActive", new { SubjectId = subjectId }, commandType: CommandType.StoredProcedure);
        }
    }
}
