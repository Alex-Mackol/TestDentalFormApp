using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentalDateBase.Models;
using Domain.Interfaces;

namespace DentalDateBase.Factory
{
    public class UserFactory : IUserFactory
    {
        public IUser CreateUser(params string[] userData)
        {
            return new User
            {
                Name = userData[0],
                Surname = userData[1],
                PhoneNumber = userData[2],
                Email = userData[3],
                Password = userData[4]
            };
        }
    }
}
