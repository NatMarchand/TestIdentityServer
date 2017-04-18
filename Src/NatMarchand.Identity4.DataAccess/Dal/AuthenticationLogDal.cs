using System;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using Dapper;
using NatMarchand.Identity4.BusinessLogic;

namespace NatMarchand.Identity4.DataAccess.Dal
{
    public class AuthenticationLogDal : IAuthenticationLogDal
    {
        private readonly DbConnection _connection;

        public AuthenticationLogDal(DbConnection dbConnection)
        {
            _connection = dbConnection;
        }

        public Task LogAsync(TokenIssuedLog tokenIssuedLog)
        {
            return _connection.ExecuteAsync("InsertTokenIssuedLog", tokenIssuedLog, commandType: CommandType.StoredProcedure);
        }

        public Task LogAsync(UserLoginLog userLoginLog)
        {
            if (userLoginLog.Provider == null)
            {
                return _connection.ExecuteAsync("InsertInternalIdentityLoginLog", new { userLoginLog.SubjectId, userLoginLog.IpAddress, userLoginLog.Timestamp }, commandType: CommandType.StoredProcedure);
            }
            else
            {
                return _connection.ExecuteAsync("InsertExternalIdentityLoginLog", new { userLoginLog.SubjectId, userLoginLog.Provider, userLoginLog.IpAddress, userLoginLog.Timestamp }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}