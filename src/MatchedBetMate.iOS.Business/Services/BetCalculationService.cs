using System;
using MatchedBetMate.DTO.Enum;
using MatchedBetMate.iOS.Business.BusinessObjects;
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

            RoundCalculationValuesToTwoDecimalPlaces(calculation);

            var betCalculationViewModel = new BetCalculationViewModel
            {
                BookMakerWinProfit = calculation.BookMakerWinProfit,
                ExchangeWinProfit = calculation.ExchangeWinProfit,
                LayStake = calculation.LayStake,
                Liability = calculation.Liability
            };

            return betCalculationViewModel;
        }

        public void RoundCalculationValuesToTwoDecimalPlaces(BetCalculationModel betCalculationModel)
        {
            betCalculationModel.BookMakerWinProfit = Math.Round(betCalculationModel.BookMakerWinProfit, 2);
            betCalculationModel.ExchangeWinProfit = Math.Round(betCalculationModel.ExchangeWinProfit, 2);
            betCalculationModel.LayStake = Math.Round(betCalculationModel.LayStake, 2);
            betCalculationModel.Liability = Math.Round(betCalculationModel.Liability, 2);
        }
    }
}
