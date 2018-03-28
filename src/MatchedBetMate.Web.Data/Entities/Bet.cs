using MatchedBetMate.DTO.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace MatchedBetMate.WebApi.Data.Entities
{
    public class Bet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [EnumDataType(typeof(BetType))]
        public BetType BetType { get; set; }

        [Required]
        [EnumDataType(typeof(Sport))]
        public Sport Sport { get; set; }
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

        public double Profit { get; set; }

        [Required]
        public IdentityUser User { get; set; }
    }
}
