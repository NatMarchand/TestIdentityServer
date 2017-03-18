using System;

namespace NatMarchand.SampleIdentityServer.WebApp.Domain
{
	public class ClientSecret
	{
		public int Id { get; set; }

		public int ClientId { get; set; }

		public string Secret { get; set; }

		public byte[] Timestamp { get; set; }
	}
}
