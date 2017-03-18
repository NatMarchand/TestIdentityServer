using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NatMarchand.SampleIdentityServer.WebApp.Domain;

namespace NatMarchand.SampleIdentityServer.WebApp.Repositories
{
	public interface IClientRepository
	{
		Task<Client> FindClientByIdAsync(string clientId);

		Task<IReadOnlyList<ClientRedirectUri>> GetRedirectUrisAsync(int id);

		Task<IReadOnlyList<ClientScope>> GetScopesAsync(int id);

		Task<IReadOnlyList<ClientSecret>> GetSecretsAsync(int id);
	}
}
