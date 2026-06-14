using Template.Entities;
using Template.Enums;

public interface IClientService
{
    public Task<List<Client>> GetAllAsync();
    public Task<Client?> UpdateStatusAsync(int id, ClientStatus status);
    public Task<Client> CreateAsync(Client client);
}