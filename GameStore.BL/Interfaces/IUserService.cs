using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameStore.Models;

namespace GameStore.BL.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User?> GetUserByIdAsync(Guid id);
        Task<User> AddUserAsync(User user);
        Task<bool> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(Guid id);
    }
}
