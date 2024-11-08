using System;

public class RoomBookingSystem
{
    public void BookRoom()
    {
        Console.WriteLine("Room has been booked.");
    }

    public void CheckAvailability()
    {
        Console.WriteLine("Checking room availability...");
    }

    public void CancelBooking()
    {
        Console.WriteLine("Room booking has been canceled.");
    }
}

public class RestaurantSystem
{
    public void BookTable()
    {
        Console.WriteLine("Table has been booked in the restaurant.");
    }

    public void OrderFood()
    {
        Console.WriteLine("Food has been ordered.");
    }
}

public class EventManagementSystem
{
    public void BookEventHall()
    {
        Console.WriteLine("Event hall has been booked.");
    }

    public void OrderEquipment()
    {
        Console.WriteLine("Equipment has been ordered for the event.");
    }
}

public class CleaningService
{
    public void ScheduleCleaning()
    {
        Console.WriteLine("Room cleaning has been scheduled.");
    }

    public void PerformCleaning()
    {
        Console.WriteLine("Cleaning in progress...");
    }
}

public class TaxiService
{
    public void OrderTaxi()
    {
        Console.WriteLine("Taxi has been ordered.");
    }
}

public class HotelFacade
{
    private RoomBookingSystem _roomBookingSystem;
    private RestaurantSystem _restaurantSystem;
    private EventManagementSystem _eventManagementSystem;
    private CleaningService _cleaningService;
    private TaxiService _taxiService;

    public HotelFacade()
    {
        _roomBookingSystem = new RoomBookingSystem();
        _restaurantSystem = new RestaurantSystem();
        _eventManagementSystem = new EventManagementSystem();
        _cleaningService = new CleaningService();
        _taxiService = new TaxiService();
    }

    public void BookRoomWithServices()
    {
        Console.WriteLine("Starting room booking with additional services...");
        _roomBookingSystem.BookRoom();
        _restaurantSystem.OrderFood();
        _cleaningService.ScheduleCleaning();
        Console.WriteLine("Room booking with additional services completed.");
    }

    public void OrganizeEvent()
    {
        Console.WriteLine("Organizing an event...");
        _eventManagementSystem.BookEventHall();
        _eventManagementSystem.OrderEquipment();
        _roomBookingSystem.BookRoom();
        Console.WriteLine("Event organization completed.");
    }

    public void BookRestaurantTableWithTaxi()
    {
        Console.WriteLine("Booking a table in the restaurant with taxi service...");
        _restaurantSystem.BookTable();
        _taxiService.OrderTaxi();
        Console.WriteLine("Table and taxi booked successfully.");
    }

    public void CancelAllBookings()
    {
        Console.WriteLine("Canceling all bookings...");
        _roomBookingSystem.CancelBooking();
        Console.WriteLine("All bookings canceled.");
    }

    public void RequestCleaning()
    {
        Console.WriteLine("Requesting immediate cleaning...");
        _cleaningService.PerformCleaning();
        Console.WriteLine("Immediate cleaning requested.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        HotelFacade hotelFacade = new HotelFacade();

        hotelFacade.BookRoomWithServices();
        Console.WriteLine();

        hotelFacade.OrganizeEvent();
        Console.WriteLine();

        hotelFacade.BookRestaurantTableWithTaxi();
        Console.WriteLine();

        hotelFacade.CancelAllBookings();
        Console.WriteLine();

        hotelFacade.RequestCleaning();
    }
}
