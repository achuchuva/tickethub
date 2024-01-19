namespace tickethub.Models;

public class Order
{
    public Order()
    {
        Code = FirstName = LastName = Email = "";
        SeatingSections = new List<Section>();
    }

    public int Id { get; set; }
    public int EventId { get; set; }
    public int TicketCount { get; set; }
    public string Code { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public List<Section> SeatingSections { get; set; }
    public int TotalPrice { get; set; }
}
