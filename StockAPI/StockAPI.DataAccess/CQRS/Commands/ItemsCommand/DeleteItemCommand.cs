using StockAPI.DataAccess.Entities;

namespace StockAPI.DataAccess.CQRS.Commands.ItemsCommand
{
    public class DeleteItemCommand : CommandBase<Item, Item>
    {
        public override async Task<Item> Execute(StockApiStorageContext context)
        {
            context.ChangeTracker.Clear();
            context.Items.Remove(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
