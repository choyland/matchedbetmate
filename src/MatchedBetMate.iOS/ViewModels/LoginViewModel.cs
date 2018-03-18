using System.Threading.Tasks;
using MatchedBetMate.Business.Enum;
using MatchedBetMate.Business.Interfaces.Services;
using MatchedBetMate.iOS.Infrastructure.IoC;
using MatchedBetMate.iOS.ViewModels.Base;
using MatchedBetMate.iOS.ViewModels.Interfaces;

namespace MatchedBetMate.iOS.ViewModels
{
    public class LoginViewModel : BaseViewModel, IMatchedBetMateViewModel
    {
        private readonly IAuthenticationService _authenticationService;

        public LoginViewModel()
        {
            _authenticationService = IoC.Container.Resolve<IAuthenticationService>();
        }

        public async Task<bool> Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return false;
            }

            LoginStatus? loginStatus = null;

            await ExecuteWithNetworkHandling(async () =>
            {
                loginStatus = await _authenticationService.Login(email, password);
            });

            return loginStatus != null && loginStatus == LoginStatus.Success;
        }
    }
}