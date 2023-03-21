

using Microsoft.EntityFrameworkCore;
using StockAPI.DataAccess.Entities;

namespace StockAPI.DataAccess.CQRS.Querries.ItemsQuerry
{
    public class GetItemByIdQuerry : QuerryBase<Item>
    {
        public int Id { get; set; }

        public async override Task<Item> Execute(StockApiStorageContext context)
        {
            var item = await context.Items.FirstOrDefaultAsync(x => x.Id == this.Id);
            return item;
        }
    }
}
