using System;

namespace NatMarchand.SampleIdentityServer.WebApp.Domain
{
	public class ClientScope
	{
		public int Id { get; set; }

		public int ClientId { get; set; }

		public string Scope { get; set; }

		public byte[] Timestamp { get; set; }
	}
}
