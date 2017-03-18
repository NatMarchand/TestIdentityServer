using System;
using System.Threading.Tasks;
using NatMarchand.SampleIdentityServer.WebApp.Domain;

namespace NatMarchand.SampleIdentityServer.WebApp.Repositories
{
	public interface IUserRepository
	{
		Task<UserProfile> CheckPasswordAsync(string login, string password);

		Task<UserProfile> GetUserProfileBySubjectAsync(string subject);
	}
}
