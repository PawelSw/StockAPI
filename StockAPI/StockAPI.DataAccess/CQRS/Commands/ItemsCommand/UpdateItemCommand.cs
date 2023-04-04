using StockAPI.DataAccess.Entities;

namespace StockAPI.DataAccess.CQRS.Commands.ItemsCommand
{
    public class UpdateItemCommand : CommandBase<Item, Item>
    {
        public override async Task<Item> Execute(StockApiStorageContext context)
        {
            context.ChangeTracker.Clear();
            context.Items.Update(Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
