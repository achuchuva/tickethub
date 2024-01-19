namespace tickethub.Models;

public class Order
{
    public Order()
    {
        Code = "";
        SeatingSections = new List<Section>();
    }

    public int Id { get; set; }
    public int EventId { get; set; }
    public int TicketCount { get; set; }
    public string Code { get; set; }
    public List<Section> SeatingSections { get; set; }
    public int TotalPrice { get; set; }
}
