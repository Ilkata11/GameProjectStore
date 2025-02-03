using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameStore.DL.Interfaces;
using GameStore.Models;

namespace GameStore.DL.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly List<Game> _games = new();

        public async Task<IEnumerable<Game>> GetAllGamesAsync()
        {
            return await Task.FromResult(_games);
        }

        public async Task<Game?> GetGameByIdAsync(Guid id)
        {
            return await Task.FromResult(_games.FirstOrDefault(g => g.Id == id));
        }

        public async Task AddGameAsync(Game game)
        {
            _games.Add(game);
            await Task.CompletedTask;
        }

        public async Task<bool> UpdateGameAsync(Game game)
        {
            var existingGame = _games.FirstOrDefault(g => g.Id == game.Id);
            if (existingGame == null) return false;

            existingGame.Title = game.Title;
            existingGame.Genre = game.Genre;
            existingGame.ReleaseDate = game.ReleaseDate;
            existingGame.Price = game.Price;

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteGameAsync(Guid id)
        {
            var game = _games.FirstOrDefault(g => g.Id == id);
            if (game == null) return false;

            _games.Remove(game);
            return await Task.FromResult(true);
        }
    }
}
