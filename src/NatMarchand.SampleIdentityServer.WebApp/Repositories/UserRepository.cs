using System;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using Dapper;
using NatMarchand.SampleIdentityServer.WebApp.Domain;

namespace NatMarchand.SampleIdentityServer.WebApp.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly DbConnection _connection;

		public UserRepository(DbConnection connection)
		{
			_connection = connection;
		}

		public async Task<UserProfile> CheckPasswordAsync(string login, string password)
		{
			if (_connection.State != ConnectionState.Open)
				await _connection.OpenAsync();

			return await _connection.QueryFirstOrDefaultAsync<UserProfile>(Queries.CheckUserPassword, new { Login = login.ToLower(), Password = password });
		}

		public async Task<UserProfile> GetUserProfileBySubjectAsync(string subject)
		{
			if (_connection.State != ConnectionState.Open)
				await _connection.OpenAsync();

			return await _connection.QueryFirstAsync<UserProfile>(Queries.GetInternalUserProfileBySubject, new { Subject = subject });
		}
	}
}
