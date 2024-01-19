using tickethub.Models;

namespace tickethub.Services;

public static class SeatService
{
    public static List<Section>? GetSeats(int eventId, int seatsCount)
    {
        Event? evnt = EventService.Get(eventId);

        if (evnt?.SeatingSections is null)
            return null;

        if (evnt.IsGeneralAdmission)
            return null;

        List<Section> seatingSection = new List<Section>();
        int seatsFound = 0;
        foreach (Section section in evnt.SeatingSections)
        {
            if (!section.Booked && section.Seats != null)
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
                            break; // Use break instead of continue to exit the inner loop
                        }
                    }
                }

                if (potentialSeats.Count > 0)
                {
                    // Add the original section with the potential seats
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
        return EventService.Get(id)?.SeatingSections?.FirstOrDefault(s => s.Id == id);
    }

    public static Seat? GetSeat(int id, int sectionId, int eventId)
    {
        return GetSection(sectionId, eventId)?.Seats?.FirstOrDefault(s => s.Id == id);
    }

    public static void UpdateFullyBooked(int eventId)
    {
        Event? evnt = EventService.Get(eventId);

        if (evnt?.SeatingSections is null)
            return;

        foreach (Section section in evnt.SeatingSections)
        {
            if (section.Seats != null)
            {
                foreach (Seat seat in section.Seats)
                {
                    if (!seat.Booked)
                    {
                        return;
                    }
                }
            }

            section.Booked = true;
        }

        evnt.IsFullyBooked = true;
    }
}