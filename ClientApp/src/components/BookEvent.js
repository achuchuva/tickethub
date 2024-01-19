import React, { useState, useEffect } from 'react';
import { useParams, useNavigate } from 'react-router-dom';

function BookEvent() {
  const { eventId } = useParams();
  const [event, setEvent] = useState({});
  const [loading, setLoading] = useState(true);
  const [ticketCount, setTicketCount] = useState(1);
  const [seatingSection, setSeatingSection] = useState([]);
  const navigate = useNavigate();

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
        const response = await fetch(`api/seat?eventId=${eventId}&seatsCount=${ticketCount}`);
        const data = await response.json();
        setSeatingSection(data);
      } catch (error) {
        console.error('Error fetching event:', error);
      }
    }

    updateSeatList();
  }, [ticketCount, eventId]);

  const handleSubmit = async (e) => {
    e.preventDefault();
    if (seatingSection.length === 0) {
      alert(`You cannot book ${ticketCount} tickets. Please select another quantity.`);
      return;
    }
    const response = await fetch('/api/order', {
      method: 'post',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({
        'eventId': eventId,
        'ticketCount': ticketCount
      })
    });

    if (!response.ok) {
      alert(`Error: ${response.status} - ${response.statusText}`);
      return;
    }

    const data = await response.json();
    navigate(`/orders/${data.id}`);
  };

  function decrementTicketCount() {
    if (ticketCount > 0) {
      setTicketCount(ticketCount - 1);
    }
  }

  function incrementTicketCount() {
    if (ticketCount < 10) {
      setTicketCount(ticketCount + 1);
    }
  }

  const contents = loading ? (
    <div>
      <p>
        <em>Loading...</em>
      </p>
    </div>
  ) : (
    <div>
      <h1>{event.title}</h1>
      <p>{event.description}</p>
      <ul>
        <li>{event.date}</li>
        <li>{event.location}</li>
      </ul>
      <p>Quantity</p>
      <button onClick={decrementTicketCount} disabled={ticketCount === 1}>-</button>
      <span> {ticketCount} </span>
      <button onClick={incrementTicketCount} disabled={ticketCount === 10}>+</button>
      <h3>Available Tickets</h3>
      {event.isGeneralAdmission ? (
        <p><em>This is a general admission event</em></p>
      ) : (
        <div>
        <ul>
          {seatingSection.map((section) => (
            section.seats.map((seat) => (
              <li key={`${section.id}-${seat.id}`}>
                Section {section.id} - Seat {seat.id} - Price ${seat.price}
              </li>
            ))
          ))}
        </ul>
        {seatingSection.length === 0 && <p><em>Sorry, we couldn't find any results</em></p>}
        </div>
      )}
      <button onClick={handleSubmit}>BOOK TICKETS</button>
    </div>
  );

  return (
    <div>
      {contents}
      <div>
        <hr />
        <em>Visual representation of seating plan</em>
        <img src={"./sampleseatingmap.png"} alt={"Sample seating plan"} />
      </div>
    </div>
  );
};

export default BookEvent;
