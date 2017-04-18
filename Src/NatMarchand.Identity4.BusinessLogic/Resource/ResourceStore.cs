using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Stores;

namespace NatMarchand.Identity4.BusinessLogic.Resource
{
    public class ResourceStore : IResourceStore
    {
        public async Task<IEnumerable<IdentityResource>> FindIdentityResourcesByScopeAsync(IEnumerable<string> scopeNames)
        {
            return (await GetAllResources()).IdentityResources.Where(ir => scopeNames.Contains(ir.Name, StringComparer.InvariantCultureIgnoreCase));
        }

        public async Task<IEnumerable<ApiResource>> FindApiResourcesByScopeAsync(IEnumerable<string> scopeNames)
        {
            var all = await GetAllResources();
            return scopeNames.Select(s => all.FindApiResourceByScope(s)).Where(ar => ar != null);
        }

        public async Task<ApiResource> FindApiResourceAsync(string name)
        {
            return (await GetAllResources()).ApiResources.FirstOrDefault(ar => string.Equals(ar.Name, name, StringComparison.InvariantCultureIgnoreCase));
        }

        public Task<Resources> GetAllResources()
        {
            return Task.FromResult(new Resources(
                new IdentityResource[] { new IdentityResources.Email(), new IdentityResources.OpenId(), new IdentityResources.Profile(), },
                new ApiResource[]
                {
                    new ApiResource("test")
                    {
                        Scopes = new List<Scope>(new[] {new Scope("test.read"), new Scope("test.write")})
                    },
                }));
        }
    }
}