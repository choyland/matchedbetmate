using System.Collections.Generic;

namespace MatchedBetMate.Business.Interfaces.Providers
{
    public interface IWebApiConfigurationProvider
    {
        KeyValuePair<string, string> AuthorizationHeader { get;}
    }
}
