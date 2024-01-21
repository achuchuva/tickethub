import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import BookConfirmation from './BookConfirmation';
import ClickableSection from './ClickableSection';

function BookEvent() {
  const { eventId } = useParams();
  const [event, setEvent] = useState({});
  const [loading, setLoading] = useState(true);
  const [ticketCount, setTicketCount] = useState(0);
  const [potentialSeats, setPotentialSeats] = useState([]);
  const [selectedSeats, setSelectedSeats] = useState([]);
  const [totalPrice, setTotalPrice] = useState(0);
  const [hasBooked, setBooked] = useState(false);
  const [sectionId, setSectionId] = useState(1);

  useEffect(() => {
    const getEvent = async () => {
      try {
        const response = await fetch(`api/event/${eventId}`);
        const data = await response.json();
        setEvent(data);
        setLoading(false);
      } catch (error) {
        console.error('Error fetching event:', error);
        setLoading(false);
      }
    };

    getEvent();
  }, [eventId]);

  useEffect(() => {
    const updateSeatList = async () => {
      try {
        const response = await fetch(`api/seat?eventId=${eventId}&sectionId=${sectionId}`);
        const data = await response.json();
        setPotentialSeats(data);
      } catch (error) {
        console.error('Error fetching event:', error);
      }
    }

    updateSeatList();
  }, [eventId, sectionId]);

  function handleSubmit() {
    if (ticketCount === 0) {
      alert(`You cannot book ${ticketCount} tickets. Please select another quantity.`);
      return;
    }

    let price = 0;
    selectedSeats.forEach((section) => {
      section.seats.forEach((seat) => {
        price += seat.price;
      });
    });

    setTotalPrice(price);
    setBooked(true);
  }

  function addSelectedSeat(seat) {
    let newSelectedSeats = [...selectedSeats];

    if (newSelectedSeats.some(obj => obj.id === sectionId)) {
      const section = newSelectedSeats.find(obj => obj.id === sectionId);
      if (!section.seats.some(obj => obj.id === seat.id)) {
        section.seats.push(seat);
        setTicketCount(prevTicketCount => prevTicketCount + 1);
      }
    } else {
      const newSection = {
        id: sectionId,
        booked: false,
        seats: [seat],
      };

      newSelectedSeats.push(newSection);
      setTicketCount(prevTicketCount => prevTicketCount + 1);
    }
    setSelectedSeats(newSelectedSeats);
  }

  const contents = loading ? (
    <div className="booking-description">
      <p>
        <em>Loading...</em>
      </p>
    </div>
  ) : (
    <div className="booking-description">
      <h1>{event.title}</h1>
      <p>{event.description}</p>
      <ul>
        <li>{event.date}</li>
        <li>{event.location}</li>
      </ul>
      <h2>Section {sectionId} Tickets</h2>
      <h3>Select Seats</h3>
      {
        <div>
          <ul>
            {potentialSeats.map((seat) => (
              <li className="clickable" onClick={() => addSelectedSeat(seat)}>
                Seat {seat.id} - Price ${seat.price}
              </li>
            )
            )}
          </ul>
          {potentialSeats.length === 0 && <p><em>Sorry, this section is booked out</em></p>}
        </div>
      }
      <h2>Your Selected Tickets</h2>
      <ul>
        {selectedSeats.map((section) => (
          section.seats.map((seat) => (
            <li key={`${section.id}-${seat.id}`}>
              Section {section.id} - Seat {seat.id} - Price ${seat.price}
            </li>
          ))
        ))}
      </ul>
      <button onClick={handleSubmit}>BOOK TICKETS</button>
    </div>
  );

  return (
    <>
      {hasBooked ? (
        <BookConfirmation eventId={eventId} ticketCount={ticketCount}
          seatingSections={selectedSeats} title={event.title}
          totalPrice={totalPrice} returnToEvent={() => setBooked(false)} />
      ) : (
        <div className="book-event">
          {!loading &&
            <div className="seating-plan">
              {
                event.seatingSections.map((section) => (
                  <>
                    <ClickableSection key={section.id} id={section.id} openSection={(id) => setSectionId(id)} />
                  </>
                ))
              }
            </div>
          }
          {contents}
        </div>
      )}
    </>
  );
};

export default BookEvent;
