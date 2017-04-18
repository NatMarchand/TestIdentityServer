using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Stores;
using NatMarchand.Identity4.DataAccess;

namespace NatMarchand.Identity4.BusinessLogic
{
    public class PersistedGrantStore : IPersistedGrantStore
    {
        private readonly IGrantsDal _grantsDal;

        public PersistedGrantStore(IGrantsDal grantsDal)
        {
            _grantsDal = grantsDal;
        }

        public Task StoreAsync(PersistedGrant grant)
        {
            return _grantsDal.UpsertAsync(grant.Map());
        }

        public async Task<PersistedGrant> GetAsync(string key)
        {
            return (await _grantsDal.GetAsync(key)).Map();
        }

        public async Task<IEnumerable<PersistedGrant>> GetAllAsync(string subjectId)
        {
            return (await _grantsDal.GetAllAsync(Guid.Parse(subjectId))).Select(g => g.Map());
        }

        public Task RemoveAsync(string key)
        {
            return _grantsDal.RemoveAsync(key);
        }

        public Task RemoveAllAsync(string subjectId, string clientId)
        {
            return _grantsDal.RemoveAllAsync(Guid.Parse(subjectId), clientId);
        }

        public Task RemoveAllAsync(string subjectId, string clientId, string type)
        {
            return _grantsDal.RemoveAllAsync(Guid.Parse(subjectId), clientId, type);
        }
    }
}