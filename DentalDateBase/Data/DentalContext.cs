using DentalDateBase.Models;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalDateBase.Data
{
    public class DentalContext : DbContext
    {
        public DentalContext(DbContextOptions<DentalContext> option)
            : base(option)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
