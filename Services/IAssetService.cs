using Models;
using Services.Reflection;
namespace Services;

public interface IAssetService
{
    ServiceNowTicket GetTicket(string ticketId);
}

[TransientService]

public class AssetService : IAssetService
{
    public ServiceNowTicket GetTicket(string ticketId)
    {
        return new ServiceNowTicket();
    }
}