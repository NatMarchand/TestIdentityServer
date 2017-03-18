using System;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer3.Core.Models;
using IdentityServer3.Core.Services;
using NatMarchand.SampleIdentityServer.WebApp.Repositories;

namespace NatMarchand.SampleIdentityServer.WebApp
{
	public class MyClientStore : IClientStore
	{
		private readonly IClientRepository _repository;

		public MyClientStore(IClientRepository repository)
		{
			_repository = repository;
		}

		public async Task<Client> FindClientByIdAsync(string clientId)
		{
			var client = await _repository.FindClientByIdAsync(clientId);
			var secrets = await _repository.GetSecretsAsync(client.Id);
			var scopes = await _repository.GetScopesAsync(client.Id);
			var redirectUris = await _repository.GetRedirectUrisAsync(client.Id);
			return new Client
			{
				AccessTokenType = AccessTokenType.Jwt,
				AllowedScopes = scopes.Select(s => s.Scope).ToList(),
				ClientId = client.ClientId,
				ClientName = client.ClientName,
				ClientSecrets = secrets.Select(s => new Secret(s.Secret, new DateTimeOffset?())).ToList(),
				Enabled = client.IsEnabled,
				Flow = (Flows)Enum.Parse(typeof(Flows), client.Flow),
				RedirectUris = redirectUris.Select(u => u.RedirectUri).ToList()
			};
		}
	}
}
