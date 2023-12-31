﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HvZWebAPI.Data;
using HvZWebAPI.Models;
using HvZWebAPI.DTOs.Mission;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using HvZWebAPI.Utils;
using HvZWebAPI.Interfaces;
using System.Security.Claims;

namespace HvZWebAPI.Controllers
{
    [Route("game/")]
    [ApiController]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class MissionController : ControllerBase
    {
        private readonly IMissionRepository _repo;
        private readonly IPlayerRepository _playerrepo;
        private readonly IMapper _mapper;


        public MissionController(IMapper mapper, IMissionRepository repo, IPlayerRepository playerrepo)
        {
            _mapper = mapper;
            _repo = repo;
            _playerrepo = playerrepo;
        }


        /// <summary>
        /// Retrieves all the missions in a game, must be filtered on the frontend so players only see missions from their faction. 
        /// </summary>
        /// <param name="game_id"></param>
        /// <returns></returns>'
        /// <response code="200">Succuess, returns a list of missions from a game</response>
        /// <response code="400">Input validation error</response>
        /// <response code="500"> Catches all other internal errors</response>
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{game_id}/[controller]")]
        public async Task<ActionResult<MissionReadDTO[]>> GetMissions(int game_id)
        {
            bool isAdmin = User.IsInRole(ClaimsTransformer.ADMIN_ROLE);
            var keyId = CheckForKeycloakId();
            try
            {

                IEnumerable<Mission> missions = await _repo.GetAll(game_id, keyId, isAdmin);
                MissionReadDTO[] missionsAsDTOs = missions.Select(mission => _mapper.Map<MissionReadDTO>(mission)).ToArray();
                return missionsAsDTOs;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"error: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"error: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorCategory.INTERNAL);
            }

        }

        /// <summary>
        /// Retrieves a specific mission object
        /// </summary>
        /// <param name="game_id"></param>
        /// <param name="mission_id"></param>
        /// <returns></returns>
        /// <response code="200">Succuess, returns a mission</response>
        /// <response code="400">Input validation error</response>
        /// <response code="403">You are not the proper faction to access these missions</response>
        /// <response code="404">The mission object we wished to get was not found</response>
        /// <response code="500"> Catches all other internal errors</response>
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{game_id}/[controller]/{mission_id}")]
        public async Task<ActionResult<MissionReadDTO>> GetMission(int game_id, int mission_id)
        {
            try
            {
                //Must send in playerId
                var keyId = CheckForKeycloakId();
                bool isAdmin = User.IsInRole(ClaimsTransformer.ADMIN_ROLE);

                Mission? mission = await _repo.GetById(game_id, mission_id, keyId, isAdmin);
                if (mission is null)
                {
                    return NotFound(ErrorCategory.FAILURE);
                }
                MissionReadDTO missionAsDTO = _mapper.Map<MissionReadDTO>(mission);
                return missionAsDTO;

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"error: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (AccessViolationException ex)
            {
                return StatusCode(StatusCodes.Status403Forbidden, ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"error: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorCategory.INTERNAL);
            }
        }

        /// <summary>
        /// (Admin Only) Updates a specific mission object, replacing the old one
        /// </summary>
        /// <param name="game_id"></param>
        /// <param name="mission_id"></param>
        /// <param name="missionAsDTO"></param>
        /// <returns></returns>
        /// <response code="204">Succuess, mission updated</response>
        /// <response code="400">Input validation error</response>
        /// <response code="404">The mission object we wished to update was not found</response>
        /// <response code="500"> Catches all other internal errors</response>
        [Authorize(Roles = "admin-client-role")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut("{game_id}/[controller]/{mission_id}")]
        public async Task<IActionResult> PutMission(int game_id, int mission_id, MissionUpdateDTO missionAsDTO)
        {
            bool IsBefore = missionAsDTO.Start_time.CompareTo(missionAsDTO.End_time) < 0;
            if (!IsBefore) return BadRequest(ErrorCategory.START_TIME_MUST_BE_BEFORE_ENDTIME());

            if (mission_id != missionAsDTO.Id)
            {
                return BadRequest("Id in body and url doesn't match");
            }

            try
            {
                await _repo.Update(game_id, _mapper.Map<MissionUpdateDTO, Mission>(missionAsDTO));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorCategory.INTERNAL);
            }
            return NoContent();
        }

        /// <summary>
        /// (Admin Only) Adds a new mission to the game
        /// </summary>
        /// <param name="game_id"></param>
        /// <param name="missionAsDTO"></param>
        /// <returns></returns>
        /// <response code="201">Succuess, new mission created</response>
        /// <response code="400">Input validation error</response>
        /// <response code="500"> Catches all other internal errors</response>
        [Authorize(Roles = "admin-client-role")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("{game_id}/[controller]")]
        public async Task<ActionResult<MissionReadDTO>> PostMission(int game_id, MissionCreateDTO missionAsDTO)
        {
            bool IsBefore = missionAsDTO.Start_time.CompareTo(missionAsDTO.End_time) < 0;
            if (!IsBefore) return BadRequest(ErrorCategory.START_TIME_MUST_BE_BEFORE_ENDTIME());

            Mission mission = _mapper.Map<MissionCreateDTO, Mission>(missionAsDTO);

            mission.GameId = game_id;

            try
            {
                var missionReadDTO = _mapper.Map<Mission, MissionReadDTO>(await _repo.Add(game_id, mission));
                return CreatedAtAction("GetMission", new { game_id = game_id, mission_id = missionReadDTO.Id }, missionReadDTO);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorCategory.INTERNAL);
            }
        }

        /// <summary>
        /// (Admin Only) Removes a mission from the game
        /// </summary>
        /// <param name="game_id"></param>
        /// <param name="mission_id"></param>
        /// <returns></returns>
        /// <response code="204">Succuess, mission is deleted</response>
        /// <response code="400">Input validation error</response>
        /// <response code="500"> Catches all other internal errors</response>
        [Authorize(Roles = "admin-client-role")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{game_id}/[controller]/{mission_id}")]
        public async Task<IActionResult> DeleteMission(int game_id, int mission_id)
        {
            try
            {
                await _repo.Delete(game_id, mission_id);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorCategory.INTERNAL);
            }
            return NoContent();
        }
        private string CheckForKeycloakId()
        {
            //If you are admin you can set whatever user you want, users simply send their own identity
            var nameClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (nameClaim != null)
                return nameClaim.Value;
            else throw new ArgumentException(ErrorCategory.NO_KEYCLOAK_ID);
        }
    }


}
