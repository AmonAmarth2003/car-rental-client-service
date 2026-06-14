using Template.Enums;

namespace Template.Entities
{
    public class Client
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CpfNumber { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public ClientStatus Status { get; set; }
    }
}
