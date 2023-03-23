using StockAPI.DataAccess.Entities;

namespace StockAPI.DataAccess.CQRS.Commands.ItemsCommand
{
    public class AddItemCommand : CommandBase<Item, Item>
    {
        public override async Task<Item> Execute(StockApiStorageContext context)
        {
            await context.Items.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
