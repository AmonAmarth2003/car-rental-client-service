using Microsoft.EntityFrameworkCore;
using Template.Data;
using Template.Entities;
using Template.Enums;

namespace Template.Services
{
    internal class ClientService : IClientService
    {
        private readonly DataContext _dataContext;

        public ClientService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Client>> GetAllAsync()
        {
            return await _dataContext.Clients.ToListAsync();
        }

        public async Task<Client> CreateAsync(Client client)
        {
            client.Status = ClientStatus.Active; // default

            _dataContext.Clients.Add(client);
            await _dataContext.SaveChangesAsync();

            return client;
        }

        public async Task<Client?> UpdateStatusAsync(int id, ClientStatus status)
        {
            var client = await _dataContext.Clients.FindAsync(id);
            if (client == null) return null;

            client.Status = status;

            await _dataContext.SaveChangesAsync();
            return client;
        }
    }
}