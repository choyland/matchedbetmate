using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MatchedBetMate.DTO.Bet;
using MatchedBetMate.WebApi.Controllers.Base;
using MatchedBetMate.WebApi.Data.Entities;
using MatchedBetMate.WebApi.Data.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace MatchedBetMate.WebApi.Controllers
{
    [Route("api/bets")]
    public class BetsController : BaseController
    {
        private readonly IBetRepository _betRepository;

        public BetsController(UserManager<IdentityUser> userManager, IBetRepository betRepository) : base(userManager)
        {
            _betRepository = betRepository;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetBets()
        {
            try
            {
                var user = await GetUser();
                if (user == null) return NotFound();

                var bets = await _betRepository.GetUsersBets(user.Id);

                var betDtos = Mapper.Map<IEnumerable<BetDto>>(bets);

                return Ok(betDtos);
            }
            catch (Exception)
            {
                return GetErrorStatusCodeAndGenericMessage();
            }
        }

        [Authorize]
        [HttpGet("{betId}", Name = "GetBet")]
        public async Task<IActionResult> GetBet(int betId)
        {
            try
            {
                var bet = await _betRepository.GetBet(betId);

                if (bet == null) return NotFound();

                var betDto = Mapper.Map<BetDto>(bet);

                return Ok(betDto);
            }
            catch (Exception)
            {
                return GetErrorStatusCodeAndGenericMessage();
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateBet([FromBody] CreateBetDto createBetDto)
        {
            try
            {
                if (createBetDto == null || !ModelState.IsValid)
                {
                    return BadRequest();
                }

                var user = await GetUser();

                if (user == null) return NotFound();

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var bet = Mapper.Map<Bet>(createBetDto);
                bet.User = user;

                await _betRepository.AddBet(bet);

                if (!await _betRepository.Save())
                {
                    return GetErrorStatusCodeAndGenericMessage();
                }

                var betDtoToReturn = Mapper.Map<BetDto>(bet);

                return CreatedAtRoute("GetBet", new { betId = betDtoToReturn.Id}, betDtoToReturn);
            }
            catch (Exception)
            {
                return GetErrorStatusCodeAndGenericMessage();
            }

        }

        [Authorize]
        [HttpPut("{betId}")]
        public async Task<IActionResult> UpdateBet(int betId, [FromBody] UpdateBetDto updateBetDto)
        {
            try
            {
                if (updateBetDto == null)
                {
                    return BadRequest();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var existingBet = await _betRepository.GetBet(betId);

                if (existingBet == null)
                {
                    return NotFound();
                }

                var user = await GetUser();

                if (existingBet.User.Id != user.Id)
                {
                    return BadRequest();
                }

                Mapper.Map(updateBetDto, existingBet);

                if (!await _betRepository.Save())
                {
                    return GetErrorStatusCodeAndGenericMessage();
                }

                return NoContent();
            }
            catch (Exception)
            {
                return GetErrorStatusCodeAndGenericMessage();
            }
        }

        [Authorize]
        [HttpPatch("{betId}")]
        public async Task<IActionResult> PartiallyUpdateBet(int betId, [FromBody]JsonPatchDocument<UpdateBetDto> patchDoc)
        {
            try
            {
                if (patchDoc == null) return BadRequest();

                var existingBet = await _betRepository.GetBet(betId);

                if (existingBet == null) return NotFound();

                var user = await GetUser();

                if (existingBet.User.Id != user.Id)
                {
                    return BadRequest();
                }

                var betToPatch = Mapper.Map<UpdateBetDto>(existingBet);

                patchDoc.ApplyTo(betToPatch, ModelState);

                if (!ModelState.IsValid) return BadRequest(ModelState);

                TryValidateModel(betToPatch);

                if (!ModelState.IsValid) return BadRequest(ModelState);

                Mapper.Map(betToPatch, existingBet);

                if (!await _betRepository.Save())
                {
                    return GetErrorStatusCodeAndGenericMessage();
                }

                return NoContent();
            }
            catch (Exception)
            {
                return GetErrorStatusCodeAndGenericMessage();
            }
        }

        [Authorize]
        [HttpDelete("{betId}")]
        public async Task<IActionResult> DeleteBet(int betId)
        {
            try
            {
                var existingBet = await _betRepository.GetBet(betId);

                if (existingBet == null) return NotFound();

                var user = await GetUser();

                if (existingBet.User.Id != user.Id)
                {
                    return BadRequest();
                }

                _betRepository.DeleteBet(existingBet);

                if (!await _betRepository.Save())
                {
                    return GetErrorStatusCodeAndGenericMessage();
                }

                return NoContent();
            }
            catch (Exception )
            {
                return GetErrorStatusCodeAndGenericMessage();
            }
        }
    }
}
