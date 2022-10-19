using System;
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

namespace HvZWebAPI.Controllers
{
    [Route("game/")]
    [ApiController]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class MissionController : ControllerBase
    {
        private readonly IMissionRepository _repo;
        private readonly IMapper _mapper;


        public MissionController(IMapper mapper, IMissionRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="game_id"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("{game_id}/[controller]")]
        public async Task<ActionResult<MissionReadDTO[]>> GetMissions(int game_id)
        {
            IEnumerable<Mission> missions = await _repo.GetAll(game_id);
            MissionReadDTO[] missionsAsDTOs = missions.Select(mission => _mapper.Map<MissionReadDTO>(mission)).ToArray();
            return missionsAsDTOs;
        }

        [Authorize]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet("{game_id}/[controller]/{mission_id}")]
        public async Task<ActionResult<MissionReadDTO>> GetMission(int game_id, int mission_id)
        {
            try
            {
                Mission? mission = await _repo.GetById(game_id, mission_id);
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
            catch (Exception ex)
            {
                Console.WriteLine($"error: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorCategory.INTERNAL);
            }
        }

        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpPut("{game_id}/[controller]/{mission_id}")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMission(int game_id, int mission_id, MissionUpdateDTO missionAsDTO)
        {
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


        [Authorize]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost("{game_id}/[controller]")]
        public async Task<ActionResult<MissionReadDTO>> PostMission(int game_id, MissionCreateDTO missionAsDTO)
        {

            Mission mission = _mapper.Map<MissionCreateDTO, Mission>(missionAsDTO);

            mission.GameId = game_id;

            try
            {
                var missionReadDTO = _mapper.Map<Mission, MissionReadDTO>(await _repo.Add(game_id, mission));
                return CreatedAtAction("GetMission", new { id = missionReadDTO.Id }, missionReadDTO);
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

        [Authorize(Roles = "admin-client-role")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
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

    }
}
