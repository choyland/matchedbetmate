using MatchedBetMate.DTO.Enum;
using MatchedBetMate.iOS.Business.Interfaces.Strategy;

namespace MatchedBetMate.iOS.Business.Interfaces.Factory
{
    public interface IBetCalcaulatorStrategyFactory
    {
        IBetCalculatorStrategy Create(BetType betType);
    }
}
