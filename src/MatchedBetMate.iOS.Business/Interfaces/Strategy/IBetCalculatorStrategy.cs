using MatchedBetMate.DTO.Enum;
using MatchedBetMate.iOS.Business.BusinessObjects;

namespace MatchedBetMate.iOS.Business.Interfaces.Strategy
{
    public interface IBetCalculatorStrategy
    {
        BetType BetType { get; }
        BetCalculationModel Calculate(double backStake, double backOdds, double layOdds, double layCommission);
    }
}
