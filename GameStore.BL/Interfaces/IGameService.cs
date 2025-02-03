using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameStore.Models;

namespace GameStore.BL.Interfaces
{
    public interface IGameService
    {
        Task<IEnumerable<Game>> GetAllGamesAsync();
        Task<Game?> GetGameByIdAsync(Guid id);
        Task<Game> AddGameAsync(Game game); // Връща добавения обект
        Task<bool> UpdateGameAsync(Game game);
        Task<bool> DeleteGameAsync(Guid id);
    }
}
