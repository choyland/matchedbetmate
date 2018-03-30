using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MatchedBetMate.DTO.Enum;
using MatchedBetMate.iOS.Business.Interfaces.Factory;
using MatchedBetMate.iOS.Business.Interfaces.Strategy;

namespace MatchedBetMate.iOS.Business.Factory
{
    public class BetCalculatorStrategyFactory : IBetCalcaulatorStrategyFactory
    {
        private readonly IEnumerable<IBetCalculatorStrategy> _availableBetCalculatorStrategies;

        public BetCalculatorStrategyFactory(IEnumerable<IBetCalculatorStrategy> availableBetCalculatorStrategies)
        {
            _availableBetCalculatorStrategies = availableBetCalculatorStrategies;
        }

        public IBetCalculatorStrategy Create(BetType betType)
        {
            var availableStrategy = _availableBetCalculatorStrategies?.FirstOrDefault(x => x.BetType == betType);

            if (availableStrategy == null)
            {
                throw new InvalidOperationException($"not strategy available for Bet Type: {betType}");
            }

            return availableStrategy;
        }
    }
}
