namespace projekt_back;

public class TicketService
{
    private readonly ITicketRepository _repository;
 
    public event TicketAddedHandler? TicketAdded;
 
    public TicketService(ITicketRepository repository)
    {
        _repository = repository;
    }
 
    public async Task AddTicketAsync(ServiceTicket ticket)
    {
        await _repository.AddAsync(ticket);
 
        TicketAdded?.Invoke(ticket);
    }
 
    public async Task<List<ServiceTicket>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }
}