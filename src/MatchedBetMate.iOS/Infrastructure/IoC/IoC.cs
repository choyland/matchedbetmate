using MatchedBetMate.iOS.Business.Interfaces.Clients;
using MatchedBetMate.iOS.Business.Interfaces.Providers;
using MatchedBetMate.iOS.Business.Interfaces.Services;
using MatchedBetMate.iOS.Business.Services;
using MatchedBetMate.iOS.Infrastructure.Clients;
using MatchedBetMate.iOS.Infrastructure.Providers;
using MatchedBetMate.iOS.Infrastructure.SecureStorage;
using TinyIoC;

namespace MatchedBetMate.iOS.Infrastructure.IoC
{
    public static class IoC
    {
        public static TinyIoCContainer Container { get; private set; }
        public static void Initialise()
        {
            Container = TinyIoCContainer.Current;
            var container = Container;

            container.Register<IHttpClient, HttpClient>();
            container.Register<IWebApiConfigurationProvider, WebApiConfigurationProvider>();
            container.Register<ICredentialsService, CredentialsService>();
            container.Register<IAuthenticationService, AuthenticationService>();
        }
    }
}