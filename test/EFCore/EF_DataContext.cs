using ShoppingWebApi.EfCore;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SkipperBack2.EFCore;

namespace test.EFCore
{
    public class EF_DataContext : DbContext
    {
        public EF_DataContext(DbContextOptions<EF_DataContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; } 
    }
}