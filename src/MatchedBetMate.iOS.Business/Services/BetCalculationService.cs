using MatchedBetMate.DTO.Enum;
using MatchedBetMate.iOS.Business.Interfaces.Factory;
using MatchedBetMate.iOS.Business.Interfaces.Services;
using MatchedBetMate.iOS.Model.ViewModel;

namespace MatchedBetMate.iOS.Business.Services
{
    public class BetCalculationService : IBetCalculationService
    {
        private readonly IBetCalcaulatorStrategyFactory _betCalcaulatorStrategyFactory;

        public BetCalculationService(IBetCalcaulatorStrategyFactory betCalcaulatorStrategyFactory)
        {
            _betCalcaulatorStrategyFactory = betCalcaulatorStrategyFactory;
        }

        public BetCalculationViewModel CalculateBet(BetType betType, double backStake, double backOdds, double layOdds,
            double layCommission)
        {
            var decimalLayCommission = layCommission / 100;

            var betCalculationStrategy = _betCalcaulatorStrategyFactory.Create(betType);

            var calculation = betCalculationStrategy.Calculate(backStake, backOdds, layOdds, decimalLayCommission);

            var betCalculationViewModel = new BetCalculationViewModel
            {
                BookMakerWinProfit = calculation.BookMakerWinProfit,
                ExchangeWinProfit = calculation.ExchangeWinProfit,
                LayStake = calculation.LayStake,
                Liability = calculation.Liability
            };

            return betCalculationViewModel;
        }
    }
}
