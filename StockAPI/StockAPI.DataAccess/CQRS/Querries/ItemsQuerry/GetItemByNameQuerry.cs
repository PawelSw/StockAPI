using Microsoft.EntityFrameworkCore;
using StockAPI.DataAccess.Entities;

namespace StockAPI.DataAccess.CQRS.Querries.ItemsQuerry
{
    public class GetItemByNameQuerry : QuerryBase<List<Item>>
    {
        public string ItemName { get; set; }
        public async override Task<List<Item>> Execute(StockApiStorageContext context)
        {
            return await context.Items.Where(x => x.ItemName.Contains(this.ItemName)).ToListAsync();
        }
    }
}
