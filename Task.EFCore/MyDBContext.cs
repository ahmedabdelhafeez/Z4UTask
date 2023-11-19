
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Task.EFCore.Models;

namespace Task.EFCore
{
    public class MyDBContext:IdentityDbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        { 
        }
        public DbSet<Product> Products { set; get; }

    }
}

