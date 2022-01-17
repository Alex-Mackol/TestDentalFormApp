using DentalDateBase.Data;
using DentalDateBase.Interfaces;
using DentalDateBase.Models;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalDateBase.Repository
{
    public class DentalBase : IDataBase
    {
        private DentalContext _context;
        private readonly string _connectionString;
        public DentalBase(IConfiguration config)
        {
            _connectionString = config["Default:ConnectionString"];
        }
        public async Task<bool> AddAsync(IUser item)
        {
            bool isAdd = false;
            DbContextOptions<DentalContext> option = GetOption();

            using(_context = new DentalContext(option))
            {
                if(item == null)
                {
                    return isAdd;
                }

                Role userRole = await _context.Roles.FirstOrDefaultAsync(role => role.RoleName == "client");
                if (userRole != null)
                {
                    ((User)item).Role = userRole;
                }

                _context.Users.Add((User)item);
                isAdd = true;
                await _context.SaveChangesAsync();

                return isAdd;
            }
        }

        public async Task<IUser> IsUserlExist(string email, string password)
        {
            bool isExist = false;
            DbContextOptions<DentalContext> option = GetOption();

            using (_context = new DentalContext(option))
            {
                User user = await _context.Users
                    .Include(u => u.Role)
                    .FirstOrDefaultAsync(u => u.Email == email && u.Password == password);

                    return user;
            }
        }

        public async Task<IEnumerable<IUser>> GetAllAsync()
        {
            DbContextOptions<DentalContext> option = GetOption();

            using (_context = new DentalContext(option))
            {
                return await _context.Users.ToListAsync();
            }
        }

        public async Task<IUser> GetUserById(long id)
        {
            DbContextOptions<DentalContext> option = GetOption();

            using (_context = new DentalContext(option))
            {
                return await _context.FindAsync<IUser>(id);
            }
        }

        public async Task<bool> IsIdExist(long id)
        {
            bool isExist = false;

            DbContextOptions<DentalContext> option = GetOption();

            using (_context = new DentalContext(option))
            {
                var item = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
                if(item == null)
                {
                    return isExist;
                }
                isExist = true;
                return isExist;
            }

        }

        public async Task<bool> Remove(long id)
        {
            bool isRemoved = false;
            DbContextOptions<DentalContext> option = GetOption();

            using (_context = new DentalContext(option))
            {
                var item = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
                if(item == null)
                {
                    return isRemoved;
                }
                _context.Users.Remove(item);
                isRemoved = true;
                return isRemoved;
            }
        }

        public async Task<bool> UpdateAsync(IUser item)
        {
            DbContextOptions<DentalContext> option = GetOption();

            using (_context = new DentalContext(option))
            {
                var userToUpdate = await _context.Users.FirstOrDefaultAsync(x => x.Id == item.Id);
                if(userToUpdate == null)
                {
                    return false;
                }

                userToUpdate.Name = item.Name;
                userToUpdate.Surname = item.Surname;
                userToUpdate.Email = item.Email;   
                userToUpdate.PhoneNumber = item.PhoneNumber;
                userToUpdate.Password = item.Password;
                _context.Users.Update(userToUpdate);
                await _context.SaveChangesAsync();

                return true;
            }
        }

        private DbContextOptions<DentalContext> GetOption()
        {
            DbContextOptionsBuilder<DentalContext> optionBuilder = new DbContextOptionsBuilder<DentalContext>();
            DbContextOptions<DentalContext> option = optionBuilder.UseSqlServer(_connectionString).Options;

            return option;
        }

    }
}
