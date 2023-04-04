using Microsoft.EntityFrameworkCore;
using StockAPI.DataAccess.Entities;

namespace StockAPI.DataAccess.CQRS.Querries.ProducersQuerry
{
    public class GetProducerByIdQuerry : QuerryBase<Producer>
    {
        public int Id { get; set; }

        public async override Task<Producer> Execute(StockApiStorageContext context)
        {
            var producer = await context.Producers.FirstOrDefaultAsync(x => x.Id == this.Id);
            return producer;
        }
    }
}
