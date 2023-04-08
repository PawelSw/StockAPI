using Microsoft.EntityFrameworkCore;
using StockAPI.DataAccess.Entities;

namespace StockAPI.DataAccess.CQRS.Querries.SuppliersQuerry
{
    public class GetSuppliersQuerry : QuerryBase<List<Supplier>>
    {
        public override Task<List<Supplier>> Execute(StockApiStorageContext context)
        {
            return context.Suppliers
                .Include(x => x.Items)
                .ToListAsync();
        }
    }
}
