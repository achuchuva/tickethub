import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';

function BookConfirmation({ eventId, ticketCount, seatingSections, title, totalPrice, returnToEvent }) {
  const [fname, setFname] = useState("");
  const [lname, setLname] = useState("");
  const [email, setEmail] = useState("");
  const navigate = useNavigate();

  const handleSubmit = async (e) => {
    e.preventDefault();
    if (!window.confirm(`Do you confirm the purchase of ${ticketCount} tickets?`)) {
      return;
    }

    const response = await fetch('/api/order', {
      method: 'post',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({
        'eventId': eventId,
        'ticketCount': ticketCount,
        'firstName': fname,
        'lastName': lname,
        'email': email,
        'seatingSections': seatingSections,
        'totalPrice': totalPrice
      })
    });

    if (!response.ok) {
      alert(`Error: ${response.status} - ${response.statusText}`);
      return;
    }

    const data = await response.json();
    navigate(`/orders/${data.id}`);
  };

  return (
    <div>
      <button onClick={returnToEvent}>RETURN TO EVENT</button>
      <h1>Booking Confirmation for {title}</h1>
      <p>Tickets quantity: <strong>{ticketCount}</strong></p>
      <ul>
        {seatingSections.map((section) => (
          section.seats.map((seat) => (
            <li key={`${section.id}-${seat.id}`}>
              Section {section.id} - Seat {seat.id} - Price ${seat.price}
            </li>
          ))
        ))}
      </ul>
      <p>Total amount: <strong>${totalPrice}</strong></p>
      <p><em>&#40;Insert payment methods here&#41;</em></p>
      <p>Please provide name and email address</p>
      <label for="fname">First name:</label>
      <input type="text" id="fname" name="fname" onChange={e => setFname(e.target.value)} /><br /><br />
      <label for="lname">Last name:</label>
      <input type="text" id="lname" name="lname" onChange={e => setLname(e.target.value)} /><br /><br />
      <label for="email">Email:</label>
      <input type="email" id="email" name="email" onChange={e => setEmail(e.target.value)} /><br /><br />
      <button onClick={handleSubmit}>CONFIRM BOOKING</button>
    </div>
  );
};

export default BookConfirmation;
