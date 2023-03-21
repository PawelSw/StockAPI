using StockAPI.DataAccess.CQRS.Querries;

namespace StockAPI.DataAccess.CQRS
{
    public interface IQuerryExecutor
    {
        Task<TResult> Execute<TResult>(QuerryBase<TResult> query);
    }
}
