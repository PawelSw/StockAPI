using Microsoft.EntityFrameworkCore;
using StockAPI.DataAccess.Entities;

namespace StockAPI.DataAccess.CQRS.Querries.ProducersQuerry
{
    public class GetProducerByNameQuerry : QuerryBase<List<Producer>>
    {
        public string Name { get; set; }
        public async override Task<List<Producer>> Execute(StockApiStorageContext context)
        {
            return await context.Producers.Where(x => x.Name.Contains(this.Name)).ToListAsync();
        }
    }
}
