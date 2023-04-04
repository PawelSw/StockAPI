using Microsoft.EntityFrameworkCore;
using StockAPI.DataAccess.Entities;

namespace StockAPI.DataAccess.CQRS.Querries.SuppliersQuerry
{
    public class GetSupplierByIdQuerry : QuerryBase<Supplier>
    {
        public int Id { get; set; }

        public async override Task<Supplier> Execute(StockApiStorageContext context)
        {
            var supplier = await context.Suppliers.FirstOrDefaultAsync(x => x.Id == this.Id);
            return supplier;
        }
    }
}
