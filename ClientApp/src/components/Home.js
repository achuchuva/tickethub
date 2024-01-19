import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';

function Home() {
  const [events, setEvents] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const getEvents = async () => {
      try {
        const response = await fetch('api/event');
        const data = await response.json();
        setEvents(data);
        setLoading(false);
      } catch (error) {
        console.error('Error fetching events:', error);
        setLoading(false);
      }
    };

    getEvents();
  }, []);

  const renderEvents = () => (
    <>
      {events.map((event) => (
        <div key={event.id}>
          <h2>{event.title}</h2>
          <p>{event.date}</p>
          <p>{event.location}</p>
          {event.isFullyBooked ? (
            <span className='button-disabled'>BOOKED OUT</span>
          ) : (
            <Link className="button-link" to={`/events/${event.id}`}>FIND TICKETS</Link>
          )}
        </div>
      ))}
    </>
  );

  const contents = loading ? <p><em>Loading...</em></p> : renderEvents();

  return (
    <div>
      <h1>Events available</h1>
      {contents}
    </div>
  );
};

export default Home;
