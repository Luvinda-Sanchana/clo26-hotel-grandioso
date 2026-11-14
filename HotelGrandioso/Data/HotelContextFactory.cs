
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace HotelGrandioso.Data;

public class HotelContextFactory : IDesignTimeDbContextFactory<HotelContext>
{
    public HotelContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException(
                "Connection string 'DefaultConnection' saknas.");

        var options = new DbContextOptionsBuilder<HotelContext>()
            .UseSqlite(connectionString)
            .Options;

        return new HotelContext(options);
    }
}
