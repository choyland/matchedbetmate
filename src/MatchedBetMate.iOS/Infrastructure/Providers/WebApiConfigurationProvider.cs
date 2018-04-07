using System.Collections.Generic;
using MatchedBetMate.iOS.Business.Interfaces.Providers;
using MatchedBetMate.iOS.Business.Interfaces.Services;

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

        public string BaseUrl => "http://192.168.0.10/MatchedBetMate.WebApi/api/";

        public string GetBetsResourceUrl => "bets/";
        public string CreateBetResourceUrl => GetBetsResourceUrl;
        public string UpdateBetResourceUrl => GetBetsResourceUrl;
        public string DeleteBetResourceUlr => GetBetsResourceUrl;
    }
}