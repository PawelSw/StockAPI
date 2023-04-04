using StockAPI.DataAccess.Entities;

namespace StockAPI.DataAccess.CQRS.Commands.SuppliersCommand
{
    public class DeleteSupplierCommand : CommandBase<Supplier, Supplier>
    {
        public override async Task<Supplier> Execute(StockApiStorageContext context)
        {
            context.ChangeTracker.Clear();
            context.Suppliers.Remove(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }

    }
}
