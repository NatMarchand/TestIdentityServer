using System;

namespace NatMarchand.SampleIdentityServer.WebApp.Domain
{
	public class Client
	{
		public int Id { get; set; }

		public string ClientId { get; set; }

		public string ClientName { get; set; }

		public bool IsEnabled { get; set; }

		public string Flow { get; set; }

		public byte[] Timestamp { get; set; }
	}
}
