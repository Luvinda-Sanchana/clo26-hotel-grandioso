
using HotelGrandioso.Services;

namespace HotelGrandioso.UI;

public class Menu
{
    private readonly IHotelRepository _repository;

    public Menu(IHotelRepository repository)
    {
        _repository = repository;
    }

    public void Show()
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n=== HOTEL GRANDIOSO ===");
            Console.WriteLine("1. Boka rum");
            Console.WriteLine("2. Avboka bokning");
            Console.WriteLine("3. Visa alla bokningar");
            Console.WriteLine("4. Visa lediga rum");
            Console.WriteLine("5. Avsluta");

            Console.Write("\nVälj ett alternativ: ");
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BookRoom();
                    break;

                case "2":
                    Console.WriteLine("Avbokningsfunktionen kommer snart.");
                    break;

                case "3":
                    ShowAllBookings();
                    break;

                case "4":
                    ShowAllRooms();
                    break;

                case "5":
                    running = false;
                    Console.WriteLine("Tack för besöket!");
                    break;

                default:
                    Console.WriteLine("Ogiltigt val. Försök igen.");
                    break;
            }
        }
    }

    private void ShowAllBookings()
    {
        var bookings = _repository.GetAllBookings();

        Console.WriteLine("\n=== ALLA BOKNINGAR ===");

        if (bookings.Count == 0)
        {
            Console.WriteLine("Det finns inga bokningar.");
            return;
        }

        foreach (var booking in bookings)
        {
            Console.WriteLine(
                $"Bokning: {booking.BookingId} | " +
                $"Gäst: {booking.Guest.Name} | " +
                $"Rum: {booking.Room.RoomNumber} | " +
                $"Incheckning: {booking.CheckIn:yyyy-MM-dd} | " +
                $"Utcheckning: {booking.CheckOut:yyyy-MM-dd}");
        }
    }

    private void ShowAllRooms()
    {
        var rooms = _repository.GetAllRooms();

        Console.WriteLine("\n=== ALLA RUM ===");

        if (rooms.Count == 0)
        {
            Console.WriteLine("Det finns inga rum registrerade.");
            return;
        }

        foreach (var room in rooms)
        {
            Console.WriteLine(
                $"Rum: {room.RoomNumber} | " +
                $"Våning: {room.Floor} | " +
                $"Rumstyp: {room.RoomType.Name} | " +
                $"Pris per natt: {room.PricePerNight:N0} kr");
        }
    }

    private void BookRoom()
    {
        Console.WriteLine("\n=== BOKA RUM ===");

        Console.Write("Ange gästens namn: ");
        string? name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Namnet kan inte vara tomt.");
            return;
        }

        Console.Write("Ange telefonnummer: ");
        string? telephoneNumber = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(telephoneNumber))
        {
            Console.WriteLine("Telefonnumret kan inte vara tomt.");
            return;
        }

        Console.Write("Ange antal gäster: ");
        string? guestsInput = Console.ReadLine();

        if (!int.TryParse(guestsInput, out int numberOfGuests) || numberOfGuests <= 0)
        {
            Console.WriteLine("Ange ett giltigt antal gäster.");
            return;
        }

        Console.Write("Ange incheckningsdatum (yyyy-MM-dd): ");
        string? checkInInput = Console.ReadLine();

        if (!DateTime.TryParseExact(
            checkInInput,
            "yyyy-MM-dd",
            null,
            System.Globalization.DateTimeStyles.None,
            out DateTime checkIn))
        {
            Console.WriteLine("Ogiltigt datum.");
            return;
        }

        Console.Write("Ange utcheckningsdatum (yyyy-MM-dd): ");
        string? checkOutInput = Console.ReadLine();

        if (!DateTime.TryParseExact(
            checkOutInput,
            "yyyy-MM-dd",
            null,
            System.Globalization.DateTimeStyles.None,
            out DateTime checkOut))
        {
            Console.WriteLine("Ogiltigt datum.");
            return;
        }

        if (checkIn.Date < DateTime.Today)
        {
            Console.WriteLine("Incheckningsdatum kan inte vara i dåtid.");
            return;
        }

        if (checkOut.Date <= checkIn.Date)
        {
            Console.WriteLine("Utcheckningsdatum måste vara efter incheckningsdatum.");
            return;
        }

        var availableRooms = _repository.GetAvailableRooms(checkIn, checkOut);

        Console.WriteLine("\n=== LEDIGA RUM ===");

        if (availableRooms.Count == 0)
        {
            Console.WriteLine("Det finns inga lediga rum under dessa datum.");
            return;
        }

        foreach (var room in availableRooms)
        {
            Console.WriteLine(
                $"Rum: {room.RoomNumber} | " +
                $"Våning: {room.Floor} | " +
                $"Rumstyp: {room.RoomType.Name} | " +
                $"Storlek: {room.SizeM2:N0} m² | " +
                $"Pris per natt: {room.PricePerNight:N0} kr");
        }

        Console.Write("\nVälj rumsnummer: ");

        if (!int.TryParse(Console.ReadLine(), out int selectedRoomNumber))
        {
            Console.WriteLine("Ogiltigt rumsnummer.");
            return;
        }

        var selectedRoom = availableRooms.FirstOrDefault(
            room => room.RoomNumber == selectedRoomNumber);

        if (selectedRoom == null)
        {
            Console.WriteLine("Det valda rummet är inte tillgängligt.");
            return;
        }

        int numberOfNights = (checkOut.Date - checkIn.Date).Days;

        decimal totalPrice = selectedRoom.PricePerNight * numberOfNights;

        Console.WriteLine("\n=== BOKNINGSSAMMANFATTNING ===");
        Console.WriteLine($"Gäst: {name}");
        Console.WriteLine($"Telefonnummer: {telephoneNumber}");
        Console.WriteLine($"Antal gäster: {numberOfGuests}");
        Console.WriteLine($"Rum: {selectedRoom.RoomNumber}");
        Console.WriteLine($"Rumstyp: {selectedRoom.RoomType.Name}");
        Console.WriteLine($"Incheckning: {checkIn:yyyy-MM-dd}");
        Console.WriteLine($"Utcheckning: {checkOut:yyyy-MM-dd}");
        Console.WriteLine($"Antal nätter: {numberOfNights}");
        Console.WriteLine($"Pris per natt: {selectedRoom.PricePerNight:N0} kr");
        Console.WriteLine($"Totalt pris: {totalPrice:N0} kr");

        Console.Write("\nVill du bekräfta bokningen? (J/N): ");
        string? confirmation = Console.ReadLine();

        if (confirmation?.ToUpper() != "J")
        {
            Console.WriteLine("Bokningen avbröts.");
            return;
        }

        Console.WriteLine("Bokningen har bekräftats!");
    }
}
