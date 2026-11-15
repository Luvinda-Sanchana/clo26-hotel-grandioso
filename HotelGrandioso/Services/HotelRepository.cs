
using HotelGrandioso.Data;
using HotelGrandioso.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelGrandioso.Services;

public class HotelRepository : IHotelRepository
{
    private readonly HotelContext _context;

    public HotelRepository(HotelContext context)
    {
        _context = context;
    }

    public List<Room> GetAllRooms()
    {
        return _context.Rooms
            .Include(room => room.RoomType)
            .ToList();
    }

    public List<Booking> GetAllBookings()
    {
        return _context.Bookings
            .Include(booking => booking.Guest)
            .Include(booking => booking.Room)
            .ToList();
    }

    public Booking? GetBookingById(int bookingId)
    {
        return _context.Bookings
            .Include(booking => booking.Guest)
            .Include(booking => booking.Room)
            .FirstOrDefault(booking => booking.BookingId == bookingId);
    }

    public List<Room> GetAvailableRooms(DateTime checkIn, DateTime checkOut)
    {
        return _context.Rooms
            .Include(room => room.RoomType)
            .Where(room => !_context.Bookings.Any(booking =>
                booking.RoomId == room.RoomId &&
                booking.CheckIn < checkOut &&
                booking.CheckOut > checkIn))
            .OrderBy(room => room.RoomNumber)
            .ToList();
    }

    public void AddGuest(Guest guest)
    {
        _context.Guests.Add(guest);
        _context.SaveChanges();
    }

    public void AddBooking(Booking booking)
    {
        _context.Bookings.Add(booking);
        _context.SaveChanges();
    }

    public void DeleteBooking(Booking booking)
    {
        _context.Bookings.Remove(booking);
        _context.SaveChanges();
    }
}
