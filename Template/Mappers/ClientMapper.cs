using Client.API.DTO;

namespace Client.API.Mappers
{
    public static class ClientMapper
    {
        public static Entities.Client ToEntity(CreateClientDto clientDto)
        {
            return new Entities.Client
            {
                Name = clientDto.Name,
                Email = clientDto.Email,
                CpfNumber = clientDto.CpfNumber,
                PhoneNumber = clientDto.PhoneNumber
            };
        }

        public static DetailsClientDto ToDetailsDto(Entities.Client client)
        {
            return new DetailsClientDto
            {
                Id = client.Id,
                Name = client.Name,
                Email = client.Email,
                CpfNumber = client.CpfNumber,
                PhoneNumber = client.PhoneNumber,
                Status = client.Status.ToString(),
            };
        }
    }
}
