namespace tickethub.Models;

public class Event
{
    public int Id { get; set; }
    public string? Title { get; set; }
    
    public string? Location { get; set; }

    public string? Date { get; set; }

    public int Price { get; set; }

    public string? Description { get; set; }
    // public List<Seating>? SeatingSections { get; set; }
    // public List<Seating>? AvailableSeatingSections { get; set; }
}

public class Seating
{
    public int Id { get; set; }
    public List<int>? Seats { get; set; }
}
