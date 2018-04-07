using System.ComponentModel.DataAnnotations;
using MatchedBetMate.DTO.Enum;

namespace MatchedBetMate.iOS.Model.ViewModel
{
    public class BetViewModel
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
        public decimal? Profit { get; set; }
        public decimal BackStake { get; set; }

        public decimal BackOdds { get; set; }

        public decimal BackCommission { get; set; }

        public decimal LayOdds { get; set; }
        public decimal LayCommission { get; set; }
        public decimal LayStake { get; set; }
        public decimal Liability { get; set; }
    }
}
