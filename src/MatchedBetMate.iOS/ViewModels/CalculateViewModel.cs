using System;
using System.Threading.Tasks;
using MatchedBetMate.DTO.Enum;
using MatchedBetMate.iOS.Business.Interfaces.Services;
using MatchedBetMate.iOS.Infrastructure.IoC;
using MatchedBetMate.iOS.Model.ViewModel;
using MatchedBetMate.iOS.ViewModels.Base;
using MatchedBetMate.iOS.ViewModels.Interfaces;

namespace MatchedBetMate.iOS.ViewModels
{
    public class CalculateViewModel : BaseViewModel, IMatchedBetMateViewModel
    {
        private readonly IBetCalculationService _betCalculationService;
        private readonly IBetService _betService;

        public CalculateViewModel()
        {
            _betCalculationService = IoC.Container.Resolve<IBetCalculationService>();;
            _betService = IoC.Container.Resolve<IBetService>();
        }

        public BetCalculationViewModel CalculateBet(BetType betType, double backStake, double backOdds, double layOdds,
            double layCommission)
        {
            var betCalcViewModel =
                _betCalculationService.CalculateBet(betType, backStake, backOdds, layOdds, layCommission);

            return betCalcViewModel;
        }

        public async Task<bool> AddBet(BetViewModel betToAdd)
        {
            if (betToAdd == null) return false;

            var success = await _betService.AddBet(betToAdd);

            return success;
        }

        public async Task<bool> UpdateBet(BetViewModel betToUpdate)
        {
            if (betToUpdate == null) return false;

            return await GenericUpdateBet(betToUpdate);
        }

        public async Task<bool> CompleteBet(BetViewModel betToComplete)
        {
            if (betToComplete.Profit == null) return false;

            return await GenericUpdateBet(betToComplete);
        }

        private async Task<bool> GenericUpdateBet(BetViewModel betToComplete)
        {
            var success = await _betService.UpdateBet(betToComplete);

            return success;
        }
    }
}