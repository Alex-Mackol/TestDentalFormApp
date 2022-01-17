using Domain.Interfaces;
using System.Collections.Generic;

namespace DentalDateBase.Models
{
    public class Role: IRole
    {
        public long Id { get; set; }
        public string RoleName { get; set; }
        public List<User> Users { get; set; } = new List<User>();

    }
}
