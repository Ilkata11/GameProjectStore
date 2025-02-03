using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Moq;
using GameStore.BL.Interfaces;
using GameStore.BL.Services;
using GameStore.DL.Interfaces;
using GameStore.Models;

namespace GameStore.Tests.Services
{
    public class GameServiceTests
    {
        private readonly Mock<IGameRepository> _gameRepositoryMock;
        private readonly IGameService _gameService;

        public GameServiceTests()
        {
            _gameRepositoryMock = new Mock<IGameRepository>();
            _gameService = new GameService(_gameRepositoryMock.Object);
        }

        [Fact]
        public async Task GetAllGamesAsync_ShouldReturnGames()
        {
            // Arrange
            var games = new List<Game>
            {
                new Game { Id = Guid.NewGuid(), Title = "Game 1", Genre = "Action", ReleaseDate = DateTime.UtcNow, Price = 59.99m },
                new Game { Id = Guid.NewGuid(), Title = "Game 2", Genre = "RPG", ReleaseDate = DateTime.UtcNow, Price = 49.99m }
            };
            _gameRepositoryMock.Setup(repo => repo.GetAllGamesAsync()).ReturnsAsync(games);

            // Act
            var result = await _gameService.GetAllGamesAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetGameByIdAsync_ShouldReturnCorrectGame()
        {
            // Arrange
            var gameId = Guid.NewGuid();
            var game = new Game { Id = gameId, Title = "Test Game", Genre = "Shooter", ReleaseDate = DateTime.UtcNow, Price = 39.99m };
            _gameRepositoryMock.Setup(repo => repo.GetGameByIdAsync(gameId)).ReturnsAsync(game);

            // Act
            var result = await _gameService.GetGameByIdAsync(gameId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(gameId, result.Id);
        }
    }
}
