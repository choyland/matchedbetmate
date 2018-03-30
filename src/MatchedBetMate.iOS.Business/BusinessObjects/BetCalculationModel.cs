using System;
using System.Collections.Generic;
using System.Text;

namespace MatchedBetMate.iOS.Business.BusinessObjects
{
    public class BetCalculationModel
    {
        public double LayStake { get; set; }
        public double Liability { get; set; }
        public double BookMakerWinProfit { get; set; }
        public double ExchangeWinProfit { get; set; }
    }
}
