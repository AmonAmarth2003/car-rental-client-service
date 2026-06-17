using Client.API.Data;
using Client.API.DTO;
using Client.API.Enums;
using Client.API.Mappers;
using Client.API;
using Microsoft.EntityFrameworkCore;

namespace Client.API.Services
{
    internal class ClientService : IClientService
    {
        private readonly DataContext _dataContext;
        private readonly IExternalApiService _externalApiService;

        public ClientService(DataContext dataContext, IExternalApiService externalApiService)
        {
            _dataContext = dataContext;
            _externalApiService = externalApiService;
        }

        public async Task<List<DetailsClientDto>> GetAllAsync()
        {
            var clients = await _dataContext.Clients.ToListAsync();
            return clients.Select(ClientMapper.ToDetailsDto).ToList();
        }

        public async Task<DetailsClientDto?> GetByIdAsync(int id)
        {
            var client = await _dataContext.Clients.FindAsync(id);
            return client == null ? null : ClientMapper.ToDetailsDto(client);
        }

        public async Task<DetailsClientDto> CreateAsync(CreateClientDto clientDto)
        {
            var client = ClientMapper.ToEntity(clientDto);
            client.Status = ClientStatus.Active;

            _dataContext.Clients.Add(client);
            await _dataContext.SaveChangesAsync();

            return ClientMapper.ToDetailsDto(client);
        }

        public async Task<DetailsClientDto?> UpdateStatusAsync(int id, ClientStatus status)
        {
            var client = await _dataContext.Clients.FindAsync(id);
            if (client == null) return null;

            client.Status = status;

            
            if (status == ClientStatus.Blocked)
            {
                try
                {
                    await _externalApiService.NotifyBlockedClientAsync(client.Id);
                }
                catch (Exception)
                {
                    throw;
                }
            }
            
            await _dataContext.SaveChangesAsync();
            return ClientMapper.ToDetailsDto(client);
        }
    }
}