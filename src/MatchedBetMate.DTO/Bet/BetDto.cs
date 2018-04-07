using System.ComponentModel.DataAnnotations;
using MatchedBetMate.DTO.Enum;

namespace MatchedBetMate.DTO.Bet
{
    public class BetDto
    {
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [EnumDataType(typeof(BetType))]
        public BetType BetType { get; set; }
        [Required]
        [EnumDataType(typeof(Sport))]
        public Sport Sport { get; set; }
        public double Profit { get; set; }
        public double BackStake { get; set; }

        public double BackOdds { get; set; }

        public double BackCommission { get; set; }

        public double LayOdds { get; set; }
        public double LayCommission { get; set; }
        public double LayStake { get; set; }
        public double Liability { get; set; }

        public BetStatus BetStatus { get; set; }
    }
}
