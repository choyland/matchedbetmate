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

        public double Profit { get; set; }

        [Required]
        public IdentityUser User { get; set; }
    }
}
