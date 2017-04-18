using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NatMarchand.Identity4.BusinessLogic;
using NatMarchand.Identity4.BusinessLogic.Client;
using NatMarchand.Identity4.BusinessLogic.Identity;
using NatMarchand.Identity4.BusinessLogic.Resource;
using NatMarchand.Identity4.DataAccess;
using NatMarchand.Identity4.DataAccess.Dal;
using NLog.Web;

namespace NatMarchand.Identity4.IdentityApp
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }
        public IContainer Container { get; private set; }

        public Startup(IHostingEnvironment environment)
        {
            environment.ConfigureNLog("nlog.config");
            var builder = new ConfigurationBuilder()
                .SetBasePath(environment.ContentRootPath)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMemoryCache();

            services.AddMvc()
                .AddControllersAsServices();
            services.AddIdentityServer(options =>
                {
                    options.Events.RaiseSuccessEvents = true;
                    options.Events.RaiseFailureEvents = true;
                    options.Events.RaiseErrorEvents = true;
                })
                .AddClientStoreCache<ClientStore>()
                .AddResourceStoreCache<ResourceStore>()
                .AddResourceOwnerValidator<ResourceOwnerPasswordValidator>()
                .AddProfileService<ProfileService>()
                .AddTemporarySigningCredential();

            services.AddTransient<ClientStore>();
            services.AddTransient<ResourceStore>();
            services.AddTransient<IPersistedGrantStore, PersistedGrantStore>();

            services.AddTransient<ILocalIdentityStore, LocalIdentityStore>();
            services.AddTransient<IExternalIdentityStore, ExternalIdentityStore>();
            
            services.AddTransient<IUsersDal, UsersDal>();
            services.AddTransient<IClaimsDal, ClaimsDal>();
            services.AddTransient<IGrantsDal, GrantsDal>();

            services.AddSingleton<ICache<Client>, DefaultCache<Client>>();
            services.AddSingleton<ICache<IEnumerable<IdentityResource>>, DefaultCache<IEnumerable<IdentityResource>>>();
            services.AddSingleton<ICache<IEnumerable<ApiResource>>, DefaultCache<IEnumerable<ApiResource>>>();
            services.AddSingleton<ICache<ApiResource>, DefaultCache<ApiResource>>();
            services.AddSingleton<ICache<Resources>, DefaultCache<Resources>>();

            services.AddTransient<IEventSink, EventSink>();
            services.AddTransient<IAuthenticationLogDal, AuthenticationLogDal>();

            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.Register(ctx => new SqlConnection(@"Data Source=(localdb)\Tests;Initial Catalog=Identity4;Integrated Security=True")).As<DbConnection>().InstancePerLifetimeScope();
            Container = builder.Build();
            return new AutofacServiceProvider(Container);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            loggerFactory.AddNLog();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<StackifyMiddleware.RequestTracerMiddleware>();
            app.AddNLogWeb();
            app.UseIdentityServer();
            app.UseOpenIdConnectAuthentication(new OpenIdConnectOptions
            {
                SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme,
                SignOutScheme = IdentityServerConstants.SignoutScheme,
                AuthenticationScheme = "MicrosoftAccount",
                DisplayName = "Microsoft Account",
                Authority = "https://login.microsoftonline.com/common/v2.0",
                ClientId = "585e684a-1bc9-4bc1-8928-0f2f4f03fe15",
                Scope = { "email" },
                TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerValidator = (issuer, token, parameters) =>
                    {
                        if (issuer.StartsWith("https://login.microsoftonline.com/"))
                            return issuer;
                        return null;
                    },
                    NameClaimType = "name",
                    RoleClaimType = "role"
                }
            });
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
