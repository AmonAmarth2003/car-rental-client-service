namespace Client.API.DTO
{
    public class CreateClientDto
    {
        public string Name { get; set; }
        public string CpfNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
