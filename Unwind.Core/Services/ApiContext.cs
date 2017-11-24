using System;
using Microsoft.EntityFrameworkCore;
using Unwind.Core.DbModels;

namespace Unwind.Core.Services
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
