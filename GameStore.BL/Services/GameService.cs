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

        public Task<IEnumerable<Game>> GetAllGamesAsync()
        {
            return _gameRepository.GetAllGamesAsync();
        }

        public async Task<Game?> GetGameByIdAsync(Guid id)
        {
            var game = await _gameRepository.GetGameByIdAsync(id);
            return game ?? null; // Обработваме случая, когато играта не е намерена
        }

        public async Task<Game> AddGameAsync(Game game)
        {
            game.Id = Guid.NewGuid();
            await _gameRepository.AddGameAsync(game);
            return game; // Връщаме създадената игра
        }

        public Task<bool> UpdateGameAsync(Game game)
        {
            return _gameRepository.UpdateGameAsync(game);
        }

        public Task<bool> DeleteGameAsync(Guid id)
        {
            return _gameRepository.DeleteGameAsync(id);
        }
    }
}
