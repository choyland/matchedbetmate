using System.ComponentModel.DataAnnotations;
using MatchedBetMate.DTO.Enum;

namespace MatchedBetMate.DTO.Bet
{
    public class CreateBetDto
    {
        [Required]
        public string Description { get; set; }
        [Required]
        [EnumDataType(typeof(BetType))]
        public BetType BetType { get; set; }
        [Required]
        [EnumDataType(typeof(Sport))]
        public Sport Sport { get; set; }
        public double Profit { get; set; }
    }
}
