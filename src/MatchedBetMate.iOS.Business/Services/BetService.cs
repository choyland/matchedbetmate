using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MatchedBetMate.DTO.Bet;
using MatchedBetMate.DTO.Enum;
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
            var bets = await _httpClient.ExecuteGetRequest<List<BetDto>>(_configProvider.GetBetsResourceUrl, true);

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
            var betDto = new CreateBetDto
            {
                BackOdds = newBet.BackOdds,
                BackStake = newBet.BackStake,
                BetType = newBet.BetType,
                Description = "TestingAddingBet",
                LayCommission = newBet.LayCommission,
                LayOdds = newBet.LayOdds,
                Sport = Sport.Football
            };

            var successfullyCreatedBet = await
                _httpClient.ExecutePostRequest<CreateBetDto, BetDto>(betDto, _configProvider.CreateBetResourceUrl, true);

            return successfullyCreatedBet != null;
        }

        public async Task<bool> UpdateBet(BetViewModel betToUpdate)
        {
            if (betToUpdate == null) return false;

            // TODO Map BetViewModel to UpdateBetDto
            var updateBetDto = new UpdateBetDto();

            var updateResourceUrl = $"{_configProvider.UpdateBetResourceUrl}/{betToUpdate.Id}";

            var updatedBet = await _httpClient.ExecutePostRequest<UpdateBetDto, BetDto>(updateBetDto, updateResourceUrl, true);

            return updatedBet != null;
        }

        public async Task<bool> DeleteBet(BetViewModel betToDelete)
        {
            if (betToDelete == null) return false;

            var deleteBetResourceUrl = $"{_configProvider.DeleteBetResourceUlr}/{betToDelete.Id}";

            await _httpClient.ExecuteDeleteRequest(deleteBetResourceUrl, true);

            return true;
        }
    }
}
