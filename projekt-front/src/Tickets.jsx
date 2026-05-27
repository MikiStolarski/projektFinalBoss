import { useEffect, useState } from "react";
 
export default function TicketList() {
  const [tickets, setTickets] = useState([]);
 
  useEffect(() => {
    fetch("http://localhost:5041/api/tickets")
      .then((res) => res.json())
      .then((data) => setTickets(data));
  }, []);
 
  return (
<div className="p-6">
      {tickets.map((ticket) => (
<div
          key={ticket.id}
          className="border p-4 mb-4"
>
<h2 className="font-bold">
            {ticket.fullName}
</h2>
 
          <p>{ticket.description}</p>
 
          <span>{ticket.category}</span>

          <p>{ticket.createTime}</p>
</div>
      ))}
</div>
  );
}