
using HotelGrandioso.Data;
using HotelGrandioso.Services;
using HotelGrandioso.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

// Set the working directory to the project folder
Directory.SetCurrentDirectory(
    Path.GetFullPath(
        Path.Combine(AppContext.BaseDirectory, "..", "..", "..")));

// Read database configuration
var configuration = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json")
    .Build();

// Get connection string
var connectionString = configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException(
        "Connection string 'DefaultConnection' saknas.");

// Configure database
var options = new DbContextOptionsBuilder<HotelContext>()
    .UseSqlite(connectionString)
    .Options;

// Create database context
using var context = new HotelContext(options);

// Apply database migrations
context.Database.Migrate();

// Create repository
IHotelRepository repository = new HotelRepository(context);

// Start menu
var menu = new Menu(repository);
menu.Show();
