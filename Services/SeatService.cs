using tickethub.Models;

namespace tickethub.Services;

public static class SeatService
{
    public static List<Seat>? GetAvailableSeats(int eventId, int sectionId)
    {
        Event? evnt = EventService.Get(eventId);

        if (evnt is null)
            return null;

        Section? section = evnt.SeatingSections.FirstOrDefault(s => s.Id == sectionId);

        if (section is null)
            return null;

        List<Seat> seats = new List<Seat>();
        foreach(Seat seat in section.Seats)
        {
            if (!seat.Booked)
            {
                seats.Add(seat);
            }
        }

        return seats;
    }

    public static void UpdateFullyBooked(int eventId)
    {
        Event? evnt = EventService.Get(eventId);

        if (evnt is null)
            return;

        foreach (Section section in evnt.SeatingSections)
        {
            foreach (Seat seat in section.Seats)
            {
                if (!seat.Booked)
                {
                    return;
                }
            }

            section.Booked = true;
        }

        evnt.IsFullyBooked = true;
    }
}