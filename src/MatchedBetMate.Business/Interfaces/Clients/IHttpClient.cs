using System.Threading.Tasks;

namespace MatchedBetMate.Business.Interfaces.Clients
{
    public interface IHttpClient
    {
        Task<TResponse> ExecuteGetRequest<TResponse>(string resource, bool isAuthenticated);
        Task<TResponse> ExecutePostRequest<TRequest, TResponse>(TRequest requestContract, string resource, bool isAuthenticated);
        Task<TResponse> ExecutePutRequest<TRequest, TResponse>(TRequest requestContract, string resource, bool isAuthenticated);
    }
}
