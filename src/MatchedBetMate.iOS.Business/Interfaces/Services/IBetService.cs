using System.Collections.Generic;
using System.Threading.Tasks;
using MatchedBetMate.iOS.Model.ViewModel;

namespace MatchedBetMate.iOS.Business.Interfaces.Services
{
    public interface IBetService
    {
        Task<List<BetViewModel>> GetBets();
        Task<bool> AddBet(BetViewModel newBet);
    }
}
