using Microsoft.AspNetCore.Mvc;

namespace projekt_back;

[ApiController]
[Route("api/[controller]")]
public class TicketsController : ControllerBase
{
    private readonly TicketService _ticketService;
    private readonly ServiceTicketValidator _validator;

    public TicketsController(
        TicketService ticketService,
        ServiceTicketValidator validator)
    {
        _ticketService = ticketService;
        _validator = validator;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var tickets = await _ticketService.GetAllAsync();

            return Ok(tickets);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create(ServiceTicket ticket)
    {
        try
        {
            if (!_validator.Validate(ticket, out var errors))
            {
                return BadRequest(errors);
            }

            var newTicket = new ServiceTicket
            {
                Id = Guid.NewGuid(),
                FullName = ticket.FullName,
                Email = ticket.Email,
                Description = ticket.Description,
                Category = ticket.Category,
                CreatedAt = DateTime.UtcNow
            };

            await _ticketService.AddTicketAsync(newTicket);

            return Ok(newTicket);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}