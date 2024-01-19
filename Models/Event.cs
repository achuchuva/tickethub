namespace tickethub.Models;

public class Event
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Location { get; set; }
    public string? Date { get; set; }
    public bool IsGeneralAdmission { get; set; }
    public int Price { get; set; }
    public string? Description { get; set; }
    public List<Section>? SeatingSections { get; set; }
    public bool IsFullyBooked { get; set; }
}

public class Section
{
    public int Id { get; set; }
    public bool Booked { get; set; }
    public List<Seat>? Seats { get; set; }
}

public class Seat
{
    public int Id { get; set; }
    public bool Booked { get; set; }
    public int Price { get; set; }
}
