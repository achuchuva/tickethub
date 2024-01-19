using tickethub.Models;

namespace tickethub.Services;

public static class BookingService
{
    public static void Update(int eventId, int seatCount)
    {
        Event? evnt = EventService.Get(eventId);

        if (evnt?.SeatingSections is null)
            return;

        int updatedSeats = 0;
        foreach (Section section in evnt.SeatingSections)
        {
            if (section.Seats != null)
            {
                foreach (Seat seat in section.Seats)
                {
                    if (!seat.Booked)
                    {
                        seat.Booked = true;
                        updatedSeats++;
                        if (updatedSeats >= seatCount)
                            return;
                    }
                }
            }
        }

    }
}