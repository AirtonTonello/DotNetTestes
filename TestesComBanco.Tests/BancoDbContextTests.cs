
using Microsoft.EntityFrameworkCore;
using TestesComBanco.Context;
using TestesComBanco.Tests.Mocks;

namespace TestesComBanco.Tests
{
    public class BancoDbContextTests : IDisposable
    {
        private readonly BancoDbContext _dbContext;

        public BancoDbContextTests()
        {
            _dbContext = new(DbContextOptionMock.Options);
        }

        [Fact]
        public void Test_Connection_Success()
        {
            // Arrange
            bool isConnected = false;
            using var dbContextLocal = new BancoDbContext(DbContextOptionMock.Options);

            // Act
            isConnected = dbContextLocal.Database.CanConnect();

            // Assert
            Assert.True(isConnected);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
