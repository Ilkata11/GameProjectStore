using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameStore.DL.Interfaces;
using GameStore.Models;

namespace GameStore.DL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private static List<User> _users = new List<User>
        {
            new User { Id = Guid.NewGuid(), Username = "Admin", Email = "admin@example.com" },
            new User { Id = Guid.NewGuid(), Username = "Player1", Email = "player1@example.com" }
        };

        public Task<IEnumerable<User>> GetAllUsersAsync() => Task.FromResult<IEnumerable<User>>(_users);
        public Task<User?> GetUserByIdAsync(Guid id) => Task.FromResult(_users.FirstOrDefault(u => u.Id == id));

        public Task<User> AddUserAsync(User user)
        {
            user.Id = Guid.NewGuid();
            _users.Add(user);
            return Task.FromResult(user);
        }

        public Task<bool> UpdateUserAsync(User user)
        {
            var existingUser = _users.FirstOrDefault(u => u.Id == user.Id);
            if (existingUser == null) return Task.FromResult(false);

            existingUser.Username = user.Username;
            existingUser.Email = user.Email;
            return Task.FromResult(true);
        }

        public Task<bool> DeleteUserAsync(Guid id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null) return Task.FromResult(false);

            _users.Remove(user);
            return Task.FromResult(true);
        }
    }
}
