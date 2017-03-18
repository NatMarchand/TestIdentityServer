using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityServer3.Core.Models;
using IdentityServer3.Core.Services;

namespace NatMarchand.SampleIdentityServer.WebApp
{
	public class MyScopeStore : IScopeStore
	{
		public async Task<IEnumerable<Scope>> FindScopesAsync(IEnumerable<string> scopeNames)
		{
			return new List<Scope>(StandardScopes.All);
		}

		public async Task<IEnumerable<Scope>> GetScopesAsync(bool publicOnly = true)
		{
			return new List<Scope>(StandardScopes.All);
		}
	}
}
