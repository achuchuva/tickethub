using tickethub.Models;

namespace tickethub.Services;

public static class OrderService
{
    static List<Order> Orders { get; }
    static int nextId = 2;
    private static Random random = new Random();

    static OrderService()
    {
        Orders = new List<Order>
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

    public static List<Order> GetAll() => Orders;

    public static Order? Get(int id) => Orders.FirstOrDefault(o => o.Id == id);

    public static void Add(Order Order)
    {
        Order.Code = RandomString(10);
        Order.Id = nextId++;
        Orders.Add(Order);
    }

    public static void Delete(int id)
    {
        var Order = Get(id);
        if (Order is null)
            return;

        Orders.Remove(Order);
    }

    public static void Update(Order Order)
    {
        var index = Orders.FindIndex(o => o.Id == Order.Id);
        if (index == -1)
            return;

        Orders[index] = Order;
    }
}