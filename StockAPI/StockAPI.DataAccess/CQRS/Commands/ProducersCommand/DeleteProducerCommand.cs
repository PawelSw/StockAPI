using StockAPI.DataAccess.Entities;

namespace StockAPI.DataAccess.CQRS.Commands.ProducersCommand
{
    public class DeleteProducerCommand : CommandBase<Producer, Producer>
    {
        public override async Task<Producer> Execute(StockApiStorageContext context)
        {
            context.ChangeTracker.Clear();
            context.Producers.Remove(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
