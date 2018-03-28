using System.Collections.Generic;

namespace MatchedBetMate.iOS.Business.Interfaces.Providers
{
    public interface IWebApiConfigurationProvider
    {
        KeyValuePair<string, string> AuthorizationHeader { get;}

        string GetBetsResource { get; }
        string CreateBetResource { get; }
    }
}
