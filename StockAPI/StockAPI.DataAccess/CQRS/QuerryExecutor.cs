using StockAPI.DataAccess.CQRS.Querries;

namespace StockAPI.DataAccess.CQRS
{
    public class QuerryExecutor : IQuerryExecutor
    {
        private readonly StockApiStorageContext context;

        public QuerryExecutor(StockApiStorageContext context)
        {
            this.context = context;
        }

        public Task<TResult> Execute<TResult>(QuerryBase<TResult> query)
        {
            return query.Execute(this.context);
        }
    }
}
