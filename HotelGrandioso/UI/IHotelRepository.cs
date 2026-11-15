
using HotelGrandioso.Models;

namespace HotelGrandioso.Services;

public interface IHotelRepository
{
    List<Room> GetAllRooms();

    List<Booking> GetAllBookings();

    List<Room> GetAvailableRooms(DateTime checkIn, DateTime checkOut);

    Booking? GetBookingById(int bookingId);

    void AddGuest(Guest guest);

    void AddBooking(Booking booking);

    void DeleteBooking(Booking booking);
}
