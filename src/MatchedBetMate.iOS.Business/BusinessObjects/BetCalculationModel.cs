using System;
using System.Collections.Generic;
using System.Text;

namespace MatchedBetMate.iOS.Business.BusinessObjects
{
    public class BetCalculationModel
    {
        public decimal LayStake { get; set; }
        public decimal Liability { get; set; }
        public decimal BookMakerWinProfit { get; set; }
        public decimal ExchangeWinProfit { get; set; }
    }
}
