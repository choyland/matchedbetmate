using System.Collections.Generic;

namespace MatchedBetMate.iOS.Business.Interfaces.Providers
{
    public interface IWebApiConfigurationProvider
    {
        KeyValuePair<string, string> AuthorizationHeader { get;}
        string BaseUrl { get; }

        string GetBetsResourceUrl { get; }
        string CreateBetResourceUrl { get; }
        string UpdateBetResourceUrl { get; }
        string DeleteBetResourceUlr { get; }
    }
}
