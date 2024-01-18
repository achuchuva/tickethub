using tickethub.Models;

namespace tickethub.Services;

public static class EventService
{
    static List<Event> Events { get; }
    static int nextId = 4;
    static EventService()
    {
        List<Seating> seatings = new List<Seating>();
        seatings.Add(new Seating { Id = 1, Seats = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 } });
        seatings.Add(new Seating { Id = 2, Seats = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 } });
        seatings.Add(new Seating { Id = 3, Seats = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 } });
        seatings.Add(new Seating { Id = 4, Seats = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 } });
        seatings.Add(new Seating { Id = 5, Seats = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 } });

        Events = new List<Event>
        {
            new Event { Id = 1, Title = "Rod Laver Arena Reserved Seat", Date = new DateOnly(2023, 1, 20).ToLongDateString(), Location = "Rod Laver Arena, Melbourne, VIC", Price = 60,
                Description = "Experience the magic of Rod Laver Arena, where tennis hits different! Named after Australia's Grand Slam icon, this monumental arena with 15,000 seats sets the stage for thrilling day and night sessions every day of the Australian Open." },
                // SeatingSections = seatings },
            new Event { Id = 2, Title = "Margaret Court Arena Reserved Seat", Date = new DateOnly(2023, 1, 21).ToLongDateString(), Location = "Margaret Court Arena, Melbourne, VIC", Price = 70,
                Description = "With seating for 7,500 spectators, Margaret Court Arena offers a close-up view of world-class tennis. This iconic arena is where emerging talents and seasoned champions shine in both night and day sessions." },
                // SeatingSections = seatings },
            new Event { Id = 3, Title = "John Cain Arena Reserved Seat", Date = new DateOnly(2023, 1, 22).ToLongDateString(), Location = "John Cain Arena, Melbourne, VIC", Price = 45,
                Description = "Brace yourself for electrifying vibes and an unforgettable atmosphere in John Cain Arena, aka the 'People's Court'. this 10,500-seater brings you close to big tennis stars with daily sessions until Monday 22 January." },
                // SeatingSections = seatings },
            new Event { Id = 4, Title = "Australia Open Ground Pass", Date = new DateOnly(2023, 1, 23).ToLongDateString(), Location = "Australia Open Tennis Courts, Melbourne, VIC", Price = 30,
                Description = "Embark on an iconic Melbourne Park adventure with the Ground Pass! Explore the incredible world of food, beverages and entertainment on Grand Slam Oval, catch tennis up close in Kia Arena and the Western Courts, or relax while enjoying a big-screen view." },
                // SeatingSections = seatings },
        };
    }

    public static List<Event> GetAll() => Events;

    public static Event? Get(int id) => Events.FirstOrDefault(p => p.Id == id);

    public static void Add(Event Event)
    {
        Event.Id = nextId++;
        Events.Add(Event);
    }

    public static void Delete(int id)
    {
        var Event = Get(id);
        if (Event is null)
            return;

        Events.Remove(Event);
    }

    public static void Update(Event Event)
    {
        var index = Events.FindIndex(p => p.Id == Event.Id);
        if (index == -1)
            return;

        Events[index] = Event;
    }
}