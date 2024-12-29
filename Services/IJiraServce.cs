using Models;
namespace Services;

public interface IJiraServce
{
    JiraTicket GetTicket(string ticketId);
}
