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
    public class ClaimsDal : IClaimsDal
    {
        private readonly DbConnection _connection;

        public ClaimsDal(DbConnection connection)
        {
            _connection = connection;
        }

        public async Task<IReadOnlyList<Claim>> GetClaimsForUserAsync(Guid subjectId)
        {
            return (await SqlMapper.QueryAsync<Claim>(_connection, "GetClaimsForUser", new { SubjectId = subjectId }, commandType: CommandType.StoredProcedure)).ToList();
        }

        public Task<Claim> GetClaimForUserAsync(Guid subjectId, string type)
        {
            return SqlMapper.QuerySingleOrDefaultAsync<Claim>(_connection, "GetClaimForUser", new { SubjectId = subjectId, Type = type }, commandType: CommandType.StoredProcedure);
        }
    }
}