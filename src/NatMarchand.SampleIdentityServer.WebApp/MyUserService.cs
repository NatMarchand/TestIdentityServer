using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer3.Core.Extensions;
using IdentityServer3.Core.Models;
using IdentityServer3.Core.Services;
using NatMarchand.SampleIdentityServer.WebApp.Repositories;

namespace NatMarchand.SampleIdentityServer.WebApp
{
	public class MyUserService : IUserService
	{
		private readonly IUserRepository _userRepository;

		public MyUserService(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public Task PreAuthenticateAsync(PreAuthenticationContext context)
		{
			return Task.FromResult(true);
		}

		public async Task AuthenticateLocalAsync(LocalAuthenticationContext context)
		{
			var profile = await _userRepository.CheckPasswordAsync(context.UserName, context.Password);
			if (profile != null)
			{
				context.AuthenticateResult = new AuthenticateResult(profile.Subject.ToString(), profile.Login, new[]
				{
						new Claim(ClaimTypes.Email, profile.Email),
						new Claim(ClaimTypes.GivenName, profile.FirstName),
						new Claim(ClaimTypes.Surname, profile.LastName)
				});
			}
			else
			{
				context.AuthenticateResult = new AuthenticateResult("Invalid user/password");
			}
		}

		public Task AuthenticateExternalAsync(ExternalAuthenticationContext context)
		{
			return Task.FromResult(true);
		}

		public Task PostAuthenticateAsync(PostAuthenticationContext context)
		{
			return Task.FromResult(true);
		}

		public Task SignOutAsync(SignOutContext context)
		{
			return Task.FromResult(true);
		}

		public async Task GetProfileDataAsync(ProfileDataRequestContext context)
		{
			var profile = await _userRepository.GetUserProfileBySubjectAsync(context.Subject.GetSubjectId());
			var claims = new List<Claim>();
			foreach (var requestedClaimType in context.RequestedClaimTypes)
			{
				switch (requestedClaimType)
				{
					
				}
			}
			context.IssuedClaims = claims;
		}

		public Task IsActiveAsync(IsActiveContext context)
		{
			return Task.FromResult(true);
		}
	}
}
