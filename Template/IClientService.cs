using Client.API.DTO;
using Client.API.Enums;

namespace Client.API;

public interface IClientService
{
    public Task<List<DetailsClientDto>> GetAllAsync();
    public Task<DetailsClientDto?> UpdateStatusAsync(int id, ClientStatus status);
    public Task<DetailsClientDto> CreateAsync(CreateClientDto clientDto);
}