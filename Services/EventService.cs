using tickethub.Models;

namespace tickethub.Services;

public static class EventService
{
    static List<Event> events { get; }
    static int nextId = 5;
    static EventService()
    {
        List<Section> seatings1 = new List<Section>();
        for (int i = 1; i <= 4; i++)
        {
            List<Seat> seats = new List<Seat>();
            for (int j = 1; j <= 3; j++)
            {
                seats.Add(new Seat { Id = j, Booked = false, Price = 90 });
            }
            seatings1.Add(new Section { Id = i, Booked = false, Seats = seats });
        }

        List<Section> seatings2 = new List<Section>();
        for (int i = 1; i <= 3; i++)
        {
            List<Seat> seats = new List<Seat>();
            for (int j = 1; j <= 4; j++)
            {
                seats.Add(new Seat { Id = j, Booked = false, Price = 90 });
            }
            seatings2.Add(new Section { Id = i, Booked = false, Seats = seats });
        }

        List<Section> seatings3 = new List<Section>();
        for (int i = 1; i <= 2; i++)
        {
            List<Seat> seats = new List<Seat>();
            for (int j = 1; j <= 5; j++)
            {
                seats.Add(new Seat { Id = j, Booked = false, Price = 90 });
            }
            seatings3.Add(new Section { Id = i, Booked = false, Seats = seats });
        }


        events = new List<Event>
        {
            new Event { Id = 1, Title = "Rod Laver Arena Reserved Seat", Date = new DateOnly(2023, 1, 20).ToLongDateString(), Location = "Rod Laver Arena, Melbourne, VIC", Price = 90,
                Description = "Experience the magic of Rod Laver Arena, where tennis hits different! Named after Australia's Grand Slam icon, this monumental arena with 15,000 seats sets the stage for thrilling day and night sessions every day of the Australian Open.",
                SeatingSections = seatings1 },
            new Event { Id = 2, Title = "Margaret Court Arena Reserved Seat", Date = new DateOnly(2023, 1, 21).ToLongDateString(), Location = "Margaret Court Arena, Melbourne, VIC", Price = 90,
                Description = "With seating for 7,500 spectators, Margaret Court Arena offers a close-up view of world-class tennis. This iconic arena is where emerging talents and seasoned champions shine in both night and day sessions.",
                SeatingSections = seatings2 },
            new Event { Id = 3, Title = "John Cain Arena Reserved Seat", Date = new DateOnly(2023, 1, 22).ToLongDateString(), Location = "John Cain Arena, Melbourne, VIC", Price = 90,
                Description = "Brace yourself for electrifying vibes and an unforgettable atmosphere in John Cain Arena, aka the 'People's Court'. this 10,500-seater brings you close to big tennis stars with daily sessions until Monday 22 January.",
                SeatingSections = seatings3 },
            new Event { Id = 4, Title = "Australia Open Ground Pass", Date = new DateOnly(2023, 1, 23).ToLongDateString(), Location = "Australia Open Tennis Courts, Melbourne, VIC", Price = 30, IsGeneralAdmission = true,
                Description = "Embark on an iconic Melbourne Park adventure with the Ground Pass! Explore the incredible world of food, beverages and entertainment on Grand Slam Oval, catch tennis up close in Kia Arena and the Western Courts, or relax while enjoying a big-screen view."},
        };
    }

    public static List<Event> GetAll() => events;

    public static Event? Get(int id) => events.FirstOrDefault(p => p.Id == id);

    public static void Add(Event evnt)
    {
        evnt.Id = nextId++;
        events.Add(evnt);
    }

    public static void Delete(int id)
    {
        var evnt = Get(id);
        if (evnt is null)
            return;

        events.Remove(evnt);
    }

    public static void Update(Event evnt)
    {
        var index = events.FindIndex(p => p.Id == evnt.Id);
        if (index == -1)
            return;

        events[index] = evnt;
    }
}