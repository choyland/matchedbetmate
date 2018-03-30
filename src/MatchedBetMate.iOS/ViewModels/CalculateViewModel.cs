using MatchedBetMate.DTO.Enum;
using MatchedBetMate.iOS.Business.Interfaces.Services;
using MatchedBetMate.iOS.Model.ViewModel;
using MatchedBetMate.iOS.ViewModels.Base;
using MatchedBetMate.iOS.ViewModels.Interfaces;

namespace MatchedBetMate.iOS.ViewModels
{
    public class CalculateViewModel : BaseViewModel, IMatchedBetMateViewModel
    {
        private readonly IBetCalculationService _betCalculationService;

        public CalculateViewModel(IBetCalculationService betCalculationService)
        {
            _betCalculationService = betCalculationService;
        }

        public BetCalculationViewModel CalculateBet(BetType betType, double backStake, double backOdds, double layOdds,
            double layCommission)
        {
            var betCalcViewModel =
                _betCalculationService.CalculateBet(betType, backStake, backOdds, layOdds, layCommission);

            return betCalcViewModel;
        }
    }
}