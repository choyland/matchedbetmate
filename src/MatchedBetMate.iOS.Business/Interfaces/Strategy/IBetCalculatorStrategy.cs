using MatchedBetMate.DTO.Enum;
using MatchedBetMate.iOS.Business.BusinessObjects;

namespace MatchedBetMate.iOS.Business.Interfaces.Strategy
{
    public interface IBetCalculatorStrategy
    {
        BetType BetType { get; }
        BetCalculationModel Calculate(decimal backStake, decimal backOdds, decimal layOdds, decimal layCommission);
    }
}
