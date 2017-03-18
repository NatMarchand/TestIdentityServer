using System;

namespace NatMarchand.SampleIdentityServer.WebApp.Domain
{
	public class UserProfile
	{
		public Guid Subject { get; set; }

		public string Login { get; set; }

		public string Email { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }
	}
}
