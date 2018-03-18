using MatchedBetMate.WebApi.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MatchedBetMate.WebApi.Data.Context
{
    public class MatchedBetMateDbContext : IdentityDbContext
    {
        public MatchedBetMateDbContext(DbContextOptions<MatchedBetMateDbContext> options) : base(options)
        {
            Database.Migrate();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(GetConnectionString());
            //optionsBuilder.UseMySql(GetConnectionString());
        }
        
        private static string GetConnectionString()
        {
            const string databaseName = "MatchedBetMate";
            const string databaseUser = "sa";
            const string databasePass = "Pa55word123";

            return $"Server=CHOYLAND-DESKTO\\SQLEXPRESS01;" +
                   $"initial catalog={databaseName};" +
                   "trusted_connection=true";
        }

        public DbSet<Bet> Bets { get; set; }
    }
}