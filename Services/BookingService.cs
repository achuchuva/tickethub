using tickethub.Models;

namespace tickethub.Services;

public static class BookingService
{
    public static void Update(Order order)
    {
        Event? evnt = EventService.Get(order.EventId);

        if (evnt?.SeatingSections is null)
            return;

        foreach (Section section in order.SeatingSections)
        {
            Section? eventSection = evnt.SeatingSections.FirstOrDefault(s => s.Id == section.Id);
            if (eventSection is not null)
            {
                foreach (Seat seat in eventSection.Seats)
                {
                    Seat? eventSeat = section.Seats.FirstOrDefault(s => s.Id == seat.Id);
                    if (eventSeat is not null)
                    {
                        seat.Booked = true;
                        seat.FirstName = order.FirstName;
                        seat.LastName = order.LastName;
                        seat.Code  = order.Code;
                    }
                }
            }
        }
    }
}