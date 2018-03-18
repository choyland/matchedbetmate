using System.Net.Http;
using System.Threading.Tasks;
using MatchedBetMate.Business.Interfaces.Providers;
using MatchedBetMate.iOS.Infrastructure.Reachability.Enum;
using RestSharp.Portable;
using RestSharp.Portable.HttpClient;
using IHttpClient = MatchedBetMate.Business.Interfaces.Clients.IHttpClient;

namespace MatchedBetMate.iOS.Infrastructure.Clients
{
    public class HttpClient : IHttpClient
    {
        private readonly IWebApiConfigurationProvider _webApiConfigurationProvider;
        public HttpClient()
        {
            _webApiConfigurationProvider = IoC.IoC.Container.Resolve<IWebApiConfigurationProvider>();
        }
        public async Task<TResponse> ExecuteGetRequest<TResponse>(string resource, bool isAuthenticated)
        {
            CheckNetwork();

            var request = new RestRequest(resource, Method.GET);

            if (isAuthenticated)
            {
                AddAuthorizationHeader(request);
            }

            using (var client = new RestClient("http://192.10.10.56:60702/"))
            {
                var response = await client.Execute<TResponse>(request).ConfigureAwait(false);
                return response.Data;
            }
        }

        public async Task<TResponse> ExecutePostRequest<TRequest, TResponse>(TRequest requestContract, string resource, bool isAuthenticated)
        {
            //CheckNetwork();

            var request = new RestRequest(resource, Method.POST);

            if (isAuthenticated)
            {
                AddAuthorizationHeader(request);
            }

            request.AddJsonBody(requestContract);

            using (var client = new RestClient("http://192.10.10.56:60702/"))
            {
                var response = await client.Execute<TResponse>(request);
                return response.Data;
            }
        }

        public async Task<TResponse> ExecutePutRequest<TRequest, TResponse>(TRequest requestContract, string resource, bool isAuthenticated)
        {
            CheckNetwork();

            var request = new RestRequest(resource, Method.PUT);

            if (isAuthenticated)
            {
                AddAuthorizationHeader(request);
            }

            request.AddJsonBody(requestContract);

            using (var client = new RestClient("http://192.10.10.56:60702/"))
            {
                var response = await client.Execute<TResponse>(request);
                return response.Data;
            }
        }

        private void AddAuthorizationHeader(RestRequest request)
        {
            var authHeader = _webApiConfigurationProvider.AuthorizationHeader;

            request.AddHeader(authHeader.Key, authHeader.Value);
        }

        private static void CheckNetwork()
        {
            var reachibility = Reachability.Reachability.InternetConnectionStatus();
            if (reachibility == NetworkStatus.NotReachable)
            {
                throw new HttpRequestException("No network");
            }
        }
    }
}