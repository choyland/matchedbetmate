using System.Net.Http;
using System.Threading.Tasks;
using MatchedBetMate.iOS.Business.Interfaces.Providers;
using MatchedBetMate.iOS.Infrastructure.Reachability.Enum;
using RestSharp.Portable;
using RestSharp.Portable.HttpClient;
using IHttpClient = MatchedBetMate.iOS.Business.Interfaces.Clients.IHttpClient;

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

            using (var client = GetClient())
            {
                var response = await client.Execute<TResponse>(request).ConfigureAwait(false);
                CheckResponse(response);
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

            using (var client = GetClient())
            {
                var response = await client.Execute<TResponse>(request);
                CheckResponse(response);
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

            using (var client = GetClient())
            {
                var response = await client.Execute<TResponse>(request);
                CheckResponse(response);
                return response.Data;
            }
        }

        public async Task ExecuteDeleteRequest(string resource, bool isAuthenticated)
        {
            CheckNetwork();

            var request = new RestRequest(resource, Method.DELETE);

            if (isAuthenticated)
            {
                AddAuthorizationHeader(request);
            }

            using (var client = GetClient())
            {
                var response = await client.Execute(request);
                CheckResponse(response);
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

        private void CheckResponse(IRestResponse response)
        {
            if (!response.IsSuccess)
            {
                throw new HttpRequestException($"There was an error processing the request - status code: {response.StatusCode} - {response.StatusDescription}");
            }
        }

        private RestClient GetClient()
        {
            return new RestClient(_webApiConfigurationProvider.BaseUrl);
        }
    }
}