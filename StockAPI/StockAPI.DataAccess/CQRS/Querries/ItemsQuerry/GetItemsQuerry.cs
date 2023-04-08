using Microsoft.EntityFrameworkCore;
using StockAPI.DataAccess.Entities;

namespace StockAPI.DataAccess.CQRS.Querries.ItemsQuerry
{
    public class GetItemsQuerry : QuerryBase<List<Item>>
    {
        public async override Task<List<Item>> Execute(StockApiStorageContext context)
        {
            return await context.Items
                .Include(x => x.Producers)
                .Include(x => x.Supplier)
                .ToListAsync();
          
        }
    }
}
