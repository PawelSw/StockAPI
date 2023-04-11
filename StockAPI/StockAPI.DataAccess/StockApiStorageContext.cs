using Microsoft.EntityFrameworkCore;
using StockAPI.DataAccess.Entities;

namespace StockAPI.DataAccess
{
    public class StockApiStorageContext : DbContext
    {
        public StockApiStorageContext(DbContextOptions<StockApiStorageContext> options) : base(options)
        {

        }
        public DbSet<Item> Items { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
