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
        var Order = OrderService.Get(id);

        if (Order == null)
            return NotFound();

        return Order;
    }

    [HttpPost]
    public IActionResult Create(Order Order)
    {
        OrderService.Add(Order);
        return CreatedAtAction(nameof(Get), new { id = Order.Id }, Order);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Order Order)
    {
        if (id != Order.Id)
            return BadRequest();

        var existingOrder = OrderService.Get(id);
        if (existingOrder is null)
            return NotFound();

        OrderService.Update(Order);

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
