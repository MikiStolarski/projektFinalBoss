const BASE_URL = "http://localhost:5041/api/tickets";
 
export async function getTickets()
{
    const response = await fetch(BASE_URL);
 
    if (!response.ok)
    {
        throw new Error("Nie załadowane");
    }
 
    return await response.json();
}
 
export async function createTicket(ticket)
{
    const response = await fetch(BASE_URL,
    {
        method: "POST",
        headers:
        {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(ticket)
    });
 
    if (!response.ok)
    {
        const errorData = await response.json();
        throw errorData;
    }
 
    return await response.json();
}