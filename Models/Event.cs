namespace tickethub.Models;

public class Event
{
    public Event()
    {
        Title = Location = Date = Description = "";
        SeatingSections = new List<Section>();
    }

    public int Id { get; set; }
    public string Title { get; set; }
    public string Location { get; set; }
    public string Date { get; set; }
    public string Description { get; set; }
    public List<Section> SeatingSections { get; set; }
    public bool IsFullyBooked { get; set; }
}

public class Section
{
    public Section()
    {
        Seats = new List<Seat>();
    }

    public int Id { get; set; }
    public bool Booked { get; set; }
    public List<Seat> Seats { get; set; }
}

public class Seat
{
    public Seat()
    {
        FirstName = LastName = Code = "";
    }

    public int Id { get; set; }
    public bool Booked { get; set; }
    public int Price { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Code { get; set; }
}
