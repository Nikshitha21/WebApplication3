using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class UserDetailDbContext: DbContext
    {
        public UserDetailDbContext(DbContextOptions<UserDetailDbContext> options):base(options)
        {

        }
        public DbSet<UserDetails> UserDetailss { get; set; }

    }
}
