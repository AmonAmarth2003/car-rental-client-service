using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Client.API
{
    internal class ExternalApiService : IExternalApiService
    {
        private readonly HttpClient _httpClient;

        public ExternalApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task NotifyBlockedClientAsync(int clientId)
        {
            var payload = new { clientId };
            var response = await _httpClient.PutAsJsonAsync("/rentals/blocked-status", payload);
            response.EnsureSuccessStatusCode();
        }
    }
}
