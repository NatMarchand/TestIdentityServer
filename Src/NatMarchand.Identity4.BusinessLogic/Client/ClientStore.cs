using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Stores;

namespace NatMarchand.Identity4.BusinessLogic.Client
{
    public class ClientStore : IClientStore
    {
        private readonly IReadOnlyList<IdentityServer4.Models.Client> _clients;

        public ClientStore()
        {
            _clients = new List<IdentityServer4.Models.Client>
            {
                new IdentityServer4.Models.Client
                {
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = {"test.read"},
                    ClientId = "batchApp",
                    ClientSecrets = new[] {new Secret("secret".Sha256())}
                },
                new IdentityServer4.Models.Client
                {
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowedScopes =
                    {
                        IdentityServer4.IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServer4.IdentityServerConstants.StandardScopes.Profile,
                        IdentityServer4.IdentityServerConstants.StandardScopes.Email,
                        "test.read"
                    },
                    ClientId = "legacyApp",
                    ClientSecrets = new[] {new Secret("secret".Sha256())}
                },
                new IdentityServer4.Models.Client
                {
                    AllowAccessTokensViaBrowser = true,
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowedScopes =
                    {
                        IdentityServer4.IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServer4.IdentityServerConstants.StandardScopes.Profile,
                        IdentityServer4.IdentityServerConstants.StandardScopes.Email,
                        "test.read"
                    },
                    AlwaysIncludeUserClaimsInIdToken = true,
                    ClientId = "jsApp",
                    ClientSecrets = new[] {new Secret("secret".Sha256())},
                    RedirectUris = new[] {"http://localhost:1234"}
                },
                new IdentityServer4.Models.Client
                {
                    AllowedGrantTypes = GrantTypes.Code,
                    AllowedScopes =
                    {
                        IdentityServer4.IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServer4.IdentityServerConstants.StandardScopes.Profile,
                        IdentityServer4.IdentityServerConstants.StandardScopes.Email,
                        "test.read"
                    },
                    AlwaysIncludeUserClaimsInIdToken = true,
                    ClientId = "mvcApp",
                    ClientSecrets = new[] {new Secret("secret".Sha256())},
                    RedirectUris = new[] {"http://localhost:1234"}
                }
            };
        }

        public Task<IdentityServer4.Models.Client> FindClientByIdAsync(string clientId)
        {
            return Task.FromResult(_clients.FirstOrDefault(c => string.Equals(c.ClientId, clientId, StringComparison.InvariantCultureIgnoreCase)));
        }
    }
}