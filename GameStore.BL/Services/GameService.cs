using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameStore.BL.Interfaces;
using GameStore.DL.Interfaces;
using GameStore.Models;

namespace GameStore.BL.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<IEnumerable<Game>> GetAllGamesAsync()
        {
            return await _gameRepository.GetAllGamesAsync();
        }

        public async Task<Game?> GetGameByIdAsync(Guid id)
        {
            return await _gameRepository.GetGameByIdAsync(id);
        }

        public async Task AddGameAsync(Game game)
        {
            game.Id = Guid.NewGuid();
            await _gameRepository.AddGameAsync(game);
        }

        public async Task<bool> UpdateGameAsync(Game game)
        {
            return await _gameRepository.UpdateGameAsync(game);
        }

        public async Task<bool> DeleteGameAsync(Guid id)
        {
            return await _gameRepository.DeleteGameAsync(id);
        }
    }
}
