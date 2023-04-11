using Microsoft.EntityFrameworkCore;
using StockAPI.DataAccess.Entities;

namespace StockAPI.DataAccess.CQRS.Querries.ProducersQuerry
{
    public class GetProducersQuerry : QuerryBase<List<Producer>>
    {
        public override Task<List<Producer>> Execute(StockApiStorageContext context)
        {
            return context.Producers
                .Include(x => x.Items)
                .ToListAsync();

        }
    }
}
