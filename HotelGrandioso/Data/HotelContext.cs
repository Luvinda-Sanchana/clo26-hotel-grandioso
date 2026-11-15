
using HotelGrandioso.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelGrandioso.Data;

public class HotelContext : DbContext
{
    public HotelContext(DbContextOptions<HotelContext> options)
        : base(options)
    {
    }

    public DbSet<Room> Rooms => Set<Room>();

    public DbSet<RoomType> RoomTypes => Set<RoomType>();

    public DbSet<Guest> Guests => Set<Guest>();

    public DbSet<Booking> Bookings => Set<Booking>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Room types
        modelBuilder.Entity<RoomType>().HasData(
            new RoomType
            {
                RoomTypeId = 1,
                Name = "Standard",
                Description = "Standardrum"
            },
            new RoomType
            {
                RoomTypeId = 2,
                Name = "Lyxsvit",
                Description = "Lyxig svit på toppvåningen"
            },
            new RoomType
            {
                RoomTypeId = 3,
                Name = "Bröllopsvit",
                Description = "Exklusiv bröllopssvit på toppvåningen"
            }
        );

        // Rooms on floor 1
        modelBuilder.Entity<Room>().HasData(
            new Room
            {
                RoomId = 1,
                RoomNumber = 101,
                Floor = 1,
                SizeM2 = 80,
                PricePerNight = 800,
                RoomTypeId = 1
            },
            new Room
            {
                RoomId = 2,
                RoomNumber = 102,
                Floor = 1,
                SizeM2 = 80,
                PricePerNight = 800,
                RoomTypeId = 1
            },
            new Room
            {
                RoomId = 3,
                RoomNumber = 103,
                Floor = 1,
                SizeM2 = 80,
                PricePerNight = 800,
                RoomTypeId = 1
            },
            new Room
            {
                RoomId = 4,
                RoomNumber = 104,
                Floor = 1,
                SizeM2 = 80,
                PricePerNight = 800,
                RoomTypeId = 1
            },
            new Room
            {
                RoomId = 5,
                RoomNumber = 105,
                Floor = 1,
                SizeM2 = 80,
                PricePerNight = 800,
                RoomTypeId = 1
            },

            // Rooms on floor 2
            new Room
            {
                RoomId = 6,
                RoomNumber = 201,
                Floor = 2,
                SizeM2 = 100,
                PricePerNight = 1000,
                RoomTypeId = 1
            },
            new Room
            {
                RoomId = 7,
                RoomNumber = 202,
                Floor = 2,
                SizeM2 = 100,
                PricePerNight = 1000,
                RoomTypeId = 1
            },
            new Room
            {
                RoomId = 8,
                RoomNumber = 203,
                Floor = 2,
                SizeM2 = 100,
                PricePerNight = 1000,
                RoomTypeId = 1
            },
            new Room
            {
                RoomId = 9,
                RoomNumber = 204,
                Floor = 2,
                SizeM2 = 100,
                PricePerNight = 1000,
                RoomTypeId = 1
            },
            new Room
            {
                RoomId = 10,
                RoomNumber = 205,
                Floor = 2,
                SizeM2 = 100,
                PricePerNight = 1000,
                RoomTypeId = 1
            },

            // Rooms on floor 3
            new Room
            {
                RoomId = 11,
                RoomNumber = 301,
                Floor = 3,
                SizeM2 = 120,
                PricePerNight = 1200,
                RoomTypeId = 1
            },
            new Room
            {
                RoomId = 12,
                RoomNumber = 302,
                Floor = 3,
                SizeM2 = 120,
                PricePerNight = 1200,
                RoomTypeId = 1
            },
            new Room
            {
                RoomId = 13,
                RoomNumber = 303,
                Floor = 3,
                SizeM2 = 120,
                PricePerNight = 1200,
                RoomTypeId = 1
            },
            new Room
            {
                RoomId = 14,
                RoomNumber = 304,
                Floor = 3,
                SizeM2 = 180,
                PricePerNight = 2800,
                RoomTypeId = 2
            },
            new Room
            {
                RoomId = 15,
                RoomNumber = 305,
                Floor = 3,
                SizeM2 = 220,
                PricePerNight = 3500,
                RoomTypeId = 3
            }
        );
    }
}
