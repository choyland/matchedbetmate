using System.Collections.Generic;
using MatchedBetMate.Business.Interfaces.Providers;
using MatchedBetMate.Business.Interfaces.Services;

namespace MatchedBetMate.iOS.Infrastructure.Providers
{
    public class WebApiConfigurationProvider : IWebApiConfigurationProvider
    {
        private readonly ICredentialsService _credentialsService;

        public WebApiConfigurationProvider(ICredentialsService credentialsService)
        {
            _credentialsService = credentialsService;
        }

        public KeyValuePair<string, string> AuthorizationHeader
        {
            get
            {
                var token = _credentialsService.AuthToken;
                return new KeyValuePair<string, string>("Authorization", $"Bearer {token}");
            }
        }
    }
}