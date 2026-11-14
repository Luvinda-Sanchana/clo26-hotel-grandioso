
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
}
