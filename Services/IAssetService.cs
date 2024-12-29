using Models;
namespace Services;

public interface IAssetService
{
    ServiceNowTicket GetTicket(string ticketId);
}
