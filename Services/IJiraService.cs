using Models;
using Services.Reflection;
namespace Services;

public interface IJiraService
{
    JiraTicket GetTicket(string ticketId);
}

[TransientService]
public class JiraService : IJiraService
{
    public JiraTicket GetTicket(string ticketId)
    {
        return new JiraTicket();
    }
}
