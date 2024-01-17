import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';

function BookEvent() {
  const { eventId } = useParams();
  const [event, setEvent] = useState({});
  const [loading, setLoading] = useState(true);

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
        <li>${event.price}</li>
      </ul>
      <button>BOOK NOW</button>
    </div>
  );

  return (
    <div>
      <div>
        <img src={"./sampleseatingmap.png"} alt={"Sample seating plan"} />
      </div>
      {contents}
    </div>
  );
};

export default BookEvent;
