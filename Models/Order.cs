namespace tickethub.Models;

public class Order
{
    public int Id { get; set; }
    public int EventId { get; set; }
    public int TicketCount { get; set; }
    public string? Code { get; set; }
}
