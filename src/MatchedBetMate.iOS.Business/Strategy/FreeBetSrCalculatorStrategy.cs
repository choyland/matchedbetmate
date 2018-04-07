using MatchedBetMate.DTO.Enum;
using MatchedBetMate.iOS.Business.BusinessObjects;
using MatchedBetMate.iOS.Business.Interfaces.Strategy;

namespace MatchedBetMate.iOS.Business.Strategy
{
    public class FreeBetSrCalculatorStrategy : IBetCalculatorStrategy
    {
        public BetType BetType => BetType.FreeBetSr;

        public BetCalculationModel Calculate(decimal backStake, decimal backOdds, decimal layOdds, decimal layCommission)
        {
            var optimalLayStake = backOdds / (layOdds - layCommission) * backStake;

            var bookmakerWinProfit = backOdds * backStake - (layOdds - 1) * optimalLayStake;

            var exchangeWinProfit = optimalLayStake * (1 - layCommission);

            var liability = optimalLayStake * (layOdds - 1);

            return new BetCalculationModel
            {
                LayStake = optimalLayStake,
                BookMakerWinProfit = bookmakerWinProfit,
                ExchangeWinProfit = exchangeWinProfit,
                Liability = liability
            };
        }
    }
}