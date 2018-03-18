using MatchedBetMate.WebApi.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MatchedBetMate.WebApi.Data.Repository.Interfaces
{
    public interface IBetRepository
    {
        bool BetExists(int betId);
        Task<IEnumerable<Bet>> GetUsersBets(string userId);
        Task<Bet> GetBet(int betId);
        Task AddBet(Bet bet);
        void DeleteBet(Bet bet);
        Task<bool> Save();
    }
}
