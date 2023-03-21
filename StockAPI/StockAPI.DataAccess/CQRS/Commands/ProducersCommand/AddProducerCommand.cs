using StockAPI.DataAccess.Entities;

namespace StockAPI.DataAccess.CQRS.Commands.ProducersCommand
{
    public class AddProducerCommand : CommandBase<Producer, Producer>
    {
        public override async Task<Producer> Execute(StockApiStorageContext context)
        {
            await context.Producers.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
