using StockAPI.DataAccess.CQRS.Commands;

namespace StockAPI.DataAccess.CQRS
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly StockApiStorageContext context;

        public CommandExecutor(StockApiStorageContext context)
        {
            this.context = context;
        }
        public Task<TResult> Execute<TParameters, TResult>(CommandBase<TParameters, TResult> command)
        {
            return command.Execute(this.context);
        }
    }
}
