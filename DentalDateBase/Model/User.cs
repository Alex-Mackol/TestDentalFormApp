using Domain.Interfaces;

namespace DentalDateBase.Models
{
    public class User : IUser
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Role Role { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
