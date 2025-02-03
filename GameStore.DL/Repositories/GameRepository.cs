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
        private static List<Game> _games = new List<Game>
        {
            new Game { Id = Guid.NewGuid(), Title = "The Witcher 3", Genre = "RPG", Price = 39.99m },
            new Game { Id = Guid.NewGuid(), Title = "Cyberpunk 2077", Genre = "Action", Price = 59.99m }
        };

        public Task<IEnumerable<Game>> GetAllGamesAsync()
        {
            return Task.FromResult<IEnumerable<Game>>(_games);
        }

        public Task<Game?> GetGameByIdAsync(Guid id)
        {
            var game = _games.FirstOrDefault(g => g.Id == id);
            return Task.FromResult(game);
        }

        public Task<Game> AddGameAsync(Game game)
        {
            game.Id = Guid.NewGuid(); // Генерираме ново ID
            _games.Add(game);
            return Task.FromResult(game);
        }

        public Task<bool> UpdateGameAsync(Game game)
        {
            var existingGame = _games.FirstOrDefault(g => g.Id == game.Id);
            if (existingGame == null) return Task.FromResult(false);

            existingGame.Title = game.Title;
            existingGame.Genre = game.Genre;
            existingGame.ReleaseDate = game.ReleaseDate;
            existingGame.Price = game.Price;

            return Task.FromResult(true);
        }

        public Task<bool> DeleteGameAsync(Guid id)
        {
            var game = _games.FirstOrDefault(g => g.Id == id);
            if (game == null) return Task.FromResult(false);

            _games.Remove(game);
            return Task.FromResult(true);
        }
    }
}
