using tickethub.Models;

namespace tickethub.Services;

public static class OrderService
{
    static List<Order> orders { get; }
    static int nextId = 2;
    private static Random random = new Random();

    static OrderService()
    {
        orders = new List<Order>
        {
            new Order { Id = 1, EventId = 4, TicketCount = 2, Code = RandomString(10)}
        };
    }

    public static string RandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }

    public static List<Order> GetAll() => orders;

    public static Order? Get(int id) => orders.FirstOrDefault(o => o.Id == id);

    public static void Add(Order order)
    {
        order.Code = RandomString(10);
        order.Id = nextId++;
        orders.Add(order);
    }

    public static void Delete(int id)
    {
        var Order = Get(id);
        if (Order is null)
            return;

        orders.Remove(Order);
    }

    public static void Update(Order order)
    {
        var index = orders.FindIndex(o => o.Id == order.Id);
        if (index == -1)
            return;

        orders[index] = order;
    }
}