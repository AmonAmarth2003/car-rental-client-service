using Client.API.Data;
using Client.API.DTO;
using Client.API.Enums;
using Client.API.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Client.API.Services
{
    internal class ClientService : IClientService
    {
        private readonly DataContext _dataContext;

        public ClientService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<DetailsClientDto>> GetAllAsync()
        {
            var clients = await _dataContext.Clients.ToListAsync();
            return clients.Select(ClientMapper.ToDetailsDto).ToList();
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

            await _dataContext.SaveChangesAsync();
            return ClientMapper.ToDetailsDto(client);
        }
    }
}