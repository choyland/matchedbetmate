using MatchedBetMate.DTO.Enum;
using MatchedBetMate.iOS.Model.ViewModel;

namespace MatchedBetMate.iOS.Business.Interfaces.Services
{
    public interface IBetCalculationService
    {
        BetCalculationViewModel CalculateBet(BetType betType, double backStake, double backOdds, double layOdds,
            double layCommission);
    }
}
