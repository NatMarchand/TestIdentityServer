using Microsoft.Owin;
using System.Reflection;
using System.Runtime.InteropServices;
using NatMarchand.SampleIdentityServer.WebApp;

[assembly: AssemblyTitle("NatMarchand.SampleIdentityServer.WebApp")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("NatMarchand.SampleIdentityServer")]
[assembly: AssemblyCopyright("Copyright NatMarchand © 2017")]
[assembly: AssemblyTrademark("")]
[assembly: ComVisible(false)]
[assembly: Guid("08efe360-185b-4b99-ac15-c9c662144dd0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: OwinStartup(typeof(Startup))]
