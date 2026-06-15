using System.Threading.Tasks;

namespace Client.API
{
    public interface IExternalApiService
    {
        Task NotifyBlockedClientAsync(int clientId);
    }
}
