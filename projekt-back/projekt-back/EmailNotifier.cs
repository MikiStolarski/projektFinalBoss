namespace projekt_back;

public class EmailNotifier
{
    public void Send(ServiceTicket ticket)
    {
        Console.WriteLine(
            $"Confirmation sent to {ticket.Email}"
        );
    }
}