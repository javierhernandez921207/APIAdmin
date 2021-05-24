using APIAdmin.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIAdmin
{
    public class AplicationDBContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public AplicationDBContext(DbContextOptions<AplicationDBContext> options) : base(options)
        {
        }
    }
}