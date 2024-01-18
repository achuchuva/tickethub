import React, { useState, useEffect } from 'react';
import { useParams, Link } from 'react-router-dom';

function BookSuccess() {
  const { orderId } = useParams();
  const [order, setOrder] = useState({});
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const getOrder = async () => {
      try {
        const response = await fetch(`api/order/${orderId}`);
        const data = await response.json();
        setOrder(data);
        setLoading(false);
      } catch (error) {
        console.error('Error fetching event:', error);
        setLoading(false);
      }
    };

    getOrder();
  }, [orderId]);

  return (
    <div>
      {loading ? (
        <div>
          <p>
            <em>Loading...</em>
          </p>
        </div>
      ) : (
        <div>
          <h1>Your order has been processed successfully.</h1>
          <p>Thank you for your purchase with TicketHub.</p>
          <p>Order code: <strong>{order.code}</strong></p>
          <p>Tickets purchased: <strong>{order.ticketCount}</strong></p>
          <Link to='/'>EXPLORE MORE EVENTS</Link>
        </div>
      )}
    </div>
  );
};

export default BookSuccess;
