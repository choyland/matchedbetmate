using System.Threading.Tasks;
using MatchedBetMate.Business.Enum;

namespace MatchedBetMate.Business.Interfaces.Services
{
    public interface IAuthenticationService
    {
        Task<LoginStatus> Login(string userName, string password);
    }
}
