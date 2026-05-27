using System.Text.Json;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using projekt_back;
using Microsoft.AspNetCore.Mvc.Testing;

namespace TestProject2;

[TestClass]
public class ServiceTicketValidatorTests
{
    [TestMethod]
    public void Should_Return_False_When_Email_Is_Invalid()
    {
        var validator = new ServiceTicketValidator();

        var ticket = new ServiceTicket
        {
            FullName = "hans",
            Email = "leonid",
            Description = "Problemik z drukarkom",
            Category = ServiceTicketCategories.Hardware
        };

        var result = validator.Validate(ticket, out _);

        Assert.IsFalse(result);
    }
    
    [TestMethod]
    public async Task Should_Invoke_Delegate_When_Ticket_Added()
    {
        bool invoked = false;

        var repo = new JsonTicketRepository();

        var service = new TicketService(repo);

        service.TicketAdded += (ticket) =>
        {
            invoked = true;
        };

        await service.AddTicketAsync(new ServiceTicket());

        Assert.IsTrue(invoked);
    }
    
    [TestMethod]
    public void Should_Serialize_And_Deserialize()
    {
        var ticket = new ServiceTicket
        {
            FullName = "aaa",
            Email = "bbb@ccc",
            Description = "komputer padł",
            Category = ServiceTicketCategories.Hardware
        };

        var json = JsonSerializer.Serialize(ticket);

        var deserialized =
            JsonSerializer.Deserialize<ServiceTicket>(json);

        Assert.AreEqual(ticket.Email, deserialized?.Email);
    }
    
    [TestClass]
    public class TicketsApiTests
    {
        private readonly HttpClient _client;

        public TicketsApiTests()
        {
            var factory =
                new WebApplicationFactory<Program>();

            _client = factory.CreateClient();
        }

        [TestMethod]
        public async Task Get_Should_Return_Success()
        {
            var response = await _client.GetAsync("/api/tickets");

            Assert.IsTrue(response.IsSuccessStatusCode);
        }
    }
}

