using StockAPI.DataAccess.Entities;

namespace StockAPI.DataAccess.CQRS.Commands.SuppliersCommand
{
    public class AddSupplierCommand : CommandBase<Supplier,Supplier>
    {
        public override async Task<Supplier> Execute(StockApiStorageContext context)
        {
            await context.Suppliers.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
