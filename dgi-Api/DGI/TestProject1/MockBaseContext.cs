using DGI.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace TestProject1
{
    public static class MockBaseContext
    {
        public static ApplicationDbContext Get()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: $"ApplicationDbContext-{Guid.NewGuid()}")
            .Options;


            var contextFake = new ApplicationDbContext(options);
            contextFake.Database.EnsureDeleted();

            return contextFake;
        }
    }
}
