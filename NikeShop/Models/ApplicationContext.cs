using Microsoft.EntityFrameworkCore;
using NikeShop.Models.DB.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NikeShop.Models
{
    public class ApplicationContext: DbContext
    {
        public static ApplicationContext db = new ApplicationContext();

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Nike> Nikes { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<NewNike> NewNike { get; set; }
        public DbSet<OrdersList> OrdersLists { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
             
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;" +
                "Database=SneakerShop;Username=postgres;Password=1234");
        }
    }
}
