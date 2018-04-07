using MatchedBetMate.DTO.Enum;
using MatchedBetMate.iOS.Model.ViewModel;

namespace MatchedBetMate.iOS.Business.Interfaces.Services
{
    public interface IBetCalculationService
    {
        BetCalculationViewModel CalculateBet(BetType betType, decimal backStake, decimal backOdds, decimal layOdds,
            decimal layCommission);
    }
}
