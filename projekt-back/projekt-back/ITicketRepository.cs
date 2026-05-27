namespace projekt_back;

public interface ITicketRepository
{
    Task AddAsync(ServiceTicket ticket);

    Task<List<ServiceTicket>> GetAllAsync();
}