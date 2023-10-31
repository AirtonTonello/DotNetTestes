using Microsoft.EntityFrameworkCore;
using TestesComBanco.Context;

namespace TestesComBanco.Tests.Mocks
{
    internal static class DbContextOptionMock
    {
        public static DbContextOptions<BancoDbContext> Options => new DbContextOptionsBuilder<BancoDbContext>()
                                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                .EnableSensitiveDataLogging()
                                .Options;
    }
}
