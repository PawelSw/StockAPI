using Microsoft.EntityFrameworkCore;
using StockAPI.DataAccess.Entities;

namespace StockAPI.DataAccess.CQRS.Querries.ItemsQuerry
{
    public class GetItemsQuerry : QuerryBase<List<Item>>
    {
        public override Task<List<Item>> Execute(StockApiStorageContext context)
        {
            return context.Items.ToListAsync();
          
        }
    }
}
