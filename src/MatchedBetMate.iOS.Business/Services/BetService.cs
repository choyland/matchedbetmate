using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MatchedBetMate.DTO.Bet;
using MatchedBetMate.iOS.Business.Interfaces.Clients;
using MatchedBetMate.iOS.Business.Interfaces.Providers;
using MatchedBetMate.iOS.Business.Interfaces.Services;
using MatchedBetMate.iOS.Model.ViewModel;

namespace MatchedBetMate.iOS.Business.Services
{
    public class BetService : IBetService
    {
        private readonly IWebApiConfigurationProvider _configProvider;
        private readonly IHttpClient _httpClient;

        public BetService(IWebApiConfigurationProvider configProvider, IHttpClient httpClient)
        {
            _configProvider = configProvider;
            _httpClient = httpClient;
        }

        public async Task<List<BetViewModel>> GetBets()
        {
            var bets = await _httpClient.ExecuteGetRequest<List<BetDto>>(_configProvider.GetBetsResource, true);

            var betViewModels = new List<BetViewModel>();

            if (bets != null)
            {
                //TODO Map betdtos to bet viewmodels
            }

            return betViewModels;
        }

        public async Task<bool> AddBet(BetViewModel newBet)
        {
            // TODO Map betviewmodel to CreateBetDto
            var betDto = new CreateBetDto();

            var successfullyCreatedBet = await
                _httpClient.ExecutePostRequest<CreateBetDto, BetDto>(betDto, _configProvider.CreateBetResource, true);

            return successfullyCreatedBet != null;
        }
    }
}
