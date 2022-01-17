using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalDateBase.Interfaces
{
    public interface IDataBase
    {
        Task<bool> AddAsync(IUser item);
        Task<IUser> IsUserlExist(string email, string password);

        Task<IEnumerable<IUser>> GetAllAsync();

        Task<IUser> GetUserById(long id);

        Task<bool> Remove(long id);

        Task<bool> UpdateAsync(IUser item);

        Task<bool> IsIdExist(long id);
    }
}
