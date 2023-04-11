using Microsoft.EntityFrameworkCore;
using StockAPI.DataAccess.Entities;

namespace StockAPI.DataAccess.CQRS.Querries.UsersQuerry
{
    public class GetUsersQuerry : QuerryBase<List<User>>
    {
        public override Task<List<User>> Execute(StockApiStorageContext context)
        {
            return context.Users
                .ToListAsync();
        }
    }
}
