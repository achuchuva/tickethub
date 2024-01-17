using Microsoft.AspNetCore.Mvc;
using tickethub.Models;
using tickethub.Services;

namespace tickethub.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventController : ControllerBase
{
    public EventController()
    {

    }

    [HttpGet]
    public ActionResult<List<Event>> GetAll() =>
    EventService.GetAll();


    [HttpGet("{id}")]
    public ActionResult<Event> Get(int id)
    {
        var Event = EventService.Get(id);

        if (Event == null)
            return NotFound();

        return Event;
    }


    [HttpPost]
    public IActionResult Create(Event Event)
    {
        EventService.Add(Event);
        return CreatedAtAction(nameof(Get), new { id = Event.Id }, Event);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Event Event)
    {
        if (id != Event.Id)
            return BadRequest();

        var existingEvent = EventService.Get(id);
        if (existingEvent is null)
            return NotFound();

        EventService.Update(Event);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var Event = EventService.Get(id);

        if (Event is null)
            return NotFound();

        EventService.Delete(id);

        return NoContent();
    }
}
