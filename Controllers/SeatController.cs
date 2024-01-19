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
    public ActionResult<List<Section>> Get(int eventId, int seatsCount)
    {
        List<Section>? SeatingSection = SeatService.GetSeats(eventId, seatsCount);

        if (SeatingSection == null)
            return NotFound();

        return SeatingSection;
    }
}
