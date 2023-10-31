using TestesComBanco.Interfaces;
using TestesComBanco.Models;
using TestesComBanco.Repositories;
using TestesComBanco.Tests.Mocks;

namespace TestesComBanco.Tests
{
    public class AgencyRepositoryTests : IDisposable
    {
        private readonly IAgencyRepository _agencyRepository;

        public AgencyRepositoryTests()
        {
            _agencyRepository = new AgencyRepository(new(DbContextOptionMock.Options));
        }

        [Fact]
        public async Task Test_GetAllAsync_Success()
        {
            // Arrange

            // Act
            var list = await _agencyRepository.GetAllAsync();

            // Assert
            Assert.NotNull(list);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public async Task Test_GetByIdAsync_Success(int id)
        {
            // Arrange

            // Act
            var entity = await _agencyRepository.GetByIdAsync(id);

            // Assert
            Assert.NotNull(entity);
            Assert.Equal(id, entity.Id);
        }

        [Theory]
        [InlineData(15, "Agency 15")]
        [InlineData(16, "Agency 16")]
        public async Task Test_AddAsync_Success(int id, string name)
        {
            // Arrange
            Agency agency = new(id, name);

            // Act
            await _agencyRepository.AddAsync(agency);

            var agencyAdded = await _agencyRepository.GetByIdAsync(id);

            // Assert
            Assert.Equal(id, agencyAdded.Id);
        }

        [Theory]
        [InlineData(1, "Agency 1.1")]
        [InlineData(2, "Agency 2.1")]
        public async Task Test_UpdateAsync_Success(int id, string name)
        {
            // Arrange
            var agency = await _agencyRepository.GetByIdAsync(id);
            agency.Name = name;

            // Act
            await _agencyRepository.UpdateAsync(agency);

            var agencyUpdated = await _agencyRepository.GetByIdAsync(id);

            // Assert
            Assert.Equal(id, agencyUpdated.Id);
            Assert.Equal(name, agencyUpdated.Name);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        public async Task Test_DeleteAsync_Success(int id)
        {
            // Arrange

            // Act
            await _agencyRepository.DeleteAsync(id);

            var agencies = await _agencyRepository.GetAllAsync();

            // Assert
            Assert.DoesNotContain(agencies, i => i.Id == id);
        }

        public void Dispose()
        {
            _agencyRepository.Dispose();
        }
    }
}
