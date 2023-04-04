using Microsoft.EntityFrameworkCore;
using StockAPI.DataAccess.Entities;

namespace StockAPI.DataAccess.CQRS.Querries.SuppliersQuerry
{
    public class GetSupplierByNameQuerry : QuerryBase<List<Supplier>>
    {
        public string Name { get; set; }
        public async override Task<List<Supplier>> Execute(StockApiStorageContext context)
        {
            return await context.Suppliers.Where(x => x.Name.Contains(this.Name)).ToListAsync();
        }
    }
}
