using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameStore.BL.Interfaces;
using GameStore.DL.Interfaces;
using GameStore.Models;

namespace GameStore.BL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<IEnumerable<User>> GetAllUsersAsync() => _userRepository.GetAllUsersAsync();
        public Task<User?> GetUserByIdAsync(Guid id) => _userRepository.GetUserByIdAsync(id);
        public Task<User> AddUserAsync(User user) => _userRepository.AddUserAsync(user);
        public Task<bool> UpdateUserAsync(User user) => _userRepository.UpdateUserAsync(user);
        public Task<bool> DeleteUserAsync(Guid id) => _userRepository.DeleteUserAsync(id);
    }
}
