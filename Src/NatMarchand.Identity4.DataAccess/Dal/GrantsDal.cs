using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using NatMarchand.Identity4.DataAccess.Entities;

namespace NatMarchand.Identity4.DataAccess.Dal
{
    public class GrantsDal : IGrantsDal
    {
        private readonly DbConnection _connection;

        public GrantsDal(DbConnection connection)
        {
            _connection = connection;
        }

        public Task UpsertAsync(Grant grant)
        {
            return _connection.ExecuteAsync("UpsertGrant", grant, commandType: CommandType.StoredProcedure);
        }

        public Task<Grant> GetAsync(string key)
        {
            return _connection.QuerySingleOrDefaultAsync<Grant>("GetGrantByKey", new { Key = key }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IReadOnlyList<Grant>> GetAllAsync(Guid subjectId)
        {
            return (await _connection.QueryAsync<Grant>("GetGrantsByUser", new { SubjectId = subjectId }, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
        }

        public Task RemoveAsync(string key)
        {
            return _connection.ExecuteAsync("DeleteGrant", new { Key = key }, commandType: CommandType.StoredProcedure);
        }

        public Task RemoveAllAsync(Guid subjectId, string clientId, string type = null)
        {
            var p = new DynamicParameters(new { SubjectId = subjectId, ClientId = clientId });
            if (type != null)
                p.Add("Type", type);
            return _connection.ExecuteAsync("DeleteGrants", p, commandType: CommandType.StoredProcedure);
        }
    }
}
