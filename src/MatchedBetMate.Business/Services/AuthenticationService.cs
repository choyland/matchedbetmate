using System.Threading.Tasks;
using MatchedBetMate.Business.Enum;
using MatchedBetMate.Business.Interfaces.Clients;
using MatchedBetMate.Business.Interfaces.Services;

namespace MatchedBetMate.Business.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IHttpClient _httpClient;
        private readonly ICredentialsService _credentialsService;
        public AuthenticationService(IHttpClient httpClient, ICredentialsService credentialsService)
        {
            _httpClient = httpClient;
            _credentialsService = credentialsService;
        }
        public async Task<LoginStatus> Login(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                return LoginStatus.Failure;
            }

            var registerDto = new RegisterDto {Email = userName, Password = password};

            //var response = await _httpClient.ExecutePostRequest<RegisterDto, object>(registerDto, "account/login", false);
            var response = "teststringauthtoken";
            if (response == null) return LoginStatus.Failure;

            _credentialsService.AuthToken = response.ToString();

            return LoginStatus.Success;
        }
    }
}
