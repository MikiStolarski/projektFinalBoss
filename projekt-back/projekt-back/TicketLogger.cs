namespace projekt_back;

public class TicketLogger
{
    public void Log(ServiceTicket ticket)
    {
        Console.WriteLine(
            $"Added ticket: {ticket.Id}"
        );
    }
}