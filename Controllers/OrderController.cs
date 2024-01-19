using Microsoft.AspNetCore.Mvc;
using tickethub.Models;
using tickethub.Services;

namespace tickethub.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    public OrderController()
    {

    }

    [HttpGet]
    public ActionResult<List<Order>> GetAll() =>
    OrderService.GetAll();


    [HttpGet("{id}")]
    public ActionResult<Order> Get(int id)
    {
        var order = OrderService.Get(id);

        if (order == null)
            return NotFound();

        return order;
    }

    [HttpPost]
    public IActionResult Create(Order order)
    {
        OrderService.Add(order);
        BookingService.Update(order.EventId, order.TicketCount);
        SeatService.UpdateFullyBooked(order.EventId);
        return CreatedAtAction(nameof(Get), new { id = order.Id }, order);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Order order)
    {
        if (id != order.Id)
            return BadRequest();

        var existingOrder = OrderService.Get(id);
        if (existingOrder is null)
            return NotFound();

        OrderService.Update(order);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var Order = OrderService.Get(id);

        if (Order is null)
            return NotFound();

        OrderService.Delete(id);

        return NoContent();
    }
}
