using System;

namespace NatMarchand.SampleIdentityServer.WebApp.Domain
{
	public class ClientRedirectUri
	{
		public int Id { get; set; }

		public int ClientId { get; set; }

		public string RedirectUri { get; set; }

		public byte[] Timestamp { get; set; }
	}
}
