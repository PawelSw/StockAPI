using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace StockAPI.DataAccess
{
    public class StockApiStorageContextFactory : IDesignTimeDbContextFactory<StockApiStorageContext>
    {
        public StockApiStorageContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<StockApiStorageContext>();
            optionsBuilder.UseSqlServer("Data Source = .\\SQLEXPRESS; Initial Catalog = StockApiStorage; Integrated Security = True;Encrypt=False;" +
                "TrustServerCertificate=True;MultipleActiveResultSets=True");
            return new StockApiStorageContext(optionsBuilder.Options);
        }
    }
}
