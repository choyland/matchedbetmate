using System.Threading.Tasks;
using MatchedBetMate.iOS.Business.Enum;

namespace MatchedBetMate.iOS.Business.Interfaces.Services
{
    public interface IAuthenticationService
    {
        Task<LoginStatus> Login(string userName, string password);
    }
}
