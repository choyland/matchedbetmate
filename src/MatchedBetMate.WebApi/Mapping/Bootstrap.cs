using MatchedBetMate.DTO.Bet;
using MatchedBetMate.WebApi.Data.Entities;

namespace MatchedBetMate.WebApi.Mapping
{
    public static class Bootstrap
    {
        public static void InitialiseAutomapper()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Bet, BetDto>().ReverseMap();
                cfg.CreateMap<Bet, UpdateBetDto>().ReverseMap();
                cfg.CreateMap<Bet, CreateBetDto>().ReverseMap();
            }); 
        }
    }
}
