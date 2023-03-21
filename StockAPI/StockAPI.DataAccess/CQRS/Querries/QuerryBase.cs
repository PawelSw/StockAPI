namespace StockAPI.DataAccess.CQRS.Querries
{
    public abstract class QuerryBase<TResult>
    {
        public abstract Task<TResult> Execute(StockApiStorageContext context);
    }
}
