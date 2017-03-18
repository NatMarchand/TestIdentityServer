using System;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Services;
using NatMarchand.SampleIdentityServer.WebApp.Repositories;
using Owin;

namespace NatMarchand.SampleIdentityServer.WebApp
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			var serverServiceFactory = new IdentityServerServiceFactory
			{
				UserService = new Registration<IUserService, MyUserService>(),
				ClientStore = new Registration<IClientStore, MyClientStore>(),
				ScopeStore = new Registration<IScopeStore, MyScopeStore>()
			};
			serverServiceFactory.Register(new Registration<IClientRepository, ClientRepository>());
			serverServiceFactory.Register(new Registration<IUserRepository, UserRepository>());
			serverServiceFactory.Register(new Registration<DbConnection>(r => new SqlConnection(ConfigurationManager.ConnectionStrings["IdentityConnectionString"].ConnectionString) as DbConnection));
			var identityServerOptions = new IdentityServerOptions
			{
				Factory = serverServiceFactory,
				RequireSsl = false,
				SiteName = "Identity Server sample",
				SigningCertificate = new X509Certificate2(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin\\idsrv3test.pfx"), "idsrv3test", X509KeyStorageFlags.UserKeySet | X509KeyStorageFlags.Exportable | X509KeyStorageFlags.PersistKeySet)
			};
			var options = identityServerOptions;
			app.UseIdentityServer(options);
		}
	}
}
