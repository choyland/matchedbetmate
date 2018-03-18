using System.Collections.Generic;
using System.Threading.Tasks;
using MatchedBetMate.DTO.Bet;

namespace MatchedBetMate.WebApi.Business.Services.Interfaces
{
    public interface IBetService
    {
        Task<IEnumerable<BetDto>> GetBets(string userId);

        Task<BetDto> GetBet(int betId);

        Task<int> CreateBet(BetDto bet);

        Task UpdateBet(BetDto existingBet, UpdateBetDto updatedBet);

        Task DeleteBet(BetDto existingBet);

        Task<bool> BetExists(int betId);
    }
}
