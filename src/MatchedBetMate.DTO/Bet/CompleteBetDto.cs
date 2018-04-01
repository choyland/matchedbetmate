using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using MatchedBetMate.DTO.Enum;

namespace MatchedBetMate.DTO.Bet
{
    public class CompleteBetDto
    {
        [Required]
        public string Description { get; set; }

        [Required]
        [EnumDataType(typeof(BetType))]
        public BetType BetType { get; set; }

        [Required]
        [EnumDataType(typeof(Sport))]
        public Sport Sport { get; set; }
        [Required]
        public double Profit { get; set; }
        [Required]
        public double BackStake { get; set; }
        [Required]
        public double BackOdds { get; set; }
        [Required]
        public double BackCommission { get; set; }
        [Required]
        public double LayOdds { get; set; }
        [Required]
        public double LayCommission { get; set; }
        public double LayStake { get; set; }
        public double Liability { get; set; }
    }
}
