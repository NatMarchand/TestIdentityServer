using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using NatMarchand.SampleIdentityServer.WebApp.Domain;

namespace NatMarchand.SampleIdentityServer.WebApp.Repositories
{
	public class ClientRepository : IClientRepository
	{
		private readonly DbConnection _connection;

		public ClientRepository(DbConnection connection)
		{
			_connection = connection;
		}

		public async Task<Client> FindClientByIdAsync(string clientId)
		{
			if (_connection.State != ConnectionState.Open)
				await _connection.OpenAsync();

			var client = await _connection.QuerySingleOrDefaultAsync<Client>(Queries.GetClientByClientId, new { ClientId = clientId });
			return client;
		}

		public async Task<IReadOnlyList<ClientRedirectUri>> GetRedirectUrisAsync(int id)
		{
			if (_connection.State != ConnectionState.Open)
				await _connection.OpenAsync();

			var uris = await _connection.QueryAsync<ClientRedirectUri>(Queries.GetRedirectUrisForClient, new { ClientId = id });
			return uris.ToList();
		}

		public async Task<IReadOnlyList<ClientScope>> GetScopesAsync(int id)
		{
			if (_connection.State != ConnectionState.Open)
				await _connection.OpenAsync();

			var scopes = await _connection.QueryAsync<ClientScope>(Queries.GetScopesForClient, new { ClientId = id });
			return scopes.ToList();
		}

		public async Task<IReadOnlyList<ClientSecret>> GetSecretsAsync(int id)
		{
			if (_connection.State != ConnectionState.Open)
				await _connection.OpenAsync();

			var secrets = await _connection.QueryAsync<ClientSecret>(Queries.GetSecretsForClient, new { ClientId = id });
			return secrets.ToList();
		}
	}
}
