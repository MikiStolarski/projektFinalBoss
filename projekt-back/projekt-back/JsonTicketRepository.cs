using System.Text.Json;

namespace projekt_back;

public class JsonTicketRepository : ITicketRepository
{
    private readonly string _filePath = "tickets.json";
 
    public async Task AddAsync(ServiceTicket ticket)
    {
        var tickets = await GetAllAsync();
 
        tickets.Add(ticket);
 
        var json = JsonSerializer.Serialize(
            tickets,
            new JsonSerializerOptions
            {
                WriteIndented = true
            });
 
        await File.WriteAllTextAsync(_filePath, json);
    }
 
    public async Task<List<ServiceTicket>> GetAllAsync()
    {
        if (!File.Exists(_filePath))
            return new List<ServiceTicket>();
 
        var json = await File.ReadAllTextAsync(_filePath);
 
        return JsonSerializer.Deserialize<List<ServiceTicket>>(json)
               ?? new List<ServiceTicket>();
    }
}