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
        public decimal Profit { get; set; }
        [Required]
        public decimal BackStake { get; set; }
        [Required]
        public decimal BackOdds { get; set; }
        [Required]
        public decimal BackCommission { get; set; }
        [Required]
        public decimal LayOdds { get; set; }
        [Required]
        public decimal LayCommission { get; set; }
        public decimal LayStake { get; set; }
        public decimal Liability { get; set; }
    }
}
