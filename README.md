# Hotel Grandioso — Inlämning 1

**Namn:** Luvinda Sanchana Weerasinghe

## Databas

- Databas: SQLite
- Migrationer: Entity Framework Core 10. Databasen skapas och uppdateras med Entity Framework Core migrations


## UML-klassdiagram

```mermaid
classDiagram
    class Room {
        +int RoomId
        +int RoomNumber
        +int Floor
        +double SizeM2
        +decimal PricePerNight
        +int RoomTypeId
    }

    class RoomType {
        +int RoomTypeId
        +string Name
        +string Description
    }

    class Guest {
        +int GuestId
        +string Name
        +string TelephoneNumber
    }

    class Booking {
        +int BookingId
        +int GuestId
        +int RoomId
        +DateTime CheckIn
        +DateTime CheckOut
        +int NumberOfGuests
    }

    class HotelContext
    class IHotelRepository
    class HotelRepository
    class Menu

    RoomType "1" --> "*" Room
    Room "1" --> "*" Booking
    Guest "1" --> "*" Booking

    HotelRepository ..|> IHotelRepository
    HotelRepository --> HotelContext
    Menu --> IHotelRepository
    HotelContext --> Room
    HotelContext --> RoomType
    HotelContext --> Guest
    HotelContext --> Booking
```

## GDPR


Utvärdera fälten i `Guest` ett i taget. Vad bygger du in, och varför?

>

## Designmönster

Beskriv det designmönster du använt (till exempel Repository), vad det gör och varför du valde det.

>

## Tekniker

- C# / .NET 10
- Entity Framework Core
