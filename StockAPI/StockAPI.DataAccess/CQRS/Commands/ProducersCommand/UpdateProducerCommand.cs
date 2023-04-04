using StockAPI.DataAccess.Entities;
using System.Reflection.Metadata;

namespace StockAPI.DataAccess.CQRS.Commands.ProducersCommand
{
    public class UpdateProducerCommand : CommandBase<Producer,Producer>
    {
        public override async Task<Producer> Execute(StockApiStorageContext context)
        {
            context.ChangeTracker.Clear();
            context.Producers.Update(Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
