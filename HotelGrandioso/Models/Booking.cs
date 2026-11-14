
namespace HotelGrandioso.Models;

public class Booking
{

    public int BookingId { get; set; }

    public int GuestId { get; set; }

    public int RoomId { get; set; }

    public DateTime CheckIn { get; set; }

    public DateTime CheckOut { get; set; }

    public int NumberOfGuests { get; set; }

    public Guest Guest { get; set; } = null!;

    public Room Room { get; set; } = null!;
}
