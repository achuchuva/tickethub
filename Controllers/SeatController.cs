using Microsoft.AspNetCore.Mvc;
using tickethub.Models;
using tickethub.Services;

namespace tickethub.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SeatController : ControllerBase
{
    public SeatController()
    {

    }

    [HttpGet]
    public ActionResult<List<Seat>> GetSeats(int eventId, int sectionId)
    {
        List<Seat>? seats = SeatService.GetAvailableSeats(eventId, sectionId);

        if (seats == null)
            return NotFound();

        return seats;
    }
}
