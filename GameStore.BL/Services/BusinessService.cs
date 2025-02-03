using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameStore.BL.Interfaces;
using GameStore.DL.Interfaces;

namespace GameStore.BL.Services
{
    public class BusinessService : IBusinessService
    {
        private readonly IGameRepository _gameRepository;

        public BusinessService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<decimal> CalculateTotalGamePriceAsync(IEnumerable<Guid> gameIds)
        {
            var games = await _gameRepository.GetAllGamesAsync();
            return games.Where(g => gameIds.Contains(g.Id)).Sum(g => g.Price);
        }

        public async Task<int> CountGamesByGenreAsync(string genre)
        {
            var games = await _gameRepository.GetAllGamesAsync();
            return games.Count(g => g.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase));
        }
    }
}
