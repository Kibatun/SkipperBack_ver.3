using SkipperBack3.EfCore;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SkipperBack3.EFCore;

namespace SkipperBack3.EFCore
{
    public class EF_DataContext : DbContext
    {
        public EF_DataContext(DbContextOptions<EF_DataContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        //public DbSet<Token> Tokens { get; set; }
    }
}