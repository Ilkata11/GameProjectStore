using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameStore.Models;

namespace GameStore.DL.Interfaces
{
    public interface IGameRepository
    {
        Task<IEnumerable<Game>> GetAllGamesAsync();
        Task<Game?> GetGameByIdAsync(Guid id);
        Task<Game> AddGameAsync(Game game); // Връщаме създадената игра
        Task<bool> UpdateGameAsync(Game game);
        Task<bool> DeleteGameAsync(Guid id);
    }
}
