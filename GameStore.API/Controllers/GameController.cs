using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GameStore.BL.Interfaces;
using GameStore.Models;
using System.Runtime.InteropServices;

namespace GameStore.API.Controllers
{
    [ApiController]
    [Route("api/games")]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGames()
        {
            var games = await _gameService.GetAllGamesAsync();
            return Ok(games);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGameById(Guid id)
        {
            var game = await _gameService.GetGameByIdAsync(id);
            if (game == null) return NotFound();

            return Ok(game);
        }

        [HttpPost]
        public async Task<IActionResult> AddGame([FromBody] Game game)
        {
            await _gameService.AddGameAsync(game);
            return CreatedAtAction(nameof(GetGameById), new { id = game.Id }, game);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGame(Guid id, [FromBody] Game game)
        {
            if (id != game.Id) return BadRequest("ID mismatch");

            var updated = await _gameService.UpdateGameAsync(game);
            if (!updated) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGame(Guid id)
        {
            var deleted = await _gameService.DeleteGameAsync(id);
            if (!deleted) return NotFound();

            return NoContent();
        }
    }
}
