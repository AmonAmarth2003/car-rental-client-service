using Client.API.Enums;

namespace Client.API.DTO
{
    public class DetailsClientDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CpfNumber { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Status { get; set; }
    }
}
