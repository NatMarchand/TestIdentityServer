using System;
using System.IdentityModel.Claims;
using System.IdentityModel.Tokens;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Jwt;
using Owin;

[assembly: OwinStartup(typeof(NatMarchand.SampleIdentityServer.Client.WebApi.Startup))]

namespace NatMarchand.SampleIdentityServer.Client.WebApi
{
	public class Startup
	{
		private readonly HttpConfiguration _httpConfiguration;

		public Startup()
		{
			_httpConfiguration = new HttpConfiguration();
			_httpConfiguration.MapHttpAttributeRoutes();
			_httpConfiguration.EnsureInitialized();
		}

		public void Configuration(IAppBuilder app)
		{
			var cert = new X509Certificate2(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin\\idsrv3test.pfx"), "idsrv3test", X509KeyStorageFlags.UserKeySet | X509KeyStorageFlags.Exportable | X509KeyStorageFlags.PersistKeySet);
			app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions
			{
				AuthenticationMode = AuthenticationMode.Active,
				AuthenticationType = "jwt",
				TokenValidationParameters = new TokenValidationParameters
				{
					IssuerSigningKeys = new []{new X509AsymmetricSecurityKey(cert) },
					ValidIssuers = new[] { "http://localhost:11240" },
					ValidAudiences = new[] { "abcd" },
					NameClaimType = ClaimTypes.NameIdentifier
				}
			});
			app.UseWebApi(_httpConfiguration);
		}
	}

	[Authorize]
	[RoutePrefix("values")]
	public class ValuesController : ApiController
	{
		[HttpGet]
		[Route]
		public IHttpActionResult Get()
		{
			return Ok($"Hello {User.Identity.Name} {User.Identity.IsAuthenticated}");
		}
	}
}
