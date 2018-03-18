using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatchedBetMate.WebApi.Data.Context;
using MatchedBetMate.WebApi.Data.Entities;
using MatchedBetMate.WebApi.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MatchedBetMate.WebApi.Data.Repository.Implementation
{
    public class BetRepository : IBetRepository
    {
        private readonly MatchedBetMateDbContext _context;

        public BetRepository(MatchedBetMateDbContext context)
        {
            _context = context;
        }

        public bool BetExists(int betId)
        {
            return _context.Bets.Any(b => b.Id == betId);
        }

        public async Task<IEnumerable<Bet>> GetUsersBets(string userId)
        {
            return await _context.Bets.Where(b => b.User.Id == userId).ToListAsync();
        }

        public async Task<Bet> GetBet(int betId)
        {
            return await _context.Bets.FirstOrDefaultAsync(b => b.Id == betId);
        }

        public async Task AddBet(Bet bet)
        {
            await _context.Bets.AddAsync(bet);
        }

        public void DeleteBet(Bet bet)
        {
            _context.Bets.Remove(bet);
        }

        public async Task<bool> Save()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
