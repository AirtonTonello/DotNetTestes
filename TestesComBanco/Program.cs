using Microsoft.EntityFrameworkCore;
using TestesComBanco.Context;
using TestesComBanco.Models;

var options = new DbContextOptionsBuilder<BancoDbContext>()
        .UseInMemoryDatabase(Guid.NewGuid().ToString())
        .EnableSensitiveDataLogging()
        .Options;

using var dbContext = new BancoDbContext(options);
dbContext.Database.EnsureCreated();

await dbContext.Agencies.AddRangeAsync(new List<Agency>()
{
   new Agency(10, "Agency 10"),
   new Agency(11, "Agency 11"),
   new Agency(12, "Agency 12"),
   new Agency(13, "Agency 13"),
   new Agency(14, "Agency 14"),
   new Agency(15, "Agency 15"),
});
await dbContext.SaveChangesAsync();

var agencies = await dbContext.Agencies.ToListAsync();

foreach (var agency in agencies)
    Console.WriteLine(agency);

Console.WriteLine();
Console.WriteLine("Done");
Console.ReadKey();