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
    public IActionResult Create(Event evnt)
    {
        EventService.Add(evnt);
        return CreatedAtAction(nameof(Get), new { id = evnt.Id }, evnt);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Event evnt)
    {
        if (id != evnt.Id)
            return BadRequest();

        var existingEvent = EventService.Get(id);
        if (existingEvent is null)
            return NotFound();

        EventService.Update(evnt);

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
