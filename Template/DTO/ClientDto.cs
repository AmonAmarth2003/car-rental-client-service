using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Net.NetworkInformation;
using Template.Enums;

namespace Template.DTO
{
    public class ClientDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string CpfNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public ClientStatus Status{ get; set; }
    }
}