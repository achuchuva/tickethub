using tickethub.Models;

namespace tickethub.Services;

public static class SeatService
{
    public static List<Section>? GetSeats(int eventId, int seatsCount)
    {
        Event? evnt = EventService.Get(eventId);

        if (evnt is null)
            return null;

        List<Section> seatingSection = new List<Section>();
        int seatsFound = 0;
        foreach (Section section in evnt.SeatingSections)
        {
            if (!section.Booked)
            {
                List<Seat> potentialSeats = new List<Seat>();

                foreach (Seat seat in section.Seats)
                {
                    if (!seat.Booked)
                    {
                        potentialSeats.Add(seat);
                        seatsFound++;
                        if (seatsFound == seatsCount)
                        {
                            break;
                        }
                    }
                }

                if (potentialSeats.Count > 0)
                {
                    seatingSection.Add(new Section { Id = section.Id, Seats = potentialSeats });
                }

                if (seatsFound == seatsCount)
                {
                    return seatingSection;
                }
            }
        }

        return new List<Section>();
    }

    public static Section? GetSection(int id, int eventId)
    {
        return EventService.Get(id)?.SeatingSections.FirstOrDefault(s => s.Id == id);
    }

    public static Seat? GetSeat(int id, int sectionId, int eventId)
    {
        return GetSection(sectionId, eventId)?.Seats.FirstOrDefault(s => s.Id == id);
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